using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PaletteSlot : MonoBehaviour
{
    public AbilityBase currentSkill { get; private set; }
    private Image display;
    public void Awake()
    {
        display = GetComponent<Image>();
    }
    public void Reload()
    {
        display = currentSkill.GetIcon();
    }
    public void SetSkill(AbilityBase target)
    {
        currentSkill = target;
        Reload();
    }
}
