using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractButton : MonoBehaviour
{
    public void Awake()
    {
        InstanceManager.Instance.interactButton = this;
        gameObject.SetActive(false);
    }
}
