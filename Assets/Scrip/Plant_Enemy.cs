using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public GameObject bullet;
    public Transform bulletPos;

    public float timerAttack;
    float timer;
    Animator animator;
    private RaycastHit2D raycastHit2D;
    public LayerMask layerMask;
    public Vector2 vector2;
    public bool atk;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (atk)
        {
            timer += Time.deltaTime;
            // float loop = Random.Range(2f, 5f);

            if (timer >= 1f)
            {
                animator.SetTrigger("atk");
                timer = timerAttack;
            }
        }
    }

    public void PlantShoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }

    public void FixedUpdate()
    {
        RaycastDetecPlayer();
    }

    public void RaycastDetecPlayer()
    {
        RaycastHit2D raycastHit2D = Physics2D.Raycast(bulletPos.position, Vector2.left, 10f, layerMask);

        if (raycastHit2D)
        {
            Debug.DrawRay(bulletPos.position, Vector2.left * raycastHit2D.distance, Color.red);
            atk = true;
        }
        else
        {
            Debug.DrawRay(bulletPos.position, Vector2.left * 10f, Color.green);
            atk = false;
        }
    }
}
