using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Civilian : Entity
{
    public override void Attack(Entity target)
    {
        throw new System.NotImplementedException();
    }

    public override void Move(Vector3 target)
    {
        var nma = GetComponent<NavMeshAgent>();

        nma.SetDestination(target);
    }


    private void FixedUpdate()
    {
        if (dmg)
        {
            if (visul <= 0)
            {
                visul = 0;
                dmg = false;
                var material = GetComponent<MeshRenderer>().material;
                material.color = new Color(0, 1, 0.08871648f, 1);
            }
            else
            {
                visul -= 0.02f;
            }
        }
    }

    private void Update()
    {
        if (!GetComponent<NavMeshAgent>().hasPath)
        {
            Move(new Vector3(Random.Range(-8, 8), 0, Random.Range(-8, 8)));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Sphere")
        {
            HP -= Shooter.damage;
            Visual();
            if (HP <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
