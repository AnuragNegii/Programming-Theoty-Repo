using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.Rotate(30, 0, 0);
    }

    private void LateUpdate()
    {
        Vector3 plaeyrPos = player.transform.position;
        

        transform.position = plaeyrPos + new Vector3(0f, 7f, -8.0f);
        

    }
}
