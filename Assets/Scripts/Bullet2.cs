using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public int damage;
    public float distance;
    public LayerMask whatIsSolid;

    public GameObject DestroyEffect;


    // Start is called before the first frame update
    void Start()
    {
        //rb.velocity = transform.forward * speed;
        //Invoke("DestroyBullet", lifeTime);
    }

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                Debug.Log("ENEMY Takes Damage!");
                hitInfo.collider.GetComponent<EnemyScript>().TakeDamage(damage);
            }
            DestroyBullet();
        }
    }

    void DestroyBullet()
    {
        Instantiate(DestroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
