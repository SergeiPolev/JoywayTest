using UnityEngine;

[CreateAssetMenu(menuName = "Game/Actions/Attack")]
public class AttackAction : ActionBase
{
    [SerializeField] private float damage = 3f;

    public override void DoAction(IActionTarget actionTarget)
    {
        base.DoAction(actionTarget);

        AudioManager._instance.PlayOneShot(AudioManager._instance.SoundsLibrary.AttackSound, 1f);
        actionTarget.ApplyDamage(damage);
    }
}