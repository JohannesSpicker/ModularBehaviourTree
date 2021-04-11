using UnityEngine;
using UnityEngine.AI;

namespace ModularBehaviourTree
{
    public class Context
    {
        public readonly NavMeshAgent navMeshAgent;

        public readonly MonoBehaviour treeTicker;

        public readonly Transform target;
        
        public Context(MonoBehaviour treeTicker, NavMeshAgent navMeshAgent, Transform target)
        {
            this.treeTicker   = treeTicker;
            this.navMeshAgent = navMeshAgent;
            this.target       = target;
        }
    }
}