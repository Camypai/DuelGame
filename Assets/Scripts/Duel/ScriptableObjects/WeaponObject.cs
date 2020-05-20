using System.Linq;
using Duel.Models;
using UnityEngine;


namespace Duel.ScriptableObjects
{
    [CreateAssetMenu(fileName = "weapon", menuName = "Duel/ScriptableObjects/Weapon", order = 0)]
    public class WeaponObject : ScriptableObject
    {
        public GameObject weapon;
        public Vector3 bulletStartPosition;
        public float damage = 20f;
        public GameObject bullet;
        public float bulletSpeed = 20000f;
        public StatusObject[] statusObjects;
    }
}