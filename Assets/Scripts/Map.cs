using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    
    public Transform playerPos;
    public Transform offscreenPos;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.M))
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
            //Time.timeScale = 0f;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, offscreenPos.position, speed * Time.deltaTime);
            //Time.timeScale = 1f;
        }
    }
}
