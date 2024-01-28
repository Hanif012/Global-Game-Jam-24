using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followMouse : MonoBehaviour

{
    public Vector2 center = Vector2.zero;
    public float radius = 5f;

    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10f));
        Vector2 direction = mousePosition - (Vector3)center;
        direction = Vector2.ClampMagnitude(direction, radius);
        transform.position = center + direction;
    }
}
