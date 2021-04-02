using System;

namespace ModularBehaviourTree.Composites
{
    public class Sequence : Composite
    {
        public override void Initialise(Context context) { }

        public override void       Terminate(Context context) => throw new NotImplementedException();
        public override IBehaviour CreateIterator()           => new SequenceIterator(nodes);
    }
}