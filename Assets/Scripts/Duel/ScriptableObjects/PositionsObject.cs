using UnityEngine;
using UnityEngine.Serialization;


namespace Duel.ScriptableObjects
{
    [CreateAssetMenu(fileName = "positions", menuName = "Duel/ScriptableObjects/Positions", order = 0)]
    public class PositionsObject : ScriptableObject
    {
        public Vector3 spawnMasterPosition;
        public Vector3 spawnOtherPosition;
        public Vector3 cameraMasterPosition;
        public Vector3 cameraMasterRotate;
        public Vector3 cameraOtherPosition;
        public Vector3 cameraOtherRotate;
    }
}