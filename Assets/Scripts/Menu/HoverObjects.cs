using UnityEngine;
using UnityEngine.Events;

public class HoverObjects : MonoBehaviour
{
    private Outline outline;
    public Color hoverColor = Color.yellow;
    public float hoverWidth = 5f;
    public UnityEvent onClickAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        outline = gameObject.AddComponent<Outline>();

        outline.OutlineColor = hoverColor;
        outline.OutlineWidth = hoverWidth;
        outline.OutlineMode = Outline.Mode.OutlineVisible;

        // 3. Keep it disabled until we hover
        outline.enabled = false;
    }

    void OnMouseEnter()
    {
        outline.enabled = true;
    }

    void OnMouseExit()
    {
        outline.enabled = false;
    }

    void OnMouseDown()
    {
        onClickAction.Invoke();
    }

}
