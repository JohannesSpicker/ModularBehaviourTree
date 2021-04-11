using ModularBehaviourTree;
using NUnit.Framework;
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
            decorator = new MockDecorator();

            GameObject gameObject = new GameObject();
            context = new Context(gameObject.AddComponent<TreeTicker>(), gameObject.AddComponent<NavMeshAgent>());
        }

        private static void CleanUp(Context context) => Object.DestroyImmediate(context.treeTicker.gameObject);
    }
}