using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barral : MonoBehaviour
{
    public float offset;
    public float speed = 1f;
    

    private void Update()
    {
        //Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Deg2Rad;
        //transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);



        Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);


    }

    
}
