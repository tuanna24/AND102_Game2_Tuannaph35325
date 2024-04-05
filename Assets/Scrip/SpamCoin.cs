using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpamCoin : MonoBehaviour
{
    bool enableSpawn;
    public Transform player;
    public GameObject coinPrefab;

    // List để lưu trữ tất cả các coin đã sinh ra
    List<GameObject> coins = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        enableSpawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (enableSpawn)
        {
            enableSpawn = false;
            int soLuong = Random.Range(15, 26);
            float coinPosX = player.position.x + Random.Range(15f, 30f);
            float coinPosY = Mathf.Sin(coinPosX) + 1.5f;
            for (int i = 0; i < soLuong; i++)
            {
                GameObject newCoin = Instantiate(coinPrefab, new Vector3(coinPosX, coinPosY, 0), Quaternion.identity);
                coins.Add(newCoin); // Thêm coin mới vào danh sách
                coinPosX++;
                coinPosY =  Mathf.Sin(coinPosX) + 1.5f;
                // 5 * Mathf.Abs(Mathf.Sin(coinPosX / 3)); 
             }
            StartCoroutine(DelayCoin());
        }

        // Kiểm tra và xóa coin khi khoảng cách với nhân vật lớn hơn 50f
        for (int i = 0; i < coins.Count; i++)
        {
            if (coins[i] != null)
            {
                float distance = Mathf.Abs(coins[i].transform.position.x - player.position.x);
                if (distance > 30f)
                {
                    Destroy(coins[i]);
                    coins.RemoveAt(i); // Xóa coin khỏi danh sách
                }
            }
        }
    }

    IEnumerator DelayCoin()
    {
        float timer = Random.Range(5f, 8f);
        yield return new WaitForSeconds(timer);
        enableSpawn = true;
    }
}
