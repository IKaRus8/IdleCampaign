using UnityEngine;

namespace Models.Interfaces
{
    public interface IPlayer
    {
        IEnemy TargetToPursue { get; set; }
        GameObject PlayerObject { get; set; }
        Vector3 PlayerPosition { get; }
        float MaxHealth { get; }
        float Attack { get; }
        T GetComponent<T>() where T : Component;

    }
}
