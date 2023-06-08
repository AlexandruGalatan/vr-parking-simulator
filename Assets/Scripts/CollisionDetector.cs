using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionDetector : MonoBehaviour
{

    public Transform player;
    public GameObject gameEnd;

    public GameObject lInteract;
    public GameObject rInteract;

    private bool GameEnded = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (GameEnded) {
            return;
        }

        GameEnded = true;
        player.position += new Vector3(0, 3, 0);
        gameEnd.SetActive(true);

        lInteract.SetActive(true);
        rInteract.SetActive(true);
    }
}