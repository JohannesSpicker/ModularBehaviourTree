using System;

namespace ModularBehaviourTree
{
    /// <summary>
    ///     Sequence (others are "Selector", "Repeater")
    /// </summary>
    public class SequenceIterator : IBehaviour
    {
        private   IBehaviour activeIterator;
        private   int        cursor;
        protected Node[]     nodes;
        public SequenceIterator(Node[] nodes) { this.nodes = nodes; }

        public void Initialise(Context context)
        {
            activeIterator = nodes[0].CreateIterator();
            activeIterator.Initialise(context);
        }

        public Node.NodeState Tick(Context context)
        {
            while (true)
                switch (activeIterator.Tick(context))
                {
                    case Node.NodeState.Failure:
                    {
                        activeIterator.Terminate(context);

                        return Node.NodeState.Failure;
                    }
                    case Node.NodeState.Running: return Node.NodeState.Running;
                    case Node.NodeState.Success:
                    {
                        activeIterator.Terminate(context);

                        if (nodes.Length <= ++cursor)
                            return Node.NodeState.Success;

                        activeIterator = nodes[cursor].CreateIterator();
                        activeIterator.Initialise(context);

                        break;
                    }
                    default: throw new ArgumentOutOfRangeException();
                }
        }

        public void Terminate(Context context) {}
    }

    public class OneIterator : IBehaviour
    {
        protected Node node;
        public OneIterator(Node node) { this.node = node; }

        public void           Initialise(Context context) => node.Initialise(context);
        public Node.NodeState Tick(Context       context) => node.Tick(context);
        public void           Terminate(Context  context) => node.Terminate(context);
    }

    public interface IBehaviour
    {
        /// <summary>
        ///     Call once immediately before first tick.
        /// </summary>
        public void Initialise(Context context);

        /// <summary>
        ///     Called exactly once each tree tick until returns Failure or Success.
        /// </summary>
        public Node.NodeState Tick(Context context);

        /// <summary>
        ///     Called once immediately after Tick returns Failure or Success.
        /// </summary>
        public void Terminate(Context context);
    }
}