using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : BaseEnemy
{
     private Transform Player;

    private void OnEnable()
    {
        Player = GameObject.Find("Player").transform;
    }

    private void FixedUpdate()
    {
          transform.position = Vector3.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
    }
}