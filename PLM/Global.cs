using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLM
{

    //Declaring Global objects
    // private IntPtr ptrHook;
    //private LowLevelKeyboardProc objKeyboardProcess;


    public class CONFIG
    {
        public string url { get; set; }
    }
    public class APPINFO
    {
        public string mode { get; set; }
        //public string username { get; set; }
        public string accessKey { get; set; }
        // public int part { get; set; }
        public int meeting_id { get; set; }
        public int seq { get; set; }
        public string token { get; set; }
    }
    public class FILE
    {
        public int report_section_id { get; set; }
        public int report_section_actor_id { get; set; }
        public int seq { get; set; }
        public string seq_desc { get; set; } //add 2030304
        public int meeting_id { get; set; }
        public int user_id { get; set; }
        public string fullname { get; set; }
        public string start_time { get; set; }
        public string end_time { get; set; }
        //public string current_process { get; set; }
        public int current_process { get; set; }
        public string current_process_desc { get; set; }
        public int section_status { get; set; }
        public string section_status_desc { get; set; }
        public int report_section_task_id { get; set; }
        public int function { get; set; }
        public int process { get; set; }
        public int version { get; set; }
        public string version_desc { get; set; }
        //public string report_status { get; set; }
        public int report_status { get; set; }
        //public int row_no { get; set; }
        public string report_status_desc { get; set; }
        public string video { get; set; }

        //public string name { get; set; }
        //public int part { get; set; }
        //public string period { get; set; }
        //public string status { get; set; }
        //public int status_id { get; set; }
        //public int version { get; set; }
    }
    public class FILE_CONTENT
    {
        public FILE data { get; set; }
        public List<TRANSCRIPTION> transcription { get; set; }
    }
    public class ROOMALL
    {
        public string name { get; set; }
        public string time { get; set; }
        public string section { get; set; }
        public string type { get; set; }
        public string group { get; set; }
        public string year { get; set; }
        public string no { get; set; }
        public string status { get; set; }
        public int status_id { get; set; }
        public FILE[] files { get; set; }
    }
    public class dataROOM
    {
        public int? meeting_id { get; set; }
        public int? council_type_id { get; set; }
        public int? episode_id { get; set; }
        public int? room_id { get; set; }
        public int? meeting_type_id { get; set; }
        //public string no { get; set; }
        public int? meeting_number { get; set; }
        //public string year { get; set; }
        public int? meeting_year { get; set; }
        //public string group { get; set; }
        public int? meeting_group { get; set; }
        public string    meeting_title { get; set; }
        //public string time { get; set; }
        public string    start_timestamp { get; set; }
        public string end_timestamp { get; set; }
        public int section_time { get; set; }
        public int overlap_time { get; set; }
        public int process_seq { get; set; }
        //public int status_id { get; set; }
        public int meeting_status { get; set; }
        public string process_meta { get; set; }
        public int duration { get; set; }
        public int shorthand_group_id { get; set; }
        public int created_by { get; set; }
        //public string status { get; set; }
        public string meeting_status_desc { get; set; }
        //public string section { get; set; }
        public string council_type { get; set; }
        //public string type { get; set; }
        //public string meeting_episode { get; set; }
        public string episode_name { get; set; }
        public string shorthand_group { get; set; }
        public int total_section { get; set; }

    }
    public class ROOM
    {
        public string success { get; set; }

        public List<dataROOM> data { get; set; }
    }
    public class TRANSCRIPTION
    {
        public string utt { get; set; }
        public float start { get; set; }
        public float stop { get; set; }
        //public string result { get; set; }
        public string text { get; set; }
        //public double start_DB { get; set; }
        //public double stop_DB { get; set; }
    }
    ////public class VIDEO
    ////{
    ////    public string video { get; set; }
    ////    public string doc { get; set; }
    ////    public CONTENT[] content { get; set; }

    ////}
    public class dataCONTENTINFO
    {
        public int report_section_id { get; set; }
        public int report_section_actor_id { get; set; }
        public int seq { get; set; }
        public int meeting_id { get; set; }
        public int user_id { get; set; }
        public string fullname { get; set; } 
        public string start_time { get; set; } = string.Empty;
        public string end_time { get; set; } = string.Empty;
        public int current_process { get; set; }
        public string current_process_desc { get; set; }
        //public string status_id { get; set; }
        public int section_status { get; set; }
        //public string status { get; set; }
        public string section_status_desc { get; set; }
        public int report_section_task_id { get; set; }
        public int function { get; set; }
        public int process { get; set; }
        public int version { get; set; }
        public string version_desc { get; set; }
        public int task_status { get; set; }
        public int row_no { get; set; }
       // public string modify_time { get; set; }
    }

    public class CONTENTINFO
    {
        public string success { get; set; }

        public List<dataCONTENTINFO> data { get; set; }
    }
    public class ADDTRANSCRIPTION
    {
        public string success { get; set; }
        public int version { get; set; }
        public int function { get; set; }
    }
    public class ADDTRANSCRIPTION_FILE
    {
        public string success { get; set; }
        public int version { get; set; }
        public string filepath { get; set; }
    }


    public class VERSIONINFO
    {
        public string success { get; set; }

        public List<dataVERSIIONINFOO> data { get; set; }
    }
    public class dataVERSIIONINFOO
    {
        public int meeting_id { get; set; }
        public int seq { get; set; }
        public int process { get; set; }
        public int version { get; set; }
        public int report_section_id { get; set; }
        public int report_section_actor_id { get; set; }
        public int report_section_task_id { get; set; }
        public int user_id { get; set; }
        public string start_time { get; set; }
        public string end_time { get; set; }
        public int current_process { get; set; }
        public string current_process_desc { get; set; }
    }

    public class SUGGEST
    {

        public List<string> result { get; set; }
        public string status { get; set; }
    }
    


}
