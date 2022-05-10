using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ArrowWave", menuName = "Resources/Ability/Mastery/ArrowWave", order = 0)]
public class ArrowWave : AbilityBase
{
    [SerializeField]
    private int arrowAmount;
    [SerializeField]
    private float firingArc;
    [SerializeField]
    private float timeToLive;
    [SerializeField]
    private float speed;
    public override void Active()
    {
        if (CanActive())
        {
            Player player = InstanceManager.Instance.player;
            base.Active();
            player.Move(Vector2.zero);
            player.UpdateRotation();
            float startRotation = player.GetRotation() - firingArc / 2;
            float increaseRotation = firingArc / arrowAmount;
            for(int i = 0; i < arrowAmount; i++)
            {
                Arrow arrow = Instantiate(AssetManager.Instance.pfArrow, player.transform.position, Quaternion.identity).GetComponent<Arrow>();
                arrow.InitValue(speed,startRotation + i *  increaseRotation, timeToLive, strikePotency);
            }
        }
    }
}
