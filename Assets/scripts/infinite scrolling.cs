using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infinitescrolling : MonoBehaviour
{
    private Material material;

    private Vector2 scroll_speed;

    public int xVelocity, yVelocity;
    // Start is called before the first frame update
    private void Awake()
    {
        material = GetComponent<Renderer>().material;
    }
    void Start()
    {
        scroll_speed = new Vector2(xVelocity, 0.25f);
    }

    // Update is called once per frame
    void Update()
    {
        material.mainTextureOffset += scroll_speed * Time.deltaTime;
    }
}