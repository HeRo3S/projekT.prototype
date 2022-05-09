using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dash", menuName = "Resources/Ability/Mastery/Dash", order = 0)]
public class Dash : AbilityBase
{
    [SerializeField]
    private float executionTime;
    private float executingTime;
    [SerializeField]
    private float speedModification;
    public override void Active()
    {
        if (CanActive())
        {
            Player player = InstanceManager.Instance.player;
            base.Active();
            player.Move(Vector2.zero);
            player.UpdateRotation();
            player.Move(player.GetDirection() * speedModification);
            player.StartPhasing();
            player.inAttackAnimation = true;
            executingTime = executionTime;
        }
    }
    public override void DoUpdate()
    {
        base.DoUpdate();
        if(executingTime <= 0 && executingTime != -1)
        {
            Player player = InstanceManager.Instance.player;
            player.inAttackAnimation = false;
            player.EndPhasing();
            executingTime = -1;
        }
        else if (executingTime > 0)
        {
            executingTime-= Time.fixedDeltaTime;
        }
    }
}
