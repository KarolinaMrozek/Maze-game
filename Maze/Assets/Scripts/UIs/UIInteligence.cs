using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInteligence : MonoBehaviour
{

    private Transform Player;
    private Transform Enemy;

    public float speedRotation = 4.0f;
    public float speedMove = 5.0f;
    public float range = 30.0f;
    public float health = 1;

    public float space = 0f;

    void Start()
    {
        Enemy = transform;
        GameObject go = GameObject.FindWithTag("Player");
        Player = go.transform;

    }

    void Update()
    {
        float mydistance = Vector3.Distance(Enemy.position, Player.position);

        if (mydistance < range && mydistance > space)
        {
            Enemy.rotation = Quaternion.Slerp(Enemy.rotation, Quaternion.LookRotation(Player.position - Enemy.position), speedMove * Time.deltaTime);

            Enemy.position += Enemy.forward * speedMove * Time.deltaTime;
        }


    }
}