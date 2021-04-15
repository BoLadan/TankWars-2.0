using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public GameObject Bullet;
    public Transform FirePoint;

    private float timeBtwShots;
    public float startTimeBtwShots;
    //Quaternion Direction;
    // Update is called once per frame

    private void Start()
    {
        //Direction = Quaternion.Euler(0, 0, 180);
    }

    void Update()
    {

        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(Bullet, FirePoint.position, transform.rotation);
                Debug.Log("bullet fired");
                timeBtwShots = startTimeBtwShots;
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;

        }

    }

   
}
