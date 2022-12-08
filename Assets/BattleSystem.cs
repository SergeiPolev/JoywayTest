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
                playerTeam.StartTurn();
                break;
            case BattleState.ENEMY_TURN:
                enemyTeam.StartTurn();
                playerTeam.OnEndTurn?.Invoke();
                break;
            case BattleState.WIN:
                break;
            case BattleState.LOSE:
                break;
            default:
                break;
        }
    }
}