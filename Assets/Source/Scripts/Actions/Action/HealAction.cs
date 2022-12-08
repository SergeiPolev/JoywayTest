using UnityEngine;

[CreateAssetMenu(menuName = "Game/Actions/Heal")]
public class HealAction : ActionBase
{
    [SerializeField] private float heal = 3f;

    public override void DoAction(IActionTarget actionTarget)
    {
        base.DoAction(actionTarget);

        actionTarget.ApplyHeal(heal);
        actionTarget.ClearEffect(new PoisonEffect(null, 0, 0, ShowIcon, false));
    }
}