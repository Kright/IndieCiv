using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using IndieCivCore.Resources;
using IndieCivCore.Localization;

namespace IndieCivCore {
    public enum EExecutionEnvironment {
        EExecutionEnvironment_Editor,
        EExecutionEnvironment_Game,
    }
    public enum EExecutionState {
        Stopped,
        Playing,
        Paused,
    }
    public static class IndieCivCoreApp {
        public static EExecutionEnvironment EEnvironmentEnvironment { get; set; }
        public static EExecutionState EExecutionState { get; set; }

        public static void Init(EExecutionEnvironment EEnvironmentMode) {
            EExecutionState = EExecutionState.Stopped;

            Game.Instance = new Game();

            LocaleManager.Load();
            ResourceLoader.Load();

            ResourceLoader.LoadArt();

        }

        public static void Update(GameTime game_time, KeyboardState state) {
            Game.Instance.Update(game_time, state);
        }

        public static void Render(GameTime game_time) {
            Game.Instance.Render();
        }
    }
}
