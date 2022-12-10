using UnityEngine;

public class BattleSystem : MonoBehaviour, IStateListener
{
    [SerializeField] private PlayerTeam playerTeam;
    [SerializeField] private EnemyTeam enemyTeam;

    [SerializeField] private ActionBase[] enemyActions;
    [SerializeField] private ActionBase[] playerActions;

    private void Start()
    {
        InitTeams();

        enemyTeam.OnEndTurn += () => BattleStateSystem._instance.ChangeState(BattleState.PLAYER_TURN);

        playerTeam.OnLose += FinishGame;
        enemyTeam.OnLose += FinishGame;
    }

    private void InitTeams()
    {
        playerTeam.Init(playerActions);

        enemyTeam.Init(enemyActions, playerTeam.GetCharacters());
    }
    
    private void FinishGame(TeamSide loseSide)
    {
        switch (loseSide)
        {
            case TeamSide.Player:
                BattleStateSystem._instance.ChangeState(BattleState.LOSE);
                break;
            case TeamSide.Enemy:
                BattleStateSystem._instance.ChangeState(BattleState.WIN);
                break;
            default:
                break;
        }
    }

    public void StateChanged(BattleState battleState)
    {
        switch (battleState)
        {
            case BattleState.PLAYER_TURN:
                AudioManager._instance.PlayOneShot(AudioManager._instance.SoundsLibrary.NextTurnSound, 1f);
                playerTeam.StartTurn();
                break;
            case BattleState.ENEMY_TURN:
                AudioManager._instance.PlayOneShot(AudioManager._instance.SoundsLibrary.NextTurnSound, 1f);
                playerTeam.OnEndTurn?.Invoke();
                enemyTeam.StartTurn();
                break;
            case BattleState.WIN:
                AudioManager._instance.PlayOneShot(AudioManager._instance.SoundsLibrary.NextTurnSound, 1f);
                break;
            case BattleState.LOSE:
                AudioManager._instance.PlayOneShot(AudioManager._instance.SoundsLibrary.NextTurnSound, 1f);
                break;
            default:
                break;
        }
    }
}