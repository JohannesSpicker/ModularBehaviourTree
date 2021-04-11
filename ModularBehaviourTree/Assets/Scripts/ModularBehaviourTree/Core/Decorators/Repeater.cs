namespace ModularBehaviourTree.Core.Decorators
{
    internal class Repeater : Decorator
    {
        private readonly uint repetitions;
        private          uint counter;
        public Repeater(Node node, uint repetitions) : base(node) { this.repetitions = repetitions; }

        protected override void Initialise(Context context) => counter = 0;

        protected override NodeState Continue(Context context)
        {
            for (; counter < repetitions; counter++)
            {
                NodeState childState = node.Tick(context);

                if (childState != NodeState.Success)
                    return childState;
            }

            return NodeState.Success;
        }

        protected override void Terminate(Context context) { }
    }
}