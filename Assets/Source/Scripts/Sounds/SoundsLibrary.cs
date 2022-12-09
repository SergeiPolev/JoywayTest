using UnityEngine;

[CreateAssetMenu(menuName = "Game/Sounds Library")]
public class SoundsLibrary : ScriptableObject
{
    [field: SerializeField] public AudioClip PickUpSound { get; private set; }
    [field: SerializeField] public AudioClip PutDownSound { get; private set; }
    [field: SerializeField] public AudioClip HealSound { get; private set; }
    [field: SerializeField] public AudioClip ArmorSound { get; private set; }
    [field: SerializeField] public AudioClip PoisonSound { get; private set; }
    [field: SerializeField] public AudioClip AttackSound { get; private set; }
    [field: SerializeField] public AudioClip MusicSound { get; private set; }
    [field: SerializeField] public AudioClip ClickSound { get; private set; }
    [field: SerializeField] public AudioClip NextTurnSound { get; private set; }
}