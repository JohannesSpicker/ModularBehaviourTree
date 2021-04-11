using ModularBehaviourTree;
using NUnit.Framework;
using TreeTickerSpace;
using UnityEngine;
using UnityEngine.AI;

namespace Tests.PrimitiveTests
{
    public class DecoratorTests
    {
        [Test]
        public void SomeDecoratorTest()
        {
            //Setup();
        }

        private static void Setup(out Context context, out MockDecorator decorator)
        {
            decorator = new MockDecorator(new MockPrimitives.MockLeaf());

            GameObject gameObject = new GameObject();
            context = new Context(gameObject.AddComponent<TreeTicker>(), gameObject.AddComponent<NavMeshAgent>(), gameObject.transform);
        }

        private static void CleanUp(Context context) => Object.DestroyImmediate(context.treeTicker.gameObject);
    }
}