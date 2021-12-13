using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTreesDown : MonoBehaviour
{
    [SerializeField]
    List<GameObject> treebranches;

    List<Vector3> newPos = new List<Vector3>();

    GameObject player;

    float changePosition = 0f;

    void Start()
    {
        player = FindObjectOfType<PlayerBehaviour>().gameObject;
        var obj = GameObject.FindObjectsOfType<CheckBoundary>();
        foreach(var a in obj)
        {
            treebranches.Add(a.gameObject);
        }

        foreach (var tree in treebranches)
        {
            newPos.Add(new Vector3(tree.transform.position.x, 
                tree.transform.position.y + changePosition));
            Debug.Log(tree.transform.position);
            Debug.Log(newPos[newPos.Count - 1]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < treebranches.Count; i++)
        {
            if (player.transform.position.y > transform.position.y)
            {
                //Debug.Log(Mathf.Abs(newPos[i].y - treebranches[i].transform.position.y));
                treebranches[i].transform.position = Vector3.MoveTowards(treebranches[i].transform.position,
                    newPos[i], 4f * Time.deltaTime);
                Debug.Log("Scrolling " + treebranches[i].name);
            }
        }
        changePosition = 0f;
    }

    public void ScrollTreeToPoint(Vector3 characterPos)
    {
        float Ydiff = characterPos.y - transform.position.y;
        Debug.Log(Ydiff);
        if(characterPos.y >= transform.position.y)
        {
            changePosition = 8f;
            Debug.Log("Scroll");
        }
        else if(characterPos.y < transform.position.y)
        {
            changePosition = 0f;
            Debug.Log("ScrollStop");
        }

        for (int i = 0; i < treebranches.Count; i++)
        {
            newPos[i] = new Vector3(treebranches[i].transform.position.x,
                treebranches[i].transform.position.y - changePosition);
            //Debug.Log(treebranches[i].transform.position);
            //Debug.Log(newPos[i]);
        }
    }
}
