using UnityEngine;

public abstract class ActionBase : ScriptableObject
{
    [SerializeField] private bool forEnemies = true;
    [SerializeField] private Sprite showIcon;
    [SerializeField] private Color showIconColor;

    public bool ForEnemies => forEnemies;
    public Sprite ShowIcon => showIcon;
    public Color ShowIconColor => showIconColor;
    public abstract void DoAction(IActionTarget actionTarget);
}