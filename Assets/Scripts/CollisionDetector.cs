using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        int randomNumber = Random.Range(1, 10001);

        Debug.Log("Collision detected!" + randomNumber);

        // You can add your custom logic here when a collision occurs
        // For example, you can play a sound, trigger an effect, or apply damage to the car
    }
}
