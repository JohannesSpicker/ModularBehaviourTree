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
        
        private static void Setup(out Context context, out BehaviourTreeTests.MockDecorator decorator)
        {
            decorator = ScriptableObject.CreateInstance<BehaviourTreeTests.MockDecorator>();

            GameObject gameObject = new GameObject();
            context = new Context(gameObject.AddComponent<TreeTicker>(), gameObject.AddComponent<NavMeshAgent>());
        }

        private static void CleanUp(Context context, BehaviourTreeTests.MockLeaf leaf)
        {
            Object.DestroyImmediate(context.treeTicker.gameObject);
            Object.DestroyImmediate(leaf);
        }
    }
}