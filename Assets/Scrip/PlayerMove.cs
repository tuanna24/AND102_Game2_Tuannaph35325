using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    public List<AudioClip> audioClips;
    AudioSource audioSource;

    public GameObject sliderHolder; // Reference tới GameObject chứa Slider

    public float SpeedMove;
    public float jump;
    public float Timer;
    public float jupmCount;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        SpeedMove = 5f;
        jump = 12f;
        Timer = 10f;
        jupmCount = 10f;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.H))
        {
            rb.velocity = new Vector2(SpeedMove, rb.velocity.y);
        }
        else 
        {
            rb.velocity = new Vector2 (0f, rb.velocity.y);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.PlayOneShot(audioClips[2]);
            rb.velocity = new Vector2(rb.velocity.x, jump);
            jupmCount++;
        }
        if (Timer > 0)
        {
            Timer -= Time.deltaTime;
        }
        else
        {
            SpeedMove++;
            Timer = 10f;
        }

        animator.SetFloat("Speed", Mathf.Abs(SpeedMove));
    }
}

