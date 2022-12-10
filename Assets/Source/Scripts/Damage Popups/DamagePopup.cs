using DG.Tweening;
using TMPro;
using UnityEngine;

public class DamagePopup : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI damageText;
    [SerializeField] private float damageTextOffset = 100f;
    [SerializeField] private float damageTextDuration = 1f;

    public void Init(float damage)
    {
        damageText.text = damage > 0 ? $"-{damage}" : $"<color=green>+{-damage}</color>";

        damageText.DOFade(0, damageTextDuration / 2f).SetDelay(damageTextDuration / 2f).OnComplete(() => Destroy(gameObject));
        damageText.transform.DOMoveY(damageText.transform.position.y + damageTextOffset, damageTextDuration / 2f);
    }
}