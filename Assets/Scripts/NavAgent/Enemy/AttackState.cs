using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackState : BaseState
{
    public float attackTimer;
    public float attackRate = 0.5f;
    public GameObject player = GameObject.FindGameObjectWithTag("Player");
    private PlayerHealthUI healthUI = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthUI>();

    public override void Enter()
    {
        
    }

    public override void Exit()
    {

    }

    public override void Perform()
    {
        if (!enemy.CanSeePlayer())
        {
            stateMachine.ChangeState(new PatrolState());
        }
        else
        {
            enemy.transform.LookAt(player.transform);
            if (Vector3.Distance(enemy.transform.position, player.transform.position) < 2f)
            {
                
                attackTimer += Time.deltaTime;
                if(attackTimer > attackRate)
                {
                    EnemyAttack();
                    attackTimer = 0;
                }
            }
            else
                enemy.Agent.SetDestination(player.transform.position);
        }
    }

    public void EnemyAttack()
    {
        //Debug.Log("attack");
        healthUI.TakeDamage(10);
    }
}
