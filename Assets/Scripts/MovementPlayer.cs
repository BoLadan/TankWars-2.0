using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementPlayer : MonoBehaviour
{
    public KeyCode pressA;
    public KeyCode pressD;
    public KeyCode pressW;
    public KeyCode pressS;

    public Sprite UpPlayer;
    public Sprite DownPlayer;
    public Sprite LeftPlayer;
    public Sprite RightPlayer;

    public GameObject TrailEffect;

    public int health = 3;
    public float invincibleTimeAfterHurt = 2;
    public GameObject deathEffect;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

        if (health <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }


        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(0.2f, 0, 0);
            transform.rotation = Quaternion.Euler(0, -180, 0);
            //this.GetComponent<SpriteRenderer>().sprite = LeftPlayer;

        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(0.2f, 0, 0);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            //this.GetComponent<SpriteRenderer>().sprite = RightPlayer;
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0.1f, 0);
            //this.GetComponent<SpriteRenderer>().sprite = UpPlayer;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -0.1f, 0);
            //this.GetComponent<SpriteRenderer>().sprite = DownPlayer;
        }

        if (Input.GetKeyDown(pressA))
            GetComponent<Transform>().eulerAngles = new Vector3(0, 0, 90);

        if (Input.GetKeyDown(pressD))
            GetComponent<Transform>().eulerAngles = new Vector3(0, 0, -90);

        if (Input.GetKeyDown(pressW))
            GetComponent<Transform>().eulerAngles = new Vector3(0, 0, 0);

        if (Input.GetKeyDown(pressS))
            GetComponent<Transform>().eulerAngles = new Vector3(0, 0, 180);

    }

    void Hurt()
    {
        health--;
        if (health <= 0)
        {
            SceneManager.LoadScene("MainMenu");
            Destroy(this.gameObject);
            Debug.Log("Player Death");
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "EnemyProjectile")
        {

            
            Debug.Log("Enemy hit");
            Hurt();
        }
    }
}