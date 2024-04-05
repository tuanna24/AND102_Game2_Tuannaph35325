using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using System.Linq;

public class randomMaps : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public List<GameObject> ground;
    public List<GameObject> groundOld;
    Vector2 nextPos;
    Vector2 endPos;
    public GameObject Plant;
    public GameObject BossLeft;
    public GameObject Boar;
    float rd;
    int id;
    int groundLen;
    void Start()
    {
        endPos = new Vector2(27f, 0f);
        for (int i = 0; i < 5; i++)
        {
            rd = Random.Range(2f, 5f);
            nextPos = new Vector2(endPos.x + rd, 0f);
            id = Random.Range(0, ground.Count);
            GameObject newGround = Instantiate(ground[id], nextPos, Quaternion.identity, transform);
            groundOld.Add(newGround);

            switch (id)
            {
                case 0: groundLen = 27; break;
                case 1: groundLen = 12; break;
                case 2: groundLen = 7; break;
                case 3: groundLen = 28; break;

            }
            endPos = new Vector2(nextPos.x + groundLen, 0f);
            if (id == 5)
            {
                SpawnBoar();
            }
            else
            {
                int getEnemy = Random.Range(0, 2);
                if (getEnemy != 0)
                {
                    SpawnPlant();
                }
                else
                {
                    SpawnBoarLeft();
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(player.position, endPos) < 50f)
        {
            for (int i = 0; i < 5; i++)
            {
                rd = Random.Range(2f, 5f);
                nextPos = new Vector2(endPos.x + rd, 0f);
                id = Random.Range(0, ground.Count);
                GameObject newGround = Instantiate(ground[id], nextPos, Quaternion.identity, transform);
                groundOld.Add(newGround);

                switch (id)
                {
                    case 0: groundLen = 27; break;
                    case 1: groundLen = 12; break;
                    case 2: groundLen = 7; break;
                    case 3: groundLen = 28; break;
                }
                endPos = new Vector2(nextPos.x + groundLen, 0f);
                if (id == 5)
                {
                    SpawnBoar();
                }
                else
                {
                    int getEnemy = Random.Range(0, 2);
                    if (getEnemy != 0)
                    {
                        SpawnPlant();
                    }
                    else
                    {
                        SpawnBoarLeft();
                    }
                }
            }
        }
        GameObject getOneGround = groundOld.FirstOrDefault();
        if (getOneGround != null && Vector2.Distance(player.position, getOneGround.transform.position) > 50f)
        {
            groundOld.Remove(getOneGround);
            Destroy(getOneGround);
        }
    }
    public void SpawnPlant()
    {
        float posX = Random.Range(nextPos.x + 2f, endPos.x - 2f);
        Vector3 pos = new Vector3(posX, 0, 0);
        Instantiate(Plant, pos, Quaternion.identity);
    }

    public void SpawnBoar()
    {
        float posX = Random.Range(nextPos.x + 7f, endPos.x - 7f);
        Vector3 pos = new Vector3(posX, 0, 0);
        Instantiate(Boar, pos, Quaternion.identity);
    }

    public void SpawnBoarLeft()
    {
        float posX = Random.Range(nextPos.x - 6f, endPos.x - 2f);
        Vector3 pos = new Vector3(posX, 0, 0);
        Instantiate(BossLeft, pos, Quaternion.identity);
    }
}
