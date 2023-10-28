using System;
using UnityEngine;

namespace Lab.Extentions
{
    public static class GameObjectExtention
    {
        public static T GetCovariantComponent<T>(this MonoBehaviour monoBehaviour)
        {
            var components = monoBehaviour.GetComponents<MonoBehaviour>();
            foreach (var component in components)
            {
                if (component is T)
                    return (T)Convert.ChangeType(component, typeof(T));
            }
            return default(T);
        }
    }
}
