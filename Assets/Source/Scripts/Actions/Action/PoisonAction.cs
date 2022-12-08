using UnityEngine;

[CreateAssetMenu(menuName = "Game/Actions/Poison")]
public class PoisonAction : ActionBase
{
    [SerializeField] private float damage = 1f;
    [SerializeField] private float periodicDamge = 1f;
    [SerializeField] private int duration = 1;

    public override void DoAction(IActionTarget actionTarget)
    {
        var poisonEffect = new PoisonEffect(actionTarget, periodicDamge, duration, ShowIcon);
        actionTarget.ApplyDamage(damage);
        actionTarget.ApplyEffect(poisonEffect);
    }
}