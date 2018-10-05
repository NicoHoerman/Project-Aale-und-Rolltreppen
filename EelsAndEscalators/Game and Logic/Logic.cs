﻿using System;
using System.Collections.Generic;
using System.Text;
using EelsAndEscalators.Contracts;
using EelsAndEscalators.ClassicEandE;
using EelsAndEscalators.States;
using System.Linq;

namespace EelsAndEscalators
{

    public class Logic
    {
        
        private IPawn CurrentPawn;
        private bool GameFinished;      
        public int CurrentPlayerID { get; set; } = 1;

        private readonly IGame _game;
        public Logic(IGame game)
        {
            _game = game;
            
        }

        //Gets the Pawn with the matching playerID from the Pawns List
        public IPawn GetPawn()
        {
            try
            {
                return CurrentPawn =  _game.Board.Pawns.Find(x => x.playerID.Equals(CurrentPlayerID));
            }
            catch(Exception e)
            {
                throw new InvalidOperationException($"Nothing Found with PlayerID {CurrentPlayerID} ",e);
            }

        }


        public TurnState CheckIfGameFinished()
        {
            try
            {
                GameFinished = CurrentPawn.location == _game.Board.size ? true : false;
                return GameFinished == true ? TurnState.GameFinished : TurnState.TurnFinished;
            }
            catch
            {
                throw new Exception();
            }

        }


        public void NextPlayer()
        {
            var orderedPlayers = _game.Board.Pawns.OrderBy(x => x.playerID).ToList();
            var nextPlayer = orderedPlayers.Where(x => x.playerID == CurrentPlayerID + 1).FirstOrDefault();
            if (nextPlayer == null)
                CurrentPlayerID = orderedPlayers.First().playerID;
            else
                CurrentPlayerID = nextPlayer.playerID;
        }


        public TurnState MakeTurn()
        {

            try
            {
                //Get current Pawn 
                GetPawn();
                //Roll Dice
                _game.Rules.RollDice();

                //Check If Player Exceeds Board and Move Pawn
                if (CurrentPawn.location + _game.Rules.DiceResult > _game.Board.size)
                {
                    NextPlayer();
                    return TurnState.PlayerExceedsBoard;
                }
                else
                    CurrentPawn.MovePawn(_game.Rules.DiceResult);
                
                //Entities check if the pawn is on them
                _game.Board.Entities.ForEach(entity =>
                {
                    if (entity.OnSamePositionAs(CurrentPawn))
                    {
                        entity.SetPawn(CurrentPawn);
                    }
                });

                
                NextPlayer();

                return CheckIfGameFinished();

            }
            catch(Exception e)
            {
                throw new InvalidOperationException($"Could not Return a TurnState",e);
            }

        }

    }
}
