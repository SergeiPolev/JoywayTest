using UnityEngine;
public class ArmorEffect : EffectBase
{
    public ArmorEffect(IActionTarget target, int duration, Sprite sprite) : base(target, duration, sprite)
    {

    }

    public override void OnEffectCancel()
    {
        target.ClearAdditionalHeal();
    }

    public override void OnEffectStart()
    {

    }

    public override void TickEffect()
    {
        
    }
}