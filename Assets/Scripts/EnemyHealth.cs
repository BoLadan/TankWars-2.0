using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{

    public float CurrentHealth { get; set; }
    public float MaxHealth { get; set; }

    public int pointsToAdd;

    // Start is called before the first frame update
    private void Start()
    {
        MaxHealth = 4f;
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
        CurrentHealth = 0;
        Destroy(gameObject);
        SceneManager.LoadScene("MainMenu");
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Projectile")
        {


            Debug.Log("hit");
            DealDamage(5);
        }
    }


}
