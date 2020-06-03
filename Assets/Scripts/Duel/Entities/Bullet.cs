using Duel.Models;
using Duel.Services;
using Photon.Pun;
using UnityEngine;


namespace Duel.Entities
{
    public class Bullet
    {
        private readonly GameObject _bullet;
        private readonly Vector3 _startPosition;
        private readonly float _speed;
        private readonly Rigidbody _rigidbody;
        private readonly TrailRenderer _trailRenderer;
        private float _direction;
        private UsableServices _services;

        public Bullet(GameObject bulletObject, Vector3 startPosition, float speed, UsableServices services)
        {
            _startPosition = startPosition;
            _speed = speed;
            _services = services;
            var direction = PhotonNetwork.IsMasterClient ? 0f : -180f;
            _direction = PhotonNetwork.IsMasterClient ? 1f : -1f;
            _bullet = Object.Instantiate(bulletObject, _startPosition, Quaternion.Euler(new Vector3(0f, direction, 0f)));

            _rigidbody = _bullet.GetComponent<Rigidbody>();
            _trailRenderer = _bullet.GetComponent<TrailRenderer>();
        }


        public void Fire()
        {
            MoveToStartPosition();
            var direction = new Vector3(0f,0f, _direction);
            Debug.Log(direction);
            _rigidbody.AddForce(direction * _speed, ForceMode.Acceleration);
            _services.InvokeService.Invoke(MoveToStartPosition, 2f);
        }

        private void MoveToStartPosition()
        {
            _rigidbody.ResetInertiaTensor();
            _rigidbody.velocity = Vector3.zero;
            _bullet.transform.position = _startPosition;
            _trailRenderer.Clear();
        }

        public void Lose()
        {
            MoveToStartPosition();
            var direction = new Vector3(0.6f,0, _direction);
            Debug.Log(direction);
            _rigidbody.AddForce(direction * _speed, ForceMode.Acceleration);
            _services.InvokeService.Invoke(MoveToStartPosition, 2f);
        }
    }
}