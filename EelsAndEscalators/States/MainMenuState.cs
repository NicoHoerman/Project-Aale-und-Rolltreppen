using System;
using System.Collections.Generic;
using System.Text;
using EelsAndEscalators.ClassicEandE;
using EelsAndEscalators.Contracts;

namespace EelsAndEscalators.States
{

    public class MainMenuState : IState
    {
        private readonly IGame _game;
        private readonly IConfigurationProvider _configurationProvider;
        private readonly ISourceWrapper _sourceWrapper;

        private bool inMenu = true;
        private bool ruleNotSet = true;
        private bool gameNotStarted = true;
        private string input;
        Parse parse = new Parse();

        private Dictionary<string, Func<IGame,IConfigurationProvider, IRules>> _rulesFactory = new Dictionary<string, Func<IGame, IConfigurationProvider, IRules>>
        {
            { "classic", (game,configP) => new ClassicRules(game,configP) },
        //    { "fancy", (g) => new FancyRules(g) },
        };

        public MainMenuState(IGame game, IConfigurationProvider configurationProvider, ISourceWrapper sourceWrapper)
        {
            _game = game;
            _configurationProvider = configurationProvider;
            _sourceWrapper = sourceWrapper;
        }

        public MainMenuState(IGame game)
            : this(game, new ConfigurationProvider(), new SourceWrapper())
        { }

        public void Execute()
        {

            while (inMenu)
            {
                _sourceWrapper.WriteOutput(parse.MainMenuInfo());
                while (ruleNotSet)
                {
                     input = _sourceWrapper.ReadInput();

                    if(input == "/closegame")
                        Environment.Exit(0);

                    else if (input.Substring(0, 1) == "/")
                        CreateNewRulesInGame(input.Substring(1, input.Length - 1));

                    else _sourceWrapper.WriteOutput("Type in an existing Command");
                }
                while (gameNotStarted)
                {
                    input = _sourceWrapper.ReadInput();
                    if (input == "/startgame")
                    {
                        _game.SwitchState(new GameStartingState(_game));
                        inMenu = false;
                        gameNotStarted = false;
                    }
                    else if(input == "/closegame")
                        Environment.Exit(0);
                    else _sourceWrapper.WriteOutput("start the game or close");
                }
            }
        }

        private void CreateNewRulesInGame(string rulesname)
        {
            if (_rulesFactory.TryGetValue(rulesname, out var createdRule))
            { 
                _game.SwitchRules(createdRule(_game,_configurationProvider));
                ruleNotSet = false;
                _sourceWrapper.WriteOutput("Classic Rules set." + "You can now start the game");
            }
            else
                GiveErrorRuleNotFound();
        }

        private void GiveErrorRuleNotFound()
        {
            if(input == "/startgame")
                _sourceWrapper.WriteOutput("select a rule first");

            else _sourceWrapper.WriteOutput("Command does not exist");
        }
    }
}
