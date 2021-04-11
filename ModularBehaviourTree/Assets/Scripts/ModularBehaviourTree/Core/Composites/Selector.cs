namespace ModularBehaviourTree.Composites
{
    internal class Selector : Composite
    {
        internal Selector(Node[] nodes) : base(nodes) { }

        protected override NodeState Continue(Context context)
        {
            for (; cursor < nodes.Length; cursor++)
            {
                NodeState childState = nodes[cursor].Tick(context);

                if (childState != NodeState.Failure)
                    return childState;
            }

            return NodeState.Failure;
        }
    }
}