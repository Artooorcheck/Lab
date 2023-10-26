using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Exceptions
{
    public class HasTaskException : Exception
    {
        public override string Message => "Last task isn't complete";
    }
}
