using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public sealed class MeleeFighter : Entity
{
    private Entity _entity;


    public override void Attack(Entity target)
    {
        target.HP -= Damage;
        target.Visual();
        if (target.HP <= 0)
        {
            Destroy(target.gameObject);
            GetComponent<NavMeshAgent>().isStopped = false;
            _entity = null;
        }
    }

    public override void Move(Vector3 target)
    {
        GetComponent<NavMeshAgent>().SetDestination(target);
    }

    private void Update()
    {
        if (_entity != null)
        {
            Attack(_entity);
        }
        else
        {
            Move(FindObjectsOfType<Entity>().Where(a=>a.gameObject!=gameObject).OrderBy(a=>Vector3.Distance(transform.position, a.transform.position)).First().transform.position);
        }
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
                material.color = new Color(1, 0, 0, 1);
            }
            else
            {
                visul -= 0.02f;
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Entity entity))
        {
            GetComponent<NavMeshAgent>().isStopped = true;
            _entity = entity;
        }
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

    public void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Entity entity) && entity == _entity)
        {
            GetComponent<NavMeshAgent>().isStopped = false;
            _entity = null;
        }
    }
}
