using System;
using UnityEngine;

[CreateAssetMenu(fileName = "EntityData", menuName = "Scriptable Objects/EntityData")]

[Serializable]
public class EntityData : ScriptableObject
{
    public string entityName;
    public float entityMass;
    public float entityMovementForce;
    public float cargoCapacity;

    public EntityData()
    {
        entityName = "Entity";
        entityMass = 100f;
        entityMovementForce = 10f;
        cargoCapacity = 50f;
    }

}
