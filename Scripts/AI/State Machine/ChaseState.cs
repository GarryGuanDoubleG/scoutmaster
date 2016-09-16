using UnityEngine;
using System.Collections;

public class ChaseState : IEnemyState
{

    private readonly StatePatternEnemy enemy;

    public ChaseState (StatePatternEnemy statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }

    public void UpdateState()
    {
        /*
        Look();
        Chase();
        */
    }


    public void ToPatrolState()
    {
        Debug.Log("Cannot go to Patrol State From Chase State");
    }

    public void ToAlertState()
    {
        enemy.currentState = enemy.alertState;
    }

    public void ToChaseState()
    {
        Debug.Log("Already in Chase State");
    }

    private void Look()
    {
        RaycastHit hit;
        //direction from eyes to target
        Vector3 enemyToTarget = (enemy.chaseTarget.position + enemy.offset - enemy.eyes.transform.position);
        //look at player 
        if (Physics.Raycast(enemy.eyes.transform.position, enemyToTarget, out hit, enemy.sightRange) && hit.collider.CompareTag("Player"))
        {
            enemy.chaseTarget = hit.transform;
            ToChaseState();
        }
        else
        {
            ToAlertState();
        }
    }

    private void Chase()
    {
        enemy.meshRendererFlag.material.color = Color.red;
        enemy.navMeshAgent.destination = enemy.chaseTarget.position;
        enemy.navMeshAgent.Resume();
    }
}
