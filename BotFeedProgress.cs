using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomActivity
{
    public class BotFeedProgress : NativeActivity
    {
        public InArgument<string> BotFeedID { get; set; }
        public InArgument<string> ModelID { get; set; }
        public InArgument<int> SequenceNo { get; set; }
        protected override void Execute(NativeActivityContext context)
        {
            
        }
    }
}
