using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class PaletteSlot : MonoBehaviour
{
    public AbilityBase currentSkill { get; private set; }
    private Image display;
    private TextMeshPro cooldownDisplay;
    public void Awake()
    {
        display = GetComponent<Image>();
        cooldownDisplay = GetComponentInChildren<TextMeshPro>();
    }
    public void Reload()
    {
        display.sprite = currentSkill.GetIcon() as Sprite;
    }
    public void SetSkill(AbilityBase target)
    {
        currentSkill = target;
        Reload();
    }
    public void FixedUpdate()
    {
        currentSkill.DoUpdate();
    }
    public void Update()
    {
        if (currentSkill.CanActive())
        {
            display.color = Color.white;
        }
        else
        {
            display.color = Color.grey;
        }
        if(currentSkill.GetCurrentCD() > 0)
        {
            cooldownDisplay.text = ((int)currentSkill.GetCurrentCD()).ToString();
        }
        else
        {
            //cooldownDisplay.text = null;
        }
    }
}
