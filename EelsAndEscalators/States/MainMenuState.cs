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

        private bool inMenu;
        private bool ruleNotSet = true;
        private bool gameNotStarted = true;
        //private int attempts = 0;
        private string _error = string.Empty;
        private string _lastInput = string.Empty;
        private string _additionalInformation = string.Empty;

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
            inMenu = true;
        }
     

        public MainMenuState(IGame game)
            : this(game, new ConfigurationProvider(), new SourceWrapper())

        { }

        public void Execute()
        {
            
            while (inMenu)
            {
                while (ruleNotSet)
                {
                    UpdateOutput();
                    _error = string.Empty;

                    var input = _sourceWrapper.ReadInput();
                    if (input == "/closegame")
                        Environment.Exit(0);

                    if (input.Length == 0 || input.Substring(0, 1) != "/")
                    {
                        _error = "Type in an existing Command";
                        _lastInput = input;
                        continue;
                    }

                    switch (input)
                    {
                        case "/startgame":
                            _error = "select a rule first";
                            break;
                        default:
                            CreateNewRulesInGame(input);
                            break;
                    }

                    _lastInput = input;
                }
                while (gameNotStarted)
                {
                    UpdateOutput();
                    _error = string.Empty;

                    var input = _sourceWrapper.ReadInput();

                    switch (input)
                    {
                        case "/startgame":
                            inMenu = false;
                            gameNotStarted = false;
                            _game.SwitchState(new GameStartingState(_game));
                            break;

                        case "/closegame":
                            Environment.Exit(0);
                            break;

                        default:
                            _error = "Start or close the game.";
                            break;
                    }
                    _lastInput = input;
                }
            }
        }

        private void UpdateOutput()
        {
            _sourceWrapper.Clear();
            _sourceWrapper.WriteOutput(parse.MainMenuInfo());
            _sourceWrapper.WriteOutput(string.Empty);

            if (_additionalInformation.Length != 0)
                _sourceWrapper.WriteOutput(_additionalInformation);

            if (_error.Length != 0)
            {
                _sourceWrapper.WriteOutput(_lastInput);
                _sourceWrapper.WriteOutput(_error);
            }
        }

        private void CreateNewRulesInGame(string rulesname)
        {
            if (_rulesFactory.TryGetValue(rulesname.Substring(1, rulesname.Length - 1), out var createdRule))
            { 
                _game.SwitchRules(createdRule(_game,_configurationProvider));
                ruleNotSet = false;
                _additionalInformation = "Ruleset chosen.\nYou can now start the game.";
            }
            else
                _error = "Command does not exist";
        }

    }
}
