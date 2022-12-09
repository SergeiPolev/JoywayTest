using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum BattleState
{
    PLAYER_TURN,
    ENEMY_TURN,
    WIN,
    LOSE
}

public class BattleStateSystem : MonoBehaviour
{
    private BattleState currentState;

    private IStateListener[] listeners;

    private event Action<BattleState> OnStateChange;


    public static BattleStateSystem _instance;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        listeners = FindObjectsOfType<MonoBehaviour>().OfType<IStateListener>().ToArray();

        foreach (IStateListener item in listeners)
        {
            OnStateChange += item.StateChanged;
        }

        ChangeState(BattleState.PLAYER_TURN);
    }
    private void Update()
    {
        if (currentState == BattleState.PLAYER_TURN && Input.GetKeyDown(KeyCode.Space))
        {
            ChangeState(BattleState.ENEMY_TURN);

            AudioManager._instance.PlayOneShot(AudioManager._instance.SoundsLibrary.ClickSound, 1f);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }
    public void ChangeState(BattleState battleState)
    {
        currentState = battleState;

        Debug.Log($"Current state: {currentState}");

        OnStateChange?.Invoke(currentState);
    }
}