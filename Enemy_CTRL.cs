using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_CTRL : MonoBehaviour
{
    [SerializeField]
    Transform target;
    NavMeshAgent agen;

    void Start()
    {
        agen = this.GetComponent<NavMeshAgent>();

        if(agen == null)
        {
            
        }
        else
        {
            SetTarget();
        }
    }

    void SetTarget()
    {
        if(target != null)
        {
            Vector3 pos = target.transform.position;
            agen.SetDestination(pos);
        }
        else if(target = null)
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        agen.destination = target.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
        if(other.gameObject.tag == "Goal")
        {
            Destroy(this.gameObject);
        }
    }

   

}
