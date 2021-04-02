using System;
using ModularBehaviourTree.Iterators;
using UnityEngine;

namespace ModularBehaviourTree
{
    //[CreateAssetMenu(fileName = "FILENAME", menuName = "MENUNAME", order = 0)]
    /// <summary>
    ///     A decorator node, like a composite node, can have a child node. Unlike a composite node, they can specifically only
    ///     have a single child. Their function is either to transform the result they receive from their child node's status,
    ///     to terminate the child, or repeat processing of the child, depending on the type of decorator node.
    ///     A commonly used example of a decorator is the Inverter, which will simply invert the result of the child. A child
    ///     fails and it will return success to its parent, or a child succeeds and it will return failure to the parent.
    /// </summary>
    public abstract class Decorator : Node
    {
        [SerializeField] protected Node node;

        public override IBehaviour CreateIterator()            => new OneIterator(this);
        public override void      Initialise(Context context) => node.Initialise(context);
        public override NodeState Tick(Context       context) => node.Tick(context);
    }
}