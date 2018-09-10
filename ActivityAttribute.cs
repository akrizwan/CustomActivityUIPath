using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomActivity
{
    //[AttributeUsage(AttributeTargets.Method)]
    public class ActivityAttribute : Attribute
    {
        public string myValue { get; set; }

        public ActivityAttribute()
        {

        }

        public ActivityAttribute(string str)
        {
            this.myValue = str;
        }
    }
}
