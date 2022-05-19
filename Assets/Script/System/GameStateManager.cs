using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Enumeration;
using UnityEngine.AddressableAssets;

public class GameStateManager : MonoBehaviour
{
    private static GameStateManager _instance;
    private GameState state;
    private string lastSceneName;
    private string currentSceneName;

    // Start is called before the first frame update

    public static GameStateManager Instance
    {
        get
        {
            if (_instance == null)
            {
                var op = Addressables.LoadAssetAsync<GameObject>("PrefabGameStateManager");
                _instance = Instantiate(op.WaitForCompletion()).GetComponent<GameStateManager>();
                Addressables.Release(op);
            }
            return _instance;
        }
    }
    private void Awake()
    {
        //Singleton
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(this);

    }
    void Start()
    {
        SetCurrentSceneName(ScenesController.Instance.CurrentSceneName());
    }

    public void UpdateGameState()
    {
        //??? For some reason after player died InstanceManager.Instance.player won't be null????
        if (InstanceManager.Instance.player == null)
        {
            state = GameState.INGAME_PLAYER_DIED;
            return;
        }
       
        switch(currentSceneName)
        {
            case "TitleScene":
                state = GameState.IN_MAINMENU;
                break;
            case "Ingame":
                if (InstanceManager.Instance.canvasController.IsCanvasActive("IngameHUDCanvas")) 
                {
                    state = GameState.INGAME_NORMAL;
                } else if (InstanceManager.Instance.canvasController.IsCanvasActive("DiedDialogue"))
                {
                    state = GameState.INGAME_PLAYER_DIED;
                }
                else { state = GameState.INGAME_UI_OPEN; }
                break;
            default:
                Debug.Log("Bug when setup game state");
                break;
        }
        Debug.Log(state);
    }

    public void SwitchToStateTitleScreen()
    {
        state = GameState.IN_MAINMENU;
    }

    public void SwitchToStateIngame()
    {
        state = GameState.INGAME_NORMAL;
        Time.timeScale = 1f;
    }

    public void SwitchToStateIngameMenuOpened()
    {
        state = GameState.INGAME_UI_OPEN;
        Time.timeScale = 0f;
    }

    public void SwitchToStateIngamePlayerDied()
    {
        state = GameState.INGAME_PLAYER_DIED;
    }

    public GameState GetGameState()
    {
        return state;
    }

    public void SetCurrentSceneName(string name)
    {
        if(currentSceneName != null) lastSceneName = currentSceneName;
        currentSceneName = name;
        if (currentSceneName != lastSceneName) { UpdateGameState(); }
    }
}
