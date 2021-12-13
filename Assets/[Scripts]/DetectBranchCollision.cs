using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DetectBranchCollision : MonoBehaviour
{
    private Collider2D collider;
    private ScrollTreesDown scrollTree;

    private GameObject player;
    private GameObject enemy;

    public UnityEvent collideTrigger;

    private void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        player = FindObjectOfType<PlayerBehaviour>().gameObject;
        enemy = FindObjectOfType<EnemyController>().gameObject;
        scrollTree = GameObject.FindObjectOfType<ScrollTreesDown>();
        collideTrigger.AddListener(delegate { scrollTree.ScrollTreeToPoint(transform.position); });

        collider.enabled = false;
    }

    private void Update()
    {
        if(player.transform.position.y > transform.position.y + 1f)
        {
            collider.enabled = true;
        }
        else if (player.transform.position.y < transform.position.y - 1f)
        {
            collider.enabled = false;
        }
        var enemyScript = enemy.GetComponent<EnemyController>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collideTrigger.Invoke();
        }
    }
}
