using UnityEngine;

[CreateAssetMenu(menuName = "Game/Actions/Poison")]
public class PoisonAction : ActionBase
{
    [SerializeField] private float damage = 1f;
    [SerializeField] private float periodicDamge = 1f;
    [SerializeField] private int duration = 1;

    public override void DoAction(IActionTarget actionTarget)
    {
        base.DoAction(actionTarget);

        var poisonEffect = new PoisonEffect(actionTarget, periodicDamge, duration, ShowIcon, tickOnEnd);
        actionTarget.ApplyEffect(poisonEffect);
    }
}