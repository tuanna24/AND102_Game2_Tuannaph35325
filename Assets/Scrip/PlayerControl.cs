using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class PlayerControl : MonoBehaviour
{
    public GameManager gameManager;
    public List<AudioClip> audioClips;
    AudioSource audioSource;
    public Transform checkGroundPos;
    public LayerMask groundLayer;
    public bool isGround;
    private RaycastHit2D hitPlayer2D;
    public LayerMask playerLayer2D;
    public Transform PlayerCheck;
    private Vector3 dirition;
    public Transform playerRaycastOrigin;
    public Transform gunPos;
    public AdsManager ads;
    public GameObject CoinBullet;
    public int mau = 3;

    public GameManager winPale;

    private void FixedUpdate()
    {


        audioSource = GetComponent<AudioSource>();
        // OverlapCheckGround();
        RaycastCheckGround();
        RayDetectPlayer();
        OverlapCheckGround();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(ShowRaycastForOneSecond());
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (gameManager.GetScore() > 0)
            {
                gameManager.TruScore();
                Instantiate(CoinBullet, gunPos.position, Quaternion.identity);
            }
        }
    }

    IEnumerator ShowRaycastForOneSecond()
    {
        // Tạo raycast từ vị trí của game object trống theo hướng Vector3.right với chiều dài là 10f
        RaycastHit2D hit = Physics2D.Raycast(playerRaycastOrigin.position, Vector3.right, 10f);

        // Hiển thị raycast màu xanh
        Debug.DrawRay(playerRaycastOrigin.position, Vector3.right * 10f, Color.blue, 1f);

        // Chờ 1 giây
        yield return new WaitForSeconds(0.5f);

        // Xóa raycast đi
        Debug.DrawRay(playerRaycastOrigin.position, Vector3.right * 10f, Color.clear, 0f);

        // Nếu raycast chạm vào một collider
        if (hit.collider != null)
        {
            // Nếu collider là của quái vật
            if (hit.collider.CompareTag("Enemy"))
            {
                // Đổi màu raycast thành màu đỏ
                Debug.DrawRay(playerRaycastOrigin.position, Vector3.right * hit.distance, Color.red, 1f);

                // Xử lý hành động khi chạm vào quái vật
                Destroy(hit.collider.gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Coin"))
        {
            gameManager.AddScore();
            gameManager.SetTextScore();
            gameManager.SaveGame();

            audioSource.PlayOneShot(audioClips[0]);
            Destroy(collider2D.gameObject);
        }
        if (collider2D.CompareTag("Zone"))
        {
            Debug.Log("da cham zone");
            gameManager.Checkscore();
            Destroy(gameObject);
        }
        if (collider2D.CompareTag("Dead"))
        {
            gameManager.Checkscore();
            Time.timeScale = 0;
            ads.ShowInterstitialAd();
        }
    }
    public void OverlapCheckGround()
    {
        Collider2D[] getColider = Physics2D.OverlapCircleAll(checkGroundPos.position, 0.2f, groundLayer);
        if (getColider.Length > 0)
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }
    }
    public void RaycastCheckGround()
    {
        RaycastHit2D hitGround = Physics2D.Raycast(checkGroundPos.position, Vector2.down, 0.2f, groundLayer);
        if (hitGround)
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }
    }
    public void RayDetectPlayer()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(PlayerCheck.position, Vector3.right, 10f);
        if (hit2D)
        {
            if (hit2D.collider.CompareTag("Enemy"))
            {
                Debug.DrawRay(PlayerCheck.position, Vector3.right * hit2D.distance, Color.cyan);
                print("Cham quai");
            }
            else
            {
                Debug.DrawRay(PlayerCheck.position, Vector3.right * hit2D.distance, Color.blue);
                print("Cham Dat");
            }
        }
        else
        {

        }
    }
}