using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsBarControl : MonoBehaviour
{
    private Canvas canvas;

    private Image Health;
    private float CurrentHealth;
    private float MaxHealth;

    private Image Mana;
    private float CurrentMana;
    private float MaxMana;

    private Image Stamina;
    private float CurrentStamina;
    private float MaxStamina;

    Player player;

    private void Start()
    {
        canvas = GetComponent<Canvas>(); 
        Health = canvas.transform.Find("HPBar").GetChild(0).GetComponent<Image>();
        Mana = canvas.transform.Find("MPBar").GetChild(0).GetComponent<Image>();
        Stamina = canvas.transform.Find("StaminaBar").GetChild(0).GetComponent<Image>();
        player = InstanceManager.Instance.player; 
    }

    private void HealthBarUpdate()
    {
        CurrentHealth = player.GetHealth();
        MaxHealth = player.GetMaxHP();
        Health.fillAmount = CurrentHealth / MaxHealth;
    }

    private void ManaBarUpdate()
    {
        CurrentMana = player.GetMana();
        MaxMana = player.GetMaxMana();
        Mana.fillAmount = CurrentMana / MaxMana;
    }

    private void StaminaBarUpdate()
    {
        CurrentStamina = player.GetStamina();
        MaxStamina = player.GetMaxStamina();
        Stamina.fillAmount = CurrentStamina / MaxStamina;
    }

    private void Update()
    {
        HealthBarUpdate();
        ManaBarUpdate();
        StaminaBarUpdate();
        
    }
}
