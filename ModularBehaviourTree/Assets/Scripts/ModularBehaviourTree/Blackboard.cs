using UnityEngine;
using UnityEngine.AI;

namespace ModularBehaviourTree
{
    public class Blackboard
    {
        public readonly NavMeshAgent navMeshAgent;

        public readonly MonoBehaviour treeTicker;

        public Transform target;

        public Blackboard(MonoBehaviour treeTicker, NavMeshAgent navMeshAgent, Transform target)
        {
            this.treeTicker   = treeTicker;
            this.navMeshAgent = navMeshAgent;
            this.target       = target;
        }
    }
}