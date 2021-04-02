namespace ModularBehaviourTree.Iterators
{
    public class OneIterator : IBehaviour
    {
        protected Node node;
        public OneIterator(Node node) { this.node = node; }

        public void           Initialise(Context context) => node.Initialise(context);
        public Node.NodeState Tick(Context       context) => node.Tick(context);
        public void           Terminate(Context  context) => node.Terminate(context);
    }
}