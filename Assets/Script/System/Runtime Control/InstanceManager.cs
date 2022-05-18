using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class InstanceManager : MonoBehaviour
{
    private static InstanceManager _instance;
    public static InstanceManager Instance
    {
        get
        {
            if (_instance == null)
            {
                var op = Addressables.LoadAssetAsync<GameObject>("PrefabInstanceManager");
                _instance = Instantiate(op.WaitForCompletion()).GetComponent<InstanceManager>();
                Addressables.Release(op);
            }
            return _instance;
        }
    }
    public void Awake()
    {
        mainCamera = Camera.main;
        inputSystem = new PlayerInputSystem();
        DontDestroyOnLoad(gameObject);
    }

    public void Reload()
    {
        _instance = null;
    }
    public PlayerInputSystem inputSystem;
    public Camera mainCamera;
    public Player player;
    public ContactFilter2D groundEntityFilter;
    public List<AbilityBase> currentSkillList;
    public Inventory currentInventory;
    public DialogueManager dialogueManager;
    public CanvasController canvasController;
    public InteractButton interactButton;
}
