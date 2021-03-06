﻿using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{

    public GameObject target;
    public float attackTimer;
    public float cooldown = 2.0f;

    // Use this for initialization
    void Start()
    {
        attackTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (attackTimer > 0)
            attackTimer -= Time.deltaTime;
        if (attackTimer < 0)
            attackTimer = 0;

        if (attackTimer == 0)
        {
            Attack();
            attackTimer = cooldown;
        }
    }

    private void Attack()
    {
        float distance = Vector3.Distance(target.transform.position, transform.position);
        Vector3 dir = (target.transform.position - transform.position).normalized;
        float direction = Vector3.Dot(dir, transform.forward);

        if (distance < 2.5f && direction > 0)
        {
            PlayerHealth ph = (PlayerHealth)target.GetComponent("PlayerHealth");
            ph.AddjustCurrentHealth(-10);
        }
    }
}
