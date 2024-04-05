// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class LonDen : MonoBehaviour
// {
//     //Di chuyển đến điểm A
//     //sau đó nghỉ 2s
//     //Quay đầu và đi đến điểm B
//     //Đứng nghỉ 2s
//     //Tốc độ di chuyển của nó là 5f 

//     //Thấy người chơi(mặt nó nhìn về người chơi) ; tăng tốc lên 8f và di chuyển về phía người chơi
//     //nâng cao : nó húc trượt . nó đứng đơ 2s -> quay lại

//     public Transform boar;
//     public Transform PosA;
//     public Transform PosB;
//     public Animator amin;
//     float speedMove = 3f;
//     bool isFaceRight;
//     float timer;

//     public SpriteRenderer sR;
//     void Start()
//     {

//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if (isFaceRight) // di chuyen sang ben phai
//         {
//             if (Vector2.Distance(boar.position, PosB.position) > 0.1f)
//             {
//                 timer += Time.deltaTime;

//                 boar.position = Vector3.MoveTowards(boar.position, PosB.position, speedMove * Time.deltaTime);
//                 amin.Play("SheetRun");
//             } 
//             else 
//             {
//                 sR.flipX = false;
//                 isFaceRight = false;
//             }
//         }
//         else // di chuyen khi sang trai
//         {
//             if (Vector2.Distance(boar.position, PosA.position) > 0.1f)
//             {
//                 boar.position = Vector3.MoveTowards(boar.position, PosA.position, speedMove * Time.deltaTime);
//                 amin.Play("SheetRun");
//             }
//             else 
//             {
//                 sR.flipX = true;
//                 isFaceRight = true;
//             }
//         }
//     }
// }

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LonDen : MonoBehaviour
{
     //Di chuyển đến điểm A
    //sau đó nghỉ 2s
    //Quay đầu và đi đến điểm B
    //Đứng nghỉ 2s
    //Tốc độ di chuyển của nó là 5f 

    //Thấy người chơi(mặt nó nhìn về người chơi) ; tăng tốc lên 8f và di chuyển về phía người chơi
    //nâng cao : nó húc trượt . nó đứng đơ 2s -> quay lại 
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public Transform boar;
    public Transform posA;
    public Transform posB;

    public Transform boarcheck;
    private Vector3 dirition;
    public LayerMask playerLayer;
    private RaycastHit2D hitPlayer;

    public bool atk;

    float speedMove = 3f;
    bool isFacingRight;
    float timer;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isFacingRight) //Phải di chuyển qu B
        {
            dirition = Vector3.right;
            if (Vector2.Distance(boar.position, posB.position) > 0.1f)
            {
                boar.position = Vector3.MoveTowards(boar.position, posB.position, speedMove * Time.deltaTime);
                animator.Play("SheetRun");
            }
            else
            {
                timer += Time.deltaTime;
                if (timer >= 2f)
                {
                    spriteRenderer.flipX = false;
                    isFacingRight = false;
                    timer = 0;
                }else if(timer <=2f)
                {
                    animator.Play("Sheet");
                }

            }
        }
        else //măt quay về trái di chuyển qua A
        {
            dirition = Vector3.left;
            if (Vector2.Distance(boar.position, posA.position) > 0.1f)
            {
                boar.position = Vector3.MoveTowards(boar.position, posA.position, speedMove * Time.deltaTime);
                animator.Play("SheetRun");
            }
            else
            {

                timer += Time.deltaTime;
                if(timer >2f)
                {
                    spriteRenderer.flipX = true;
                    isFacingRight = true;
                    timer = 0;
                }else
                {
                    animator.Play("Sheet");
                }       
            }
        }
    }

    private void FixedUpdate() {
        RayDetect();
    }

    public void RayDetect()
    {
        hitPlayer = Physics2D.Raycast(boarcheck.position,dirition,10f,playerLayer);

        if(hitPlayer)
        {
            Debug.DrawRay(boarcheck.position + Vector3.up ,dirition * hitPlayer.distance, Color.red);
            
        }else
        {
            Debug.DrawRay(boarcheck.position + Vector3.up ,dirition * 10f, Color.green);
        }
    }
}
