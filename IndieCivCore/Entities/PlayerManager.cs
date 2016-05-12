using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndieCivCore.Entities {
    static public class PlayerManager {
        static public List<Player> PlayerList = new List<Player>();

        static public Player AddPlayer() {
            Player Player = new Player();

            Player.Index = PlayerList.Count;

            PlayerList.Add(Player);

            return Player;
        }

        static public Player GetLastPlayer() {
            return PlayerList.Last();
        }

        static public Player Next(Player Player) {

            return PlayerList[(PlayerList.IndexOf(Player) + 1) == PlayerList.Count ? 0 : (PlayerList.IndexOf(Player) + 1)];
        }
    }
}
