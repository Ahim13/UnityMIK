using UnityEngine;


public abstract class AiBrain : ScriptableObject
{
    public abstract void Init(GameObject gameObject, AIProperties aiProp, Transform ball);
    public abstract void Control(Transform transform);
}