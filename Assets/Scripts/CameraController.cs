using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;
    public float speed;

    void Start()
    {
        speed = Time.deltaTime * 100;
    }

    void LateUpdate()
    {
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(0, gameObject.transform.position.x, player.gameObject.transform.position.z), speed);
    }

}
