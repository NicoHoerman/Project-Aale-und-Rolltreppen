﻿using System;
using System.Collections.Generic;
using System.Text;
using EelsAndEscalators.Contracts;
using EelsAndEscalators.ClassicEandE;
using EelsAndEscalators.States;



namespace EelsAndEscalators
{
    public class Game : IGame
    {
        public bool isRunning { get; set; }
        public IBoard Board { get; set; }
        public IRules Rules { get; private set; }
        public IState State { get; private set; }

        public void Init()
        {
            State = new MainMenuState(this);
            Run();
        }

        public void Run()
        {
            isRunning = true;
            while (isRunning)
            {
                State.Execute();
            }
        }
        
        public void InitializeGame()
        {
           Rules.SetupEntitites();
        }
        public void SwitchRules(IRules createdRule)
        {
             Rules = createdRule;     
        }       

        public void SwitchState(IState newState)
        {
            State = newState;
        }

        public void ClosingGame()
        {
            isRunning = false;
        }

    }

}   
