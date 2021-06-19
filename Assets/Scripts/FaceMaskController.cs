using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FaceMaskController : MonoBehaviour
{
    bool clickable = true;
    bool isPressed;
    public UnityEvent KeyPressed;
    public UnityEvent KeyReleased;
    new PolygonCollider2D collider2D;

    // Start is called before the first frame update
    void Start()
    {
        isPressed = false;

        KeyPressed = new UnityEvent();
        KeyReleased = new UnityEvent();
        collider2D = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
#if UNITY_STANDALONE || UNITY_EDITOR
        if (Input.GetMouseButtonDown(0) && clickable) //if mouse button was pressed       
        {
            isPressed = true;

            KeyPressed.Invoke();

            collider2D.enabled = true;
        }
        if(Input.GetMouseButtonUp(0))
        {
            isPressed = false;

            KeyReleased.Invoke();

            collider2D.enabled = false;
        }

        if (isPressed)
        {
            GetComponent<Transform>().position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
#endif
    }
}
