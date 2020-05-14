using Duel.Interfaces;
using UnityEngine;


namespace Duel.Systems
{
    public class CharacterSystem : IStartSystem, IUpdateSystem
    {
        public void Start()
        {
            Debug.Log("Start");
        }

        public void Update()
        {
            Debug.Log("Update");
        }
    }
}