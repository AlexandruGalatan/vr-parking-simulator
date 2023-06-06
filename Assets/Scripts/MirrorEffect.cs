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
        Vector3 localPlayer = mirror.InverseTransformPoint(player.position);
        //transform.position = mirror.TransformPoint(new Vector3(localPlayer.x, localPlayer.y, -localPlayer.z));

        Vector3 lookAtMirror = mirror.TransformPoint(new Vector3(-localPlayer.x, -localPlayer.y, localPlayer.z));
        transform.LookAt(lookAtMirror);
    }
}
