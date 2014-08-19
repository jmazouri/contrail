using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConTrail.Game.Models;

namespace ConTrail.Game.Interfaces
{
    public interface ITarget
    {
        ITarget Owner { get; set; }
        string Name { get; set; }

        void MoveTo();
        bool Use(ITarget source);
        ITarget GetCopy();
    }
}
