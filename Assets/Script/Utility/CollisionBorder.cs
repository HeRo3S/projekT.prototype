using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBorder : MonoBehaviour
{
    [SerializeField]
    private GameObject parent;
    [SerializeField]
    private GameObject border;
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreCollision(parent.GetComponent<Collider2D>(), border.GetComponent<Collider2D>());
    }

}
