using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ActionHolder : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    
    private ActionBase action;
    private Vector3 initPosition;

    public event Action OnActionDo;


    public void Init(ActionBase action)
    {
        this.action = action;

        initPosition = transform.position;
        spriteRenderer.color = action.ShowIconColor;
        spriteRenderer.sprite = action.ShowIcon;
    }

    public bool CanDoAction(CharacterBase target)
    {
        return action.ForEnemies ^ target.GetTeamSide() == TeamSide.Player;
    }
    public void ActivateHolder(CharacterBase target)
    {
        action.DoAction(target);
        OnActionDo?.Invoke();
    }
    public void ReturnHolder()
    {
        transform.position = initPosition;

        AudioManager._instance.PlayOneShot(AudioManager._instance.SoundsLibrary.PutDownSound, 1f);
    }
}