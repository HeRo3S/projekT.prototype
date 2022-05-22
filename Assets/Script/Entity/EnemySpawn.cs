using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    private EnemyBase spawnedEnemy;
    [SerializeField]
    private float respawnTime;
    private float respawnCounter;
    [SerializeField]
    private float recheckTime;
    private float recheckCounter;
    [SerializeField]
    private float requiredSpaceRadius;

    public void Update()
    {
        if(respawnCounter <= 0 && recheckCounter <= 0)
        {
            Collider2D[] overlap = new Collider2D[1];
            Physics2D.OverlapCircle(transform.position, requiredSpaceRadius, InstanceManager.Instance.groundEntityFilter, overlap);
            if (overlap[0] == null)
            {
                spawnedEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity).GetComponent<EnemyBase>();
                respawnCounter = respawnTime;
            }
            else
            {
                recheckCounter = recheckTime;
            }
        }
        if (spawnedEnemy == null)
        {
            if (respawnCounter <= 0 && recheckCounter <= 0)
            {
                respawnCounter = respawnTime;
            }
            if (respawnCounter > 0)
            {
                respawnCounter -= Time.deltaTime;
            }
        }

        if(recheckCounter > 0)
        {
            recheckCounter -= Time.deltaTime;
        }
    }
}
