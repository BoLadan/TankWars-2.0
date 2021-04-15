using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomScript : MonoBehaviour
{

    public int pointsToAdd;

    public float CurrentHealth { get; set; }
    public float MaxHealth { get; set; }


    private void Start()
    {
        MaxHealth = 100f;
        CurrentHealth = MaxHealth;
    }

    void DealDamage(float damageValue)
    {
        CurrentHealth -= damageValue;
        if (CurrentHealth <= 0)
            Die();
    }

    void Die()
    {
        ScoreManager.AddPoints(pointsToAdd);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "PlayerBullet")
        {
            Debug.Log("Hit Boom");
            DealDamage(25);
            //Destroy(coll.gameObject);
        }
    }


}
