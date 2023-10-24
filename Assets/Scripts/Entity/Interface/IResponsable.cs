using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Entity
{
    public interface IResponsable
    {
        event Action<IResponsable> OnStartTask;
        event Action<IResponsable> OnFinishTask;
    }
}
