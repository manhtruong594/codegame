using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    PlayerController Player;
    Vector3 Tartget;
    [SerializeField] float Speed = 1;
    [SerializeField] Vector2 offSet = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        Player = PlayerController.Instant;
    }

    // Update is called once per frame
    void Update()
    {
        Tartget = (Vector2)Player.transform.position - offSet;
        Tartget.z = -10;

        this.transform.position = Vector3.Lerp(this.transform.position, Tartget, Speed * Time.deltaTime);
    }
}
