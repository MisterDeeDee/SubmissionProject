using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyIA : MonoBehaviour
{
    public Transform target;
    NavMeshAgent agent;
    public float _distance;
    public float DistanceToFollow;
    private Vector3 Origin;


    void Start()
    {
        // Cache agent component and destination
        agent = GetComponent<NavMeshAgent>();
        Origin = this.transform.position;
    }


    void Update()
    {
        _distance = CalculateDistanceTarget(this.transform.position, target.position);
        if (_distance < DistanceToFollow)
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
        Vector3 _vDistancia;
        _vDistancia = (Target - Origen);
        _distance = _vDistancia.magnitude;
        return (_distance);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }


    }
}


