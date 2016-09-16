using UnityEngine;
using System.Collections;

public class PatrolState : IEnemyState
{
    private readonly StatePatternEnemy enemy;
    private int nextWayPoint;

    public PatrolState (StatePatternEnemy statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }

    public void UpdateState()
    {
        /*
        Look();
        Patrol();
        */
    }


    public void ToPatrolState()
    {
        Debug.Log("Can't transition to same state");
    }

    public void ToAlertState()
    {
        enemy.currentState = enemy.alertState;
    }

    public void ToChaseState()
    {
        enemy.currentState = enemy.chaseState;
    }
    //ray cast x units to check if they see player
    private void Look()
    {
        RaycastHit2D hit;

        Vector3 dir;
        Vector2 curr_vel;

        curr_vel = enemy.rigid2d.velocity;
        dir = new Vector2(curr_vel.x, curr_vel.y);

        if(dir == Vector3.zero)
        {
            dir = enemy.previousGood;
        }
        else
        {
            enemy.previousGood = dir;
        }

        //8th layer is player
        LayerMask layer = 1 << 8;
        hit = Physics2D.Raycast(enemy.transform.position, dir, enemy.sightRange, layer.value);

        if (hit.collider)
        {
            //Debug.Log("Hit");
            //ToChaseState();
        }

        Debug.DrawRay(enemy.transform.position, dir * (enemy.sightRange / dir.x), Color.green, .1f, true);        
    }

    void Patrol()
    {
      //  enemy.meshRendererFlag.material.color = Color.green;
      //  enemy.navMeshAgent.destination = enemy.wayPoints[nextWayPoint].position;
      //  enemy.navMeshAgent.Resume();

        //did we reach last waypoint
        /*if(enemy.navMeshAgent.remainingDistance <= enemy.navMeshAgent.stoppingDistance && !enemy.navMeshAgent.pathPending)
        {
            nextWayPoint = (nextWayPoint + 1) % enemy.wayPoints.Length;
        }
        */
    }
}

