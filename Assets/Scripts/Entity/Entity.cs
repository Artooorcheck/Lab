using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public float HP;

    public float Damage;

    protected bool dmg;

    protected float visul = 0;

    public abstract void Move(Vector3 target); //interface segregation principie

    public abstract void Attack(Entity target);

    public void Visual()
    {
        if(this is MeleeFighter or Shooter) //Liskov substitution principie
                                            //Open/close principie
        {
            dmg = true;
            visul = 0.3f;
           var material =  GetComponent<MeshRenderer>().material;
            material.color = Color.white;
            GetComponent<MeshRenderer>().material = material;
        }

        if (this is Civilian)
        {
            dmg = true;
            visul = 0.3f;
            var material = GetComponent<MeshRenderer>().material;
            material.color = Color.gray;
            GetComponent<MeshRenderer>().material = material;
        }
    }
}
