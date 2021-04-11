namespace ModularBehaviourTree
{
    public interface IBehaviour
    {
        /// <summary>
        ///     Called exactly once each tree tick until returns Failure or Success.
        /// </summary>
        public Node.NodeState Tick(Context context);
    }
}