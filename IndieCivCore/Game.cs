using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using IndieCivCore.Map;
using IndieCivCore.Entities;
using IndieCivCore.Resources;

namespace IndieCivCore
{
	public sealed class Game
	{
        //private static readonly Game instance = new Game();
        public static Game Instance { get; set; }

        TurnData TurnData { get; set; }

        public Player SelectedPlayer { get; set; }

        public int NumTurnsPlayed { get; set; }
        public int Year { get; set; }
        public int StartYear { get; set; }
        public int StepValue { get; set; }
        public int YearsPassedThisTurn { get; set; }
        public int TurnsLeft { get; set; }

        public Game() {
        }

        public void Init() {
            //SelectedPlayer = PlayerManager.Next(null);

            StartYear = -10000;
            TurnData = ResourceInterface.TurnData[0];
            Year = StartYear;
            TurnsLeft = TurnData.NumTurns;
            StepValue = TurnData.StepValue;

            SelectedPlayer = AddPlayer(ResourceInterface.CivilizationData[0], true);
            SelectedPlayer.ActiveUnit.CenterOnMap();
            MapManager.Current.Player = SelectedPlayer;
        }

        public Player AddPlayer(CivilizationData CivilizationData, bool IsAI) {

            Player Player = PlayerManager.AddPlayer();
            Player.IsAI = IsAI;
            Player.CivilizationData = CivilizationData;

            MapTile MapTile = MapManager.Current.GetStartingLocation(Player);
            if (MapTile == null) {
                MapTile = MapManager.Current.GetRandomLandTile();
            }

            Player.AddUnit(ResourceInterface.UnitData[0], MapTile);
            Player.AddUnit(ResourceInterface.UnitData[1], MapTile);

            Player.CurrentEra = ResourceInterface.EraData[0];

            foreach (var Item in ResourceInterface.GovernmentData) {
                if (Item.Default == true) {
                    Player.GovernmentData = Item;
                }
            }

            foreach (var Item in CivilizationData.FreeAdvances) {
                //Player.SetDiscovered(Item);
            }

            return Player;
        }

		public void Update(GameTime game_time, KeyboardState state)
		{
			MapManager.Update();

            if (IndieCivCoreApp.EExecutionState == EExecutionState.Playing) {
                SelectedPlayer.Update();

                if (SelectedPlayer.IsAI == true) {
                    if (state.IsKeyDown(Keys.Enter) && SelectedPlayer.ActiveUnitsLeft() == false) {
                        UpdateEndOfTurn();
                    }
                }
                else {
                    if (state.IsKeyDown(Keys.Enter) && SelectedPlayer.ActiveUnitsLeft() == false) {
                        UpdateEndOfTurn();
                    }
                }
            }
		}

        public void UpdateEndOfTurn() {
            SelectedPlayer.UpdateEndOfTurn();

            if (SelectedPlayer == PlayerManager.GetLastPlayer()) {
                YearsPassedThisTurn = Year + StepValue;
                Year = Year + StepValue;

                NumTurnsPlayed = NumTurnsPlayed + 1;

                if (TurnsLeft >= 0) {
                    TurnsLeft -= 1;
                }

                if (TurnsLeft == 0) {
                    TurnData = ResourceInterface.TurnData[TurnData.Index - 1];

                    if (TurnData != null) {
                        TurnsLeft = TurnData.NumTurns;
                        StepValue = TurnData.StepValue;
                    }
                }
            }

            SelectedPlayer = PlayerManager.Next(SelectedPlayer);

            if (SelectedPlayer.ActiveUnit != null) {
                SelectedPlayer.ActiveUnit.CenterOnMap();
            }
            else {
                SelectedPlayer.CityList[0].CenterOnMap();
            }

            MapManager.Current.Player = SelectedPlayer;
            //Reset MapTiles?
        }

		public void Render()
		{
			MapManager.Render();

            foreach (var Item in PlayerManager.PlayerList) {
                Item.Render();
            }
		}
	}
}
