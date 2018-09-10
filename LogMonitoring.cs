using System;
using System.Activities;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CustomActivity
{
    [Designer(typeof(LogMonitoringDesigner))]
    public class LogMonitoring : NativeActivity
    {
        [RequiredArgument]
        [DefaultValue(null)]
        public InArgument<string> Keyword { get; set; }

        [RequiredArgument]
        [DefaultValue(null)]
        public InArgument<string> Log_Path { get; set; }

        [RequiredArgument]
        [DefaultValue(null)]
        public InArgument<string> Start_Identifier { get; set; }

        [RequiredArgument]
        [DefaultValue(null)]
        public InArgument<string> End_Identifier { get; set; }
        
        [DefaultValue(' ')]
        public InArgument<char> Seperator { get; set; }

        [RequiredArgument]
        [DefaultValue(null)]
        public InArgument<int> Date_Location { get; set; }

        [RequiredArgument]
        [DefaultValue(null)]
        public InArgument<string> Date_Time_Format { get; set; }



        public OutArgument<List<string>> List_of_Exception { get; set; }

        public OutArgument<List<string>> List_of_DateTime { get; set; }

        protected override void Execute(NativeActivityContext context)
        {
            if(Seperator.Get(context) == '\0')
                Seperator.Set(context, ' ');

            List<string> exceptionList = new List<string>();
            List<string> dateTimeList = new List<string>();
            //List<DateTime> dateTimeList = new List<DateTime>();

            int counter = 0;
            string logDatePattern = this.DateTimeFormat(Date_Time_Format.Get(context));

            System.IO.StreamReader file = new System.IO.StreamReader(Log_Path.Get(context));

            string fullFile = file.ReadToEnd();
            ArrayList indexes = new ArrayList();
            ArrayList values = new ArrayList();

            foreach (Match match in Regex.Matches(fullFile, Start_Identifier.Get(context), RegexOptions.Singleline))//.Cast<Match>().Select(m => m.Value).ToArray())
            {
                indexes.Add(match.Index);

                values.Add(match.Value);
            }

            string currentException;

            for (int i = 0; i < indexes.Count - 1; i++)
            {
                currentException = fullFile.Substring(int.Parse(indexes[i].ToString()), int.Parse(indexes[i + 1].ToString()) - int.Parse(indexes[i].ToString()));
                if (currentException.Contains(Keyword.Get(context)))
                {
                    exceptionList.Add(currentException.Substring(23));
                    string[] strArray = currentException.Split(Seperator.Get(context));
                    dateTimeList.Add(strArray[Date_Location.Get(context)]);
                    //dateTimeList.Add(DateTime.Parse(strArray[Date_Location.Get(context)]));
                    counter++;
                }
            }

            currentException = fullFile.Substring(int.Parse(indexes[indexes.Count - 1].ToString()), fullFile.Length - int.Parse(indexes[indexes.Count - 1].ToString()));

            if (currentException.Contains(Keyword.Get(context)))
            {
                string[] strArray = currentException.Split(Seperator.Get(context));
                dateTimeList.Add(strArray[Date_Location.Get(context)]);
                //dateTimeList.Add(DateTime.Parse(strArray[Date_Location.Get(context)]));
                counter++;
            }
            List_of_DateTime.Set(context, dateTimeList);
            List_of_Exception.Set(context, exceptionList);
        }

        private string DateTimeFormat(string dateTimeFormat)
        {
            switch(dateTimeFormat)
            {
                case "YYYY-MM-DD": return @"\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2}";
                case "MM-DD-YYYY": return @"\d{2}-\d{2}-\d{4} \d{2}:\d{2}:\d{2}";
                case "DD-MM-YYYY": return @"\d{2}-\d{2}-\d{4} \d{2}:\d{2}:\d{2}";
                default: return "Invalid Format";
            }
        }
    }
}
