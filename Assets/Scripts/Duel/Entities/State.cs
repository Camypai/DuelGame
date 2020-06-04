using Duel.Enums;
using Duel.ScriptableObjects;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;


namespace Duel.Entities
{
    public class State
    {
        private float _healthPoints;

        public float HealthPoints
        {
            get => _healthPoints;
            set
            {
                _healthPoints = value;
                HealthPointsNotify?.Invoke(PlayerType.Player, _healthPoints);
                PhotonNetwork.RaiseEvent((byte)EventType.RefreshEnemyHealthPoint, value, new RaiseEventOptions {Receivers = ReceiverGroup.Others},
                                         SendOptions.SendReliable);
            }
        }
        public bool IsDead;
        
        public delegate void HealthPointsHandler(PlayerType playerType, float value);

        public event HealthPointsHandler HealthPointsNotify;

        public State()
        {
            
        }
        
        public State(StateObject stateObject)
        {
            HealthPoints = stateObject.healthPoints;
            IsDead = stateObject.isDead;
        }
    }
}