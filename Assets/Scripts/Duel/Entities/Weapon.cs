using Duel.Entities.Statuses;
using Duel.Helpers;
using Duel.Models;
using Duel.ScriptableObjects;
using Duel.Services;
using Photon.Pun;
using UnityEngine;


namespace Duel.Entities
{
    public class Weapon
    {
        private Vector3 _bulletPosition;
        private float _damage;
        private Bullet _bullet;
        private Status[] _statuses;
        
        public Weapon(WeaponObject weaponObject, UsableServices services)
        {
            _bulletPosition = PhotonNetwork.IsMasterClient ? weaponObject.bulletStartPositionForMasterClient : weaponObject.bulletStartPositionForOtherClient;
            _bullet = new Bullet(weaponObject.bullet, _bulletPosition, weaponObject.bulletSpeed, services);
            _damage = weaponObject.damage;
            _statuses = new Status[weaponObject.statusObjects.Length];

            var index = 0;
            foreach (var status in weaponObject.statusObjects)
            {
                _statuses[index] = Invoker.CreateStatus(status);
                index++;
            }
        }

        public void Shoot(int? faceValue)
        {
            if(faceValue != null && faceValue.Value > 2)
            {
                _bullet.Fire();
            }
            else
            {
                _bullet.Lose();
            }
        }
    }
}