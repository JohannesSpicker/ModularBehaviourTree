namespace ModularBehaviourTree
{
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