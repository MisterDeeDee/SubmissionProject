using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyIA : MonoBehaviour
{
    public Transform target;
    NavMeshAgent agent;
    public float distance;
    public float DistanceToFollow;
    private Vector3 Origin;


    void Start()
    {
        // Cache agent component and destination
        agent = GetComponent<NavMeshAgent>();
        StartEnemy();
    }

    public void StartEnemy()
    {
        Origin = this.transform.position;
        agent.speed = GameManager.GameManagerObject.enemySpeed;
    }

    void Update()
    {
        distance = CalculateDistanceTarget(this.transform.position, target.position);
        if (distance < DistanceToFollow)
        {
            agent.destination = target.position;
        }
        else
        {
            agent.destination = Origin;
        }

    }

    float CalculateDistanceTarget(Vector3 Origen, Vector3 Target)
    {
        Vector3 vDistancia;
        vDistancia = (Target - Origen);
        distance = vDistancia.magnitude;
        return (distance);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.GameManagerObject.PlayerKilled();
        }


    }
}


