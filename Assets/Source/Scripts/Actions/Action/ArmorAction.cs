using UnityEngine;

[CreateAssetMenu(menuName = "Game/Actions/Armor")]
public class ArmorAction : ActionBase
{
    [SerializeField] private float health;
    [SerializeField] private int duration;

    public override void DoAction(IActionTarget actionTarget)
    {
        actionTarget.ApplyAdditionalHeal(health);

        actionTarget.ApplyEffect(new ArmorEffect(actionTarget, duration, ShowIcon));
    }
}