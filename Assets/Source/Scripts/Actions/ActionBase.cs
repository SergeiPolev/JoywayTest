using UnityEngine;

public abstract class ActionBase : ScriptableObject
{
    [SerializeField] internal bool forEnemies = true;
    [SerializeField] internal bool tickOnEnd = false;
    [SerializeField] internal Sprite showIcon;
    [SerializeField] internal GameObject vfx;
    [SerializeField] internal Color showIconColor;

    public bool ForEnemies => forEnemies;
    public Sprite ShowIcon => showIcon;
    public Color ShowIconColor => showIconColor;
    public virtual void DoAction(IActionTarget actionTarget)
    {
        MakeVFX(actionTarget);
    }

    internal virtual void MakeVFX(IActionTarget actionTarget)
    {
        VisualEffectsExtension.SpawnSingleVFX(vfx, actionTarget.gameObject.transform.position + Vector3.up, 2f);
    }
}