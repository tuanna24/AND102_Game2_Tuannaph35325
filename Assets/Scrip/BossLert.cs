using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossLert : MonoBehaviour
{
    public float speedMove;
    Rigidbody2D rb;
    bool active;
    Animator anmi;
    void Start()
    {
        speedMove = -3f;
        rb = GetComponent<Rigidbody2D>();
        anmi = GetComponent<Animator>();
    }

    // Update is called once per frame

    private void OnBecameVisible()// sự kiện này được gọi khi mà đối tượng chứa script này xuất hiện
    {
        active = true;
    }
    private void OnBecameInvisible() // sự kiện này được gọi khi mà đối tượng chứa script này không xuất hiện
    {
        Destroy(gameObject);
    }
    void Update()
    {
        if (active)
        {
            rb.velocity = new Vector2(speedMove, rb.velocity.y);
            anmi.Play("SheetRun");
        }
    }
}
