using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndieCivCore.Entities {
    public class City : Entity, IMapInterface {
        public override void Update() {
        }

        public override void Render() {
        }

        public override void UpdateEndOfTurn() {
            throw new NotImplementedException();
        }

        public void CenterOnMap() {
            throw new NotImplementedException();
        }
    }
}
