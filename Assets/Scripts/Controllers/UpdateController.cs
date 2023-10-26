using Lab.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


class UpdateController : MonoBehaviour, IController
{
    private List<IUpdate> _updates;

    public void Init()
    {
        _updates = GetComponentsInChildren<IUpdate>().ToList();
    }

    private void Update()
    {
        for (int i = 0; i < _updates.Count; i++)
        {
            _updates[i].FrameUpdate(Time.deltaTime);
        }
    }

    public void Remove<T>(T entity)
    {
        _updates.RemoveAll(a => a.Equals(entity));
    }
}
