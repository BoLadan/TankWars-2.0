using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionWater : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Water")
        {

            SceneManager.LoadScene("MainMenu");
            Debug.Log("Water hit");
            
        }
    }

    
}
