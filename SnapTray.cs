using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapTray : MonoBehaviour
{
    public float snapThreshold = 0.5f;
    private Rigidbody rb;
    private bool isDragging;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMouseDown() => isDragging = true;

    void OnMouseUp() => isDragging = false;

    void FixedUpdate()
    {
        if (!isDragging && rb.velocity.magnitude < 0.1f)
        {
            SnapToGrid();
        }
    }

    void SnapToGrid()
    {
        Vector3 pos = transform.position;
        Vector3 snappedPos = new Vector3(Mathf.Round(pos.x), pos.y, Mathf.Round(pos.z));
        if (Vector3.Distance(pos, snappedPos) <= snapThreshold)
        {
            transform.position = snappedPos;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}

