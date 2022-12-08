using UnityEngine;

public abstract class EffectBase
{
    internal int duration = 1;
    internal IActionTarget target;
    internal Sprite icon;

    public EffectBase(IActionTarget target, int duration, Sprite showIcon)
    {
        this.duration = duration;
        this.target = target;
        icon = showIcon;
    }

    public virtual int GetEffectTurns() => duration; 
    public virtual Sprite GetIcon() => icon; 
    public abstract void OnEffectStart();
    public abstract void TickEffect();
    public abstract void OnEffectCancel();
    public virtual void OnEffectEnd()
    {
        target.ClearEffect(this);
    }
}