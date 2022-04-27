using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image Health;
    public float CurrentHealth;
    public float MaxHealth;
    Player player;

    private void Start()
    {
        Health = GetComponent<Image>();
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        CurrentHealth = player.GetHealth();
        MaxHealth = player.GetMaxHP();
        Health.fillAmount = CurrentHealth / MaxHealth;
    }
}
