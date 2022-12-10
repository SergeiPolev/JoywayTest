using UnityEngine;

public class PopupDamageTextHandler : MonoBehaviour
{
    [SerializeField] private DamagePopup damagePopup;
    [SerializeField] private Transform rootCanvas;

    public static PopupDamageTextHandler _instance;

    private void Awake()
    {
        _instance = this;    
    }
    public void SpawnPopup(Vector3 worldPos, float damage)
    {
        var screenPoint = Camera.main.WorldToScreenPoint(worldPos);

        var popup = Instantiate(damagePopup, screenPoint, Quaternion.identity, rootCanvas);
        popup.Init(damage);
    }
}