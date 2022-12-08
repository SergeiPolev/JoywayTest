using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class GameCanvas : MonoBehaviour, IStateListener
{
    [SerializeField] private Button skipStepButton;
    [SerializeField] private FinishPanel finishPanel;

    private void Awake()
    {
        skipStepButton.onClick.AddListener(SkipTurn);
    }
    public void StateChanged(BattleState battleState)
    {
        switch (battleState)
        {
            case BattleState.PLAYER_TURN:
                skipStepButton.interactable = true;
                skipStepButton.image.DOFade(1, 0.4f);
                break;
            case BattleState.ENEMY_TURN:
                skipStepButton.interactable = false;
                skipStepButton.image.DOFade(0, 0.4f);
                break;
            case BattleState.WIN:
                finishPanel.Win();
                break;
            case BattleState.LOSE:
                finishPanel.Lose();
                break;
            default:
                break;
        }
    }

    private void SkipTurn()
    {
        BattleStateSystem._instance.ChangeState(BattleState.ENEMY_TURN);
    }
}