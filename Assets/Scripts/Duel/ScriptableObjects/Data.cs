using System.IO;
using Duel.Constants;
using UnityEngine;
using UnityEngine.Serialization;


namespace Duel.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Data", menuName = "Duel/ScriptableObjects/Data")]
    public sealed class Data : ScriptableObject
    {
        #region PrivateData

        private const string BasePath = Constant.ScriptableObjectPath;

        #endregion
        
        
        #region Fields

        [SerializeField] private string diceObjectPath;
        [SerializeField] private string characterObjectPath;
        [SerializeField] private string weaponObjectPath;
        [SerializeField] private string statusesObjectPath;
        [SerializeField] private string positionsObjectPath;
        [SerializeField] private string worldObjectPath;
        [SerializeField] private string itemObjectPath;
        private static Data _instance;
        private static DiceObject _diceObject;
        private static CharacterObject _characterObject;
        private static WeaponObject _weaponObject;
        private static StatusesObject _statusesObject;
        private static PositionsObject _positionsObject;
        private static WorldObject _worldObject;

        #endregion
        
        
        #region Properties

        private static Data Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = Resources.Load<Data>($"{BasePath}{nameof(Data)}");
                }

                return _instance;
            }
        }
        
        public static DiceObject DiceObject
        {
            get
            {
                if (_diceObject == null)
                {
                    _diceObject = Load<DiceObject>($"{BasePath}{Instance.diceObjectPath}");
                }

                return _diceObject;
            }
        }
        
        public static CharacterObject CharacterObject
        {
            get
            {
                if (_characterObject == null)
                {
                    _characterObject = Load<CharacterObject>($"{BasePath}{Instance.characterObjectPath}");
                }

                return _characterObject;
            }
        }
        
        public static WeaponObject WeaponObject
        {
            get
            {
                if (_weaponObject == null)
                {
                    _weaponObject = Load<WeaponObject>($"{BasePath}{Instance.weaponObjectPath}");
                }

                return _weaponObject;
            }
        }
        
        public static StatusesObject StatusesObject
        {
            get
            {
                if (_statusesObject == null)
                {
                    _statusesObject = Load<StatusesObject>($"{BasePath}{Instance.statusesObjectPath}");
                }

                return _statusesObject;
            }
        }
        
        public static PositionsObject PositionsObject 
        {
            get
            {
                if (_positionsObject == null)
                {
                    _positionsObject = Load<PositionsObject>($"{BasePath}{Instance.positionsObjectPath}");
                }

                return _positionsObject;
            }
        }
        
        public static WorldObject WorldObject 
        {
            get
            {
                if (_worldObject == null)
                {
                    _worldObject = Load<WorldObject>($"{BasePath}{Instance.worldObjectPath}");
                }

                return _worldObject;
            }
        }

        #endregion


        #region Methods

        private static T Load<T>(string resourcesPath) where T : Object =>
            Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));
    
        #endregion
    }
}