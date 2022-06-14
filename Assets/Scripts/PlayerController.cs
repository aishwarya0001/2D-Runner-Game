using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float timer = 0f;
    public Rigidbody2D rb;
    public float moveSpeed = 5;
    public Text gameOver;
    public AudioSource gameOverAudio;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject[] go = GameObject.FindGameObjectsWithTag("GameOver");
        go[0].GetComponent<Renderer>().enabled = false;
    }
    void Update()
    {
        float moveDirection = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(0, moveDirection * moveSpeed);
    }

    
    void DestroyAll(string tagName)
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(tagName);
        for(int  i = 0; i < objects.Length; i++)
        {
            Destroy(objects[i]);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
            DestroyAll("Obstacle");
            DestroyAll("Background");
            DestroyAll("Planet");
            rb = GetComponent<Rigidbody2D>();
            GameObject[] go = GameObject.FindGameObjectsWithTag("GameOver");
            go[0].GetComponent<Renderer>().enabled = true;
            gameOverAudio.Play(0);
        }
    }
}
