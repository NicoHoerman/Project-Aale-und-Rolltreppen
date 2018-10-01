using System.Xml.Linq;


namespace EelsAndEscalators.Contracts
{
    public interface IRules
    {
        int numberOfPawns { get;}
        int diceSides { get; }  
        int diceResult { get; }


        IPawn CreatePawn(XElement configuration);
        IEntity CreateEel(XElement configuration);
        IEntity CreateEscalator(XElement configuration);
        IBoard CreateBoard();

        void RollDice();
        void SetupEntitites();
    }
}
