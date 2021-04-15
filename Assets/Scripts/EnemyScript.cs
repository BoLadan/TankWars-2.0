using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public int health;
    public GameObject deathEffect;

    public float speed;
    private Transform target;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject projectile;

    public int pointsToAdd;

    public GameObject NextPanel;
    [SerializeField]

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        timeBtwShots = startTimeBtwShots;

        gameObject.SetActive(true);
        NextPanel.SetActive(false);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
 
    // Update is called once per frame
    private void Update()
    {
        if (health <= 0)
        {
            //Instantiate(deathEffect, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            Destroy(gameObject);
            ScoreManager.AddPoints(pointsToAdd);
            NextPanel.SetActive(true);
        }

        if(Vector2.Distance(transform.position, target.position) > 2)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        } else if(Vector2.Distance(transform.position, target.position) < stoppingDistance && Vector2.Distance(transform.position, target.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        } else if (Vector2.Distance(transform.position, target.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
        }


        if (timeBtwShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        } else
        {
            timeBtwShots -= Time.deltaTime;
        }


    }
}
