using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
    public Material bg2, bg3, bg4, bg5;
    public Transform cam;

    void FixedUpdate()
    {
        bg2.mainTextureOffset = new Vector2(-cam.position.x / 80, -(cam.position.y + 0.2975f) / 100);
        bg3.mainTextureOffset = new Vector2(-cam.position.x / 88, -(cam.position.y + 0.2975f) / 100);
        bg4.mainTextureOffset = new Vector2(-cam.position.x / 92, -(cam.position.y + 0.2975f) / 100);
        bg5.mainTextureOffset = new Vector2(-cam.position.x / 100, -(cam.position.y + 0.2975f) / 100);
    }
}