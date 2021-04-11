using ModularBehaviourTree;
using ModularBehaviourTree.Construction.Factories;
using UnityEngine;
using UnityEngine.AI;

namespace TreeTickerSpace
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class TreeTicker : MonoBehaviour
    {
        [SerializeField] private NodeFactory nodeFactory;
        private                  Node        behaviourTree;

        private Context context;

        private void Awake()
        {
            context = new Context(this, gameObject.GetComponent<NavMeshAgent>(), transform);

            behaviourTree = nodeFactory.CreateNode();
        }

        private void Update() => behaviourTree.Tick(context);
    }
}