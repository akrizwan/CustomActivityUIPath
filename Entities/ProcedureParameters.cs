using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomActivity
{
    public class ProcedureParameters
    {
        public DbType dbType { get; set; }
        public string Name { get; set; }
        public object Value { get; set; }
    }
}
