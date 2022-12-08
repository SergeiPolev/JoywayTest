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

        canvasRoot.forward = Camera.main.transform.forward;
    }

    private void UpdateUI()
    {
        healthText.text = $"{characterBase.GetHealth()} / {characterBase.GetMaxHealth()}";

        foreach(Transform item in effectsRoot)
        {
            Destroy(item.gameObject);
        }

        var effects = statusHandler.GetEffects();

        foreach (var item in effects)
        {
            var imagePlace = Instantiate(effectIconPrefab, effectsRoot);
            imagePlace.sprite = item.Key.GetIcon();
        }
    }
}