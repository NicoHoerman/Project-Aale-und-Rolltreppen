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
        public bool inMenu;
        private bool ruleNotSet = true;
        private string input;
        Parse parse = new Parse();
        SourceWrapper sourceWrapper = new SourceWrapper();
        GameStartingState gameStartingState;

        private Dictionary<string, Func<IGame,IConfigurationProvider, IRules>> _rulesFactory = new Dictionary<string, Func<IGame, IConfigurationProvider, IRules>>
        {
            { "classic", (game,configP) => new ClassicRules(game,configP) },
        //    { "fancy", (g) => new FancyRules(g) },
        };


        public MainMenuState(IGame game, IConfigurationProvider configurationProvider)
        {
            _game = game;
            _configurationProvider = configurationProvider;
        }


        public void Execute()
        {

            while (inMenu)
            {
                sourceWrapper.WriteOutput(parse.MainMenuInfo());
                while (ruleNotSet)
                {
                     input = WaitingForInput();

                    if (input.Substring(0, 1) == "/")
                    {
                        CreateNewRulesInGame(input.Substring(1, input.Length - 1));
                    }
                    else sourceWrapper.WriteOutput("Type in an existing Command");
                }

                    input = WaitingForInput();
                    if (input == "/startgame")
                    {
                        _game.Logic.SwitchState(new GameStartingState(_game));
                        gameStartingState.gameStarting = true;
                        gameStartingState.Execute();
                                            
                        inMenu = false;
                    }
            }
        }

        public string WaitingForInput()
        {
            return sourceWrapper.ReadInput();
        }

        private void CreateNewRulesInGame(string rulesname)
        {
            if (_rulesFactory.TryGetValue(rulesname, out var createdRule))
            { 
                _game.SwitchRules(createdRule(_game,_configurationProvider));
                ruleNotSet = false;
            }
            else
                GiveErrorRuleNotFound();
        }

        private void GiveErrorRuleNotFound()
        {
            if(input == "/startgame")
            {
                sourceWrapper.WriteOutput("select a rule first");
            }
            else sourceWrapper.WriteOutput("Rule does not exist");
        }
    }
}
