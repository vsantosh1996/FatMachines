using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
 public class PhysicsDrag : MonoBehaviour
{
    private Rigidbody rb;
    private bool isDragging;
    private Plane dragPlane;
    private Vector3 offset;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        dragPlane = new Plane(Vector3.up, Vector3.zero);
    }

    void OnMouseDown()
    {
        isDragging = true;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (dragPlane.Raycast(ray, out float enter))
        {
            offset = transform.position - ray.GetPoint(enter);
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    void FixedUpdate()
    {
        if (!isDragging) return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (dragPlane.Raycast(ray, out float enter))
        {
            Vector3 targetPoint = ray.GetPoint(enter) + offset;
            Vector3 forceDirection = (targetPoint - transform.position);
            rb.AddForce(forceDirection * 15f, ForceMode.Acceleration); // Smooth physics-based movement
        }
    }
}


