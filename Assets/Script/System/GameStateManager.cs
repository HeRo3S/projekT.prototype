using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    private GameStateManager _instance;
    private enum gameState {inTitleMenu, inGame, ingameMenuOpened}
    private gameState state;

    // Start is called before the first frame update

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
        InstanceManager.Instance.gameStateManager= this;

    }
    void Start()
    {
        UpdateGameState();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateGameState()
    {
        switch (ScenesController.Instance.CurrentSceneName())
        {
            case "TitleScene":
                state = gameState.inTitleMenu;
                break;
            case "Ingame":
                state = gameState.inTitleMenu;
                break;
            default:
                state = gameState.inTitleMenu;
                break;
        }
    }

    public void SwitchToStateTitleScreen()
    {
        state = gameState.inTitleMenu;
    }

    public void SwitchToStateIngame()
    {
        state = gameState.inGame;
        Time.timeScale = 1f;
    }

    public void SwitchToStateIngameMenuOpened()
    {
        state = gameState.ingameMenuOpened;
        Time.timeScale = 0f;
    }

    public int GetGameState()
    {
        return (int)state;
    }
}
