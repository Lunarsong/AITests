using System;
using UnityEngine;
using AI.BehaviourTrees;
using Action = AI.BehaviourTrees.Action;

[Serializable]
[NodeDescription(name: "Wait", description: "", story: "Wait for [SecondsToWait] Seconds")]
public class WaitAction : Action
{
    public float SecondsToWait;
    float m_Timer = 0.0f;

    public override void OnStart()
    {
        m_Timer = 0.0f;
    }
    public override Status OnUpdate()
    {
        m_Timer += Time.deltaTime;
        if (m_Timer >= SecondsToWait)
        {
            return Status.Success;
        }
        return Status.Running;
    }
}
