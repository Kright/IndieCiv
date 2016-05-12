using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndieCivCore.Entities {
    public abstract class Entity {
        public int Index { get; set; }


        public abstract void Update();

        public abstract void Render();

        public abstract void UpdateEndOfTurn();
    }
}
