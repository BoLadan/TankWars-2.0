using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(105f, 0f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-0.017f, 0, 0);
            //transform.rotation = Quaternion.Euler(0, -180, 0);
            //this.GetComponent<SpriteRenderer>().sprite = LeftPlayer;

        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(0.013f, 0, 0);
            //transform.rotation = Quaternion.Euler(0, 0, 0);
            //this.GetComponent<SpriteRenderer>().sprite = RightPlayer;
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0.0046f, 0);
            //this.GetComponent<SpriteRenderer>().sprite = UpPlayer;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -0.004f, 0);
            //this.GetComponent<SpriteRenderer>().sprite = DownPlayer;
        }
    }
}
