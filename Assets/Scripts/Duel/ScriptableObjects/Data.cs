using System.IO;
using UnityEngine;
using UnityEngine.Serialization;


namespace Duel.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Data", menuName = "Duel/ScriptableObjects/Data")]
    public sealed class Data : ScriptableObject
    {
        #region PrivateData

        private const string BasePath = "Duel/Data";

        #endregion
        
        
        #region Fields

        [SerializeField] private string diceObjectPath;
        private static Data _instance;
        private static DiceObject _diceObject;

        #endregion
        
        
        #region Properties

        private static Data Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = Resources.Load<Data>($"{BasePath}/{nameof(Data)}");
                }

                return _instance;
            }
        }
        
        public static DiceObject DiceObject
        {
            get
            {
                // Debug.Log(Instance.diceObjectPath);
                if (_diceObject == null)
                {
                    _diceObject = Load<DiceObject>($"{BasePath}/{Instance.diceObjectPath}");
                }

                return _diceObject;
            }
        }

        #endregion


        #region Methods

        private static T Load<T>(string resourcesPath) where T : Object =>
            Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));
    
        #endregion
    }
}