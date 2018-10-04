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
        Parse parse = new Parse();
        DataProvider Show = new DataProvider();

        private bool inMenu;
        private bool ruleNotSet = true;
        private bool gameNotStarted = true;
        private string _error = string.Empty;
        private string _lastInput = string.Empty;
        private string _additionalInformation = string.Empty;

        private Dictionary<string, Func<IGame,IConfigurationProvider, IRules>> _rulesFactory = new Dictionary<string, Func<IGame, IConfigurationProvider, IRules>>
        {
            { "classic", (game,configP) => new ClassicRules(game,configP) },
        //    { "fancy", (g) => new FancyRules(g) },
        };
        private string rulesname;

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
                var parser = new Parse();
                parser.AddCommand("/startgame", OnStartGameCommand);
                parser.AddCommand("/closegame", OnCloseGameCommand);
                parser.AddCommand("/classic", OnClassicCommand);
                parser.SetErrorAction(OnErrorCommand);

                while (ruleNotSet)
                {
                    UpdateOutput();
                    _error = string.Empty;

                    _sourceWrapper.WriteOutput(0, 15, "Type an Command: ");
                    Console.SetCursorPosition(17, 15);
                    var input = _sourceWrapper.ReadInput();

                    _lastInput = input;
                    rulesname = input;
                    parser.Execute(input);
             
                }
                while (gameNotStarted)
                {
                    UpdateOutput();
                    _error = string.Empty;

                    _sourceWrapper.WriteOutput(0, 17, "Type an Command: ");
                    Console.SetCursorPosition(17, 17);
                    var input = _sourceWrapper.ReadInput();

                    _lastInput = input;
                    parser.Execute(input);
                }
            }
        }

        private void OnErrorCommand(string token)
        {
            _error = "Invalid input";
            return;
        }

        private void OnStartGameCommand()
        {
            if(ruleNotSet)
                _error = "Please choose a rule first";
            else
            {
                inMenu = false;
                gameNotStarted = false;
                _game.SwitchState(new GameStartingState(_game));
            }
        }

        private void OnCloseGameCommand()
        {
            Environment.Exit(0);
        }

        private void OnClassicCommand()
        {
            CreateNewRulesInGame(rulesname);
        }

        private void UpdateOutput()
        {
            _sourceWrapper.Clear();
            _sourceWrapper.WriteOutput(0,0,Show.MainMenuInfo());
            _sourceWrapper.WriteOutput(0, 12, string.Empty);

            if (_additionalInformation.Length != 0)
                _sourceWrapper.WriteOutput(0, 15, _additionalInformation);

            if (_error.Length != 0)
            {
                _sourceWrapper.WriteOutput(0, 12, "Last Input: ");
                _sourceWrapper.WriteOutput(11, 12, _lastInput);
                _sourceWrapper.WriteOutput(0, 13, "Last Error: ");
                _sourceWrapper.WriteOutput(11, 13, _error);
            }
        }

        private void CreateNewRulesInGame(string rulesname)
        {
            if (_rulesFactory.TryGetValue(rulesname.Substring(1, rulesname.Length - 1), out var createdRule))
            {
                _game.SwitchRules(createdRule(_game, _configurationProvider));
                ruleNotSet = false;
                _additionalInformation = "Ruleset chosen.\nYou can now start the game.";
            }
            else
                _error = "Interal error.";
        }

    }
}


/*
 * if (input == "/closegame")
                        Environment.Exit(0);

                    if (input.Length == 0 || input.Substring(0, 1) != "/")
                    {
                        _error = "Type in an existing Command";
                    
 */
