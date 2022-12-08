using UnityEngine;

public class BattleSystem : MonoBehaviour, IStateListener
{
    [SerializeField] private TeamBase playerTeam;
    [SerializeField] private TeamBase enemyTeam;

    [SerializeField] private ActionBase[] enemyActions;
    [SerializeField] private ActionBase[] playerActions;

    [Header("Debug")]
    [SerializeField] private ActionHolder actionHolder;
    [SerializeField] private ActionHolder actionHolderTwo;

    private void Start()
    {
        /// Debug
        actionHolder.Init(playerActions[0]);
        actionHolderTwo.Init(playerActions[1]);

        InitTeams();

        enemyTeam.OnEndTurn += () => BattleStateSystem._instance.ChangeState(BattleState.PLAYER_TURN);

        playerTeam.OnLose += FinishGame;
        enemyTeam.OnLose += FinishGame;
    }

    private void InitTeams()
    {
        playerTeam.Init(playerActions);

        enemyTeam.Init(enemyActions);
    }
    
    private void FinishGame(TeamSide loseSide)
    {
        switch (loseSide)
        {
            case TeamSide.Player:
                BattleStateSystem._instance.ChangeState(BattleState.WIN);
                break;
            case TeamSide.Enemy:
                BattleStateSystem._instance.ChangeState(BattleState.LOSE);
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