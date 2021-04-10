using ModularBehaviourTree;
using ModularBehaviourTree.Composites;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.AI;

namespace Tests.PrimitiveTests
{
    public class CompositeTests
    {
        [Test]
        public void SomeSequenceTest([Values(1, 2, 3)] int counter)
        {
            Setup(out Context context, out Sequence sequence);

            IBehaviour iterator = sequence.CreateIterator();

            iterator.Initialise(context);

            for (int i = 0; i < counter; i++)
            {
                Assert.True(iterator.Tick(context) == Node.NodeState.Running);
                Assert.True(iterator.Tick(context) == Node.NodeState.Success);
            }

            CleanUp(context, sequence);
        }

        private static void Setup(out Context context, out Sequence sequence)
        {
            sequence = ScriptableObject.CreateInstance<Sequence>();

            Node[] nodes = new Node[3]
            {
                ScriptableObject.CreateInstance<BehaviourTreeTests.MockLeaf>(),
                ScriptableObject.CreateInstance<BehaviourTreeTests.MockLeaf>(),
                ScriptableObject.CreateInstance<BehaviourTreeTests.MockLeaf>()
            };

            sequence.SetNodes(nodes);

            GameObject gameObject = new GameObject();
            context = new Context(gameObject.AddComponent<TreeTicker>(), gameObject.GetComponent<NavMeshAgent>());
        }

        private static void CleanUp(Context context, Object it)
        {
            Object.DestroyImmediate(context.treeTicker.gameObject);
            Object.DestroyImmediate(it);
        }
    }
}