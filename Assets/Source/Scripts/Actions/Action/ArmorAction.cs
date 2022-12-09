using UnityEngine;

[CreateAssetMenu(menuName = "Game/Actions/Armor")]
public class ArmorAction : ActionBase
{
    [SerializeField] private float health;
    [SerializeField] private int duration;

    public override void DoAction(IActionTarget actionTarget)
    {
        base.DoAction(actionTarget);

        AudioManager._instance.PlayOneShot(AudioManager._instance.SoundsLibrary.ArmorSound, 1f);
        actionTarget.ApplyEffect(new ArmorEffect(actionTarget, health, duration, ShowIcon, tickOnEnd, showIconColor));
    }
}