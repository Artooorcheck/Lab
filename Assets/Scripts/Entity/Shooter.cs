using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Shooter : Entity
{
    public static float damage = 3;

    float _coolDown;

    public GameObject gameObject;

    GameObject GameObject;

    Entity Entity;

    Vector3 pos;
    Vector3 pos2;

    float t = 0;

    bool stop = false;

    public override void Attack(Entity target)
    {
        if (GameObject == null)
        {
            GameObject = Instantiate(gameObject);
            GameObject.name = "Sphere";
            pos = GameObject.transform.position;
            foreach (var i in FindObjectsOfType<Entity>())
            {
                if (i == this)
                {
                    continue;
                }
                Entity = i;
            }
            pos = transform.position;
            GameObject.transform.position = pos;
            pos2 = Entity.transform.position;
            t = 0;
        }
        else
        {
            if (t <= 1)
            {
                if (GameObject.activeSelf)
                {
                    t = t + 0.04f;
                    GameObject.transform.position = Vector3.Lerp(pos, pos2, t) + Vector3.up * Mathf.Sin(t * Mathf.PI);
                }
                else
                {
                    Destroy(GameObject);
                    GameObject = null;
                    Entity = null;
                }
            }
            else
            {
                t = 0;
                Destroy(GameObject);
                GameObject = null;
                Entity = null;
            }
        }
    }

    public override void Move(Vector3 target)
    {
        transform.position = Vector3.MoveTowards(transform.position ,  transform.position + transform.position - target, 0.1f);
    }


    private void FixedUpdate()
    {
        try
        {
            if (stop != true)
            {
                Attack(null);

                if (dmg)
                {
                    if (visul <= 0)
                    {
                        visul = 0;
                        dmg = false;
                        var material = GetComponent<MeshRenderer>().material;
                        material.color = new Color(0, 0.4004605f, 1, 1);
                    }
                    else
                    {
                        visul -= 0.02f;
                    }
                }
            }
        }
        catch { stop = true; }
    }

    private void OnDestroy()
    {
        Destroy(GameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out MeleeFighter entity))
        {
            Move(entity.transform.position);
        }

        if (other.name == "Sphere" && GameObject != other.gameObject)
        {
            HP -= damage;
            Visual();
            if (HP <= 0)
            {
                Destroy(base.gameObject);
            }
        }
    }
}
