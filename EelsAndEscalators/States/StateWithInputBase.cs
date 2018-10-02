using EelsAndEscalators.Contracts;

namespace EelsAndEscalators.States
{
    public class StateWithInputBase
    {
        private readonly ISourceWrapper _sourceWrapper;

        public StateWithInputBase(ISourceWrapper sourceWrapper)
        {
            _sourceWrapper = sourceWrapper;
        }

        public StateWithInputBase()
            : this(new SourceWrapper())
        { }

        public string WaitingForInput()
        {
            return _sourceWrapper.ReadInput();
        }
    }
}
