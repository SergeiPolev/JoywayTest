using UnityEngine;

public class InputRaycaster : MonoBehaviour
{
    private const int HolderLayer = 1 << 7;
    private const int GroundLayer = 1 << 8;
    private const int CharacterLayer = 1 << 9;

    private ActionHolder currentHolder;
    private CharacterBase highlightedCharacter;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnMouseButtonDown();
        }
        else if (Input.GetMouseButton(0))
        {
            OnMouseButtonDrag();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            OnMouseButtonUp();
        }
    }

    private void OnMouseButtonDown()
    {
        if (currentHolder != null)
        {
            currentHolder.ReturnHolder();
            currentHolder = null;
        }

        Ray ray = MakeRay();

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, HolderLayer))
        {
            var holder = hit.transform.GetComponent<ActionHolder>();
            currentHolder = holder;
            AudioManager._instance.PlayOneShot(AudioManager._instance.SoundsLibrary.PickUpSound, 1f);
        }
    }
    private void OnMouseButtonDrag()
    {
        if (currentHolder != null)
        {
            Ray ray = MakeRay();
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, CharacterLayer))
            {
                var character = hit.transform.GetComponent<CharacterBase>();

                if (currentHolder.CanDoAction(character))
                {
                    character.TurnHighlight(true);
                    highlightedCharacter = character;

                    currentHolder.transform.position = highlightedCharacter.transform.position + Vector3.up;
                }
            }
            else if (Physics.Raycast(ray, out hit, Mathf.Infinity, GroundLayer))
            {
                currentHolder.transform.position = hit.point;
                
                if (highlightedCharacter != null)
                {
                    highlightedCharacter.TurnHighlight(false);
                }
            }
        }
    }
    private void OnMouseButtonUp()
    {
        if (currentHolder != null)
        {
            Ray ray = MakeRay();

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, CharacterLayer))
            {
                var target = hit.transform.GetComponent<CharacterBase>();

                if (currentHolder.CanDoAction(target))
                {
                    currentHolder.ActivateHolder(target);

                    if (highlightedCharacter != null)
                    {
                        highlightedCharacter.TurnHighlight(false);
                    }

                    Destroy(currentHolder.gameObject);
                    currentHolder = null;

                    return;
                }
            }

            currentHolder.ReturnHolder();
            currentHolder = null;
        }
    }
    private static Ray MakeRay()
    {
        var mousePos = Input.mousePosition;

        var ray = Camera.main.ScreenPointToRay(mousePos);
        return ray;
    }
}