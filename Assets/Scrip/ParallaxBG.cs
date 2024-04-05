using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBG : MonoBehaviour
{
    public PlayerMove player;
    public Material BG2;
    public Material BG3;
    public Material BG4;
    public Material BG5;

    float offset2;
    float offset3;
    float offset4;
    float offset5;

    // Update is called once per frame
    void Update()
    {
        offset5 -= Time.deltaTime * .05f * player.SpeedMove;
        offset4 -= Time.deltaTime * .04f * player.SpeedMove;
        offset3 -= Time.deltaTime * .02f * player.SpeedMove;
        offset2 -= Time.deltaTime * .01f * player.SpeedMove;

        BG2.mainTextureOffset = new Vector2(offset2 , 0);
        BG3.mainTextureOffset = new Vector2(offset3 , 0);
        BG4.mainTextureOffset = new Vector2(offset4 , 0);
        BG5.mainTextureOffset = new Vector2(offset5 , 0);
    }
}
