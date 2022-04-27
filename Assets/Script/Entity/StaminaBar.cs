using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    private Image Stamina;
    Player player;

    private void Start()
    {
        Stamina = GetComponent<Image>();
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
    }
}

