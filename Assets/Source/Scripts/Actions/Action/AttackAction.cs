using UnityEngine;

[CreateAssetMenu(menuName = "Game/Actions/Attack")]
public class AttackAction : ActionBase
{
    [SerializeField] private float damage = 3f;

    public override void DoAction(IActionTarget actionTarget)
    {
        actionTarget.ApplyDamage(damage);
    }
}