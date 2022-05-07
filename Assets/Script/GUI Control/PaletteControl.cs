using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaletteControl : MonoBehaviour
{
    [SerializeField]
    protected List<GameObject> skillObjList;
    protected List<PaletteSlot> paletteList = new List<PaletteSlot>();
    protected List<AbilityBase> skillList = new List<AbilityBase>();
    public void Start()
    {
        skillList.Add(ScriptableObject.CreateInstance<Heal>());
        foreach(GameObject palette in skillObjList)
        {
            PaletteSlot paletteSlot = palette.GetComponent<PaletteSlot>();
            paletteSlot.SetSkill(skillList[0]);
            paletteList.Add(paletteSlot);
        }
        //Subscrible to control event
        PlayerInputSystem inputSytem = InstanceManager.Instance.inputSystem;
        inputSytem.Enable();
        inputSytem.Player.SkillPalette1.started += SkillPalette1_started;
        inputSytem.Player.SkillPalette2.started += SkillPalette2_started;
        inputSytem.Player.SkillPalette3.started += SkillPalette3_started;
        inputSytem.Player.SkillPalette4.started += SkillPalette4_started;

    }

    private void SkillPalette1_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        paletteList[0].currentSkill.Active();
    }
    private void SkillPalette2_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        paletteList[1].currentSkill.Active();
    }
    private void SkillPalette3_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        paletteList[2].currentSkill.Active();
    }
    private void SkillPalette4_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        paletteList[3].currentSkill.Active();
    }
}