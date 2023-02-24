using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Web.Script.Serialization;
using Microsoft.Office.Interop.Word;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using System.Configuration;
using System.Globalization;
using RestSharp;
using MimeTypes;

namespace PLM
{
    public partial class FormMain : Form
    {

        Microsoft.Office.Interop.Word.Application WordApp;
        object missing = System.Reflection.Missing.Value;
        object fileName = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"/" + ConfigurationSettings.AppSettings["Appname"] + @"/" + ConfigurationSettings.AppSettings["Appname"] + "Template.docx"; // template file name
        object newTemplate = false;
        object docType = 0;
        object isVisible = true;

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        [DllImport("user32.dll")]
        static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);

        // Structure contain information about low-level keyboard input event

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);


        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool SetForegroundWindow(IntPtr hWnd);


        [DllImportAttribute("User32.DLL")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int SW_SHOW = 5;
        private const int SW_MINIMIZE = 6;
        private const int SW_RESTORE = 9;

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        //force foreground
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32")]
        static extern int BringWindowToTop(IntPtr hwnd);

        [DllImport("kernel32.dll")]
        static extern int GetCurrentThreadId();
        [DllImport("user32.dll")]
        static extern int GetWindowThreadProcessId(IntPtr hWnd, IntPtr ProcessId);
        [DllImport("User32.DLL")]
        private static extern int AttachThreadInput(int CurrentForegroundThread, int MakeThisThreadForegrouond, bool boolAttach);
        //end force foreground


        bool WordEditMode;
        bool WordDirty = false;
        bool WordActive = true;
        string v_bookmark;

        string WordFileName;
        //string WordPath;
        string WordFileNameNew;
        string WordFileNameNewNoExt;
        string WordFileNoExt;
        //string WordPathNew;
        int LastUtt = 1;
        //string LastUtt = "";
        int FinalUtt;
        double LastUttStart;
        double LastUttStop;
        //string URL = "http://XXXX203.185.132.221/parliament/";

        string URL = ConfigurationSettings.AppSettings["url"];
        int LastVersion;
        TimeSpan P_TimePlay;
        bool WordChang;
        int proc_cnt = 0;
        int proc_cnt_word = 0;
        string WorkPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"/" + ConfigurationSettings.AppSettings["Appname"] + @"/";
        int Kh_KeyUp_Mode = 0;//1=KeyUp , 2 = KeyUpNew
        int KeyUpCnt = 0;
        int KeyUpNewCnt = 0;
        bool WordAllowEdit = true;
        int WMPMinWidth = 400;
        int WMPMinHeight = 300;
        int WMPMaxWidth = 800;
        int WMPMaxHeight = 600;
        string Appname = ConfigurationSettings.AppSettings["Appname"];
        string Apptitle = ConfigurationSettings.AppSettings["Apptitle"];

        int v_current_bookmark_id = 0;

        public string v_result_search = "";

        //Mode Parameter
        bool P_NonEditMode = false;
        string P_ShortCutMode = ConfigurationSettings.AppSettings["ShortCutMode"];

        CONFIG conf = new CONFIG();
        APPINFO appinfo = new APPINFO();
        ////VIDEO video = new VIDEO();
        ////VIDEO videopart = new VIDEO();
        ROOM room = new ROOM();
        ROOMALL roomall = new ROOMALL();
        FILE_CONTENT fileinfo = new FILE_CONTENT();
        CONTENTINFO contentInfo = new CONTENTINFO();
        CONTENTINFO contentInfoAll = new CONTENTINFO();
        VERSIONINFO versioninfo = new VERSIONINFO();
        SUGGEST suggestinfo = new SUGGEST();

        IntPtr WordWND;
        //IntPtr PartiiWND;
        //const string STATUS00 = "ไม่ใช้งาน";
        const string STATUS01 = "ปกติ";
        const string STATUS02 = "รอดำเนินการ";
        const string STATUS03 = "อยู่ระหว่างดำเนินการ";
        const string STATUS04 = "จดรายงานเสร็จสิ้น / รอการตรวจทาน";
        const string STATUS05 = "อยู่ระหว่างการตรวจทาน";
        const string STATUS06 = "การตรวจทานเสร็จสิ้น / รอการรวมข้อมูล";
        const string STATUS07 = "อยู่ระหว่างการรวมข้อมูล";
        const string STATUS08 = "การรวมข้อมูลเสร็จสิน / รอการตรวจสอบภาพรวม";
        const string STATUS09 = "อยู่ระหว่างการตรวจสอบภาพรวม";
        const string STATUS10 = "ตรวจสอบภาพรวมเสร็จสิ้น";
        const string STATUS11 = "สภายังไม่รับรอง";
        const string STATUS12 = "สภารับรองแล้ว";
        const string STATUS13 = "สามารถเผยแพร่ได้";

        KeyboardHook kh = new KeyboardHook(true);
        //Thread tSplashScreen;
        SplashScreen startForm;

        public FormMain(SplashScreen startForm)
        {
            this.startForm = startForm;

            ////start key

            //TopMost = true;
            //kh.KeyDown += Kh_KeyDown;
            kh.KeyUp += Kh_KeyUp;

            this.KeyPreview = true;
            this.KeyUp += new KeyEventHandler(Kh_KeyUpNew);
            //this.KeyDown += new KeyEventHandler(Kh_KeyDownNew);
            this.Activate();
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        //start  key  
        public void Kh_KeyDownNew(Object sender, KeyEventArgs e)
        {
            //try
            //{

            //    if (Kh_KeyUp_Mode == 2)
            //    {
            //        STBar.Panels[3].Text = GetActiveWindowsTitle(); //check windows activate
            //        if (GetActiveWindowsTitle().Contains("Partii") == true)
            //        {
            //            KeyUpNewCnt = Int32.Parse(STBar.Panels[2].Text);
            //            KeyUpNewCnt++;
            //            STBar.Panels[2].Text = KeyUpNewCnt.ToString();

            //            //Thread thread = new Thread(() =>
            //            //{
            //                Keyboard_Process(e.KeyCode);
            //            //});
            //            //thread.Start();
            //            //thread.Join();

            //        }
            //    }
            //    else
            //    {
            //        Kh_KeyUp_Mode = 2;
            //    }
            //}
            //catch (Exception e2)
            //{
            //    STBar.Panels[3].Text = System.Reflection.MethodBase.GetCurrentMethod().Name + ":" + e2.Message;
            //}
        }
        private void Kh_KeyDown(Keys key, bool Shift, bool Ctrl, bool Alt)
        {

            try
            {
                //if (key != Keys.LControlKey)
                //{
                //    //if (GetActiveWindowsTitle().Contains("Partii") == false)
                //    //{
                //    Kh_KeyUp_Mode = 1;

                //    KeyUpCnt = Int32.Parse(STBar.Panels[1].Text);
                //    KeyUpCnt++;
                //    STBar.Panels[1].Text = KeyUpCnt.ToString();

                //    //Thread thread = new Thread(() =>
                //    //{
                //Keyboard_Process_down(key);
                //    //});
                //    //thread.Start();
                //    //thread.Join();

                //    //}

                //}
            }
            catch (Exception e2)
            {
                //    STBar.Panels[3].Text = System.Reflection.MethodBase.GetCurrentMethod().Name + ":" + e2.Message;
            }

        }

        private void Kh_KeyUp(Keys key, bool Shift, bool Ctrl, bool Alt)
        {
            try
            {
                if (key != Keys.LControlKey)
                //if ((key != Keys.LControlKey) &&
                //(key != Keys.Left) &&
                //(key != Keys.Right) &&
                //(key != Keys.Up) &&
                //(key != Keys.Down))  
                {
                    //if (GetActiveWindowsTitle().Contains("Partii") == false)
                    //{
                    Kh_KeyUp_Mode = 1;

                    //KeyUpCnt = Int32.Parse(STBar.Panels[1].Text);
                    //KeyUpCnt++;

                    Keyboard_Process(key);

                    //}

                }
            }
            catch (Exception e2)
            {

            }
        }
        private void Kh_KeyUpNew(Object sender, KeyEventArgs e)
        {
            try
            {

                if (Kh_KeyUp_Mode == 2)
                {

                    //KeyUpNewCnt = Int32.Parse(STBar.Panels[2].Text);
                    //KeyUpNewCnt++;
                    //STBar.Panels[2].Text = KeyUpNewCnt.ToString();


                    Keyboard_Process(e.KeyCode);

                }
                else
                {
                    Kh_KeyUp_Mode = 2;
                }
            }
            catch (Exception e2)
            {

            }
        }


        private void Keyboard_Process(Keys Key)
        {
            try
            {
                List<Keys> AllowEditKey = new List<Keys>();
                AllowEditKey.AddRange(new Keys[]
                    { // Alphanumeric keys.
                              Keys.Space
                        //Keys.A, Keys.B, Keys.C, Keys.D, Keys.E, Keys.F, Keys.G, Keys.H,
                        //Keys.I, Keys.J, Keys.K, Keys.L, Keys.M, Keys.N, Keys.O, Keys.P,
                        //Keys.Q, Keys.R, Keys.S, Keys.T, Keys.U, Keys.V, Keys.W, Keys.X,
                        //Keys.Y, Keys.Z,
                        //Keys.D0, Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5, Keys.D6,
                        //Keys.D7, Keys.D8, Keys.D9,
                    });
                if (P_ShortCutMode.ToString() == "X")
                {
                    switch (Key)
                    {

                        case Keys.F1:  // Play 0.5
                            WmplayerPlay05();
                            break;
                        case Keys.F2: // Play 1
                            WmplayerPlay10();
                            break;
                        case Keys.F3:  // Play 2
                            WmplayerPlay20();
                            break;
                        case Keys.F4: //play 4
                            WmplayerPlay40();
                            break;
                        case Keys.F5:  // inc volume

                            SearchText();
                            //WmPlayer.settings.volume = WmPlayer.settings.volume + 10;
                            break;
                        case Keys.F6: // dec volume

                            SearchText();
                            //WmPlayer.settings.volume = WmPlayer.settings.volume - 10;
                            break;
                        //case Keys.Space: //for edit
                        //    WmplayerEdit(); break;
                        case Keys.F7:
                            WmplayerRePlay(appinfo, fileinfo);
                            break;
                        case Keys.F8:
                            WmPlayerMovetoCurr(appinfo, fileinfo);
                            break;
                        case Keys.F9: //play puase
                                      //if (loadingPlayer)
                            if (WmPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
                            {
                                WmplayerPause();
                                break;
                            }
                            else
                            {

                                WmplayerPlay10();
                                break;
                            }
                        case Keys.F10: // play back
                            if (WordEditMode == false)
                            {
                                WmplayerBack(appinfo, fileinfo);
                            }
                            break;
                        case Keys.F11: // stop
                            WmplayerStop(); ; break;

                        case Keys.F12: // play forward
                            if (WordEditMode == false)
                            {
                                WmplayerFW(appinfo, fileinfo);
                            }

                            break;
                        default:

                            if (AllowEditKey.Contains(Key))
                            {
                                if (WordEditMode == false)
                                {
                                    WmPlayer.Ctlcontrols.pause();
                                    WordEdit();
                                }
                                break;
                            }
                            else
                            {
                                WordDirty = true;
                                break;

                            }
                    }
                }
                else
                {
                    switch (Key)
                    {
                        case Keys.F9: //play puase
                                      //if (loadingPlayer)
                            if (WmPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
                            {
                                WmplayerPause();
                                break;
                            }
                            else
                            {

                                WmplayerPlay10();
                                break;
                            }
                        default:
                            break;
                    }
                }

            }

            catch (Exception e)
            {

                //MessageBox.Show(System.Reflection.MethodBase.GetCurrentMethod().Name + ":" + e.Message);

            }
        }
        private void Keyboard_Process_down(Keys Key)
        {
            try
            {
                List<Keys> AllowEditKey = new List<Keys>();
                AllowEditKey.AddRange(new Keys[]
                    { // Alphanumeric keys.
                              Keys.F1,Keys.F2,Keys.F3,Keys.F4,Keys.F5,Keys.F6
                              ,Keys.F7,Keys.F8,Keys.F9,Keys.F10,Keys.F11,Keys.F12
                        //Keys.A, Keys.B, Keys.C, Keys.D, Keys.E, Keys.F, Keys.G, Keys.H,
                        //Keys.I, Keys.J, Keys.K, Keys.L, Keys.M, Keys.N, Keys.O, Keys.P,
                        //Keys.Q, Keys.R, Keys.S, Keys.T, Keys.U, Keys.V, Keys.W, Keys.X,
                        //Keys.Y, Keys.Z,
                        //Keys.D0, Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5, Keys.D6,
                        //Keys.D7, Keys.D8, Keys.D9,
                    });

                if (AllowEditKey.Contains(Key))
                {

                    //Thread thread4 = new Thread(() =>
                    //{

                    //Thread.Sleep(500); // Allow the process to open it's window
                    //Thread thread5 = new Thread(() =>
                    //{


                    //ShowWindow(this.Handle, SW_SHOW);
                    //this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

                    //SetForegroundWindow(PartiiWND);


                    //WdWindowState.wdWindowStateMaximize;

                    //});
                    //thread5.Start();
                    //thread5.Join();
                    //Thread thread = new Thread(() =>
                    //{
                    //this.Activate();
                    //    CTN.Panel1.Focus();

                    //});
                    //thread.Start();
                    //thread.Join();
                }


            }

            catch (Exception e)
            {

                //MessageBox.Show(System.Reflection.MethodBase.GetCurrentMethod().Name + ":" + e.Message);

            }
        }


        private void WmplayerPlay05()
        {
            WmPlayer.settings.rate = 0.5;
            if ((WmPlayer.playState != WMPLib.WMPPlayState.wmppsPlaying) && (WmPlayer.playState != WMPLib.WMPPlayState.wmppsScanForward))
            {
                WmPlayer.Ctlcontrols.play();
            }
            BT05X.Focus();

            WordNonEdit();
        }
        private void WmplayerPlay10()
        {
            WmPlayer.settings.rate = 1;
            if ((WmPlayer.playState != WMPLib.WMPPlayState.wmppsPlaying) && (WmPlayer.playState != WMPLib.WMPPlayState.wmppsScanForward))
            {
                //if (TxtRewTime.Text != "")
                //{
                //    if (int.Parse(TxtRewTime.Text) is int)
                //    {
                //        WmPlayer.Ctlcontrols.currentPosition = WmPlayer.Ctlcontrols.currentPosition - int.Parse(TxtRewTime.Text);
                //    }
                //}

                WmPlayer.Ctlcontrols.play();
            }
            else
            {
                if (TxtRewTime.Text != "")
                {
                    if (int.Parse(TxtRewTime.Text) is int)
                    {
                        WmPlayer.Ctlcontrols.currentPosition = WmPlayer.Ctlcontrols.currentPosition - int.Parse(TxtRewTime.Text);
                    }
                }

                WmPlayer.Ctlcontrols.play();
            }
            BT10X.Focus();
            WordNonEdit();

        }
        private void WmplayerPlay20()
        {
            WmPlayer.settings.rate = 2;
            if ((WmPlayer.playState != WMPLib.WMPPlayState.wmppsPlaying) && (WmPlayer.playState != WMPLib.WMPPlayState.wmppsScanForward))
            {
                WmPlayer.Ctlcontrols.play();
            }
            BT20X.Focus();
            WordNonEdit();
        }
        private void WmplayerPlay40()
        {
            WmPlayer.settings.rate = 4;

            if ((WmPlayer.playState != WMPLib.WMPPlayState.wmppsPlaying) && (WmPlayer.playState != WMPLib.WMPPlayState.wmppsScanForward))
            {
                WmPlayer.Ctlcontrols.play();
            }
            BT40X.Focus();
            WordNonEdit();
        }
        private void WmplayerRePlay(APPINFO appinfo, FILE_CONTENT files)
        {

            if (LastUtt > 0)
            //if (LastUtt != "")
            {
                //var content = files.transcription.Where(w => w.utt == LastUtt);
                var content = files.transcription.Where(w => int.Parse(w.utt) == LastUtt);
                WmPlayer.Ctlcontrols.currentPosition = content.First().start;
                v_bookmark = "P" + content.First().utt;
                //LastUtt = content.First().utt;
                LastUtt = int.Parse(content.First().utt);
                //LastUttStart = content.First().start_DB;
                //LastUttStop = content.First().stop_DB;
                if ((ChkHighlight.Checked == true) && ((WmPlayer.playState != WMPLib.WMPPlayState.wmppsPlaying) && (WmPlayer.playState != WMPLib.WMPPlayState.wmppsScanForward)))
                {
                    Thread thread = new Thread(() =>
                    {
                        WordApp.Selection.GoTo(WdGoToItem.wdGoToBookmark, Name: v_bookmark);

                    });
                    thread.Start();
                    thread.Join();
                }
                WmPlayer.Ctlcontrols.play();
            }
        }
        private void WmplayerPause()
        {
            WmPlayer.Ctlcontrols.pause();
            WordNonEdit();
        }
        private void WmplayerStop()
        {
            WmPlayer.Ctlcontrols.stop();
            WordNonEdit();
        }
        private void WordEdit()
        {
            try
            {
                WdProtectionType V_ProtectionType;
                //kh.KeyDown -= Kh_KeyDown;
                //kh.KeyDown += Kh_KeyDown;
                kh.KeyUp -= Kh_KeyUp;
                kh.KeyUp += Kh_KeyUp;


                Thread thread2 = new Thread(() =>
                {
                    V_ProtectionType = WordApp.ActiveDocument.ProtectionType;

                    if (V_ProtectionType == WdProtectionType.wdAllowOnlyReading)
                    {
                        //comment for not user requirment
                        //WordApp.ActiveDocument.Unprotect();
                        WordDirty = true;
                    }
                    else
                    {

                    }


                });
                thread2.Start();
                thread2.Join();

                Thread thread3 = new Thread(() =>
                {
                    WordApp.Selection.Move(WdUnits.wdCharacter, 1);
                    WordApp.Selection.Move(WdUnits.wdCharacter, -1);

                });
                thread3.Start();
                thread3.Join();


                Thread thread4 = new Thread(() =>
                {

                    SetForegroundWindow(WordWND);
                });
                thread4.Start();
                thread4.Join();
                LastUttStart = 0;
                LastUttStop = 0;
                WordEditMode = true;
                WmPlayerTimer.Stop();
            }
            catch (Exception e)
            {
                startForm.Hide();
                handleException(System.Reflection.MethodBase.GetCurrentMethod().Name + ":" + e.Message);
            }
        }


        private void WordNonEdit()
        {
            if (P_NonEditMode == true)
            {
                try
                {

                    Thread thread = new Thread(() =>
                    {
                        if (WordApp.ActiveDocument.ProtectionType == WdProtectionType.wdAllowOnlyReading)
                        {
                        }
                        else
                        {
                            WordApp.ActiveDocument.Protect(WdProtectionType.wdAllowOnlyReading);
                            // WordApp.ActiveDocument.Protect(WdProtectionType.wdNoProtection);
                            //WordApp.ActiveDocument.Protect;
                        }
                    });
                    thread.Start();
                    thread.Join();

                    LastUttStart = 0;
                    LastUttStop = 0;
                    WordEditMode = false;
                    WmPlayerTimer.Start();
                }
                catch (Exception e)
                {

                    startForm.Hide();
                    handleException(System.Reflection.MethodBase.GetCurrentMethod().Name + ":" + e.Message);
                }

            }
        }
        private void WmplayerBack(APPINFO appinfo, FILE_CONTENT files)
        {
            LastUtt--;
            if (LastUtt > 0)
            {
                var content = files.transcription.Where(w => int.Parse(w.utt) == LastUtt);
                WmPlayer.Ctlcontrols.currentPosition = content.First().start;
                v_bookmark = "P" + content.First().utt;
                LastUtt = int.Parse(content.First().utt);
                //LastUttStart = content.First().start_DB;
                //LastUttStop = content.First().stop_DB;
                if ((ChkHighlight.Checked == true) && ((WmPlayer.playState != WMPLib.WMPPlayState.wmppsPlaying) && (WmPlayer.playState != WMPLib.WMPPlayState.wmppsScanForward)))
                {
                    Thread thread = new Thread(() =>
                    {
                        WordApp.Selection.GoTo(WdGoToItem.wdGoToBookmark, Name: v_bookmark);

                    });
                    thread.Start();
                    thread.Join();
                }

            }
        }

        private void WmPlayerMovetoCurr(APPINFO appinfo, FILE_CONTENT files)
        {
            Thread thread = new Thread(() =>
            {
                v_current_bookmark_id = WordApp.Selection.BookmarkID;
                foreach (Bookmark SeekBookmark in WordApp.ActiveDocument.Bookmarks)
                {

                    //int CurrBookMark = int.Parse(SeekBookmark.Name.Replace("P", ""));
                    string CurrBookMark = SeekBookmark.Name.Replace("P", "");
                    int CurrBookMarkid = SeekBookmark.Range.BookmarkID;
                    if (CurrBookMarkid == v_current_bookmark_id)
                    {
                        var content = files.transcription.Where(w => w.utt == CurrBookMark);
                        WmPlayer.Ctlcontrols.currentPosition = content.First().start;
                        WmPlayer.Ctlcontrols.play();
                    }
                }
            });
            thread.Start();
            thread.Join();


        }

        private void WmplayerFW(APPINFO appinfo, FILE_CONTENT files)
        {
            LastUtt++;
            if (LastUtt <= FinalUtt)
            {
                var content = files.transcription.Where(w => int.Parse(w.utt) == LastUtt);
                WmPlayer.Ctlcontrols.currentPosition = content.First().start;
                v_bookmark = "P" + content.First().utt;
                LastUtt = int.Parse(content.First().utt);
                //LastUttStart = content.First().start_DB;
                //LastUttStop = content.First().stop_DB;
                if ((ChkHighlight.Checked == true) && ((WmPlayer.playState != WMPLib.WMPPlayState.wmppsPlaying) && (WmPlayer.playState != WMPLib.WMPPlayState.wmppsScanForward)))
                {
                    Thread thread = new Thread(() =>
                    {
                        WordApp.Selection.GoTo(WdGoToItem.wdGoToBookmark, Name: v_bookmark);

                    });
                    thread.Start();
                    thread.Join();
                }
            }

        }

        private void RequestRoomInfo(APPINFO appinfo, ref ROOM obj)

        {
            try
            {
                String UrlPhP;
                //UrlPhP = URL + "api/meeting/getmeetinginfo?Authorization=" + appinfo.accessKey + "&part=" + appinfo.part;
                UrlPhP = URL + "api/meeting/getmeetinginfo";
                //UrlPhP = URL + "api/reportsection/getreportsection";
                WebRequest myRequest = WebRequest.Create(UrlPhP);
                myRequest.ContentType = "application/json";
                myRequest.Method = "POST";
                myRequest.Headers.Add("Authorization", appinfo.accessKey);

                using (var streamWriter = new StreamWriter(myRequest.GetRequestStream()))
                {
                    string json = "{";
                    json += "\"query\":{\"meeting_id\":\"" + appinfo.meeting_id + "\"}";
                    json += "}";
                    streamWriter.Write(json);
                }
                WebResponse myResponse = myRequest.GetResponse();

                StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
                string result = sr.ReadToEnd();

                JavaScriptSerializer jss = new JavaScriptSerializer();
                var room = jss.Deserialize<ROOM>(result);
                //string sysFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                //string sysUIFormat = CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern;
                TxtRoomSection.Text = room.data[0].council_type.ToString();
                if (room.data[0].meeting_group.ToString() == "")
                {

                }
                TxtRoomGroup.Text = (room.data[0].meeting_group.ToString() != "") ? room.data[0].meeting_group.ToString() : "-";
                TxtRoomYear.Text = (room.data[0].meeting_year.ToString() != "") ? room.data[0].meeting_year.ToString() : "-";
                TxtRoomNo.Text = (room.data[0].meeting_number.ToString() != "") ? room.data[0].meeting_number.ToString() : "-";
                TxtRoomType.Text = (room.data[0].episode_name.ToString() != "") ? room.data[0].episode_name.ToString() : "-";
                //CultureInfo provider = CultureInfo.GetCultureInfo("th-TH");
                //DateTime date = DateTime.Parse(room.data[0].start_timestamp.ToString(), provider);
                DateTime meetingDate = Convert.ToDateTime(room.data[0].start_timestamp.ToString(), CultureInfo.CreateSpecificCulture("en-US"));
                TxtRoomTime.Text = meetingDate.ToString("D", CultureInfo.CreateSpecificCulture("th-TH"));
                //TxtRoomTime.Text = meetingDate.ToString("g");
                TxtRoomPart.Text = appinfo.seq.ToString();
                TxtRoomStatus.Text = room.data[0].meeting_status_desc.ToString();
                obj = room;
                sr.Close();
                myResponse.Close();


            }
            catch (Exception e)
            {
                startForm.Hide();
                handleException(System.Reflection.MethodBase.GetCurrentMethod().Name + ":" + e.Message);
            }
        }

        private void RequestFileInfo(APPINFO appinfo, ref FILE_CONTENT obj)
        {
            try
            {
                String UrlPhP;
                //UrlPhP = URL + "api/meeting/getmeetinginfo?Authorization=" + appinfo.accessKey + "&part=" + appinfo.part;
                UrlPhP = URL + "api/reportsection/gettranscription";
                WebRequest myRequest = WebRequest.Create(UrlPhP);
                myRequest.ContentType = "application/json";
                myRequest.Method = "POST";

                myRequest.Headers.Add("Authorization", appinfo.accessKey);
                using (var streamWriter = new StreamWriter(myRequest.GetRequestStream()))
                {


                    string json = "{";
                    json += "\"query\":{\"meeting_id\":\"" + appinfo.meeting_id + "\",";
                    json += "\"version\":\"" + contentInfo.data[0].version + "\",";
                    json += "\"seq\":\"" + appinfo.seq + "\"}";
                    json += "}";
                    streamWriter.Write(json);

                }
                WebResponse myResponse = myRequest.GetResponse();

                StreamReader sr = new StreamReader(myResponse.GetResponseStream(),
    System.Text.Encoding.UTF8);
                string result = sr.ReadToEnd();

                JavaScriptSerializer jss = new JavaScriptSerializer();
                var file = jss.Deserialize<FILE_CONTENT>(result);
                //var room = jss.Deserialize<dynamic>(result);

                obj = file;
                sr.Close();
                myResponse.Close();


            }
            catch (Exception e)
            {
                startForm.Hide();
                handleException(System.Reflection.MethodBase.GetCurrentMethod().Name + ":" + e.Message);
            }
        }

        private void RequestVersionInfo(APPINFO appinfo, ref VERSIONINFO obj)
        {
            try
            {
                String UrlPhP;
                UrlPhP = URL + "api/reportsection/getreportsectioninfo";

                WebRequest myRequest = WebRequest.Create(UrlPhP);
                myRequest.ContentType = "application/json";
                myRequest.Method = "POST";
                myRequest.Headers.Add("Authorization", appinfo.accessKey);
                using (var streamWriter = new StreamWriter(myRequest.GetRequestStream()))
                {


                    string json = "{";
                    json += "\"page\":\"" + 1 + "\",";
                    json += "\"size\":\"" + 100 + "\",";
                    json += "\"query\":{\"meeting_id\":\"" + appinfo.meeting_id + "\",";
                    json += "\"seq\":\"" + appinfo.seq + "\"}";
                    json += "}";

                    streamWriter.Write(json);
                }
                WebResponse myResponse = myRequest.GetResponse();

                StreamReader sr = new StreamReader(myResponse.GetResponseStream(),
    System.Text.Encoding.UTF8);
                string result = sr.ReadToEnd();

                JavaScriptSerializer jss = new JavaScriptSerializer();
                var versionInfo = jss.Deserialize<VERSIONINFO>(result);

                CBVersion.Items.Clear();
                foreach (var versionInfodata in versionInfo.data)
                {
                    if (versionInfodata.version > 0)
                    {
                        CBVersion.Items.Add(versionInfodata.version);
                    }

                }

                obj = versionInfo;
                sr.Close();
                myResponse.Close();
            }
            catch (Exception e)
            {
                startForm.Hide();
                handleException(System.Reflection.MethodBase.GetCurrentMethod().Name + ":" + e.Message);
            }
        }
        private void RequestContentInfo(APPINFO appinfo, ref CONTENTINFO obj)
        {
            try
            {
                String UrlPhP;
                UrlPhP = URL + "api/reportsection/getreportsection";

                WebRequest myRequest = WebRequest.Create(UrlPhP);
                myRequest.ContentType = "application/json";
                myRequest.Method = "POST";
                myRequest.Headers.Add("Authorization", appinfo.accessKey);
                using (var streamWriter = new StreamWriter(myRequest.GetRequestStream()))
                {
                    //string json = new JavaScriptSerializer().Serialize(new
                    //{
                    //    meeting_id = P_Meeting_id
                    //});

                    string json = "{";
                    json += "\"query\":{\"meeting_id\":\"" + appinfo.meeting_id + "\",";
                    json += "\"seq\":\"" + appinfo.seq + "\"}";
                    json += "}";

                    streamWriter.Write(json);
                }
                WebResponse myResponse = myRequest.GetResponse();

                StreamReader sr = new StreamReader(myResponse.GetResponseStream(),
    System.Text.Encoding.UTF8);
                string result = sr.ReadToEnd();

                JavaScriptSerializer jss = new JavaScriptSerializer();
                var contentInfo = jss.Deserialize<CONTENTINFO>(result);



                //TxtRoomVersion.Text = contentInfo.data[0].version.ToString();
                TxtRoomVersion.Text = contentInfo.data[0].version_desc.ToString();
                //TxtRoomPeriod.Text = contentInfo.data[0].start_time + "-" + contentInfo.data[0].end_time;
                TxtRoomPeriod.Text = (contentInfo.data[0].start_time.ToString() != "") ? Convert.ToDateTime(contentInfo.data[0].start_time).ToString("HH:mm") + "-" + Convert.ToDateTime(contentInfo.data[0].end_time).ToString("HH:mm") : "-";
                //obj = contentInfo;
                CBVersion.Text = contentInfo.data[0].version.ToString();
                ///
                obj = contentInfo;
                sr.Close();
                myResponse.Close();
            }
            catch (Exception e)
            {

                startForm.Hide();
                handleException(System.Reflection.MethodBase.GetCurrentMethod().Name + ":" + e.Message);
            }
        }
        private void RequestSeqInfo(APPINFO appinfo, ref CONTENTINFO obj)
        {
            try
            {
                String UrlPhP;
                UrlPhP = URL + "api/reportsection/getreportsection";

                WebRequest myRequest = WebRequest.Create(UrlPhP);
                myRequest.ContentType = "application/json";
                myRequest.Method = "POST";
                myRequest.Headers.Add("Authorization", appinfo.accessKey);
                using (var streamWriter = new StreamWriter(myRequest.GetRequestStream()))
                {


                    string json = "{";
                    json += "\"query\":{\"meeting_id\":\"" + appinfo.meeting_id + "\"}";
                    json += "}";

                    streamWriter.Write(json);
                }
                WebResponse myResponse = myRequest.GetResponse();

                StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
                string result = sr.ReadToEnd();

                JavaScriptSerializer jss = new JavaScriptSerializer();
                var contentInfo = jss.Deserialize<CONTENTINFO>(result);
                /*
                ListViewItem listV = default(ListViewItem);
                foreach (var contentinfodata in contentInfo.data)
                {
                    //if (contentinfodata.version > 0)
                    //{
                    listV = LVPart.Items.Add(contentinfodata.seq.ToString());
                    listV.SubItems.Add(contentinfodata.current_process.ToString() + "-" + contentinfodata.current_process_desc);
                    listV.SubItems.Add(contentinfodata.section_status.ToString() + "-" + contentinfodata.section_status_desc);
                    //}

                }

                TxtRoomVersion.Text = contentInfo.data[0].version.ToString();
                //TxtRoomPeriod.Text = contentInfo.data[0].start_time + "-" + contentInfo.data[0].end_time;
                if (contentInfo.data[0].start_time.ToString() != "")
                {
                    TxtRoomPeriod.Text = Convert.ToDateTime(contentInfo.data[0].start_time).ToString("HH:mm") + "-" + Convert.ToDateTime(contentInfo.data[0].end_time).ToString("HH:mm");

                }
                //obj = contentInfo;
                CBVersion.Text = contentInfo.data[0].version.ToString();
                */
                ///
                obj = contentInfo;
                sr.Close();
                myResponse.Close();
            }
            catch (Exception e)
            {
                startForm.Hide();
                handleException(System.Reflection.MethodBase.GetCurrentMethod().Name + ":" + e.Message);
            }
        }
        public string GetStatusFromID(int StatusID)
        {
            string vResult = "";
            switch (StatusID)
            {
                //case 0: vResult = STATUS00.ToString(); break;
                case 1: vResult = STATUS01.ToString(); break;
                case 2: vResult = STATUS02.ToString(); break;
                case 3: vResult = STATUS03.ToString(); break;
                case 4: vResult = STATUS04.ToString(); break;
                case 5: vResult = STATUS05.ToString(); break;
                case 6: vResult = STATUS06.ToString(); break;
                case 7: vResult = STATUS07.ToString(); break;
                case 8: vResult = STATUS08.ToString(); break;
                case 9: vResult = STATUS09.ToString(); break;
                case 10: vResult = STATUS10.ToString(); break;
                case 11: vResult = STATUS11.ToString(); break;
                case 12: vResult = STATUS12.ToString(); break;
                case 13: vResult = STATUS13.ToString(); break;

            }
            return vResult;
        }
        private void RequestConfig(ref CONFIG obj)
        {
            try
            {
                string json = System.IO.File.ReadAllText(WorkPath + "config.json");
                JavaScriptSerializer jss = new JavaScriptSerializer();
                CONFIG conf = jss.Deserialize<CONFIG>(json);

                obj = conf;
            }
            catch (Exception e)
            {
                startForm.Hide();
                handleException(System.Reflection.MethodBase.GetCurrentMethod().Name + ":" + e.Message);
            }
        }

        private void RequestAllInfo(APPINFO appinfo, ref CONTENTINFO obj)

        {
            try
            {
                String UrlPhP;

                UrlPhP = URL + "api/reportsection/getreportsection";

                WebRequest myRequest = WebRequest.Create(UrlPhP);
                myRequest.ContentType = "application/json";
                myRequest.Method = "POST";
                myRequest.Headers.Add("Authorization", appinfo.accessKey);
                using (var streamWriter = new StreamWriter(myRequest.GetRequestStream()))
                {

                    string json = "{";
                    json += "\"query\":{\"meeting_id\":\"" + appinfo.meeting_id + "\"";
                    json += "}";

                    streamWriter.Write(json);
                }
                WebResponse myResponse = myRequest.GetResponse();

                StreamReader sr = new StreamReader(myResponse.GetResponseStream(),
    System.Text.Encoding.UTF8);
                string result = sr.ReadToEnd();

                JavaScriptSerializer jss = new JavaScriptSerializer();
                var contentInfo = jss.Deserialize<CONTENTINFO>(result);

                foreach (var contentinfodata in contentInfo.data)
                {
                    if (contentinfodata.version > 0)
                    {
                        CBVersion.Items.Add(contentinfodata.version);
                    }

                }

                obj = contentInfo;
                sr.Close();
                myResponse.Close();
            }
            catch (Exception e)
            {
                startForm.Hide();
                handleException(System.Reflection.MethodBase.GetCurrentMethod().Name + ":" + e.Message);
            }
        }



        private void ControllInitial()
        {
            GrpEdit.Visible = false;
            GrpAudit.Visible = false;
            GrpSum.Visible = false;
            //GRPsum.Visible = false;
            GRPsumList.Visible = false;
            //GRPproof.Visible = false;
            BTEditSendReport.Visible = false;
            BTEditSaveDB.Visible = false;

            BTauditSave.Visible = false;
            BTauditApprove.Visible = false;
            BTauditNoApprove.Visible = false;

            BTSumRefresh.Visible = false;
            BTSumShow.Visible = false;
            BTsumSave.Visible = false;
            BTsumApprove.Visible = false;
            ScreenShot.Visible = false;
            //BTsumNoApprove.Visible = false;

            //BTCombine.Visible = false;
            //BTCombineSave.Visible = false;
            //BTCombineComplete.Visible = false;

        }
        private void InitialForedit()
        {
            GrpEdit.Visible = true;
            BTEditSendReport.Visible = true;
            BTEditSaveDB.Visible = true;

        }
        private void InitialForAdmin()
        {
            GRPsumList.Visible = true;
            BTEditSendReport.Visible = true;
            BTEditSaveDB.Visible = true;
            LVPartRefresh();

        }
        private void InitialForview()
        {
            BTEditSendReport.Visible = false;
            BTEditSaveDB.Visible = false;

            if (fileinfo.data.seq == 0)
            {
                GrpWM.Visible = false;
                WmPlayer.Visible = false;
                ScreenShot.Visible = true;
            }

        }
        private void InitialForaudit()
        {
            GrpAudit.Visible = true;
            BTauditSave.Visible = true;
            BTauditApprove.Visible = true;
            BTauditNoApprove.Visible = true;
        }
        //private void InitialForesum(int StatusID)
        private void InitialForeMerge()
        {
            ScreenShot.Visible = true;
            GrpWM.Visible = false;
            WmPlayer.Visible = false;
            //GRPsumList.Visible = true;
            GrpSum.Visible = true;
            //BTSumRefresh.Visible = true;
            //BTSumShow.Visible = true;
            BTsumSave.Visible = true;
            BTsumApprove.Visible = true;
            //BTsumNoApprove.Visible = true;
            //if (!(StatusID == 3) )
            //{
            //    BTsumSave.Enabled = false;
            //    BTsumApprove.Enabled = false;
            //    BTsumNoApprove.Enabled = false;
            //    WordAllowEdit = false;
            //}
            //LVPartRefresh();


        }
        private void InitialForesum()
        {

            //GRPsumList.Visible = true;
            //BTSumRefresh.Visible = true;
            //BTSumShow.Visible = true;
            //BTsumSave.Visible = true;
            //BTsumApprove.Visible = true;
            //BTsumNoApprove.Visible = true;
            //if (!(StatusID == 3) )
            //{
            //    BTsumSave.Enabled = false;
            //    BTsumApprove.Enabled = false;
            //    BTsumNoApprove.Enabled = false;
            //    WordAllowEdit = false;
            //}
            //LVPartRefresh();


        }
        //private void InitialForproof(int StatusID)
        private void InitialForproof()
        {
            ScreenShot.Visible = true;
            GrpWM.Visible = false;
            WmPlayer.Visible = false;
            GrpAudit.Visible = true;
            BTauditSave.Visible = true;
            BTauditApprove.Visible = true;
            //BTauditNoApprove.Visible = true;

            //GRPsumList.Visible = true;
            //BTSumRefresh.Visible = true;
            //BTSumShow.Visible = true;
            //BTCombine.Visible = true;
            //BTCombineSave.Visible = true;
            //BTCombineComplete.Visible = true;
            //BTCombineComplete.Enabled = false;

            //SubmitWebAPisMeetingStatus(appinfo, room, "BTCombine");

            //if (!(StatusID == 8) && !(StatusID == 9))
            //{
            //    BTCombine.Enabled = false;
            //    BTCombineSave.Enabled = false;
            //    BTCombineComplete.Enabled = false;
            //    WordAllowEdit = false;
            //}
            LVPartRefresh();

        }
        private void LVPartRefresh()
        {


            LVPart.Clear();
            LVPart.View = System.Windows.Forms.View.Details;
            LVPart.Columns.Add("ตอนที่", 50);
            LVPart.Columns.Add("ขั้นตอน", 100);
            LVPart.Columns.Add("สถานะ", 100);

            // Use a tab to indent each line of the file.

            RequestSeqInfo(appinfo, ref contentInfoAll);
            //foreach (var contentinfodata in contentInfoAll.data)
            //{
            //    listV = LVPart.Items.Add(contentinfodata.seq.ToString());
            //    listV.SubItems.Add(contentinfodata.section_status.ToString() + "-" + contentinfodata.section_status_desc);
            //}
        }


        private void SubmitWebAPisStatus(APPINFO appinfo)
        {
            try
            {
                String UrlPhP;

                UrlPhP = URL + "api/reportsection/submitreportsection";
                WebRequest myRequest = WebRequest.Create(UrlPhP);
                myRequest.ContentType = "application/json";
                myRequest.Method = "POST";
                myRequest.Headers.Add("Authorization", appinfo.accessKey);

                using (var streamWriter = new StreamWriter(myRequest.GetRequestStream()))
                {

                    string json = "{";
                    json += "\"meeting_id\":\"" + appinfo.meeting_id + "\",";
                    json += "\"seq\":" + appinfo.seq + "";
                    json += "}";

                    streamWriter.Write(json);
                }
                WebResponse myResponse = myRequest.GetResponse();
                myResponse.Close();


                RequestContentInfo(appinfo, ref contentInfo);

            }
            catch (Exception e)
            {
                startForm.Hide();
                handleException(System.Reflection.MethodBase.GetCurrentMethod().Name + ":" + e.Message);
            }
        }

        private void SubmitRejectStatus(APPINFO appinfo)
        {
            try
            {
                String UrlPhP;

                UrlPhP = URL + "api/reportsection/rejectreportsection";
                WebRequest myRequest = WebRequest.Create(UrlPhP);
                myRequest.ContentType = "application/json";
                myRequest.Method = "POST";
                myRequest.Headers.Add("Authorization", appinfo.accessKey);

                using (var streamWriter = new StreamWriter(myRequest.GetRequestStream()))
                {

                    string json = "{";
                    json += "\"meeting_id\":\"" + appinfo.meeting_id + "\",";
                    json += "\"seq\":" + appinfo.seq + "";
                    json += "}";

                    streamWriter.Write(json);
                }
                WebResponse myResponse = myRequest.GetResponse();
                myResponse.Close();


                RequestContentInfo(appinfo, ref contentInfo);

            }
            catch (Exception e)
            {
                startForm.Hide();
                handleException(System.Reflection.MethodBase.GetCurrentMethod().Name + ":" + e.Message);
            }
        }
        private void SubmitWebAPisStatusFinal(APPINFO appinfo, CONTENTINFO contentinfo, string BTinfo)
        {
            try
            {
                String UrlPhP;
                //check current status is 2 change to 3 , others not change
                switch (BTinfo)
                {
                    case "edit":
                        if (contentinfo.data[0].function == 1 && contentinfo.data[0].section_status == 0)
                        {
                            contentinfo.data[0].function = 1;
                            contentinfo.data[0].section_status = 1;
                        }
                        break;
                    case "audit":
                        if (contentinfo.data[0].function == 2 && contentinfo.data[0].section_status == 0)
                        {
                            contentinfo.data[0].function = 2;
                            contentinfo.data[0].section_status = 1;
                        }
                        break;
                    case "sum":
                        if (contentinfo.data[0].function == 3 && contentinfo.data[0].section_status == 0)
                        {
                            contentinfo.data[0].function = 3;
                            contentinfo.data[0].section_status = 1;
                        }
                        break;
                    case "proof":
                        ////if (files.status_id == 8)
                        ////{
                        ////    files.status_id = 9;
                        ////}
                        break;
                    case "BTSendReport":
                        contentinfo.data[0].function = 2;
                        contentinfo.data[0].section_status = 0;
                        break;
                    case "BTauditApprove":
                        contentinfo.data[0].function = 3;
                        contentinfo.data[0].section_status = 0;
                        break;
                    case "BTauditNoApprove":
                        ////files.status_id = 2;
                        break;
                    case "BTsumApprove":
                        ////files.status_id = 8;
                        break;
                    case "BTsumNoApprove":
                        ////files.status_id = 5;
                        break;
                    case "BTCombineComplete":
                        ////files.status_id = 10;
                        break;

                }

                TxtRoomStatus.Text = GetStatusFromID(contentinfo.data[0].section_status);


                UrlPhP = URL + "api/reportsection/addtranscription";
                WebRequest myRequest = WebRequest.Create(UrlPhP);
                myRequest.ContentType = "application/json";
                myRequest.Method = "POST";

                myRequest.Headers.Add("Authorization", appinfo.accessKey);
                using (var streamWriter = new StreamWriter(myRequest.GetRequestStream()))
                {

                    string json = "{";
                    json += "\"query\":{\"meeting_id\":\"" + appinfo.meeting_id + "\",";
                    json += "\"function \":\"" + contentinfo.data[0].function + "\",";
                    json += "\"seq\":\"" + appinfo.seq + "\"}";
                    json += "}";
                    streamWriter.Write(json);

                }
                WebResponse myResponse = myRequest.GetResponse();

                myResponse.Close();
                //SubmitWebAPisMeetingStatus(appinfo, room);
            }
            catch (Exception e)
            {
                startForm.Hide();
                handleException(System.Reflection.MethodBase.GetCurrentMethod().Name + ":" + e.Message);
            }
        }
        private void SubmitWebAPisMeetingStatus(APPINFO appinfo, ROOM room, string BTinfo)
        {
            bool v_update_meeting = false;
            int v_status = 0;
            try
            {
                switch (BTinfo)
                {

                    case "BTauditApprove":
                        v_status = 7;
                        v_update_meeting = true;
                        break;
                    case "BTsumApprove":
                        v_status = 8;
                        RequestAllInfo(appinfo, ref contentInfoAll);
                        foreach (var files in contentInfoAll.data)
                        {
                            if (files.section_status == v_status)
                            {
                                v_update_meeting = true;
                            }
                            else
                            {
                                v_update_meeting = false;
                            }
                        }
                        //v_status = 8;
                        break;
                    case "BTCombine":
                        v_status = 9;
                        v_update_meeting = true;
                        break;
                    case "BTCombineComplete":
                        v_status = 10;
                        v_update_meeting = true;
                        break;

                }





                String UrlPhP;


                UrlPhP = URL + "api/reportsection/addtranscription";
                WebRequest myRequest = WebRequest.Create(UrlPhP);
                myRequest.ContentType = "application/json";
                myRequest.Method = "POST";

                myRequest.Headers.Add("Authorization", appinfo.accessKey);
                using (var streamWriter = new StreamWriter(myRequest.GetRequestStream()))
                {


                    string json = "{";
                    json += "\"query\":{\"meeting_id\":\"" + appinfo.meeting_id + "\",";
                    json += "\"seq\":\"" + appinfo.seq + "\"}";
                    json += "}";
                    streamWriter.Write(json);

                }
                WebResponse myResponse = myRequest.GetResponse();
                myResponse.Close();

                //}
            }
            catch (Exception e)
            {
                startForm.Hide();
                handleException(System.Reflection.MethodBase.GetCurrentMethod().Name + ":" + e.Message);
            }
        }


        private void OpenWord(APPINFO appinfo, FILE_CONTENT files)
        {
            IntPtr r;
            try
            {
                string vBookmark;
                string vString;
                string urlPHP;
                int oStart;
                int oEnd;
                int vRecNo;
                byte[] data;
                //check version1 is new
                if ((files.data.current_process == "1" && (files.data.section_status == 0 || files.data.section_status == 1) && files.data.version == 1) || (appinfo.mode == "new"))//0 is original 99 fortest add version to productive
                {

                    fileName = WorkPath + Appname + "Template.docx";
                    // Create a new Document, by calling the Add function in the Documents collection
                    Document aDoc = WordApp.Documents.Open(ref fileName, ref newTemplate, ref docType, ref isVisible);
                    object rng = WordApp.Selection.Range;
                    //set value for bookmarks           
                    oStart = 1;
                    oEnd = 1;
                    vRecNo = 0;
                    foreach (TRANSCRIPTION transcription in files.transcription)
                    {
                        vRecNo++;
                        WordApp.Selection.Move(WdUnits.wdCharacter, oEnd);
                        vBookmark = "P" + transcription.utt;
                        vString = transcription.text;
                        oEnd = oStart + vString.Length;
                        WordApp.Selection.Text = vString;
                        rng = aDoc.Range(oStart - 1, oEnd);
                        WordApp.Selection.Bookmarks.Add(vBookmark, rng);
                        oStart = oEnd;
                    }
                    ////LastVersion++;
                    files.data.version = LastVersion;
                    WordFileName = Appname + appinfo.meeting_id.ToString("00000") + "-" + files.data.seq.ToString("000") + ".docx";
                    WordFileNoExt = Appname + appinfo.meeting_id.ToString("00000") + "-" + files.data.seq.ToString("000");
                    aDoc.SaveAs2(WorkPath + WordFileName, WdSaveFormat.wdFormatDocumentDefault);
                    while (System.IO.File.Exists(WorkPath + WordFileName) == false)
                    {
                        //wait file save completed
                    }

                    Thread thread = new Thread(() =>
                    {

                        WordApp.ActiveWindow.View.ReadingLayout = false;
                        WordDirty = true;

                    });
                    thread.Start();
                    thread.Join();
                    //WordEdit();
                    //WordNonEdit();



                    WordApp.Selection.GoTo(WdGoToItem.wdGoToPage, 1);
                }
                else
                {
                    try
                    {

                        String UrlPhP;

                        UrlPhP = URL + "api/reportsection/downloadreportsection";

                        RestClient client = new RestClient(URL);


                        RestRequest request = new RestRequest("api/reportsection/downloadreportsection", Method.Post);
                        request.AddHeader("Authorization", appinfo.accessKey);


                        var body = "{";
                        body += "\"meeting_id\":\"" + appinfo.meeting_id + "\",";
                        body += "\"seq\":" + appinfo.seq + ",";
                        body += "\"process\":" + contentInfo.data[0].process + ",";
                        body += "\"version\":" + files.data.version;
                        body += "}";
                        request.AddParameter("application/json", body, ParameterType.RequestBody);
                        var response = client.Execute(request);

                        if (response.StatusCode != HttpStatusCode.OK)
                        {
                            WordActive = false;
                            NewMessage("ไม่พบ File ใน Server");

                            var exit = typeof(System.Windows.Forms.Application).GetMethod("ExitInternal",
                                                                    System.Reflection.BindingFlags.NonPublic |
                                                                    System.Reflection.BindingFlags.Static);
                            exit.Invoke(null, null);
                        }
                        WordFileName = Appname + appinfo.meeting_id.ToString("00000") + "-" + files.data.seq.ToString("000") + ".docx";
                        WordFileNoExt = Appname + appinfo.meeting_id.ToString("00000") + "-" + files.data.seq.ToString("000");


                        byte[] fileForDownload = client.DownloadData(request);
                        System.IO.File.WriteAllBytes(WorkPath + WordFileName, fileForDownload);



                        fileName = WorkPath + WordFileName;

                        while (System.IO.File.Exists(fileName.ToString()) == false)
                        {
                            //wait file download completed
                        }

                        Document aDoc = WordApp.Documents.Open(ref fileName, ref newTemplate, ref docType, ref isVisible);
                        aDoc.SaveAs2(WorkPath + WordFileName, WdSaveFormat.wdFormatDocumentDefault);

                        Thread thread = new Thread(() =>
                        {

                            WordApp.ActiveWindow.View.ReadingLayout = false;
                        });
                        thread.Start();
                        thread.Join();
                        Thread thread3 = new Thread(() =>
                        {
                            WordApp.Selection.Move(WdUnits.wdCharacter, 1);
                            WordApp.Selection.Move(WdUnits.wdCharacter, -1);

                        });
                        thread3.Start();
                        thread3.Join();
                        //WordNonEdit();
                    }
                    catch (Exception e)
                    {
                        handleException(System.Reflection.MethodBase.GetCurrentMethod().Name + ":" + e.Message);
                        //System.Windows.Forms.Application.Exit();
                        return;

                    }
                }


                Thread.Sleep(500); // Allow the process to open it's window

                WordApp.Visible = true;
                if (P_NonEditMode == false)
                {
                    //comment for not user requirment
                    //WordApp.ActiveDocument.Unprotect();
                }

                foreach (Process pList in Process.GetProcesses())
                {
                    if (pList.MainWindowTitle.Contains(WordFileNoExt))
                    {
                        WordWND = pList.MainWindowHandle;
                        break;
                    }
                }

                //easier to find the window handle


                SetParent(WordWND, PNWord.Handle);
                // WordApp.WindowState = WdWindowState.wdWindowStateMaximize;
                //SetWindowPos(WordWND, -1, 0, 0, PNWord.Width, PNWord.Height, 0x0040);
                MoveWindow(WordWND, 0, 0, PNWord.Width, PNWord.Height, true);

            }
            catch (Exception e)
            {
                startForm.Hide();
                handleException(System.Reflection.MethodBase.GetCurrentMethod().Name + ":" + e.Message);
            }
        }

        private void UpdateMeetingStatus(int report_status)
        {
            string UrlPHP;
            try
            {


                string UrlPhP = URL + "api/meeting/updatemeeting";
                WebRequest myRequest = WebRequest.Create(UrlPhP);
                myRequest.ContentType = "application/json";
                myRequest.Method = "POST";
                myRequest.Headers.Add("Authorization", appinfo.accessKey);

                using (var streamWriter = new StreamWriter(myRequest.GetRequestStream()))
                {

                    string json = "{";
                    json += "\"meeting_id\":" + appinfo.meeting_id + ",";
                    json += "\"report_status\":" + report_status + "";
                    json += "}";

                    streamWriter.Write(json);
                }

                WebResponse myResponse = myRequest.GetResponse();



                myResponse.Close();
            }
            catch (Exception e)
            {
                startForm.Hide();
                handleException(System.Reflection.MethodBase.GetCurrentMethod().Name + ":" + e.Message);
            }

        }

        private void UpdateReportStatus()
        {
            try
            {

                int report_status = 0;
                string UrlPHP;
                //if (contentInfo.data[0].section_status == 0)
                //{
                report_status = 1;
                string UrlPhP = URL + "api/reportsection/updatereportsection";
                WebRequest myRequest = WebRequest.Create(UrlPhP);
                myRequest.ContentType = "application/json";
                myRequest.Method = "POST";
                myRequest.Headers.Add("Authorization", appinfo.accessKey);

                using (var streamWriter = new StreamWriter(myRequest.GetRequestStream()))
                {

                    string json = "{";
                    json += "\"meeting_id\":" + appinfo.meeting_id + ",";
                    json += "\"seq\":" + appinfo.seq + ",";
                    json += "\"section_status\":" + report_status + "";
                    json += "}";

                    streamWriter.Write(json);
                }

                WebResponse myResponse = myRequest.GetResponse();



                myResponse.Close();
                //}

            }
            catch (Exception e)
            {
                startForm.Hide();
                handleException(System.Reflection.MethodBase.GetCurrentMethod().Name + ":" + e.Message);
            }

        }
        private void UpdateToServer(int im_version)
        {
            string UrlPHP;
            try
            {

                string docFile;

                string v_transcription = "";

                foreach (var transcription in fileinfo.transcription)
                {

                    v_transcription += "{";
                    v_transcription += "\"utt\":\"" + transcription.utt + "\",";
                    v_transcription += "\"start\":" + transcription.start + ",";
                    v_transcription += "\"stop\":" + transcription.stop + ",";
                    v_transcription += "\"text\":\"" + transcription.text + "\"";
                    v_transcription += "},";

                }
                v_transcription = v_transcription.Remove(v_transcription.Length - 1);
                //UrlPhP = URL + "qapi/updatestatus.php?user=" + appinfo.username + "&key=" + appinfo.accessKey + "&part=" + appinfo.part + "&status=" + fileinfo.data.section_status + "&task=" + "file";
                string UrlPhP = URL + "api/reportsection/addtranscription";
                WebRequest myRequest = WebRequest.Create(UrlPhP);
                myRequest.ContentType = "application/json";
                myRequest.Method = "POST";
                myRequest.Headers.Add("Authorization", appinfo.accessKey);

                using (var streamWriter = new StreamWriter(myRequest.GetRequestStream()))
                {

                    string json = "{";
                    json += "\"query\":{\"meeting_id\":\"" + appinfo.meeting_id + "\",";
                    json += "\"seq\":" + appinfo.seq + "},";
                    json += "\"transcription\":";
                    json += "[";
                    json += v_transcription;
                    json += "]";
                    json += "}";

                    streamWriter.Write(json);
                }

                WebResponse myResponse = myRequest.GetResponse();

                StreamReader sr = new StreamReader(myResponse.GetResponseStream(),
    System.Text.Encoding.UTF8);
                string result = sr.ReadToEnd();

                JavaScriptSerializer jss = new JavaScriptSerializer();
                var addtrans = jss.Deserialize<ADDTRANSCRIPTION>(result);
                contentInfo.data[0].version = addtrans.version;


                sr.Close();
                myResponse.Close();
                CBVersion.Items.Add(contentInfo.data[0].version);
                CBVersion.Text = contentInfo.data[0].version.ToString();

                TxtRoomVersion.Text = contentInfo.data[0].version.ToString();

                Thread thread3 = new Thread(() =>
                {
                    WordApp.Selection.Move(WdUnits.wdCharacter, 1);
                    WordApp.Selection.Move(WdUnits.wdCharacter, -1);

                });
                thread3.Start();
                thread3.Join();

            }
            catch (Exception e)
            {
                startForm.Hide();
                handleException(System.Reflection.MethodBase.GetCurrentMethod().Name + ":" + e.Message);
            }

        }

        private void UploadToServerPost()
        {

            try
            {


                string docFile = WorkPath + @"send/" + WordFileName;
                System.IO.Directory.CreateDirectory(WorkPath + @"/send");
                System.IO.File.Copy(WorkPath + WordFileName, docFile, true);
                //WordApp.ActiveDocument.SaveAs2(docFile, WdSaveFormat.wdFormatDocumentDefault);//save to send folder
                //string docFile = WorkPath + WordFileName;
                byte[] bytes = System.IO.File.ReadAllBytes(docFile);
                RestClient client = new RestClient(URL);
                //client.Timeout = -1;
                RestRequest request = new RestRequest("/api/reportsection/uploadreportsection", Method.Post);
                //request.AlwaysMultipartFormData = true;
                request.AddHeader("Authorization", appinfo.accessKey);
                // request.AddHeader("Content-Type", "application/json");
                //request.AddFile("file", docFile);
                request.AddFile("file", bytes, Path.GetFileName(WordFileName), MimeTypeMap.GetMimeType(Path.GetExtension(WordFileName)));
                request.AddParameter("meeting_id", appinfo.meeting_id.ToString());
                if (appinfo.mode == "merge")
                {
                    request.AddParameter("seq", "0");
                }
                else
                {
                    request.AddParameter("seq", appinfo.seq.ToString());
                }
                request.AddParameter("process", contentInfo.data[0].process.ToString());
                request.AddParameter("version", contentInfo.data[0].version.ToString());
                var response = client.Execute(request);
                //Console.WriteLine(response.Content);
            }
            catch (Exception e)
            {
                startForm.Hide();
                handleException(System.Reflection.MethodBase.GetCurrentMethod().Name + ":" + e.Message);
            }
        }
        private void UploadToServerPost_temp()
        {
            string UrlPHP = URL + "api/reportsection/uploadreportsection";
            //string user = appinfo.username;
            //string key = appinfo.accessKey;
            //string part = appinfo.part.ToString();
            //string version = im_version.ToString();
            string docFile = WorkPath + @"send\" + WordFileName;
            string filename = Path.GetFileName(docFile);
            try
            {
                WordApp.ActiveDocument.SaveAs2(docFile, WdSaveFormat.wdFormatDocumentDefault);//save to send folder
                FileStream stream = new FileStream(WorkPath + WordFileName, FileMode.Open);
                var client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", appinfo.accessKey);
                //client.DefaultRequestHeaders.Authorization =   new  System.Net.Http.Headers.AuthenticationHeaderValue("Authorization", "=" + appinfo.accessKey);

                using (MultipartFormDataContent formData = new MultipartFormDataContent())
                {
                    //formData.Headers.h . Add("Authorization", appinfo.accessKey);
                    //formData.Headers.Add("Content-Type", "application/json");
                    formData.Add(new StringContent(appinfo.meeting_id.ToString()), "meeting_id");
                    formData.Add(new StringContent(appinfo.seq.ToString()), "seq");
                    formData.Add(new StringContent(contentInfo.data[0].process.ToString()), "process");
                    formData.Add(new StringContent(contentInfo.data[0].version.ToString()), "version");
                    formData.Add(new StreamContent(stream), "file", filename + "s");
                    var response = client.PostAsync(UrlPHP, formData).Result;
                }
            }
            catch (Exception e)
            {
                startForm.Hide();
                handleException(System.Reflection.MethodBase.GetCurrentMethod().Name + ":" + e.Message);
            }
        }

        private void OpenMedia(APPINFO appinfo, FILE_CONTENT files)
        {
            WmPlayer.uiMode = "full";
            WmPlayer.URL = URL + "api/meetingmedia/downloadmediadirect?meeting_id=" + files.data.meeting_id + "&file=" + files.data.video;
            WmPlayer.Ctlcontrols.stop();

        }
        private string GetActiveWindowsTitle()
        {
            const int nChar = 256;
            StringBuilder Buff = new StringBuilder(nChar);
            IntPtr handle = GetForegroundWindow();
            if (GetWindowText(handle, Buff, nChar) > 0)
            {
                return Buff.ToString();
            }
            return null;
        }
        private void ShowVersion(APPINFO appinfo, FILE_CONTENT files)
        {
            try
            {
                object doNotSaveChanges = Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges;
                WordApp.Documents.Close(ref doNotSaveChanges, ref missing, ref missing);
            }
            catch (Exception e2)
            {
                handleException(System.Reflection.MethodBase.GetCurrentMethod().Name + ":" + e2.Message);
            }
            files.data.version = int.Parse(CBVersion.SelectedItem.ToString());
            ////RequestVideoInfo(appinfo, room, ref video);
            OpenWord(appinfo, files);
        }
        private void ShowNewApp()
        {
            try
            {
                object doNotSaveChanges = Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges;
                WordApp.Documents.Close(ref doNotSaveChanges, ref missing, ref missing);
                appinfo.seq = int.Parse(LVPart.SelectedItems[0].Text);

                RequestVersionInfo(appinfo, ref versioninfo);
                RequestContentInfo(appinfo, ref contentInfo);
                RequestFileInfo(appinfo, ref fileinfo);
                OpenWord(appinfo, fileinfo);
                OpenMedia(appinfo, fileinfo);
            }

            catch (Exception e2)
            {


            }
        }

        private void WordSave(APPINFO appinfo, FILE_CONTENT files, string mode)
        {
            int vMessageVersion;
            try
            {
                var resultBox = System.Windows.Forms.DialogResult.Yes;
                vMessageVersion = LastVersion + 1;
                if (mode == "" || mode == "SAVE")
                {
                    //resultBox = MessageBox.Show("ต้องการบันทึกฉบับร่าง", "ต้องการบันทึก", MessageBoxButtons.YesNo);
                    //resultBox =  NewConfirmBox.ShowDialog(this, "ยืนยันการบันทึก" , "ต้องการบันทึกฉบับร่าง");
                    resultBox = NewMessageConfirm("ต้องการบันทึกฉบับร่าง");
                }
                else
                {
                    resultBox = System.Windows.Forms.DialogResult.Yes;
                }
                if (resultBox == System.Windows.Forms.DialogResult.Yes)
                {
                    WmPlayer.Ctlcontrols.stop();
                    Cursor.Current = Cursors.WaitCursor;
                    SaveData(appinfo, files);
                    if (WordChang)
                    {
                        UpdateToServer(vMessageVersion);
                        UploadToServerPost();
                        Cursor.Current = Cursors.Default;
                        //MessageBox.Show("ดำเนินการเสร็จเรียบร้อย");
                        NewMessage("ดำเนินการเสร็จเรียบร้อย");


                        if (P_NonEditMode == true)
                        {
                            Thread thread = new Thread(() =>
                            {
                                if (WordApp.ActiveDocument.ProtectionType == WdProtectionType.wdAllowOnlyReading)
                                {
                                }
                                else
                                {
                                    WordApp.ActiveDocument.Protect(WdProtectionType.wdAllowOnlyReading);
                                }
                            });
                            thread.Start();
                            thread.Join();
                        }
                        // goto last position
                        if (LastUtt > 0)
                        //if (LastUtt !=  "")
                        {
                            //var content = files.transcription.Where(w => w.utt == LastUtt);
                            var content = files.transcription.Where(w => int.Parse(w.utt) > LastUtt);
                            WmPlayer.Ctlcontrols.currentPosition = content.First().start;
                            v_bookmark = "P" + content.First().utt;
                            //LastUtt = content.First().utt;
                            LastUtt = int.Parse(content.First().utt);
                            if ((ChkHighlight.Checked == true) && ((WmPlayer.playState != WMPLib.WMPPlayState.wmppsPlaying) && (WmPlayer.playState != WMPLib.WMPPlayState.wmppsScanForward)))
                            {
                                Thread thread2 = new Thread(() =>
                                {
                                    WordApp.Selection.GoTo(WdGoToItem.wdGoToBookmark, Name: v_bookmark);

                                });
                                thread2.Start();
                                thread2.Join();
                            }
                        }
                        // goto last position
                        ////FormMain.ActiveForm.Focus();
                    }

                }
            }
            catch (Exception e2)
            {
                startForm.Hide();
                handleException(System.Reflection.MethodBase.GetCurrentMethod().Name + ":" + e2.Message);
                Cursor.Current = Cursors.Default;
            }
        }


        private void WordMergeSave(APPINFO appinfo, FILE_CONTENT files)
        {
            int vMessageVersion;
            try
            {
                vMessageVersion = LastVersion + 1;
                //var resultBox = MessageBox.Show("ต้องการบันทึกฉบับร่าง", "ต้องการบันทึก", MessageBoxButtons.YesNo);
                //var resultBox = NewConfirmBox.ShowDialog(this, "ยืนยันการบันทึก", "ต้องการบันทึกฉบับร่าง");

                var resultBox = NewMessageConfirm("ต้องการบันทึกฉบับร่าง");
                if (resultBox == System.Windows.Forms.DialogResult.Yes)
                {
                    SaveData(appinfo, files);
                    if (WordChang)
                    {
                        UpdateToServer(vMessageVersion);
                        UploadToServerPost();
                        Cursor.Current = Cursors.Default;
                        //MessageBox.Show("ดำเนินการเสร็จเรียบร้อย");
                        NewMessage("ดำเนินการเสร็จเรียบร้อย");


                    }
                    //WmPlayer.Ctlcontrols.stop();
                    //Cursor.Current = Cursors.WaitCursor;
                    //UpdateToServer(vMessageVersion);
                    //UploadToServerPost();
                    //    //SaveData(appinfo, files);
                    //Cursor.Current = Cursors.Default;
                    //MessageBox.Show("ดำเนินการเสร็จเรียบร้อย");


                }
            }
            catch (Exception e2)
            {
                startForm.Hide();
                handleException(System.Reflection.MethodBase.GetCurrentMethod().Name + ":" + e2.Message);
                Cursor.Current = Cursors.Default;
            }
        }

        private void MergeToNewWordFile()
        {

            //string vBookmark;
            string vString;
            string urlPHP;
            string DeletePath;
            string OriginalFile;
            string ReviseFile;
            string TemplateFile;
            string LastFile;
            int oStart;
            int oEnd;
            int vRecNo;
            byte[] data;
            try
            {

                StripProgress.Visible = true;
                // Set Minimum to 1 to represent the first file being copied.
                StripProgress.Minimum = 1;
                // Set Maximum to the total number of files to copy.
                StripProgress.Maximum = contentInfoAll.data.Count() + contentInfoAll.data.Count();
                // Set the initial value of the ProgressBar.
                StripProgress.Value = 1;
                // Set the Step property to a value of 1 to represent each file being copied.
                StripProgress.Step = 1;

                if ((fileinfo.data.current_process == "3" && (fileinfo.data.section_status == 0 || fileinfo.data.section_status == 1) && fileinfo.data.version == 1) || (appinfo.mode == "mergeNew"))
                {

                    DeletePath = WorkPath + @"Merge\";
                    System.IO.Directory.CreateDirectory(WorkPath + @"\\merge");
                    string[] files = System.IO.Directory.GetFiles(DeletePath);
                    foreach (string file in files)
                    {
                        System.IO.File.Delete(file);
                    }
                    //RequestAllInfo(appinfo, ref roomall);
                    foreach (var seqInfo in contentInfoAll.data)
                    {
                        //ฝStripProgress.PerformStep();
                        StripProgressStatus.Text = "Download File...";
                        if (seqInfo.function < 3)
                        {
                            //MessageBox.Show("ไม่สามารถรวม File เนื่องจาก ตอนที่ " + seqInfo.seq + " " + seqInfo.section_status_desc);
                            NewMessage("ไม่สามารถรวม File เนื่องจาก ตอนที่ " + seqInfo.seq + " " + seqInfo.section_status_desc);
                            return;
                        }
                        //RequestVideobyPart(appinfo, file, ref videopart);
                        if (seqInfo.seq > 0)
                        {

                            Cursor.Current = Cursors.WaitCursor;

                            Thread thread = new Thread(() =>
                            {
                                try
                                {
                                    //WordFileName = seqInfo.seq.ToString("00000") + "-" + file.version + ".docx";


                                    String UrlPhP;

                                    UrlPhP = URL + "api/reportsection/downloadreportsection";

                                    RestClient client = new RestClient(URL);


                                    RestRequest request = new RestRequest("api/reportsection/downloadreportsection", Method.Post);
                                    request.AddHeader("Authorization", appinfo.accessKey);


                                    var body = "{";
                                    body += "\"meeting_id\":\"" + appinfo.meeting_id + "\",";
                                    body += "\"seq\":" + seqInfo.seq + ",";
                                    body += "\"process\":" + seqInfo.process + ",";
                                    body += "\"version\":" + seqInfo.version;
                                    body += "}";
                                    request.AddParameter("application/json", body, ParameterType.RequestBody);
                                    var response = client.Execute(request);


                                    WordFileName = Appname + appinfo.meeting_id.ToString("00000") + "-" + seqInfo.seq.ToString("00000") + ".docx";
                                    WordFileNoExt = Appname + appinfo.meeting_id.ToString("00000") + "-" + seqInfo.seq.ToString("00000");


                                    byte[] fileForDownload = client.DownloadData(request);
                                    System.IO.File.WriteAllBytes(DeletePath + WordFileName, fileForDownload);



                                    fileName = DeletePath + WordFileName;

                                    while (System.IO.File.Exists(fileName.ToString()) == false)
                                    {
                                        //wait file download completed
                                    }


                                }
                                catch (Exception e)
                                {
                                }
                            });
                            thread.Start();
                            thread.Join();
                            //System.Threading.Thread.Sleep(500);
                            StripProgressStatus.Text = "Download Completed " + seqInfo.seq + "/" + (contentInfoAll.data.Count());
                        }
                        StripProgress.PerformStep();
                    }
                    LastFile = DeletePath + WordFileName;
                    //WordFileNameNew = Appname + appinfo.meeting_id.ToString("00000") + ".docx";
                    //WordFileNameNewNoExt = Appname + appinfo.meeting_id.ToString("00000") ;
                    WordFileName = Appname + appinfo.meeting_id.ToString("00000") + ".docx";
                    WordFileNoExt = Appname + appinfo.meeting_id.ToString("00000");
                    ReviseFile = WorkPath + WordFileName;
                    TemplateFile = WorkPath + Appname + "Template.docx";
                    fileName = ReviseFile;

                    System.IO.File.Copy(TemplateFile, ReviseFile, true);

                    //Microsoft.Office.Interop.Word.Application WordAppNew = new Microsoft.Office.Interop.Word.Application();
                    //Document ReviseDoc = WordAppNew.Documents.Open(ref fileName, ref newTemplate, ref docType, ref isVisible);
                    Document ReviseDoc = WordApp.Documents.Open(ref fileName, ref newTemplate, ref docType, ref isVisible);
                    //ReviseDoc.SaveAs2(ReviseFile, WdSaveFormat.wdFormatDocumentDefault);

                    WordApp.Visible = true;
                    WordApp.Height = 800;

                    Thread.Sleep(500); // Allow the process to open it's window

                    WordApp.Visible = true;
                    if (P_NonEditMode == false)
                    {
                        //comment for not user requirment
                        //WordApp.ActiveDocument.Unprotect();
                    }
                    foreach (Process pList in Process.GetProcesses())
                    {
                        if (pList.MainWindowTitle.Contains(WordFileNoExt))
                        {
                            WordWND = pList.MainWindowHandle;
                            break;
                        }
                    }

                    //easier to find the window handle


                    SetParent(WordWND, PNWord.Handle);
                    MoveWindow(WordWND, 0, 0, PNWord.Width, PNWord.Height, true);




                    //StripProgress.PerformStep();
                    StripProgressStatus.Text = "Merge File...";
                    string[] filesmerge = System.IO.Directory.GetFiles(DeletePath);
                    int vcnt = 0;
                    foreach (string file in filesmerge)
                    {



                        OriginalFile = file;
                        //WordApp.Selection.InsertFile(OriginalFile)
                        WordApp.Selection.InsertFile(OriginalFile
                                                , ref missing
                                                , ref missing
                                                , ref missing
                                                , ref missing);
                        WordApp.Selection.InsertBreak(WdBreakType.wdPageBreak);

                        vcnt++;
                        StripProgress.PerformStep();
                        StripProgressStatus.Text = "Merge Completed " + vcnt + "/" + (filesmerge.Count());

                    }

                    //ReviseDoc.Paragraphs.Last.Range.Select();

                    //WordApp.Selection.Delete();
                    TopMost = false;

                    ReviseDoc.SaveAs2(ReviseFile, WdSaveFormat.wdFormatDocumentDefault);
                    Cursor.Current = Cursors.Default;
                    //MessageBox.Show("รวบรวมรายงานเรียบร้อย");
                    NewMessage("รวบรวมรายงานเรียบร้อย");
                    ////BTCombineComplete.Enabled = true;
                    BTsumSave.Visible = true;
                    BTsumApprove.Visible = true;


                    //WordApp.Selection.GoTo(WdGoToItem.wdGoToBookmark, Name: v_bookmark);
                    WordApp.Selection.GoTo(WdGoToItem.wdGoToPage, 1);
                }
                else
                {
                    try
                    {
                        if (fileinfo.data.current_process == "3")
                        {

                            OpenWord(appinfo, fileinfo);
                        }
                        else
                        {
                            WordActive = false;
                            NewMessage("ไม่สามารถรวม File เนื่องจาก ยังไม่ถึงขั้นตอนรวบรวม");
                            return;
                        }
                    }
                    catch (Exception e)
                    {
                        handleException(System.Reflection.MethodBase.GetCurrentMethod().Name + ":" + e.Message);
                        Cursor.Current = Cursors.Default;
                    }

                }
            }
            catch (Exception e)
            {
                startForm.Hide();
                handleException(System.Reflection.MethodBase.GetCurrentMethod().Name + ":" + e.Message);
                Cursor.Current = Cursors.Default;
            }
        }
        private void SaveData(APPINFO appinfo, FILE_CONTENT files)
        {
            string V_WordText;
            string vBookmark = "";
            string last_result = "";
            //int last_utt = 0;
            string last_utt = "";
            int oStart;
            int oEnd;
            object rng = WordApp.Selection.Range;
            try
            {
                WordApp.Visible = false;
                WordChang = false;

                foreach (TRANSCRIPTION transcription in files.transcription)
                {
                    vBookmark = "P" + transcription.utt;
                    WordApp.Selection.GoTo(WdGoToItem.wdGoToBookmark, Name: vBookmark);
                    V_WordText = WordApp.Selection.Text;
                    last_result = transcription.text;
                    last_utt = transcription.utt;
                    if (V_WordText != transcription.text)
                    {
                        WordChang = true;
                        V_WordText = V_WordText.Replace("\b", ""); //Backspace(ascii code 08)
                        V_WordText = V_WordText.Replace("\r", ""); //Carriage return
                        V_WordText = V_WordText.Replace("\f", ""); //Form feed(ascii code 0C)
                        V_WordText = V_WordText.Replace("\n", ""); //New line
                        V_WordText = V_WordText.Replace("\t", ""); //Tab
                        V_WordText = V_WordText.Replace("\"", ""); //Double quote
                        V_WordText = V_WordText.Replace("\\", ""); //Backslash


                        V_WordText = V_WordText.Replace(System.Environment.NewLine, "");
                        transcription.text = V_WordText; ;
                    }
                }

                WordApp.Visible = true;
                //// Check user insert over bookmark
                oStart = WordApp.Selection.Start;
                oEnd = WordApp.Selection.StoryLength;
                rng = WordApp.ActiveDocument.Range(oStart, oEnd);
                WordApp.Selection.Bookmarks.Add(vBookmark, rng);
                WordApp.Selection.GoTo(WdGoToItem.wdGoToBookmark, Name: vBookmark);
                V_WordText = WordApp.Selection.Text;
                V_WordText = V_WordText.Replace("\b", ""); //Backspace(ascii code 08)
                V_WordText = V_WordText.Replace("\r", ""); //Carriage return
                V_WordText = V_WordText.Replace("\f", ""); //Form feed(ascii code 0C)
                V_WordText = V_WordText.Replace("\n", ""); //New line
                V_WordText = V_WordText.Replace("\t", ""); //Tab
                V_WordText = V_WordText.Replace("\"", ""); //Double quote
                V_WordText = V_WordText.Replace("\\", ""); //Backslash
                V_WordText = V_WordText.Replace(System.Environment.NewLine, "");



                if (WordApp.Selection.End != oEnd)
                {
                    WordChang = true;
                    var content = files.transcription.Where(w => w.utt == last_utt);
                    content.First().text = V_WordText;
                }

                if (WordChang)
                {
                    WordApp.ActiveDocument.Save(); //save old version
                    LastVersion++;
                    TxtRoomVersion.Text = contentInfo.data[0].process + "." + LastVersion.ToString();


                    fileName = WorkPath + WordFileName;

                    WordApp.ActiveDocument.SaveAs2(WorkPath + WordFileName, WdSaveFormat.wdFormatDocumentDefault); //save old version

                }
                else
                {
                    //MessageBox.Show("ไม่มีการเปลี่ยนแปลงข้อความ");
                    NewMessage("ไม่มีการเปลี่ยนแปลงข้อความ");
                }
            }
            catch (Exception e)
            {
                startForm.Hide();
                handleException(System.Reflection.MethodBase.GetCurrentMethod().Name + ":" + e.Message);
            }
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            this.Hide();
            startForm.Show();
            //tSplashScreen = new Thread(new ThreadStart(StartForm));
            //tSplashScreen.Start();

            string[] args = Environment.GetCommandLineArgs();
            //default
            //MessageBox.Show(args[0]+","+ args[1] + "," + args[2] + "," + args[3] + "," + args[4]);
            foreach (var proc in Process.GetProcessesByName("WINWORD"))
            {
                if (proc.MainWindowTitle == "")
                {
                    proc.Kill();
                }
            }

            WordApp = new Microsoft.Office.Interop.Word.Application();
            foreach (Process proc in Process.GetProcessesByName(Appname))
            {
                proc_cnt++;
            }
            if (proc_cnt > 1)
            {
                //MessageBox.Show("มีการเปิด Program " + Appname + " อบู่แล้ว");
                NewMessage("มีการเปิด Program " + Appname + " อบู่แล้ว");
                System.Windows.Forms.Application.Exit();
                return;
            }
            else
            {

                ControllInitial();
                if (args.Length > 1)
                {
                    try
                    {

                        appinfo.mode = args[1];
                        appinfo.accessKey = args[2];
                        appinfo.meeting_id = Int32.Parse(args[3]);
                        if (args.Length > 4)
                        {
                            appinfo.seq = Int32.Parse(args[4]);
                        }
                        else
                        {
                            appinfo.seq = 1;
                        }
                        appinfo.token = ConfigurationSettings.AppSettings["Token"];
                    }
                    catch (Exception e2)
                    {
                        handleException(System.Reflection.MethodBase.GetCurrentMethod().Name + ":" + e2.Message);
                        System.Windows.Forms.Application.Exit();
                        return;
                    }

                }
                else
                {

                    appinfo.mode = "edit";
                    appinfo.meeting_id = 1;
                    appinfo.seq = 1;
                    appinfo.accessKey = "JWT eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpYXQiOjE2Njc1Mjg4MzAxMjQsInVzZXJfcHJvZmlsZSI6eyJpZCI6NDAsIm5hbWUiOiLguJnguLLguIfguJPguLTguIrguLLguJnguLHguJnguJfguYwg4LiU4Li14Lii4Liy4Lih4LiyIiwidXNlcm5hbWUiOiJuaWNoYW51bi5kIiwiZW1haWwiOiJuaWNoYW51bi5kQHBhcmxpYW1lbnQuZ28udGgiLCJhZmZpbGlhdGlvbiI6IuC4quC4s-C4meC4seC4geC4o-C4suC4ouC4h-C4suC4meC4geC4suC4o-C4m-C4o-C4sOC4iuC4uOC4oeC5geC4peC4sOC4iuC4p-C5gOC4peC4giIsImxldmVsIjoi4LiX4LiU4Liq4Lit4Lia4Liq4Lix4LiH4LiB4Lix4LiUIiwicG9zaXRpb24iOiIiLCJ3b3JrZ3JvdXAiOiLguJzguLnguYnguITguKfguJrguITguLjguKHguIHguLLguKPguIjguJTguKPguLLguKLguIfguLLguJnguIHguLLguKPguJvguKPguLDguIrguLjguKEiLCJyb2xlIjoxfSwiZXhwIjoxNjY3NTI4ODMwMTM0fQ.VgDvpmZ4vJVSoMgbi1hI7t45-Qd-ZVaqrVVUQnG-x9U";

                }
                if (P_ShortCutMode.ToString() == "X")
                {
                    //STBar.Panels[1].Text = "F1 ความเร็ว 0.5x";
                    //STBar.Panels[2].Text = "F2 ความเร็ว 1x";
                    //STBar.Panels[3].Text = "F3 ความเร็ว 2x";
                    //STBar.Panels[4].Text = "F4 ความเร็ว 4x";
                    //STBar.Panels[5].Text = "F5 เพิ่มเสียง ";
                    //STBar.Panels[6].Text = "F6 ลดเสียง";
                    ////STBar.Panels[7].Text = "F7 เล่นตำแหน่งปัจจุบัน";
                    ////STBar.Panels[8].Text = "F8 เล่นซ้ำ";
                    //STBar.Panels[7].Text = "F7 เล่นซ้ำ";
                    //STBar.Panels[8].Text = "F8 เล่นตำแหน่งปัจจุบัน";
                    //STBar.Panels[10].Text = "F10 ย้อนข้อความ";
                    //STBar.Panels[11].Text = "F11 หยุดเล่นวีดีโอ ";
                    //STBar.Panels[12].Text = "F12 ข้ามข้อความ";
                }
                //STBar.Panels[9].Text = "F9 เล่นวีดีโอ/หยุดชั่วคราว ";
                URL = ConfigurationSettings.AppSettings["url"];
                RequestRoomInfo(appinfo, ref room);
                if (object.ReferenceEquals(room, null))
                {
                    //MessageBox.Show("ต้องการสิทธิ์ในการใช้งาน");
                    NewMessage("ต้องการสิทธิ์ในการใช้งาน");
                    System.Windows.Forms.Application.Exit();
                    return;
                }

                RequestVersionInfo(appinfo, ref versioninfo);
                RequestContentInfo(appinfo, ref contentInfo);
                RequestFileInfo(appinfo, ref fileinfo);

                RequestSeqInfo(appinfo, ref contentInfoAll);



                switch (appinfo.mode)
                {
                    case "edit":

                        OpenWord(appinfo, fileinfo);
                        OpenMedia(appinfo, fileinfo);
                        UpdateMeetingStatus(1);
                        UpdateReportStatus();
                        break;
                    case "new":

                        OpenWord(appinfo, fileinfo);
                        OpenMedia(appinfo, fileinfo);
                        UpdateMeetingStatus(1);
                        UpdateReportStatus();
                        break;
                    case "mergeNew":
                        MergeToNewWordFile();
                        UpdateReportStatus();
                        break;
                    case "merge":
                        MergeToNewWordFile();
                        UpdateReportStatus();
                        break;
                    case "view":
                        OpenWord(appinfo, fileinfo);
                        if (fileinfo.data.seq > 0)
                        {
                            OpenMedia(appinfo, fileinfo);
                        }
                        break;
                    case "audit":
                        OpenWord(appinfo, fileinfo);
                        OpenMedia(appinfo, fileinfo);
                        UpdateReportStatus();
                        break;
                    case "sum":
                        OpenWord(appinfo, fileinfo);
                        OpenMedia(appinfo, fileinfo);
                        break;
                    case "proof":
                        OpenWord(appinfo, fileinfo);
                        OpenMedia(appinfo, fileinfo);
                        UpdateReportStatus();
                        break;
                    case "admin":
                        break;

                }
                ////LastVersion = room.files[0].version;
                this.Activate();
                CTN.Panel1.Focus();
                WmPlayerTimer.Start();


                //this.Text = Apptitle + "-" + room.data[0].meeting_title;
                switch (appinfo.mode)
                {
                    case "edit":
                        InitialForedit();
                        break;
                    case "new":
                        InitialForedit();
                        break;
                    case "view":
                        InitialForview();
                        P_NonEditMode = true;
                        break;
                    case "audit":
                        InitialForaudit();
                        break;
                    case "merge":
                        InitialForeMerge();
                        break; ;
                    case "mergeNew":
                        InitialForeMerge();
                        break;
                    case "sum":
                        InitialForesum();
                        P_NonEditMode = true;
                        break;
                    case "proof":
                        InitialForproof();
                        break;
                    case "admin":
                        InitialForAdmin();
                        break;

                }

                //if (GetActiveWindowsTitle().Contains("Partii") == true)
                if (GetActiveWindowsTitle().Contains(Appname) == true)
                {
                    Kh_KeyUp_Mode = 2;
                }
                else
                {
                    Kh_KeyUp_Mode = 1;
                }

            }
        }

        private void BT05X_Click(object sender, EventArgs e)
        {

            WmplayerPlay05();
        }

        private void BT10X_Click(object sender, EventArgs e)
        {

            WmplayerPlay10();
        }

        private void BT20X_Click(object sender, EventArgs e)
        {

            WmplayerPlay20();
        }

        private void BT40X_Click(object sender, EventArgs e)
        {

            WmplayerPlay40();
        }

        private void BTShowVersion_Click(object sender, EventArgs e)
        {

            ShowVersion(appinfo, fileinfo);
        }

        private void BTSumRefresh_Click(object sender, EventArgs e)
        {

            LVPartRefresh();
        }

        private void BTSumShow_Click(object sender, EventArgs e)
        {

            ShowNewApp();
        }

        private void BTCombineSave_Click(object sender, EventArgs e)
        {

            WordSave(appinfo, fileinfo, "SAVE");
        }

        private void BTEditSaveDB_Click(object sender, EventArgs e)
        {
            WordSave(appinfo, fileinfo, "SAVE");

        }

        private void BTEditSendReport_Click(object sender, EventArgs e)
        {

            //var resultBox = MessageBox.Show("ต้องการส่งรายงาน", "ส่งรายงาน", MessageBoxButtons.YesNo);
            //var resultBox = NewConfirmBox.ShowDialog(this, "ยืนยันการส่งรายงาน", "ต้องการส่งรายงาน");

            var resultBox = NewMessageConfirm("ต้องการส่งรายงาน");
            if (resultBox == System.Windows.Forms.DialogResult.Yes)
            {
                WordDirty = false; //not check change
                SubmitWebAPisStatus(appinfo);
                //MessageBox.Show("ดำเนินการเสร็จเรียบร้อย");
                NewMessage("ดำเนินการเสร็จเรียบร้อย");
                var exit = typeof(System.Windows.Forms.Application).GetMethod("ExitInternal",
                                                                    System.Reflection.BindingFlags.NonPublic |
                                                                    System.Reflection.BindingFlags.Static);
                exit.Invoke(null, null);
            }
        }

        private void BTauditSave_Click(object sender, EventArgs e)
        {
            WordSave(appinfo, fileinfo, "SAVE");

        }

        private void BTauditApprove_Click(object sender, EventArgs e)
        {

            SendReport();

        }

        private void BTauditNoApprove_Click(object sender, EventArgs e)
        {

            RejectReport();
        }

        private void BTsumSave_Click(object sender, EventArgs e)
        {

            WordMergeSave(appinfo, fileinfo);
        }

        private void BTsumApprove_Click(object sender, EventArgs e)
        {

            SendReport();
        }

        private void BTsumNoApprove_Click(object sender, EventArgs e)
        {

            if (fileinfo.data.section_status >= 6)
            {
                //var resultBox = MessageBox.Show("ต้องการไม่อนุมัติ", "ไม่อนุมัติ", MessageBoxButtons.YesNo);
                //var resultBox = NewConfirmBox.ShowDialog(this, "ยืนยันการไม่อนุมัติ", "ต้องการไม่อนุมัติ");
                var resultBox = NewMessageConfirm("ต้องการไม่อนุมัติ");
                if (resultBox == System.Windows.Forms.DialogResult.Yes)
                {
                    SubmitWebAPisStatus(appinfo);
                    LVPartRefresh();
                    BTsumSave.Enabled = false;
                    BTsumApprove.Enabled = false;
                    //BTsumNoApprove.Enabled = false;
                    WordAllowEdit = false;
                }
            }
            else
            {
                //MessageBox.Show("รายการยังไม่ผ่านการ" + STATUS06);
                NewMessage("รายการยังไม่ผ่านการ" + STATUS06);
            }
        }

        private void BTCombine_Click(object sender, EventArgs e)
        {

            MergeToNewWordFile();
        }

        private void BTCombineComplete_Click(object sender, EventArgs e)
        {

            //var resultBox = MessageBox.Show("ยืนยันการรวบรวม", "ดำเนินการรวบรวมเสร็จสิ้น", MessageBoxButtons.YesNo);
            //var resultBox = NewConfirmBox.ShowDialog(this, "ยืนยันการรวบรวม", "ต้องการรวบรวม");
            var resultBox = NewMessageConfirm("ต้องการรวบรวม");
            if (resultBox == System.Windows.Forms.DialogResult.Yes)
            {

                RequestAllInfo(appinfo, ref contentInfoAll);
                foreach (var file in contentInfoAll.data)
                {

                    SubmitWebAPisStatusFinal(appinfo, contentInfo, "BTCombineComplete");
                    //SubmitWebAPisMeetingStatus(appinfo, room, "BTCombineComplete");

                }
                string ReviseFile;

                //upload to server
                ////string UrlPHP = URL + "qapi/savefinalwordfile.php";
                ////string user = appinfo.username;
                ////string key = appinfo.accessKey;
                ////string docFile = WorkPath + @"send\" + WordFileNameNew;
                ////string filename = Path.GetFileName(docFile);
                ////ReviseFile = WorkPath + WordFileNameNew;
                ////try
                ////{
                ////    System.IO.File.Delete(docFile);
                ////    System.IO.File.Copy(ReviseFile, docFile);
                ////    //WordAppNew.ActiveDocument.SaveAs2(docFile, WdSaveFormat.wdFormatDocumentDefault);//save to send folder
                ////    FileStream stream = new FileStream(docFile, FileMode.Open);
                ////    using (HttpClient client = new HttpClient())
                ////    using (MultipartFormDataContent formData = new MultipartFormDataContent())
                ////    {
                ////        formData.Add(new StringContent(user), "user");
                ////        formData.Add(new StringContent(key), "key");
                ////        formData.Add(new StreamContent(stream), "file", docFile);
                ////        var response = client.PostAsync(UrlPHP, formData).Result;
                ////    }

                ////}
                ////catch (Exception e2)
                ////{
                ////    //MessageBox.Show(System.Reflection.MethodBase.GetCurrentMethod().Name + ":" + e.Message);
                ////}
                //end upload to server

                LVPartRefresh();
            }
        }

        private void PNWord_Resize(object sender, EventArgs e)
        {
            MoveWindow(WordWND, 0, 0, PNWord.Width, PNWord.Height, true);
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            PanelResize();
            //TxtCheck.Text = "Main:" + this.Width + "," + this.Height;
            //TxtCheck.Text += ",PNWorkd:" + PNWord.Width + "," + PNWord.Height;
            //TxtCheck.Text += ",SplitCtnWord:" + SplitCtnWord.Width + "," + SplitCtnWord.Height;
            //TxtCheck.Text += ",SplitCtnWork:" + SplitCtnWork.Width + "," + SplitCtnWork.Height;
            //TxtCheck.Text += ",SplitCtnListApp:" + SplitCtnListApp.Width + "," + SplitCtnListApp.Height;
            //TxtCheck.Text += ",SplitCtnList:" + SplitCtnList.Width + "," + SplitCtnList.Height;
            //TxtCheck.Text += ",SplitCtnLEft:" + SplitCtnLEft.Width + "," + SplitCtnLEft.Height;
            //TxtCheck.Text += ",Panel1:" + CTN.Panel1.Width + "," + CTN.Panel1.Height;
            //TxtCheck.Text += ",Panel2:" + CTN.Panel2.Width + "," + CTN.Panel2.Height;
            //TxtCheck.Text += ",CTN:" + CTN.Width + "," + CTN.Height;

        }

        private void PanelResize()
        {
            CTN.Panel1.Size = new Size(CTN.Panel1.Width, 50);
            //SplitCtnWork.Width = CTN.Panel2.Width;
            //SplitCtnWork.Height = CTN.Panel2.Height;
            //SplitCtnWork.Size = new Size(CTN.Panel2.Width, CTN.Panel2.Height);
            //SplitCtnLEft.Width = SplitCtnWork.Panel1.Width;
            //SplitCtnLEft.Height = SplitCtnWork.Panel1.Height;
            //SplitCtnList.Width = SplitCtnLEft.Panel2.Width;
            //SplitCtnList.Height = SplitCtnLEft.Panel2.Height;
            //SplitCtnListApp.Width = SplitCtnList.Panel1.Width;
            //SplitCtnListApp.Height = SplitCtnList.Panel1.Height;
            //SplitCtnWord.Width = SplitCtnWork.Panel2.Width;
            //SplitCtnWord.Height = SplitCtnWork.Panel2.Height;
        }

        private void CTN_Resize(object sender, EventArgs e)
        {
            //PanelResize();
        }

        private void WmPlayer_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            //string v_timespan;
            switch (e.newState)
            {
                //    case 0:    // Undefined

                //        loadingPlayer = false;
                //        break;
                case 1:    // Stopped
                    WordNonEdit();
                    break;
                case 2:    // Paused
                    WordNonEdit();
                    break;
                case 3:    // Playing
                    BT10X.Focus();
                    WordNonEdit();
                    break;
                //        WmPlayerTimer.Start();
                //    break;
                //        loadingPlayer = true;
                //        //WmPlayerTimer.Start();
                //        //v_timespan = WmPlayer.Ctlcontrols.currentPositionString;
                //        //if (v_timespan == "")
                //        //{ v_timespan = "00:00:00.0"; }
                //        //else
                //        //{ v_timespan = "00:" + v_timespan + ".0"; } 
                //        //P_TimePlay = TimeSpan.Parse(v_timespan);

                //        //WmplayerPlay10();
                //        break;

                case 4:    // ScanForward
                    WordNonEdit();
                    break;

                case 5:    // ScanReverse
                    WordNonEdit();
                    break;

                    //    case 6:    // Buffering
                    //        loadingPlayer = true;
                    //        break;

                    //    case 7:    // Waiting
                    //        loadingPlayer = false;
                    //        break;

                    //    case 8:    // MediaEnded
                    //        loadingPlayer = false;
                    //        break;

                    //    case 9:    // Transitioning
                    //        loadingPlayer = false;
                    //        break;

                    //    case 10:   // Ready
                    //        loadingPlayer = false;
                    //        break;

                    //    case 11:   // Reconnecting
                    //        loadingPlayer = false;
                    //        break;

                    //    case 12:   // Last
                    //        loadingPlayer = false;
                    //        break;

                    //    default:
                    //        loadingPlayer = false;
                    //        break;
            }
        }

        private void WmPlayer_Enter(object sender, EventArgs e)
        {

            this.Activate();
        }

        private void WmPlayerTimer_Tick(object sender, EventArgs e)
        {

            WordHighlight(appinfo, fileinfo);

        }

        private void WordHighlight(APPINFO appinfo, FILE_CONTENT files)
        {
            try
            {

                if ((ChkHighlight.Checked == true)
                    && ((WmPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying) || (WmPlayer.playState == WMPLib.WMPPlayState.wmppsScanForward))
                    //&& (WmPlayer.Ctlcontrols.currentPosition > LastUttStop)
                    && (WmPlayer.Ctlcontrols.currentPosition != LastUttStop)
                    )
                {


                    var content = files.transcription.Where(w => w.start <= WmPlayer.Ctlcontrols.currentPosition).Where(x => x.stop >= WmPlayer.Ctlcontrols.currentPosition);

                    if (content.Any())
                    {
                        v_bookmark = "P" + content.First().utt;
                        LastUtt = int.Parse(content.First().utt);
                        LastUttStart = content.First().start;
                        LastUttStop = content.First().stop;
                        try
                        {
                            if (WordApp.ActiveDocument.Bookmarks.Exists(v_bookmark) == true)
                            {
                                WordApp.Selection.GoTo(WdGoToItem.wdGoToBookmark, Name: v_bookmark);

                            }

                        }

                        catch (Exception e3)
                        {
                            handleException(e3.Message);
                        }

                    }
                    ForceForegroundWindow1(this.Handle, 1);

                }


            }
            catch (Exception e2)
            {

            }
        }


        private static void ForceForegroundWindow1(IntPtr hWnd, int Status)
        {

            int foreThread = GetWindowThreadProcessId(GetForegroundWindow(), IntPtr.Zero);

            int appThread = GetCurrentThreadId();

            int SW_SHOW = 5;
            if (Status == 0)
                SW_SHOW = 3;

            if (foreThread != appThread)
            {

                AttachThreadInput(foreThread, appThread, true);

                BringWindowToTop(hWnd);

                ShowWindow(hWnd, SW_SHOW);

                AttachThreadInput(foreThread, appThread, false);

            }

            else
            {

                BringWindowToTop(hWnd);

                ShowWindow(hWnd, SW_SHOW);

            }

        }

        private void WmPlayerTimer_Tick_1(object sender, EventArgs e)
        {

            WordHighlight(appinfo, fileinfo);
        }

        private void SplitWM_SizeChanged(object sender, EventArgs e)
        {

        }

        private void SplitCtnWork_SizeChanged(object sender, EventArgs e)
        {
        }

        private void SplitCtnLEft_SizeChanged(object sender, EventArgs e)
        {

            //SplitWM.Panel1.Size = new Size(SplitCtnLEft.Width, SplitCtnLEft.Height - 50);
            //SplitWM.Panel1.Size.Height = 50;
            SplitWM.Panel2.Size = new Size(SplitCtnLEft.Width, 80);
        }

        private void SplitCtnWord_Resize(object sender, EventArgs e)
        {
            GrpEdit.Location = new System.Drawing.Point((SplitCtnWord.Panel2.Width / 2) - (GrpEdit.Width / 2), GrpEdit.Location.Y);
            GrpAudit.Location = new System.Drawing.Point((SplitCtnWord.Panel2.Width / 2) - (GrpAudit.Width / 2), GrpAudit.Location.Y);
            GrpSum.Location = new System.Drawing.Point((SplitCtnWord.Panel2.Width / 2) - (GrpSum.Width / 2), GrpSum.Location.Y);
        }

        private void SplitWM_Resize(object sender, EventArgs e)
        {

            GrpWM.Location = new System.Drawing.Point((SplitWM.Panel2.Width / 2) - (GrpWM.Width / 2), GrpWM.Location.Y);
        }

        private void SplitCtnWork_Resize(object sender, EventArgs e)
        {
            //SplitCtnLEft.Panel1.Size = new Size(SplitCtnWork.Width, SplitCtnWork.Height / 2);
            //SplitCtnLEft.Panel2.Size = new Size(SplitCtnWork.Width, SplitCtnWork.Height / 2);
            SplitCtnLEft.Panel1.Size = new System.Drawing.Size(SplitCtnLEft.Width, SplitCtnWork.Height / 2);
            SplitCtnLEft.Panel2.Size = new System.Drawing.Size(SplitCtnLEft.Width, SplitCtnWork.Height / 2);
        }

        private void SplitCtnListApp_Resize(object sender, EventArgs e)
        {

            GrpList.Location = new System.Drawing.Point((SplitCtnListApp.Panel2.Width / 2) - (GrpList.Width / 2), GrpList.Location.Y);
        }

        private void BTEditSendReport_Click_1(object sender, EventArgs e)
        {
            SendReport();
        }
        private void SendReport()
        {

            //var resultBox = MessageBox.Show("ต้องการส่งรายงาน", "ส่งรายงาน", MessageBoxButtons.YesNo);
            //
            //var resultBox = NewConfirmBox.ShowDialog(this, "ยืนยันการส่งรายงาน", "ต้องการส่งรายงาน");
            var resultBox = NewMessageConfirm("ต้องการส่งรายงาน");
            if (resultBox == System.Windows.Forms.DialogResult.Yes)
            {
                WordSave(appinfo, fileinfo, "SEND");
                SubmitWebAPisStatus(appinfo);
                var exit = typeof(System.Windows.Forms.Application).GetMethod("ExitInternal",
                                                                    System.Reflection.BindingFlags.NonPublic |
                                                                    System.Reflection.BindingFlags.Static);
                exit.Invoke(null, null);
            }
        }
        private void RejectReport()
        {

            //var resultBox = MessageBox.Show("ไม่อนุมัติ", "ไม่อนุมัติ", MessageBoxButtons.YesNo);
            //var resultBox = NewConfirmBox.ShowDialog(this, "ยืนยันการไม่อนุมัติ", "ต้องการไม่อนุมัติ");
            var resultBox = NewMessageConfirm("ต้องการไม่อนุมัติ");
            if (resultBox == System.Windows.Forms.DialogResult.Yes)
            {
                WordDirty = false; //not check change
                SubmitRejectStatus(appinfo);
                //MessageBox.Show("ดำเนินการเสร็จเรียบร้อย");
                NewMessage("ดำเนินการเสร็จเรียบร้อย");
                var exit = typeof(System.Windows.Forms.Application).GetMethod("ExitInternal",
                                                                    System.Reflection.BindingFlags.NonPublic |
                                                                    System.Reflection.BindingFlags.Static);
                exit.Invoke(null, null);
            }
        }
        private void PNWord_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BTShowVersion_Click_1(object sender, EventArgs e)
        {
            ShowVersion();


        }

        private void ShowVersion()
        {
            try
            {
                object doNotSaveChanges = Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges;
                WordApp.Documents.Close(ref doNotSaveChanges, ref missing, ref missing);
                contentInfo.data[0].version = int.Parse(CBVersion.SelectedItem.ToString());
                RequestFileInfo(appinfo, ref fileinfo);
                OpenWord(appinfo, fileinfo);
            }
            catch (Exception e2)
            {
                startForm.Hide();
                handleException(System.Reflection.MethodBase.GetCurrentMethod().Name + ":" + e2.Message);
            }
            //RequestVideoInfo(appinfo, room, ref video);
            //OpenWord(appinfo, room, ref video);
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (WordActive == true && (WordDirty == true || appinfo.mode != "view"))
            {
                ////CheckDataChange(appinfo, fileinfo);
            }
            object doNotSaveChanges = Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges;
            try
            {
                if (WordApp.Options.SaveInterval == 10)
                {
                    WordApp.Options.SaveInterval = 0;
                }

                WordApp.Documents.Close(ref doNotSaveChanges, ref missing, ref missing);
                WordApp.Quit();

                foreach (Process pList in Process.GetProcesses())
                {
                    if (pList.MainWindowTitle.Contains(WordFileNoExt))
                    {
                        pList.Kill();
                        break;
                    }
                }

            }
            catch (Exception e2)
            {
                if (proc_cnt == 1)
                {
                    foreach (Process proc in Process.GetProcessesByName("WINWORD"))
                    {
                        proc.Kill();
                    }
                }

            }
        }
        private void NewMessage(string message)
        {
            FlexibleMessageBox.Show(message);


            //    NewMessageBox msgResized = new NewMessageBox("", message);
            //msgResized.StartPosition = FormStartPosition.CenterScreen;
            ////msgResized.Show();
            //msgResized.ShowDialog();
        }
        private DialogResult NewMessageConfirm(string message)
        {
            //FlexibleMessageBox.Show(message);

            return FlexibleMessageBox.Show(message, this.Text, MessageBoxButtons.YesNo);
            //    NewMessageBox msgResized = new NewMessageBox("", message);
            //msgResized.StartPosition = FormStartPosition.CenterScreen;
            ////msgResized.Show();
            //msgResized.ShowDialog();
        }
        private void SearchText()
        {
            Thread thread = new Thread(() =>
            {

                string textin;
                string textout = "";
                textin = WordApp.Selection.Text;
                if ((appinfo.mode == "view") || (appinfo.mode == "sum"))
                {

                }
                else
                {

                    SearchBox msgResized = new SearchBox(textin, suggestinfo);
                    if (msgResized.IsAccessible == false)
                    {


                        msgResized.StartPosition = FormStartPosition.CenterScreen;
                        msgResized.ShowDialog();

                        if (msgResized.result_search != "")
                        {
                            WordApp.Selection.Text = msgResized.result_search;

                        }
                    }
                }
            });
            thread.Start();
            thread.Join();




        }
        private void CheckDataChange(APPINFO appinfo, FILE_CONTENT files)
        {
            string V_WordText = "";
            string vBookmark = "";
            string last_result = "";
            string last_utt = "";
            int oStart;
            int oEnd;
            try
            {
                object rng = WordApp.Selection.Range;
                if (WordAllowEdit)
                {
                    WordChang = false;

                    foreach (TRANSCRIPTION transcription in files.transcription)
                    {
                        vBookmark = "P" + transcription.utt;
                        WordApp.Selection.GoTo(WdGoToItem.wdGoToBookmark, Name: vBookmark);
                        V_WordText = WordApp.Selection.Text;
                        last_result = transcription.text;
                        last_utt = transcription.utt;

                        V_WordText = V_WordText.Replace("\b", ""); //Backspace(ascii code 08)
                        V_WordText = V_WordText.Replace("\r", ""); //Carriage return
                        V_WordText = V_WordText.Replace("\f", ""); //Form feed(ascii code 0C)
                        V_WordText = V_WordText.Replace("\n", ""); //New line
                        V_WordText = V_WordText.Replace("\t", ""); //Tab
                        V_WordText = V_WordText.Replace("\"", ""); //Double quote
                        V_WordText = V_WordText.Replace("\\", ""); //Backslash
                        V_WordText = V_WordText.Replace(System.Environment.NewLine, "");

                        if (V_WordText != transcription.text)
                        {
                            transcription.text = V_WordText;

                            WordChang = true;
                        }
                    }


                    // Check user insert over bookmark
                    oStart = WordApp.Selection.Start;
                    oEnd = WordApp.Selection.StoryLength;
                    rng = WordApp.ActiveDocument.Range(oStart, oEnd);
                    WordApp.Selection.Bookmarks.Add(vBookmark, rng);
                    WordApp.Selection.GoTo(WdGoToItem.wdGoToBookmark, Name: vBookmark);
                    if (V_WordText != WordApp.Selection.Text)

                    //if (WordApp.Selection.End != oEnd - 1)
                    {

                        V_WordText = WordApp.Selection.Text;

                        V_WordText = V_WordText.Replace("\b", ""); //Backspace(ascii code 08)
                        V_WordText = V_WordText.Replace("\r", ""); //Carriage return
                        V_WordText = V_WordText.Replace("\f", ""); //Form feed(ascii code 0C)
                        V_WordText = V_WordText.Replace("\n", ""); //New line
                        V_WordText = V_WordText.Replace("\t", ""); //Tab
                        V_WordText = V_WordText.Replace("\"", ""); //Double quote
                        V_WordText = V_WordText.Replace("\\", ""); //Backslash
                        V_WordText = V_WordText.Replace(System.Environment.NewLine, "");

                        var content = files.transcription.Where(w => w.utt == last_utt);
                        content.First().text = V_WordText;
                    }

                    if (WordChang)
                    {
                        //DialogResult dialogResult = MessageBox.Show("ต้องการบันทึกข้อมูลที่แก้ไข", "ยืนยันการแก้ไข", MessageBoxButtons.YesNo);
                        //DialogResult dialogResult = NewConfirmBox.ShowDialog(this,"ต้องการบันทึกข้อมูลที่แก้ไข", "ยืนยันการแก้ไข");
                        var dialogResult = NewMessageConfirm("ยืนยันการแก้ไข");
                        //var resultBox = NewConfirmBox.ShowDialog(this, "ยืนยันการไม่อนุมัติ", "ต้องการไม่อนุมัติ");
                        if (dialogResult == DialogResult.Yes)
                        {
                            WordApp.ActiveDocument.Save(); //save old version
                            LastVersion++;
                            TxtRoomVersion.Text = contentInfo.data[0].process + "." + LastVersion.ToString();
                            //fileName = WorkPath + appinfo.part.ToString("00000") + "-" + LastVersion.ToString() + ".docx";
                            //WordFileName = appinfo.part.ToString("00000") + "-" + LastVersion.ToString() + ".docx";
                            fileName = WorkPath + WordFileName;

                            WordApp.ActiveDocument.SaveAs2(WorkPath + WordFileName, WdSaveFormat.wdFormatDocumentDefault); //save old version
                            int vMessageVersion = LastVersion;
                            UpdateToServer(vMessageVersion);
                            UploadToServerPost();
                        }



                    }
                    //else
                    //{
                    //    MessageBox.Show("ไม่มีการเปลี่ยนแปลงข้อความ");
                    //}
                }
            }
            catch (Exception e)
            {
                //MessageBox.Show(System.Reflection.MethodBase.GetCurrentMethod().Name + ":" + e.Message);
            }
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            startForm.Hide();
            //TopMost = false;
            //tSplashScreen.Abort();
            TopMost = true;
            Thread.Sleep(500);
            TopMost = false;
            this.Show();
        }
        public void StartForm()
        {
            SplashScreen splashScreen = new SplashScreen();
            System.Windows.Forms.Application.Run(splashScreen);
            splashScreen.Show();
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            startForm.Close();
        }

        private void handleException(String msg)
        {
            TopMost = false;
            startForm.TopMost = false;
            MessageBox.Show(msg);
            //System.Environment.Exit(1);
        }
    }
}