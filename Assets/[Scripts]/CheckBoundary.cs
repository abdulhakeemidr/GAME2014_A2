/* 
 * Full Name        : Abdulhakeem Idris
 * StudentID        : 101278361
 * Date Modified    : November 24, 2021
 * File             : ScrollTreePrefab.cs
 * Description      : This is the Tree Mover Script
 * Revision History : Version02
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBoundary : MonoBehaviour
{
    public float verticalSpeed = 2f;
    public float verticalBoundary = 8f;

    public float minXpos = 2.3f;
    public float maxXpos = 6.5f;

    GameObject branchleavesParent;

    private void Start()
    {
        branchleavesParent = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        //transform.position -= new Vector3(0.0f, verticalSpeed) * Time.deltaTime;
        CheckBounds();
    }

    private void CheckBounds()
    {
        if(transform.position.y <= -verticalBoundary)
        {
            SetBranchLeaves();
            transform.position = new Vector3(transform.position.x, verticalBoundary);
        }
    }

    private void SetBranchLeaves()
    {
        float newXpos = Random.Range(minXpos, maxXpos);
        branchleavesParent.transform.localPosition = new Vector3(newXpos, branchleavesParent.transform.localPosition.y);
    }

    
}