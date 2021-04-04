using System;
using UnityEngine;
using AI.BehaviourTrees;
using Action = AI.BehaviourTrees.Action;

[Serializable]
[NodeDescription(name: "Move", description: "", story: "[Agent] moves to [location]")]
public class MoveAction : Action
{
    public GameObject Agent;
    public Transform Location;
    public override Status OnUpdate()
    {
        return Status.Success;
    }
}
