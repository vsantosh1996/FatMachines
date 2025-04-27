using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrayDrag : MonoBehaviour
{
    private Rigidbody rb;
    private bool isDragging;
    private Vector3 offset;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.drag = 5f; // for smoother stopping
    }

    void OnMouseDown()
    {
        isDragging = true;
        offset = transform.position - GetMouseWorldPos();
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    void FixedUpdate()
    {
        if (isDragging)
        {
            Vector3 target = GetMouseWorldPos() + offset;
            Vector3 force = (target - transform.position) * 10f;
            rb.AddForce(force, ForceMode.VelocityChange);
        }
    }

    Vector3 GetMouseWorldPos()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        if (plane.Raycast(ray, out float distance))
        {
            return ray.GetPoint(distance);
        }
        return Vector3.zero;
    }
}




