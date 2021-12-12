using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTreePrefab : MonoBehaviour
{
    public float verticalSpeed = 2f;
    public float verticalBoundary = 8f;

    void Update()
    {
        transform.position -= new Vector3(0.0f, verticalSpeed) * Time.deltaTime;
        CheckBounds();
    }

    private void CheckBounds()
    {
        if(transform.position.y <= -verticalBoundary)
        {
            transform.position = new Vector3(transform.position.x, verticalBoundary);
        }
    }
}
