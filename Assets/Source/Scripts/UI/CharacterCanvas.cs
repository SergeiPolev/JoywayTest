using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(StatusHandler))]
[RequireComponent(typeof(CharacterBase))]
public class CharacterCanvas : MonoBehaviour
{
    [SerializeField] private Transform canvasRoot;
    [SerializeField] private Transform effectsRoot;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private Image effectIconPrefab;

    private StatusHandler statusHandler;
    private CharacterBase characterBase;

    private void Awake()
    {
        statusHandler = GetComponent<StatusHandler>();
        characterBase = GetComponent<CharacterBase>();

        statusHandler.OnEffectUpdate += UpdateUI;
        characterBase.OnHealthChange += UpdateUI;

        canvasRoot.forward = Camera.main.transform.forward;
    }
    private void Start()
    {
        UpdateUI();
    }
    private void UpdateUI()
    {
        if (characterBase.GetAdditionalHealth() > 0)
        {
            healthText.text = $"{characterBase.GetHealth()}<color=green>+{characterBase.GetAdditionalHealth()}</color> / {characterBase.GetMaxHealth()}";
        }
        else
        {
            healthText.text = $"{characterBase.GetHealth()} / {characterBase.GetMaxHealth()}";
        }

        foreach(Transform item in effectsRoot)
        {
            Destroy(item.gameObject);
        }

        var effects = statusHandler.GetEffects();

        foreach (var item in effects)
        {
            var imagePlace = Instantiate(effectIconPrefab, effectsRoot);
            imagePlace.sprite = item.Key.GetIcon();
            imagePlace.color = item.Key.GetColor();
        }
    }
}