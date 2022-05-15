using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class PaletteSlot : MonoBehaviour
{
    public AbilityBase CurrentSkill { get; private set; }
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
        display.sprite = CurrentSkill.GetIcon() as Sprite;
    }
    public void SetSkill(AbilityBase target)
    {
        CurrentSkill = target;
        Reload();
    }
    public void Update()
    {
        if (CurrentSkill.CanActive())
        {
            display.color = Color.white;
        }
        else
        {
            display.color = Color.grey;
        }
        if(CurrentSkill.GetCurrentCD() > 0)
        {
            cooldownNumber.text = ((int)CurrentSkill.GetCurrentCD() + 1).ToString();
        }
        else
        {
            cooldownNumber.text = null;
        }
        cooldownOverlay.fillAmount = CurrentSkill.GetCurrentCD() / CurrentSkill.GetCooldown();
    }
}
