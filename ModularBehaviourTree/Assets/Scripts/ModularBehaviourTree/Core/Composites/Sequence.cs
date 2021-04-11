namespace ModularBehaviourTree.Composites
{
    internal class Sequence : Composite
    {
        internal Sequence(Node[] nodes) : base(nodes) { }
        
        protected override NodeState Continue(Context context)
        {
            for (; cursor < nodes.Length; cursor++)
            {
                NodeState childState = nodes[cursor].Tick(context);

                if (childState != NodeState.Success)
                    return childState;
            }

            return NodeState.Success;
        }
    }
}