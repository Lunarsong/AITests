using System;
using UnityEngine;
using AI.BehaviourTrees;
using Action = AI.BehaviourTrees.Action;

[Serializable]
[NodeDescription(name: "Set String", description: "", story: "Set [StringVar] To [StringVal]")]
public class SetStringAction : Action
{
    public string StringVar;
    public string StringVal;
    public override Status OnUpdate()
    {
        StringVar = StringVal;
        return Status.Success;
    }
}
