using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target; // Player
    public Transform bg1;    // Left wall background 1
    public Transform bg2;    // Left wall background 2
    public Transform bg3;    // Right wall background 1
    public Transform bg4;    // Right wall background 2
    private float size;

    // Start is called before the first frame update
    void Start()
    {
        size = bg1.GetComponent<BoxCollider2D>().size.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += GameObject.Find("Player").GetComponent<Movement>().runSpeed * Vector3.up * Time.deltaTime;

        // Handle left wall backgrounds
        if (transform.position.y >= bg2.position.y)
        {
            bg1.position = new Vector3(bg1.position.x, bg2.position.y + size, bg1.position.z);
            SwitchBg(ref bg1, ref bg2);
        }
        if (transform.position.y < bg1.position.y)
        {
            bg2.position = new Vector3(bg2.position.x, bg1.position.y - size, bg2.position.z);
            SwitchBg(ref bg1, ref bg2);
        }

        // Handle right wall backgrounds
        if (transform.position.y >= bg4.position.y)
        {
            bg3.position = new Vector3(bg3.position.x, bg4.position.y + size, bg3.position.z);
            SwitchBg(ref bg3, ref bg4);
        }
        if (transform.position.y < bg3.position.y)
        {
            bg4.position = new Vector3(bg4.position.x, bg3.position.y - size, bg4.position.z);
            SwitchBg(ref bg3, ref bg4);
        }
    }

    private void SwitchBg(ref Transform bgA, ref Transform bgB)
    {
        Transform temp = bgA;
        bgA = bgB;
        bgB = temp;
    }
}
