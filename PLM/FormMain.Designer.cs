
using System.Windows.Forms;

namespace PLM
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.CTN = new System.Windows.Forms.SplitContainer();
            this.TxtRoomTime = new System.Windows.Forms.TextBox();
            this.TxtRoomVersion = new System.Windows.Forms.TextBox();
            this.LbTop = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtRoomSection = new System.Windows.Forms.TextBox();
            this.TxtRoomType = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtRoomStatus = new System.Windows.Forms.TextBox();
            this.TxtRoomGroup = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtRoomNo = new System.Windows.Forms.TextBox();
            this.TxtRoomPart = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtRoomPeriod = new System.Windows.Forms.TextBox();
            this.TxtRoomYear = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SplitCtnWork = new System.Windows.Forms.SplitContainer();
            this.SplitCtnLEft = new System.Windows.Forms.SplitContainer();
            this.SplitWM = new System.Windows.Forms.SplitContainer();
            this.ScreenShot = new System.Windows.Forms.PictureBox();
            this.GrpWM = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.TxtRewTime = new System.Windows.Forms.TextBox();
            this.ChkHighlight = new System.Windows.Forms.CheckBox();
            this.SplitCtnList = new System.Windows.Forms.SplitContainer();
            this.SplitCtnListApp = new System.Windows.Forms.SplitContainer();
            this.GrpList = new System.Windows.Forms.GroupBox();
            this.CBVersion = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.GRPsumList = new System.Windows.Forms.GroupBox();
            this.LVPart = new System.Windows.Forms.ListView();
            this.SplitCtnWord = new System.Windows.Forms.SplitContainer();
            this.PNWord = new System.Windows.Forms.Panel();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StripProgressStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.StripProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.GrpSum = new System.Windows.Forms.GroupBox();
            this.GrpAudit = new System.Windows.Forms.GroupBox();
            this.GrpEdit = new System.Windows.Forms.GroupBox();
            this.TxtLog = new System.Windows.Forms.TextBox();
            this.WmPlayerTimer = new System.Windows.Forms.Timer(this.components);
            this.WmPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.BT40X = new PLM.RJControls.RJButton();
            this.BT20X = new PLM.RJControls.RJButton();
            this.BT10X = new PLM.RJControls.RJButton();
            this.BT05X = new PLM.RJControls.RJButton();
            this.BTShowVersion = new PLM.RJControls.RJButton();
            this.BTSumShow = new PLM.RJControls.RJButton();
            this.BTSumRefresh = new PLM.RJControls.RJButton();
            this.BTsumApprove = new PLM.RJControls.RJButton();
            this.BTsumSave = new PLM.RJControls.RJButton();
            this.BTauditNoApprove = new PLM.RJControls.RJButton();
            this.BTauditApprove = new PLM.RJControls.RJButton();
            this.BTauditSave = new PLM.RJControls.RJButton();
            this.BTEditSendReport = new PLM.RJControls.RJButton();
            this.BTEditSaveDB = new PLM.RJControls.RJButton();
            ((System.ComponentModel.ISupportInitialize)(this.CTN)).BeginInit();
            this.CTN.Panel1.SuspendLayout();
            this.CTN.Panel2.SuspendLayout();
            this.CTN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitCtnWork)).BeginInit();
            this.SplitCtnWork.Panel1.SuspendLayout();
            this.SplitCtnWork.Panel2.SuspendLayout();
            this.SplitCtnWork.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitCtnLEft)).BeginInit();
            this.SplitCtnLEft.Panel1.SuspendLayout();
            this.SplitCtnLEft.Panel2.SuspendLayout();
            this.SplitCtnLEft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitWM)).BeginInit();
            this.SplitWM.Panel1.SuspendLayout();
            this.SplitWM.Panel2.SuspendLayout();
            this.SplitWM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScreenShot)).BeginInit();
            this.GrpWM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitCtnList)).BeginInit();
            this.SplitCtnList.Panel1.SuspendLayout();
            this.SplitCtnList.Panel2.SuspendLayout();
            this.SplitCtnList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitCtnListApp)).BeginInit();
            this.SplitCtnListApp.Panel1.SuspendLayout();
            this.SplitCtnListApp.Panel2.SuspendLayout();
            this.SplitCtnListApp.SuspendLayout();
            this.GrpList.SuspendLayout();
            this.GRPsumList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitCtnWord)).BeginInit();
            this.SplitCtnWord.Panel1.SuspendLayout();
            this.SplitCtnWord.Panel2.SuspendLayout();
            this.SplitCtnWord.SuspendLayout();
            this.StatusStrip.SuspendLayout();
            this.GrpSum.SuspendLayout();
            this.GrpAudit.SuspendLayout();
            this.GrpEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WmPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // CTN
            // 
            this.CTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CTN.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.CTN.IsSplitterFixed = true;
            this.CTN.Location = new System.Drawing.Point(0, 0);
            this.CTN.Name = "CTN";
            this.CTN.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // CTN.Panel1
            // 
            this.CTN.Panel1.AutoScroll = true;
            this.CTN.Panel1.BackColor = System.Drawing.Color.Brown;
            this.CTN.Panel1.Controls.Add(this.TxtRoomTime);
            this.CTN.Panel1.Controls.Add(this.TxtRoomVersion);
            this.CTN.Panel1.Controls.Add(this.LbTop);
            this.CTN.Panel1.Controls.Add(this.label8);
            this.CTN.Panel1.Controls.Add(this.TxtRoomSection);
            this.CTN.Panel1.Controls.Add(this.TxtRoomType);
            this.CTN.Panel1.Controls.Add(this.label1);
            this.CTN.Panel1.Controls.Add(this.label9);
            this.CTN.Panel1.Controls.Add(this.label3);
            this.CTN.Panel1.Controls.Add(this.TxtRoomStatus);
            this.CTN.Panel1.Controls.Add(this.TxtRoomGroup);
            this.CTN.Panel1.Controls.Add(this.label6);
            this.CTN.Panel1.Controls.Add(this.label2);
            this.CTN.Panel1.Controls.Add(this.TxtRoomNo);
            this.CTN.Panel1.Controls.Add(this.TxtRoomPart);
            this.CTN.Panel1.Controls.Add(this.label7);
            this.CTN.Panel1.Controls.Add(this.label5);
            this.CTN.Panel1.Controls.Add(this.TxtRoomPeriod);
            this.CTN.Panel1.Controls.Add(this.TxtRoomYear);
            this.CTN.Panel1.Controls.Add(this.label4);
            this.CTN.Panel1MinSize = 50;
            // 
            // CTN.Panel2
            // 
            this.CTN.Panel2.Controls.Add(this.SplitCtnWork);
            this.CTN.Panel2MinSize = 0;
            this.CTN.Size = new System.Drawing.Size(1264, 761);
            this.CTN.SplitterWidth = 3;
            this.CTN.TabIndex = 0;
            this.CTN.TabStop = false;
            this.CTN.Resize += new System.EventHandler(this.CTN_Resize);
            // 
            // TxtRoomTime
            // 
            this.TxtRoomTime.BackColor = System.Drawing.Color.Brown;
            this.TxtRoomTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtRoomTime.Font = new System.Drawing.Font("Kanit", 9.75F);
            this.TxtRoomTime.ForeColor = System.Drawing.Color.White;
            this.TxtRoomTime.Location = new System.Drawing.Point(117, 19);
            this.TxtRoomTime.Name = "TxtRoomTime";
            this.TxtRoomTime.ReadOnly = true;
            this.TxtRoomTime.Size = new System.Drawing.Size(194, 20);
            this.TxtRoomTime.TabIndex = 23;
            this.TxtRoomTime.TabStop = false;
            this.TxtRoomTime.Text = "Room.Time";
            // 
            // TxtRoomVersion
            // 
            this.TxtRoomVersion.BackColor = System.Drawing.Color.Brown;
            this.TxtRoomVersion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtRoomVersion.Font = new System.Drawing.Font("Kanit", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtRoomVersion.ForeColor = System.Drawing.Color.White;
            this.TxtRoomVersion.Location = new System.Drawing.Point(1061, 20);
            this.TxtRoomVersion.Name = "TxtRoomVersion";
            this.TxtRoomVersion.ReadOnly = true;
            this.TxtRoomVersion.Size = new System.Drawing.Size(198, 20);
            this.TxtRoomVersion.TabIndex = 39;
            this.TxtRoomVersion.TabStop = false;
            this.TxtRoomVersion.Text = "Room.Version";
            // 
            // LbTop
            // 
            this.LbTop.AutoSize = true;
            this.LbTop.Font = new System.Drawing.Font("Kanit", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbTop.ForeColor = System.Drawing.Color.White;
            this.LbTop.Location = new System.Drawing.Point(5, 0);
            this.LbTop.Name = "LbTop";
            this.LbTop.Size = new System.Drawing.Size(111, 20);
            this.LbTop.TabIndex = 20;
            this.LbTop.Text = "ประเภทการประชุม :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Kanit", 9.75F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(998, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 20);
            this.label8.TabIndex = 38;
            this.label8.Text = "เวอร์ชั่น :";
            // 
            // TxtRoomSection
            // 
            this.TxtRoomSection.BackColor = System.Drawing.Color.Brown;
            this.TxtRoomSection.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtRoomSection.Font = new System.Drawing.Font("Kanit", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtRoomSection.ForeColor = System.Drawing.Color.White;
            this.TxtRoomSection.Location = new System.Drawing.Point(116, 0);
            this.TxtRoomSection.Name = "TxtRoomSection";
            this.TxtRoomSection.ReadOnly = true;
            this.TxtRoomSection.Size = new System.Drawing.Size(195, 20);
            this.TxtRoomSection.TabIndex = 21;
            this.TxtRoomSection.TabStop = false;
            this.TxtRoomSection.Text = "Room.Section";
            // 
            // TxtRoomType
            // 
            this.TxtRoomType.BackColor = System.Drawing.Color.Brown;
            this.TxtRoomType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtRoomType.Font = new System.Drawing.Font("Kanit", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtRoomType.ForeColor = System.Drawing.Color.White;
            this.TxtRoomType.Location = new System.Drawing.Point(1061, 0);
            this.TxtRoomType.Name = "TxtRoomType";
            this.TxtRoomType.ReadOnly = true;
            this.TxtRoomType.Size = new System.Drawing.Size(179, 20);
            this.TxtRoomType.TabIndex = 37;
            this.TxtRoomType.TabStop = false;
            this.TxtRoomType.Text = "Room.Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Kanit", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(78, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 20);
            this.label1.TabIndex = 22;
            this.label1.Text = "วันที่ :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Kanit", 9.75F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(1016, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 20);
            this.label9.TabIndex = 36;
            this.label9.Text = "สมัย :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Kanit", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(318, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 20);
            this.label3.TabIndex = 24;
            this.label3.Text = "ชุดที่ :";
            // 
            // TxtRoomStatus
            // 
            this.TxtRoomStatus.BackColor = System.Drawing.Color.Brown;
            this.TxtRoomStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtRoomStatus.Font = new System.Drawing.Font("Kanit", 9.75F);
            this.TxtRoomStatus.ForeColor = System.Drawing.Color.White;
            this.TxtRoomStatus.Location = new System.Drawing.Point(817, 19);
            this.TxtRoomStatus.Name = "TxtRoomStatus";
            this.TxtRoomStatus.ReadOnly = true;
            this.TxtRoomStatus.Size = new System.Drawing.Size(207, 20);
            this.TxtRoomStatus.TabIndex = 35;
            this.TxtRoomStatus.TabStop = false;
            this.TxtRoomStatus.Text = "Room.Status";
            // 
            // TxtRoomGroup
            // 
            this.TxtRoomGroup.BackColor = System.Drawing.Color.Brown;
            this.TxtRoomGroup.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtRoomGroup.Font = new System.Drawing.Font("Kanit", 9.75F);
            this.TxtRoomGroup.ForeColor = System.Drawing.Color.White;
            this.TxtRoomGroup.Location = new System.Drawing.Point(360, 0);
            this.TxtRoomGroup.Name = "TxtRoomGroup";
            this.TxtRoomGroup.ReadOnly = true;
            this.TxtRoomGroup.Size = new System.Drawing.Size(145, 20);
            this.TxtRoomGroup.TabIndex = 25;
            this.TxtRoomGroup.TabStop = false;
            this.TxtRoomGroup.Text = "Room.Group";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Kanit", 9.75F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(769, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 20);
            this.label6.TabIndex = 34;
            this.label6.Text = "สถานะ :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Kanit", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(312, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 26;
            this.label2.Text = "ตอนที่ :";
            // 
            // TxtRoomNo
            // 
            this.TxtRoomNo.BackColor = System.Drawing.Color.Brown;
            this.TxtRoomNo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtRoomNo.Font = new System.Drawing.Font("Kanit", 9.75F);
            this.TxtRoomNo.ForeColor = System.Drawing.Color.White;
            this.TxtRoomNo.Location = new System.Drawing.Point(817, 0);
            this.TxtRoomNo.Name = "TxtRoomNo";
            this.TxtRoomNo.ReadOnly = true;
            this.TxtRoomNo.Size = new System.Drawing.Size(207, 20);
            this.TxtRoomNo.TabIndex = 33;
            this.TxtRoomNo.TabStop = false;
            this.TxtRoomNo.Text = "Room.No";
            // 
            // TxtRoomPart
            // 
            this.TxtRoomPart.BackColor = System.Drawing.Color.Brown;
            this.TxtRoomPart.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtRoomPart.Font = new System.Drawing.Font("Kanit", 9.75F);
            this.TxtRoomPart.ForeColor = System.Drawing.Color.White;
            this.TxtRoomPart.Location = new System.Drawing.Point(360, 19);
            this.TxtRoomPart.Name = "TxtRoomPart";
            this.TxtRoomPart.ReadOnly = true;
            this.TxtRoomPart.Size = new System.Drawing.Size(145, 20);
            this.TxtRoomPart.TabIndex = 27;
            this.TxtRoomPart.TabStop = false;
            this.TxtRoomPart.Text = "Room.Part";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Kanit", 9.75F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(772, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 20);
            this.label7.TabIndex = 32;
            this.label7.Text = "ครั้งที่ :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Kanit", 9.75F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(540, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 20);
            this.label5.TabIndex = 28;
            this.label5.Text = "ปีที่ :";
            // 
            // TxtRoomPeriod
            // 
            this.TxtRoomPeriod.BackColor = System.Drawing.Color.Brown;
            this.TxtRoomPeriod.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtRoomPeriod.Font = new System.Drawing.Font("Kanit", 9.75F);
            this.TxtRoomPeriod.ForeColor = System.Drawing.Color.White;
            this.TxtRoomPeriod.Location = new System.Drawing.Point(571, 19);
            this.TxtRoomPeriod.Name = "TxtRoomPeriod";
            this.TxtRoomPeriod.ReadOnly = true;
            this.TxtRoomPeriod.Size = new System.Drawing.Size(247, 20);
            this.TxtRoomPeriod.TabIndex = 31;
            this.TxtRoomPeriod.TabStop = false;
            this.TxtRoomPeriod.Text = "Room.Period";
            // 
            // TxtRoomYear
            // 
            this.TxtRoomYear.BackColor = System.Drawing.Color.Brown;
            this.TxtRoomYear.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtRoomYear.Font = new System.Drawing.Font("Kanit", 9.75F);
            this.TxtRoomYear.ForeColor = System.Drawing.Color.White;
            this.TxtRoomYear.Location = new System.Drawing.Point(571, 0);
            this.TxtRoomYear.Name = "TxtRoomYear";
            this.TxtRoomYear.ReadOnly = true;
            this.TxtRoomYear.Size = new System.Drawing.Size(247, 20);
            this.TxtRoomYear.TabIndex = 29;
            this.TxtRoomYear.TabStop = false;
            this.TxtRoomYear.Text = "Room.Year";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Kanit", 9.75F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(531, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 20);
            this.label4.TabIndex = 30;
            this.label4.Text = "เวลา :";
            // 
            // SplitCtnWork
            // 
            this.SplitCtnWork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitCtnWork.Location = new System.Drawing.Point(0, 0);
            this.SplitCtnWork.Name = "SplitCtnWork";
            // 
            // SplitCtnWork.Panel1
            // 
            this.SplitCtnWork.Panel1.Controls.Add(this.SplitCtnLEft);
            // 
            // SplitCtnWork.Panel2
            // 
            this.SplitCtnWork.Panel2.Controls.Add(this.SplitCtnWord);
            this.SplitCtnWork.Size = new System.Drawing.Size(1264, 708);
            this.SplitCtnWork.SplitterDistance = 279;
            this.SplitCtnWork.SplitterWidth = 3;
            this.SplitCtnWork.TabIndex = 1;
            this.SplitCtnWork.TabStop = false;
            this.SplitCtnWork.SizeChanged += new System.EventHandler(this.SplitCtnWork_SizeChanged);
            this.SplitCtnWork.Resize += new System.EventHandler(this.SplitCtnWork_Resize);
            // 
            // SplitCtnLEft
            // 
            this.SplitCtnLEft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitCtnLEft.Location = new System.Drawing.Point(0, 0);
            this.SplitCtnLEft.Name = "SplitCtnLEft";
            this.SplitCtnLEft.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitCtnLEft.Panel1
            // 
            this.SplitCtnLEft.Panel1.Controls.Add(this.SplitWM);
            this.SplitCtnLEft.Panel1MinSize = 330;
            // 
            // SplitCtnLEft.Panel2
            // 
            this.SplitCtnLEft.Panel2.Controls.Add(this.SplitCtnList);
            this.SplitCtnLEft.Size = new System.Drawing.Size(279, 708);
            this.SplitCtnLEft.SplitterDistance = 360;
            this.SplitCtnLEft.SplitterWidth = 3;
            this.SplitCtnLEft.TabIndex = 0;
            this.SplitCtnLEft.TabStop = false;
            this.SplitCtnLEft.SizeChanged += new System.EventHandler(this.SplitCtnLEft_SizeChanged);
            // 
            // SplitWM
            // 
            this.SplitWM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitWM.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.SplitWM.IsSplitterFixed = true;
            this.SplitWM.Location = new System.Drawing.Point(0, 0);
            this.SplitWM.Name = "SplitWM";
            this.SplitWM.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitWM.Panel1
            // 
            this.SplitWM.Panel1.Controls.Add(this.ScreenShot);
            this.SplitWM.Panel1.Controls.Add(this.WmPlayer);
            this.SplitWM.Panel1MinSize = 220;
            // 
            // SplitWM.Panel2
            // 
            this.SplitWM.Panel2.Controls.Add(this.GrpWM);
            this.SplitWM.Panel2MinSize = 100;
            this.SplitWM.Size = new System.Drawing.Size(279, 360);
            this.SplitWM.SplitterDistance = 257;
            this.SplitWM.SplitterWidth = 3;
            this.SplitWM.TabIndex = 0;
            this.SplitWM.TabStop = false;
            this.SplitWM.SizeChanged += new System.EventHandler(this.SplitWM_SizeChanged);
            this.SplitWM.Resize += new System.EventHandler(this.SplitWM_Resize);
            // 
            // ScreenShot
            // 
            this.ScreenShot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScreenShot.Image = ((System.Drawing.Image)(resources.GetObject("ScreenShot.Image")));
            this.ScreenShot.InitialImage = ((System.Drawing.Image)(resources.GetObject("ScreenShot.InitialImage")));
            this.ScreenShot.Location = new System.Drawing.Point(0, 0);
            this.ScreenShot.Name = "ScreenShot";
            this.ScreenShot.Size = new System.Drawing.Size(279, 257);
            this.ScreenShot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ScreenShot.TabIndex = 2;
            this.ScreenShot.TabStop = false;
            // 
            // GrpWM
            // 
            this.GrpWM.AutoSize = true;
            this.GrpWM.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GrpWM.BackColor = System.Drawing.SystemColors.Control;
            this.GrpWM.Controls.Add(this.BT40X);
            this.GrpWM.Controls.Add(this.label10);
            this.GrpWM.Controls.Add(this.BT20X);
            this.GrpWM.Controls.Add(this.label12);
            this.GrpWM.Controls.Add(this.BT10X);
            this.GrpWM.Controls.Add(this.label11);
            this.GrpWM.Controls.Add(this.BT05X);
            this.GrpWM.Controls.Add(this.TxtRewTime);
            this.GrpWM.Controls.Add(this.ChkHighlight);
            this.GrpWM.Location = new System.Drawing.Point(3, 3);
            this.GrpWM.Name = "GrpWM";
            this.GrpWM.Size = new System.Drawing.Size(273, 96);
            this.GrpWM.TabIndex = 8;
            this.GrpWM.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Kanit", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(11, 46);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 20);
            this.label10.TabIndex = 9;
            this.label10.Text = "ความเร็ว";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Kanit", 8.25F);
            this.label12.Location = new System.Drawing.Point(121, 17);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 17);
            this.label12.TabIndex = 11;
            this.label12.Text = "ย้อนกลับ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Kanit", 8.25F);
            this.label11.Location = new System.Drawing.Point(224, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 17);
            this.label11.TabIndex = 10;
            this.label11.Text = "วินาที";
            // 
            // TxtRewTime
            // 
            this.TxtRewTime.Location = new System.Drawing.Point(175, 14);
            this.TxtRewTime.Name = "TxtRewTime";
            this.TxtRewTime.Size = new System.Drawing.Size(42, 20);
            this.TxtRewTime.TabIndex = 9;
            this.TxtRewTime.TabStop = false;
            // 
            // ChkHighlight
            // 
            this.ChkHighlight.AutoSize = true;
            this.ChkHighlight.BackColor = System.Drawing.SystemColors.Control;
            this.ChkHighlight.Font = new System.Drawing.Font("Kanit", 8.25F);
            this.ChkHighlight.Location = new System.Drawing.Point(10, 14);
            this.ChkHighlight.Name = "ChkHighlight";
            this.ChkHighlight.Size = new System.Drawing.Size(80, 21);
            this.ChkHighlight.TabIndex = 8;
            this.ChkHighlight.Text = "เน้นข้อความ";
            this.ChkHighlight.UseVisualStyleBackColor = false;
            this.ChkHighlight.CheckedChanged += new System.EventHandler(this.ChkHighlight_CheckedChanged);
            // 
            // SplitCtnList
            // 
            this.SplitCtnList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitCtnList.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.SplitCtnList.Location = new System.Drawing.Point(0, 0);
            this.SplitCtnList.Name = "SplitCtnList";
            this.SplitCtnList.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitCtnList.Panel1
            // 
            this.SplitCtnList.Panel1.BackColor = System.Drawing.Color.White;
            this.SplitCtnList.Panel1.Controls.Add(this.SplitCtnListApp);
            this.SplitCtnList.Panel1MinSize = 0;
            // 
            // SplitCtnList.Panel2
            // 
            this.SplitCtnList.Panel2.Controls.Add(this.BTSumShow);
            this.SplitCtnList.Panel2.Controls.Add(this.BTSumRefresh);
            this.SplitCtnList.Panel2MinSize = 40;
            this.SplitCtnList.Size = new System.Drawing.Size(279, 345);
            this.SplitCtnList.SplitterDistance = 298;
            this.SplitCtnList.SplitterWidth = 3;
            this.SplitCtnList.TabIndex = 0;
            this.SplitCtnList.TabStop = false;
            // 
            // SplitCtnListApp
            // 
            this.SplitCtnListApp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitCtnListApp.Location = new System.Drawing.Point(0, 0);
            this.SplitCtnListApp.Name = "SplitCtnListApp";
            this.SplitCtnListApp.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitCtnListApp.Panel1
            // 
            this.SplitCtnListApp.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.SplitCtnListApp.Panel1.Controls.Add(this.GrpList);
            this.SplitCtnListApp.Panel1MinSize = 50;
            // 
            // SplitCtnListApp.Panel2
            // 
            this.SplitCtnListApp.Panel2.Controls.Add(this.GRPsumList);
            this.SplitCtnListApp.Panel2MinSize = 0;
            this.SplitCtnListApp.Size = new System.Drawing.Size(279, 298);
            this.SplitCtnListApp.SplitterDistance = 51;
            this.SplitCtnListApp.SplitterWidth = 3;
            this.SplitCtnListApp.TabIndex = 0;
            this.SplitCtnListApp.TabStop = false;
            this.SplitCtnListApp.Resize += new System.EventHandler(this.SplitCtnListApp_Resize);
            // 
            // GrpList
            // 
            this.GrpList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GrpList.Controls.Add(this.CBVersion);
            this.GrpList.Controls.Add(this.BTShowVersion);
            this.GrpList.Controls.Add(this.label13);
            this.GrpList.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.GrpList.Location = new System.Drawing.Point(3, 3);
            this.GrpList.Name = "GrpList";
            this.GrpList.Size = new System.Drawing.Size(273, 50);
            this.GrpList.TabIndex = 11;
            this.GrpList.TabStop = false;
            // 
            // CBVersion
            // 
            this.CBVersion.FormattingEnabled = true;
            this.CBVersion.Location = new System.Drawing.Point(65, 17);
            this.CBVersion.Name = "CBVersion";
            this.CBVersion.Size = new System.Drawing.Size(82, 21);
            this.CBVersion.TabIndex = 13;
            this.CBVersion.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Kanit", 9.75F);
            this.label13.ForeColor = System.Drawing.Color.Transparent;
            this.label13.Location = new System.Drawing.Point(11, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 20);
            this.label13.TabIndex = 11;
            this.label13.Text = "เวอร์ชั่น";
            // 
            // GRPsumList
            // 
            this.GRPsumList.Controls.Add(this.LVPart);
            this.GRPsumList.Font = new System.Drawing.Font("Kanit", 8.25F);
            this.GRPsumList.Location = new System.Drawing.Point(0, -1);
            this.GRPsumList.Name = "GRPsumList";
            this.GRPsumList.Size = new System.Drawing.Size(279, 243);
            this.GRPsumList.TabIndex = 1;
            this.GRPsumList.TabStop = false;
            this.GRPsumList.Text = "รายงานการประชุมทั้งหมด";
            // 
            // LVPart
            // 
            this.LVPart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LVPart.HideSelection = false;
            this.LVPart.Location = new System.Drawing.Point(3, 20);
            this.LVPart.Name = "LVPart";
            this.LVPart.Size = new System.Drawing.Size(273, 220);
            this.LVPart.TabIndex = 0;
            this.LVPart.TabStop = false;
            this.LVPart.UseCompatibleStateImageBehavior = false;
            // 
            // SplitCtnWord
            // 
            this.SplitCtnWord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitCtnWord.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.SplitCtnWord.IsSplitterFixed = true;
            this.SplitCtnWord.Location = new System.Drawing.Point(0, 0);
            this.SplitCtnWord.Name = "SplitCtnWord";
            this.SplitCtnWord.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitCtnWord.Panel1
            // 
            this.SplitCtnWord.Panel1.Controls.Add(this.PNWord);
            this.SplitCtnWord.Panel1MinSize = 0;
            // 
            // SplitCtnWord.Panel2
            // 
            this.SplitCtnWord.Panel2.Controls.Add(this.StatusStrip);
            this.SplitCtnWord.Panel2.Controls.Add(this.GrpSum);
            this.SplitCtnWord.Panel2.Controls.Add(this.GrpAudit);
            this.SplitCtnWord.Panel2.Controls.Add(this.GrpEdit);
            this.SplitCtnWord.Size = new System.Drawing.Size(982, 708);
            this.SplitCtnWord.SplitterDistance = 661;
            this.SplitCtnWord.SplitterWidth = 3;
            this.SplitCtnWord.TabIndex = 0;
            this.SplitCtnWord.TabStop = false;
            this.SplitCtnWord.Resize += new System.EventHandler(this.SplitCtnWord_Resize);
            // 
            // PNWord
            // 
            this.PNWord.AutoSize = true;
            this.PNWord.BackColor = System.Drawing.Color.White;
            this.PNWord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PNWord.Location = new System.Drawing.Point(0, 0);
            this.PNWord.Name = "PNWord";
            this.PNWord.Size = new System.Drawing.Size(982, 661);
            this.PNWord.TabIndex = 1;
            this.PNWord.TabStop = true;
            this.PNWord.Paint += new System.Windows.Forms.PaintEventHandler(this.PNWord_Paint);
            this.PNWord.Resize += new System.EventHandler(this.PNWord_Resize);
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.StripProgressStatus,
            this.StripProgress});
            this.StatusStrip.Location = new System.Drawing.Point(0, 26);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(982, 22);
            this.StatusStrip.TabIndex = 18;
            this.StatusStrip.Visible = false;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // StripProgressStatus
            // 
            this.StripProgressStatus.Name = "StripProgressStatus";
            this.StripProgressStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // StripProgress
            // 
            this.StripProgress.Name = "StripProgress";
            this.StripProgress.Size = new System.Drawing.Size(100, 16);
            // 
            // GrpSum
            // 
            this.GrpSum.BackColor = System.Drawing.SystemColors.Control;
            this.GrpSum.Controls.Add(this.BTsumApprove);
            this.GrpSum.Controls.Add(this.BTsumSave);
            this.GrpSum.Location = new System.Drawing.Point(705, 7);
            this.GrpSum.Name = "GrpSum";
            this.GrpSum.Size = new System.Drawing.Size(274, 32);
            this.GrpSum.TabIndex = 13;
            this.GrpSum.TabStop = false;
            this.GrpSum.Visible = false;
            // 
            // GrpAudit
            // 
            this.GrpAudit.Controls.Add(this.BTauditNoApprove);
            this.GrpAudit.Controls.Add(this.BTauditApprove);
            this.GrpAudit.Controls.Add(this.BTauditSave);
            this.GrpAudit.Location = new System.Drawing.Point(305, 2);
            this.GrpAudit.Name = "GrpAudit";
            this.GrpAudit.Size = new System.Drawing.Size(394, 39);
            this.GrpAudit.TabIndex = 14;
            this.GrpAudit.TabStop = false;
            this.GrpAudit.Visible = false;
            // 
            // GrpEdit
            // 
            this.GrpEdit.Controls.Add(this.TxtLog);
            this.GrpEdit.Controls.Add(this.BTEditSendReport);
            this.GrpEdit.Controls.Add(this.BTEditSaveDB);
            this.GrpEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GrpEdit.ForeColor = System.Drawing.SystemColors.Control;
            this.GrpEdit.Location = new System.Drawing.Point(6, 3);
            this.GrpEdit.Name = "GrpEdit";
            this.GrpEdit.Size = new System.Drawing.Size(293, 40);
            this.GrpEdit.TabIndex = 16;
            this.GrpEdit.TabStop = false;
            // 
            // TxtLog
            // 
            this.TxtLog.Location = new System.Drawing.Point(0, 2);
            this.TxtLog.Margin = new System.Windows.Forms.Padding(2);
            this.TxtLog.Multiline = true;
            this.TxtLog.Name = "TxtLog";
            this.TxtLog.Size = new System.Drawing.Size(293, 19);
            this.TxtLog.TabIndex = 13;
            this.TxtLog.Visible = false;
            // 
            // WmPlayerTimer
            // 
            this.WmPlayerTimer.Tick += new System.EventHandler(this.WmPlayerTimer_Tick_1);
            // 
            // WmPlayer
            // 
            this.WmPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WmPlayer.Enabled = true;
            this.WmPlayer.Location = new System.Drawing.Point(0, 0);
            this.WmPlayer.Name = "WmPlayer";
            this.WmPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("WmPlayer.OcxState")));
            this.WmPlayer.Size = new System.Drawing.Size(279, 257);
            this.WmPlayer.TabIndex = 1;
            this.WmPlayer.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.WmPlayer_PlayStateChange);
            this.WmPlayer.Enter += new System.EventHandler(this.WmPlayer_Enter);
            // 
            // BT40X
            // 
            this.BT40X.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(84)))), ((int)(((byte)(152)))));
            this.BT40X.FlatAppearance.BorderSize = 0;
            this.BT40X.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT40X.Font = new System.Drawing.Font("Kanit", 8.25F);
            this.BT40X.ForeColor = System.Drawing.Color.White;
            this.BT40X.Location = new System.Drawing.Point(223, 42);
            this.BT40X.Name = "BT40X";
            this.BT40X.Size = new System.Drawing.Size(44, 34);
            this.BT40X.TabIndex = 8;
            this.BT40X.TabStop = false;
            this.BT40X.Text = "4.0 x";
            this.BT40X.UseVisualStyleBackColor = false;
            this.BT40X.Click += new System.EventHandler(this.BT40X_Click);
            // 
            // BT20X
            // 
            this.BT20X.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(84)))), ((int)(((byte)(152)))));
            this.BT20X.FlatAppearance.BorderSize = 0;
            this.BT20X.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT20X.Font = new System.Drawing.Font("Kanit", 8.25F);
            this.BT20X.ForeColor = System.Drawing.Color.White;
            this.BT20X.Location = new System.Drawing.Point(173, 42);
            this.BT20X.Name = "BT20X";
            this.BT20X.Size = new System.Drawing.Size(44, 34);
            this.BT20X.TabIndex = 7;
            this.BT20X.TabStop = false;
            this.BT20X.Text = "2.0 x";
            this.BT20X.UseVisualStyleBackColor = false;
            this.BT20X.Click += new System.EventHandler(this.BT20X_Click);
            // 
            // BT10X
            // 
            this.BT10X.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(84)))), ((int)(((byte)(152)))));
            this.BT10X.FlatAppearance.BorderSize = 0;
            this.BT10X.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT10X.Font = new System.Drawing.Font("Kanit", 8.25F);
            this.BT10X.ForeColor = System.Drawing.Color.White;
            this.BT10X.Location = new System.Drawing.Point(123, 43);
            this.BT10X.Name = "BT10X";
            this.BT10X.Size = new System.Drawing.Size(44, 34);
            this.BT10X.TabIndex = 6;
            this.BT10X.TabStop = false;
            this.BT10X.Text = "1.0 x";
            this.BT10X.UseVisualStyleBackColor = false;
            this.BT10X.Click += new System.EventHandler(this.BT10X_Click);
            // 
            // BT05X
            // 
            this.BT05X.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(84)))), ((int)(((byte)(152)))));
            this.BT05X.FlatAppearance.BorderSize = 0;
            this.BT05X.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT05X.Font = new System.Drawing.Font("Kanit", 8.25F);
            this.BT05X.ForeColor = System.Drawing.Color.White;
            this.BT05X.Location = new System.Drawing.Point(73, 42);
            this.BT05X.Name = "BT05X";
            this.BT05X.Size = new System.Drawing.Size(44, 34);
            this.BT05X.TabIndex = 5;
            this.BT05X.TabStop = false;
            this.BT05X.Text = "0.5 x";
            this.BT05X.UseVisualStyleBackColor = false;
            this.BT05X.Click += new System.EventHandler(this.BT05X_Click);
            // 
            // BTShowVersion
            // 
            this.BTShowVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(29)))), ((int)(((byte)(58)))));
            this.BTShowVersion.FlatAppearance.BorderSize = 0;
            this.BTShowVersion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTShowVersion.Font = new System.Drawing.Font("Kanit", 8.25F);
            this.BTShowVersion.ForeColor = System.Drawing.Color.White;
            this.BTShowVersion.Location = new System.Drawing.Point(153, 12);
            this.BTShowVersion.Name = "BTShowVersion";
            this.BTShowVersion.Size = new System.Drawing.Size(65, 29);
            this.BTShowVersion.TabIndex = 12;
            this.BTShowVersion.TabStop = false;
            this.BTShowVersion.Text = "เรียกข้อมูล";
            this.BTShowVersion.UseVisualStyleBackColor = false;
            this.BTShowVersion.Click += new System.EventHandler(this.BTShowVersion_Click_1);
            // 
            // BTSumShow
            // 
            this.BTSumShow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(29)))), ((int)(((byte)(58)))));
            this.BTSumShow.FlatAppearance.BorderSize = 0;
            this.BTSumShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTSumShow.Font = new System.Drawing.Font("Kanit", 8.25F);
            this.BTSumShow.ForeColor = System.Drawing.Color.White;
            this.BTSumShow.Location = new System.Drawing.Point(148, 9);
            this.BTSumShow.Name = "BTSumShow";
            this.BTSumShow.Size = new System.Drawing.Size(65, 34);
            this.BTSumShow.TabIndex = 8;
            this.BTSumShow.TabStop = false;
            this.BTSumShow.Text = "ตรวจสอบ";
            this.BTSumShow.UseVisualStyleBackColor = false;
            this.BTSumShow.Click += new System.EventHandler(this.BTSumShow_Click);
            // 
            // BTSumRefresh
            // 
            this.BTSumRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(29)))), ((int)(((byte)(58)))));
            this.BTSumRefresh.FlatAppearance.BorderSize = 0;
            this.BTSumRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTSumRefresh.Font = new System.Drawing.Font("Kanit", 8.25F);
            this.BTSumRefresh.ForeColor = System.Drawing.Color.White;
            this.BTSumRefresh.Location = new System.Drawing.Point(65, 9);
            this.BTSumRefresh.Name = "BTSumRefresh";
            this.BTSumRefresh.Size = new System.Drawing.Size(65, 34);
            this.BTSumRefresh.TabIndex = 7;
            this.BTSumRefresh.TabStop = false;
            this.BTSumRefresh.Text = "Refresh";
            this.BTSumRefresh.UseVisualStyleBackColor = false;
            this.BTSumRefresh.Click += new System.EventHandler(this.BTSumRefresh_Click);
            // 
            // BTsumApprove
            // 
            this.BTsumApprove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(29)))), ((int)(((byte)(58)))));
            this.BTsumApprove.FlatAppearance.BorderSize = 0;
            this.BTsumApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTsumApprove.Font = new System.Drawing.Font("Kanit", 8.25F);
            this.BTsumApprove.ForeColor = System.Drawing.Color.White;
            this.BTsumApprove.Location = new System.Drawing.Point(152, 0);
            this.BTsumApprove.Name = "BTsumApprove";
            this.BTsumApprove.Size = new System.Drawing.Size(109, 34);
            this.BTsumApprove.TabIndex = 10;
            this.BTsumApprove.TabStop = false;
            this.BTsumApprove.Text = "ส่งรายงาน/อนุมัติ";
            this.BTsumApprove.UseVisualStyleBackColor = false;
            this.BTsumApprove.Click += new System.EventHandler(this.BTsumApprove_Click);
            // 
            // BTsumSave
            // 
            this.BTsumSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(29)))), ((int)(((byte)(58)))));
            this.BTsumSave.FlatAppearance.BorderSize = 0;
            this.BTsumSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTsumSave.Font = new System.Drawing.Font("Kanit", 8.25F);
            this.BTsumSave.ForeColor = System.Drawing.Color.White;
            this.BTsumSave.Location = new System.Drawing.Point(17, 0);
            this.BTsumSave.Name = "BTsumSave";
            this.BTsumSave.Size = new System.Drawing.Size(109, 34);
            this.BTsumSave.TabIndex = 9;
            this.BTsumSave.TabStop = false;
            this.BTsumSave.Text = "บันทึกฉบับร่าง";
            this.BTsumSave.UseVisualStyleBackColor = false;
            this.BTsumSave.Click += new System.EventHandler(this.BTsumSave_Click);
            // 
            // BTauditNoApprove
            // 
            this.BTauditNoApprove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(29)))), ((int)(((byte)(58)))));
            this.BTauditNoApprove.FlatAppearance.BorderSize = 0;
            this.BTauditNoApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTauditNoApprove.Font = new System.Drawing.Font("Kanit", 8.25F);
            this.BTauditNoApprove.ForeColor = System.Drawing.Color.White;
            this.BTauditNoApprove.Location = new System.Drawing.Point(279, 5);
            this.BTauditNoApprove.Name = "BTauditNoApprove";
            this.BTauditNoApprove.Size = new System.Drawing.Size(109, 34);
            this.BTauditNoApprove.TabIndex = 11;
            this.BTauditNoApprove.TabStop = false;
            this.BTauditNoApprove.Text = "ไม่อนุมัติ";
            this.BTauditNoApprove.UseVisualStyleBackColor = false;
            this.BTauditNoApprove.Click += new System.EventHandler(this.BTauditNoApprove_Click);
            // 
            // BTauditApprove
            // 
            this.BTauditApprove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(29)))), ((int)(((byte)(58)))));
            this.BTauditApprove.FlatAppearance.BorderSize = 0;
            this.BTauditApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTauditApprove.Font = new System.Drawing.Font("Kanit", 8.25F);
            this.BTauditApprove.ForeColor = System.Drawing.Color.White;
            this.BTauditApprove.Location = new System.Drawing.Point(140, 5);
            this.BTauditApprove.Name = "BTauditApprove";
            this.BTauditApprove.Size = new System.Drawing.Size(109, 34);
            this.BTauditApprove.TabIndex = 10;
            this.BTauditApprove.TabStop = false;
            this.BTauditApprove.Text = "ส่งรายงาน/อนุมัติ";
            this.BTauditApprove.UseVisualStyleBackColor = false;
            this.BTauditApprove.Click += new System.EventHandler(this.BTauditApprove_Click);
            // 
            // BTauditSave
            // 
            this.BTauditSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(29)))), ((int)(((byte)(58)))));
            this.BTauditSave.FlatAppearance.BorderSize = 0;
            this.BTauditSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTauditSave.Font = new System.Drawing.Font("Kanit", 8.25F);
            this.BTauditSave.ForeColor = System.Drawing.Color.White;
            this.BTauditSave.Location = new System.Drawing.Point(0, 5);
            this.BTauditSave.Name = "BTauditSave";
            this.BTauditSave.Size = new System.Drawing.Size(109, 34);
            this.BTauditSave.TabIndex = 9;
            this.BTauditSave.TabStop = false;
            this.BTauditSave.Text = "บันทึกฉบับร่าง";
            this.BTauditSave.UseVisualStyleBackColor = false;
            this.BTauditSave.Click += new System.EventHandler(this.BTauditSave_Click);
            // 
            // BTEditSendReport
            // 
            this.BTEditSendReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(29)))), ((int)(((byte)(58)))));
            this.BTEditSendReport.FlatAppearance.BorderSize = 0;
            this.BTEditSendReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTEditSendReport.Font = new System.Drawing.Font("Kanit", 8.25F);
            this.BTEditSendReport.ForeColor = System.Drawing.Color.White;
            this.BTEditSendReport.Location = new System.Drawing.Point(161, 6);
            this.BTEditSendReport.Name = "BTEditSendReport";
            this.BTEditSendReport.Size = new System.Drawing.Size(109, 34);
            this.BTEditSendReport.TabIndex = 11;
            this.BTEditSendReport.TabStop = false;
            this.BTEditSendReport.Text = "ส่งรายงาน/อนุมัติ";
            this.BTEditSendReport.UseVisualStyleBackColor = false;
            this.BTEditSendReport.Click += new System.EventHandler(this.BTEditSendReport_Click_1);
            // 
            // BTEditSaveDB
            // 
            this.BTEditSaveDB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(29)))), ((int)(((byte)(58)))));
            this.BTEditSaveDB.FlatAppearance.BorderSize = 0;
            this.BTEditSaveDB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTEditSaveDB.Font = new System.Drawing.Font("Kanit", 8.25F);
            this.BTEditSaveDB.ForeColor = System.Drawing.Color.White;
            this.BTEditSaveDB.Location = new System.Drawing.Point(20, 6);
            this.BTEditSaveDB.Name = "BTEditSaveDB";
            this.BTEditSaveDB.Size = new System.Drawing.Size(109, 34);
            this.BTEditSaveDB.TabIndex = 10;
            this.BTEditSaveDB.TabStop = false;
            this.BTEditSaveDB.Text = "บันทึกฉบับร่าง";
            this.BTEditSaveDB.UseVisualStyleBackColor = false;
            this.BTEditSaveDB.Click += new System.EventHandler(this.BTEditSaveDB_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 761);
            this.Controls.Add(this.CTN);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parliament";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            this.CTN.Panel1.ResumeLayout(false);
            this.CTN.Panel1.PerformLayout();
            this.CTN.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CTN)).EndInit();
            this.CTN.ResumeLayout(false);
            this.SplitCtnWork.Panel1.ResumeLayout(false);
            this.SplitCtnWork.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitCtnWork)).EndInit();
            this.SplitCtnWork.ResumeLayout(false);
            this.SplitCtnLEft.Panel1.ResumeLayout(false);
            this.SplitCtnLEft.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitCtnLEft)).EndInit();
            this.SplitCtnLEft.ResumeLayout(false);
            this.SplitWM.Panel1.ResumeLayout(false);
            this.SplitWM.Panel2.ResumeLayout(false);
            this.SplitWM.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitWM)).EndInit();
            this.SplitWM.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ScreenShot)).EndInit();
            this.GrpWM.ResumeLayout(false);
            this.GrpWM.PerformLayout();
            this.SplitCtnList.Panel1.ResumeLayout(false);
            this.SplitCtnList.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitCtnList)).EndInit();
            this.SplitCtnList.ResumeLayout(false);
            this.SplitCtnListApp.Panel1.ResumeLayout(false);
            this.SplitCtnListApp.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitCtnListApp)).EndInit();
            this.SplitCtnListApp.ResumeLayout(false);
            this.GrpList.ResumeLayout(false);
            this.GrpList.PerformLayout();
            this.GRPsumList.ResumeLayout(false);
            this.SplitCtnWord.Panel1.ResumeLayout(false);
            this.SplitCtnWord.Panel1.PerformLayout();
            this.SplitCtnWord.Panel2.ResumeLayout(false);
            this.SplitCtnWord.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitCtnWord)).EndInit();
            this.SplitCtnWord.ResumeLayout(false);
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.GrpSum.ResumeLayout(false);
            this.GrpAudit.ResumeLayout(false);
            this.GrpEdit.ResumeLayout(false);
            this.GrpEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WmPlayer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer CTN;
        private SplitContainer SplitCtnWork;
        private SplitContainer SplitCtnLEft;
        private SplitContainer SplitCtnList;
        private SplitContainer SplitCtnListApp;
        private SplitContainer SplitCtnWord;
        private GroupBox GRPsumList;
        private ListView LVPart;
        private RJControls.RJButton BTSumShow;
        private RJControls.RJButton BTSumRefresh;
        private Timer WmPlayerTimer;
        private GroupBox GrpEdit;
        private RJControls.RJButton BTEditSaveDB;
        private GroupBox GrpAudit;
        private RJControls.RJButton BTauditNoApprove;
        private RJControls.RJButton BTauditApprove;
        private RJControls.RJButton BTauditSave;
        private GroupBox GrpSum;
        private RJControls.RJButton BTsumApprove;
        private RJControls.RJButton BTsumSave;
        private Panel PNWord;
        private TextBox TxtRoomTime;
        private TextBox TxtRoomVersion;
        private Label LbTop;
        private Label label8;
        private TextBox TxtRoomSection;
        private TextBox TxtRoomType;
        private Label label1;
        private Label label9;
        private Label label3;
        private TextBox TxtRoomStatus;
        private TextBox TxtRoomGroup;
        private Label label6;
        private Label label2;
        private TextBox TxtRoomNo;
        private TextBox TxtRoomPart;
        private Label label7;
        private Label label5;
        private TextBox TxtRoomPeriod;
        private TextBox TxtRoomYear;
        private Label label4;
        private SplitContainer SplitWM;
        private AxWMPLib.AxWindowsMediaPlayer WmPlayer;
        private GroupBox GrpWM;
        private Label label12;
        private Label label11;
        private TextBox TxtRewTime;
        private CheckBox ChkHighlight;
        private Label label10;
        private RJControls.RJButton BT40X;
        private RJControls.RJButton BT20X;
        private RJControls.RJButton BT10X;
        private RJControls.RJButton BT05X;
        private RJControls.RJButton BTEditSendReport;
        private GroupBox GrpList;
        private ComboBox CBVersion;
        private RJControls.RJButton BTShowVersion;
        private Label label13;
        private PictureBox ScreenShot;
        private StatusStrip StatusStrip;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel StripProgressStatus;
        private ToolStripProgressBar StripProgress;
        private TextBox TxtLog;
    }
}