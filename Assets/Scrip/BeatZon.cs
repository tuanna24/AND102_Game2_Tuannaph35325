using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatZon : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x, 0, 0);
    }
}
