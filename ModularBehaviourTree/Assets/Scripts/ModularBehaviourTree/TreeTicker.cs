using UnityEngine;
using UnityEngine.AI;

namespace ModularBehaviourTree
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class TreeTicker : MonoBehaviour
    {
        [SerializeField] private Node startingTree;

        private Context context;

        private IBehaviour iterator;

        private void Awake() => context = new Context(this, gameObject.GetComponent<NavMeshAgent>());

        private void Start()
        {
            iterator = startingTree.CreateIterator();
            iterator.Initialise(context);
        }

        private void Update() => iterator.Tick(context);
    }

    public class Context
    {
        public readonly NavMeshAgent navMeshAgent;

        public readonly TreeTicker treeTicker;

        public Context(TreeTicker treeTicker, NavMeshAgent navMeshAgent)
        {
            this.treeTicker   = treeTicker;
            this.navMeshAgent = navMeshAgent;
        }
    }
}