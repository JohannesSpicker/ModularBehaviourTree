using UnityEngine;

namespace ModularBehaviourTree.Core.Conditions
{
    public class IsInRange : Condition
    {
        private readonly float range;

        public IsInRange(float range) { this.range = range; }

        protected override void Initialise(Context context) { }
        protected override void Terminate(Context  context) { }

        protected override bool Check(Context context) => context.target != null
                                                          && Vector3.Distance(context.treeTicker.transform.position,
                                                                              context.target.position) < range;
    }
}