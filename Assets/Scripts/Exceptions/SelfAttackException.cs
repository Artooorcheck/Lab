using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Exceptions
{
    public class SelfAttackException : Exception
    {
        public override string Message => "Can't attack itself";
    }
}
