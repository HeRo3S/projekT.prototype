using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    private Image Mana;
    public float CurrentMana;
    public float MaxMana;
    Player player;

    private void Start()
    {
        Mana = GetComponent<Image>();
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        CurrentMana = player.GetMana();
        MaxMana = player.GetMaxMana();
        Mana.fillAmount = CurrentMana / MaxMana;
    }
}
