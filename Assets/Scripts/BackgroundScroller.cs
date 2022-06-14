using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public BoxCollider2D collider;
    public Rigidbody2D rb;
    private float width;
    private float scrollSpeed = -5f;
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        width = collider.size.x;
        Debug.Log(width);
        collider.enabled = false;
        rb.velocity = new Vector2(scrollSpeed, 0);
        ResetObstacle();
    }

    void Update()
    {
        if(transform.position.x < -width) {
            Vector2 resetPosition = new Vector2(width * 2f, 0);
            transform.position = (Vector2)transform.position + resetPosition;
            ResetObstacle();
        }
    }
    void ResetObstacle()
    {
        transform.GetChild(1).localPosition = new Vector3(0, Random.Range(-4,4), 0);
        transform.GetChild(3).localPosition = new Vector3(0, Random.Range(-4,4), 0);
    }
    
}



