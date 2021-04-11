using ModularBehaviourTree.Core.Decorators;
using UnityEngine;

namespace ModularBehaviourTree.Construction.Factories.Decorators
{
    [CreateAssetMenu(fileName = "Repeater", menuName = "ModularBehaviourTree/Decorators/Repeater")]
    internal class RepeaterFactory: DecoratorFactory
    {
        [SerializeField] private uint  repetitions;
        public override          Node CreateNode() => new Repeater(nodeFactory.CreateNode(), repetitions);
    }
}