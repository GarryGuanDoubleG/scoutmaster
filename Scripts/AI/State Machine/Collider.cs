using UnityEngine;
using System.Collections;

public class Collider : MonoBehaviour
{
    private  StatePatternEnemy enemy;
    [HideInInspector] private string mTag;

    public void Awake()
    {
        enemy = transform.root.gameObject.GetComponent<StatePatternEnemy>();
        if (!enemy)
            Debug.Log("Enemy is null");
        else
            Debug.Log("Found enemy");
                 
        mTag = GetComponent<CircleCollider2D>().tag;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player"))
            return;

        if (mTag == "Alert_Collider")
        {
            Debug.Log("Entered Alert");
            enemy.currentState.ToAlertState();
        }
        else if(mTag == "Chase_Collider")
        {
            Debug.Log("Entered Chase");
            enemy.chaseTarget = other.transform;
            enemy.currentState.ToChaseState();
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player"))
            return;

        if(mTag == "Chase_Collider")
        {
            Debug.Log("Exited Chase");
            enemy.chaseTarget = null;
            enemy.currentState.ToAlertState();
        }
        else if (mTag == "Alert_Collider")
        {
            Debug.Log("Exited Alert");
            enemy.currentState.ToPatrolState();
        }
    }
}
