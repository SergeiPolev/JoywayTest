using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameCanvas : MonoBehaviour, IStateListener
{
    [SerializeField] private Button skipStepButton;
    [SerializeField] private Button MuteButton;
    [SerializeField] private CanvasGroup skipStepGroup;
    [SerializeField] private FinishPanel finishPanel;
    [SerializeField] private TextMeshProUGUI turnsTitle;

    private Tween turnsTween;

    private void Awake()
    {
        skipStepButton.onClick.AddListener(SkipTurn);
        MuteButton.onClick.AddListener(Mute);
    }
    private void AppearTurnTitle(string text)
    {
        turnsTween.KillTo0();

        turnsTitle.DOFade(0, 0);
        turnsTitle.DOFade(1f, 0.4f);
        turnsTitle.text = text;

        turnsTween = turnsTitle.DOFade(0, 0.4f).SetDelay(2f);
    }
    public void StateChanged(BattleState battleState)
    {
        switch (battleState)
        {
            case BattleState.PLAYER_TURN:
                skipStepGroup.interactable = true;
                skipStepGroup.DOFade(1, 0.4f);

                AppearTurnTitle("YOUR TURN");
                break;
            case BattleState.ENEMY_TURN:
                skipStepGroup.interactable = false;
                skipStepGroup.DOFade(0, 0.4f);

                AppearTurnTitle("<color=red>ENEMY'S TURN</color>");
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
    private void Mute()
    {
        AudioManager._instance.Mute();
    }
}