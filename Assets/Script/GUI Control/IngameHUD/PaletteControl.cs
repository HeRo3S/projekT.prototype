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
        skillList.Add((AbilityBase)AssetLoader.LoadScriptable("Ability/Sorcery/Heal"));
        skillList.Add((AbilityBase)AssetLoader.LoadScriptable("Ability/Mastery/Dash"));
        skillList.Add((AbilityBase)AssetLoader.LoadScriptable("Ability/Mastery/ArrowWave"));
        skillList.Add((AbilityBase)AssetLoader.LoadScriptable("Ability/Sorcery/Rumble"));
        for (int i = 0; i < skillObjList.Capacity; i++)
        {
            PaletteSlot paletteSlot = skillObjList[i].GetComponent<PaletteSlot>();
            paletteSlot.SetSkill(skillList[i]);
            paletteList.Add(paletteSlot);
        }
        InstanceManager.Instance.currentSkillList = skillList;
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
        paletteList[0].CurrentSkill.Active();
    }
    private void SkillPalette2_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        paletteList[1].CurrentSkill.Active();
    }
    private void SkillPalette3_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        paletteList[2].CurrentSkill.Active();
    }
    private void SkillPalette4_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        paletteList[3].CurrentSkill.Active();
    }


    //Update skill list
    public void FixedUpdate()
    {
        foreach(AbilityBase ability in skillList)
        {
            ability.DoUpdate();
        }
    }
}