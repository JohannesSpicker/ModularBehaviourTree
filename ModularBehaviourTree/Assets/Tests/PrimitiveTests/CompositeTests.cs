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
        public void SequenceShouldReturnRunningOnFirstThreeTicks([Values(0, 1, 2)] int extraTicks)
        {
            Setup(out Context context, out Sequence sequence);

            for (int i = 0; i < extraTicks; i++)
                sequence.Tick(context);

            Assert.True(sequence.Tick(context) == Node.NodeState.Running);

            CleanUp(context);
        }

        [Test]
        public void SequenceShouldReturnSuccessOnFourthTick()
        {
            Setup(out Context context, out Sequence sequence);

            for (int i = 0; i < 3; i++)
                sequence.Tick(context);

            Assert.True(sequence.Tick(context) == Node.NodeState.Success);

            CleanUp(context);
        }

        private static void Setup(out Context context, out Sequence sequence)
        {
            Node[] nodes = new Node[3]
            {
                new BehaviourTreeTests.MockLeaf(), new BehaviourTreeTests.MockLeaf(),
                new BehaviourTreeTests.MockLeaf()
            };

            sequence = new Sequence(nodes);

            GameObject gameObject = new GameObject();
            context = new Context(gameObject.AddComponent<TreeTicker>(), gameObject.GetComponent<NavMeshAgent>());
        }

        private static void CleanUp(Context context) => Object.DestroyImmediate(context.treeTicker.gameObject);
    }
}