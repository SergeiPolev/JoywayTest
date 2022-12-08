using UnityEngine;

[CreateAssetMenu(menuName = "Game/Actions/Armor")]
public class ArmorAction : ActionBase
{
    [SerializeField] private float health;
    [SerializeField] private int duration;

    public override void DoAction(IActionTarget actionTarget)
    {
        base.DoAction(actionTarget);

        actionTarget.ApplyEffect(new ArmorEffect(actionTarget, health, duration, ShowIcon, tickOnEnd));
    }
}