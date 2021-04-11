using System;

namespace ModularBehaviourTree.Core.Decorators
{
    internal class Inverter : Decorator
    {
        public Inverter(Node                       node) : base(node) { }
        protected override void Initialise(Context context) { }

        protected override NodeState Continue(Context context)
        {
            NodeState childState = base.Continue(context);

            switch (childState)
            {
                case NodeState.Failure: return NodeState.Success;
                case NodeState.Running: return NodeState.Running;
                case NodeState.Success: return NodeState.Failure;
                default:                throw new ArgumentOutOfRangeException();
            }
        }

        protected override void Terminate(Context context) { }
    }
}