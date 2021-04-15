using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;

    public GameObject DestroyEffect;
    

    // Start is called before the first frame update
    void Start()
    {
        //rb.velocity = transform.forward * speed;
        Invoke("DestroyBullet", lifeTime);
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


        //Vector3 vectorToTarget = targetTransform.position - transform.position;
        //float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        

        //Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, q, Time.deltaTime * speed);
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
