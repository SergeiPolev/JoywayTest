using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ActionHolder : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerMoveHandler
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    
    private ActionBase action;
    private Vector3 initPosition;

    private bool isHandling;

    private const int GroundLayer = 1 << 8;
    private const int EnemyLayer = 1 << 9;

    public event Action OnActionDo;

    private void Awake()
    {
        
    }
    public void Init(ActionBase action)
    {
        this.action = action;

        initPosition = transform.position;
        spriteRenderer.color = action.ShowIconColor;
        spriteRenderer.sprite = action.ShowIcon;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isHandling = false;

        var mousePos = Input.mousePosition;

        var ray = Camera.main.ScreenPointToRay(mousePos);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, EnemyLayer))
        {
            var target = hit.transform.GetComponent<CharacterBase>();

            if (action.ForEnemies ^ target.GetTeamSide() == TeamSide.Player)
            {
                action.DoAction(target);
                OnActionDo?.Invoke();

                Destroy(gameObject);

                return;
            }
        }

        transform.position = initPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isHandling = true;
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        if (isHandling)
        {
            var mousePos = Input.mousePosition;

            var ray = Camera.main.ScreenPointToRay(mousePos);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, GroundLayer))
            {
                transform.position = hit.point;
            }
        }
    }
}
