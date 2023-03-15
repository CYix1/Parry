using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player;

    private void Start() => setPos();
    // Update is called once per frame
    void FixedUpdate() => setPos();

    void setPos()
    {float new_distance = 1.5f * GameData.instance.health;
        transform.position = new Vector3(player.position.x+new_distance, player.position.y, player.position.z);

    }
}
