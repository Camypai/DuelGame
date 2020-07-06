using UnityEngine;


namespace Duel.ScriptableObjects
{
    [CreateAssetMenu(fileName = "board", menuName = "Duel/ScriptableObjects/Board", order = 0)]
    public class BoardObject : ScriptableObject
    {
        public CellObject[] CellsForFirstPlayer = new CellObject[10];
    }
}