using Duel.Models;
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

        public Bullet(GameObject bulletObject, Vector3 startPosition, float speed)
        {
            _startPosition = startPosition;
            _speed = speed;
            _direction = PhotonNetwork.IsMasterClient ? 0f : -180f;
            _bullet = Object.Instantiate(bulletObject, _startPosition, Quaternion.Euler(new Vector3(0f, _direction, 0f)));

            _rigidbody = _bullet.GetComponent<Rigidbody>();
            _trailRenderer = _bullet.GetComponent<TrailRenderer>();
        }


        public void Fire(float damage, int? faceValue)
        {
            Debug.Log("Fire");
            MoveToStartPosition();
            var direction = PhotonNetwork.IsMasterClient ? Vector3.forward : Vector3.back;
            _rigidbody.AddForce(direction * _speed);
        }

        private void MoveToStartPosition()
        {
            _rigidbody.ResetInertiaTensor();
            _bullet.transform.position = _startPosition;
            _trailRenderer.Clear();
        }

        public void Lose()
        {
            MoveToStartPosition();
            _rigidbody.AddForce(new Vector3(0.6f, 0f,0f) * _speed);
        }
    }
}