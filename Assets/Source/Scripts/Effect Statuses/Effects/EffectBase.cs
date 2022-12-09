using UnityEngine;

public abstract class EffectBase
{
    internal int duration = 1;
    internal IActionTarget target;
    internal Sprite icon;
    internal Color showColor;
    internal bool tickOnEnd;

    public EffectBase(IActionTarget target, int duration, Sprite showIcon, bool tickOnEnd, Color color)
    {
        this.duration = duration;
        this.target = target;
        icon = showIcon;
        showColor = color;
        this.tickOnEnd = tickOnEnd;
    }

    public virtual int GetEffectTurns() => duration; 
    public virtual Sprite GetIcon() => icon; 
    public virtual Color GetColor() => showColor; 

    public abstract void OnEffectStart();
    public abstract void TickEffect();
    public abstract void OnEffectCancel();
    public virtual void OnEffectEnd()
    {
        target.ClearEffect(this);
    }
}