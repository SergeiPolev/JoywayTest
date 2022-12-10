using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishPanel : MonoBehaviour
{
    [SerializeField] private CanvasGroup finishPanel;
    [SerializeField] private TextMeshProUGUI finishTitle;
    [SerializeField] private Button restartButton;

    private void Awake()
    {
        restartButton.onClick.AddListener(() => SceneManager.LoadScene(0));
    }

    public void Win()
    {
        EnablePanel();
        finishTitle.text = "YOU WON";
    }
    public void Lose()
    {
        EnablePanel();
        finishTitle.text = "YOU LOSE";
    }
    private void EnablePanel()
    {
        finishPanel.interactable = true;
        finishPanel.blocksRaycasts = true;
        finishPanel.DOFade(1, 0.5f);
    }
}