using System;
using UnityEngine;
using AI.BehaviourTrees;
using Action = AI.BehaviourTrees.Action;

[Serializable]
[NodeDescription(name: "Talk", description: "", story: "[Agent] Says [Sentence]")]
public class TalkAction : Action
{
    public new GameObject Agent;
    public string Sentence;
    public override Status OnUpdate()
    {
        ExampleSystems.Instance.TextSystem.Add(Sentence, Agent);
        return Status.Success;
    }
}
