using System;
using System.Collections.Generic;
using System.Text;
using EelsAndEscalators.Configurations;


namespace EelsAndEscalators.Contracts
{
    //Nico
    public interface IRules
    {
        int numberOfPawns { get; set; }
        int diceSides { get; set; }  
        int diceResult { get; set; }


        IPawn CreatePawn(PawnConfig configuration);
        IEntity CreateEel(EelConfig configuration);
        IEntity CreateEscalator(EscalatorConfig configuration);
        IBoard CreateBoard();

        void RollDice();
        
    }
}
