using System;
using System.Collections.Generic;
using System.Text;
using EelsAndEscalators.Configurations;
using EelsAndEscalators.Contracts;

namespace EelsAndEscalators.ClassicEandE
{
    public class ClassicRules : IRules
    {
        private readonly IGame _game;
        ConfigurationProvider configurationProvider = new ConfigurationProvider();
        public ClassicRules(IGame game)
        {
            _game = game;
        }

        public ClassicRules()
        {

        }
        public int numberOfPawns { get =>numberOfPawns; set =>numberOfPawns = 2; }
        public int diceSides { get => diceSides; set => diceSides = 6; }
        public int diceResult { get ;set; }

        public IBoard CreateBoard()
        {
            return new ClassicBoard();
        }

        public IPawn CreatePawn(PawnConfig configuraton)
        {
            
            return new ClassicPawn();
        }

        public IEntity CreateEel(EelConfig configuration)
        {
            throw new NotImplementedException();
        }

        public IEntity CreateEscalator(EscalatorConfig configuration)
        {
            throw new NotImplementedException();
        }

        public void RollDice()
        {
            throw new NotImplementedException();
        }
    }
}
