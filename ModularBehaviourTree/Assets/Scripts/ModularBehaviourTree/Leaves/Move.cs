using UnityEngine;

namespace ModularBehaviourTree.Leaves
{
    public class Move : Leaf
    {
        private const float failureMargin = 0.2f;

        protected override void Initialise(Context context) => context.navMeshAgent.SetDestination(Vector3.forward);

        protected override NodeState Continue(Context context) =>
            Vector3.Distance(context.navMeshAgent.destination, context.navMeshAgent.transform.position) < failureMargin
                ? NodeState.Success
                : NodeState.Running;

        protected override void Terminate(Context context) =>
            context.navMeshAgent.SetDestination(context.navMeshAgent.transform.position);
    }
}