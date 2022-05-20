using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngameHUDCanvas: MonoBehaviour
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
    bool hasElementsBeenTurnOff;
    private void Start()
    {
        canvas = GetComponent<Canvas>(); 
        Health = canvas.transform.Find("HPBar").GetChild(0).GetComponent<Image>();
        Mana = canvas.transform.Find("MPBar").GetChild(0).GetComponent<Image>();
        Stamina = canvas.transform.Find("StaminaBar").GetChild(0).GetComponent<Image>();
        player = InstanceManager.Instance.player;
        hasElementsBeenTurnOff = false;
    }

    private void DisableUIElementsWhenPlayerDied()
    {
        if (hasElementsBeenTurnOff) return;
        for(int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.name != "SystemTray") { transform.GetChild(i).gameObject.SetActive(false); }
        }
        hasElementsBeenTurnOff = true;
    }

    private void EnableUIElementsWhenPlayerRessurrected()
    {
        if (hasElementsBeenTurnOff == false) return;
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
        hasElementsBeenTurnOff = false;
    }

    private void BarUpdate(float currentStats, float maxValueStatsCanGet, Image imageToFill)
    {
        imageToFill.fillAmount = currentStats / maxValueStatsCanGet;
    }

    private void Update()
    {
        if (player == null)
        {
            DisableUIElementsWhenPlayerDied();
            return;
        }
        //EnableUIElementsWhenPlayerRessurrected();
        BarUpdate(player.GetHealth(), player.GetMaxHP(), Health);
        BarUpdate(player.GetMana(), player.GetMaxMana(), Mana);
        BarUpdate(player.GetStamina(), player.GetMaxStamina(), Stamina);
    }
}
