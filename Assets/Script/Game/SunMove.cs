using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunMove : MonoBehaviour
{
    private GameObject player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag(GameInfo.PlayerTag);
    }

    void Update()
    {
        if (player != null)
        {
            Vector2 newPosition = transform.position;
            newPosition.x = player.transform.position.x - 3;
            transform.position = newPosition;
        }
    }
}
