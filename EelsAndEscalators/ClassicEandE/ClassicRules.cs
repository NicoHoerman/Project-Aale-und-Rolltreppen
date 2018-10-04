using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

using EelsAndEscalators.Contracts;

namespace EelsAndEscalators.ClassicEandE
{

    public class ClassicRules : IRules
    {
        private long _idCounter;

        private readonly IGame _game;
        private readonly IConfigurationProvider _configurationProvider;

        private Dictionary<EntityType, Func<XElement, IEntity>> _entityFactory = new Dictionary<EntityType, Func<XElement, IEntity>>();

        public int numberOfPawns { get; } = 2;
        public int diceSides { get; } = 6;
        public int diceResult { get; set; }


        public ClassicRules(IGame game, IConfigurationProvider configurationProvider)
        {
            _game = game;
            _configurationProvider = configurationProvider;

            _entityFactory = new Dictionary<EntityType, Func<XElement, IEntity>>
            {
                { EntityType.Eel, (config) => CreateEel(config)},
                { EntityType.Escalator, (config) => CreateEscalator(config) },
            };
        }

        public ClassicRules(IGame game)
             : this(game, new ConfigurationProvider())
        { }
        

        public void SetupEntitites()
        {
            _game.Board = new ClassicBoard();

            var configurations = _configurationProvider.GetEntityConfigurations();
            configurations.ForEach(config =>
            {
                var entityType = (EntityType)config.Get("entitytype", Convert.ToInt32);
                if (entityType == EntityType.Pawn)
                    _game.Board.Pawns.Add(CreatePawn(config));
                else
                    _game.Board.Entities.Add(_entityFactory[entityType](config));
            });
        }

        public IBoard CreateBoard()
        {
            return new ClassicBoard();
        }

        public IPawn CreatePawn(XElement configuration)
        {
            return new ClassicPawn
            {
                color = configuration.Get("color", Convert.ToInt32),
                location = configuration.Get("location", Convert.ToInt32),
                playerID = configuration.Get("playerid", Convert.ToInt32),
                Id = NextId(),
            };
        }

        public IEntity CreateEel(XElement configuration)
        {
            return new ClassicEel
            {
                top_location = configuration.Get("toplocation", Convert.ToInt32),
                bottom_location = configuration.Get("bottomlocation", Convert.ToInt32),
                Id = NextId(),
            };
        }

        public IEntity CreateEscalator(XElement configuration)
        {
            return new ClassicEscalator
            {
                top_location = configuration.Get("toplocation", Convert.ToInt32),
                bottom_location = configuration.Get("bottomlocation", Convert.ToInt32),
                Id = NextId(),
            };
        }

        public void RollDice()
        {
            Random rnd = new Random();
            diceResult = rnd.Next(1, diceSides+1);

        }

        #region Private methods

        private long NextId()
        {
            _idCounter++;
            return _idCounter;
        }

        #endregion
    }
}
