using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Enumeration;
using UnityEngine.AddressableAssets;

public class GameStateManager : MonoBehaviour
{
    private static GameStateManager _instance;
    private GameState state;

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
        UpdateGameState();
    }

    void UpdateGameState()
    {
        state = ScenesController.Instance.CurrentSceneName() switch
        {
            "TitleScene" => GameState.IN_MAINMENU,
            "Ingame" => GameState.INGAME_NORMAL,
            _ => GameState.IN_MAINMENU,
        };
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

    public GameState GetGameState()
    {
        return state;
    }
}
