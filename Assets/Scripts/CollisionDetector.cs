using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionDetector : MonoBehaviour
{

    public Transform player;
    public GameObject gameEnd;
    public GameObject gameWin;

    public GameObject lInteract;
    public GameObject rInteract;

    public AudioSource audioSource;
    public AudioClip audioClip;

    private bool GameEnded = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    
    void Update()
    {
        float rightTrigger = Input.GetAxis("RightTrigger");
        if (rightTrigger >= 0.9f) {
            if (GameEnded) {
                return;
            }

            GameEnded = true;
            player.position += new Vector3(0, 3, 0);
            gameWin.SetActive(true);

            lInteract.SetActive(true);
            rInteract.SetActive(true);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (GameEnded) {
            return;
        }

        audioSource.PlayOneShot(audioClip);

        GameEnded = true;
        player.position += new Vector3(0, 3, 0);
        gameEnd.SetActive(true);

        lInteract.SetActive(true);
        rInteract.SetActive(true);
    }
}