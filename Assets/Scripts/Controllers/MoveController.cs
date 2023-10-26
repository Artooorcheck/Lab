using Lab.Entity;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

class MoveController : MonoBehaviour, IController, IUpdate
{
    [SerializeField] private Rect _fieldSize;

    private List<IMovable> _movables;
    public void Init()
    {
        _movables = GetComponentsInChildren<IMovable>().ToList();
        foreach (var movable in _movables)
        {
            movable.OnFinishTask += (resp) => _movables.Add((IMovable)resp);
            movable.OnStartTask += (resp) => _movables.Remove((IMovable)resp);
        }
    }

    public void Remove<T>(T entity)
    {
        _movables.RemoveAll(a => a.Equals(entity));
    }

    public void FrameUpdate(float deltaTime)
    {
        for (int i = 0; i < _movables.Count; i++)
        {
            _movables[i].Move(GetRandomPosition());
        }
    }

    private Vector3 GetRandomPosition()
    {
        return new Vector3(Random.Range(_fieldSize.x, _fieldSize.x + _fieldSize.width), 0, Random.Range(_fieldSize.y, _fieldSize.y + _fieldSize.height));
    }
}