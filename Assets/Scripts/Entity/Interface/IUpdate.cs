using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Entity
{
    public interface IUpdate
    {
        void FrameUpdate(float deltaTime);
    }
}
