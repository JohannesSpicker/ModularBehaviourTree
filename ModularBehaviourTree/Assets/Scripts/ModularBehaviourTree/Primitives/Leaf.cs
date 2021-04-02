namespace ModularBehaviourTree
{
    //[CreateAssetMenu(fileName = "FILENAME", menuName = "MENUNAME", order = 0)]
    public abstract class Leaf : Node
    {
        public override IBehaviour CreateIterator() => new OneIterator(this);
    }
}