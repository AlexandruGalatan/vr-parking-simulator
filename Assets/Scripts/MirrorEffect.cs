using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorEffect : MonoBehaviour
{
    public Transform player;
    public Transform mirror;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 inversePlayer = mirror.InverseTransformPoint(player.position);

        Vector3 playerPoint = new Vector3(-inversePlayer.x, -inversePlayer.y, inversePlayer.z);

        Vector3 mirrorTarget = mirror.TransformPoint(playerPoint);
        
        transform.LookAt(mirrorTarget);

    }
}
