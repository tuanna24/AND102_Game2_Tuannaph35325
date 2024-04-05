using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBullet : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    void Start()
    {
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2 (15f, rb.velocity.y);
    }

    private void OnTriggerEnter2D (Collider2D collider2D)
    {
        if (!collider2D.CompareTag("Coin"))
        {
            Destroy(gameObject);
        }
    }
}
