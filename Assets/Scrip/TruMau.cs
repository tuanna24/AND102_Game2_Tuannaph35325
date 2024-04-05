// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class TruMau : MonoBehaviour
// {

//     public Image fillArea;
//     public Slider playerHealthSlider;
//     public GameObject endGame;

//     private void FixedUpdate()
//     {
//         playerHealthSlider.maxValue = 100;
//         playerHealthSlider.value = 100;

//         playerHealthSlider.onValueChanged.AddListener(delegate { OnHealthChanged(); });
//         OnHealthChanged();
//     }
//     void Start ()
//     {
//         endGame.SetActive(false);
//     }
//     void OnHealthChanged()
//     {
//         float health = playerHealthSlider.value;

//         if (health >= 70)
//         {
//             fillArea.color = Color.green;
//         }
//         else if (health <= 70 && health >= 30)
//         {
//             fillArea.color = Color.yellow;
//         }
//         else
//         {
//             fillArea.color = Color.red;
//         }
//     }

//     public void SetHealth()
//     {
//         float health = playerHealthSlider.value;

//         if (health >= 70)
//         {
//             fillArea.color = Color.green;
//         }
//         else if (health <= 70 && health >= 30)
//         {
//             fillArea.color = Color.yellow;
//         }
//         else
//         {
//             fillArea.color = Color.red;
//         }
//     }
//     void Update()
//     {
//         if (Input.GetKeyDown(KeyCode.Y))
//         {
//             playerHealthSlider.value -= 10;
//         }

//         if (Input.GetKeyDown(KeyCode.U))
//         {
//             playerHealthSlider.value += 10;
//         }
//     }
//     private void OnTriggerEnter2D(Collider2D collider2D)
//     {
//         if (collider2D.CompareTag("Bullet"))
//         {
//             playerHealthSlider.value -= 20;
//             if (playerHealthSlider.value <= 0)
//             {
//                 endGame.SetActive(true);
//             }
//         }
//     }
// }
