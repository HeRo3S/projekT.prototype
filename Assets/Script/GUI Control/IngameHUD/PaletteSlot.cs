using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class PaletteSlot : MonoBehaviour
{
    public AbilityBase currentSkill { get; private set; }
    private Image display;
    private TextMeshProUGUI cooldownNumber;
    private Image cooldownOverlay;
    public void Awake()
    {
        display = GetComponent<Image>();
        cooldownNumber = GetComponentInChildren<TextMeshProUGUI>();
        cooldownOverlay = transform.GetChild(0).GetComponent<Image>();
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
            cooldownNumber.text = ((int)currentSkill.GetCurrentCD() + 1).ToString();
        }
        else
        {
            cooldownNumber.text = null;
        }
        cooldownOverlay.fillAmount = currentSkill.GetCurrentCD() / currentSkill.GetCooldown();
    }
}
