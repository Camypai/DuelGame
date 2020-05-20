using Duel.Models;
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

        public Bullet(GameObject bulletObject, Vector3 startPosition, float speed)
        {
            _startPosition = startPosition;
            _speed = speed;
            _bullet = Object.Instantiate(bulletObject, _startPosition, Quaternion.identity);

            _rigidbody = _bullet.GetComponent<Rigidbody>();
            _trailRenderer = _bullet.GetComponent<TrailRenderer>();
        }


        public void Fire(float damage, int? faceValue)
        {
            Debug.Log("Fire");
            MoveToStartPosition();
            _rigidbody.AddForce(Vector3.forward * _speed);
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
            _rigidbody.AddForce(new Vector3(0.6f,0f,1f) * _speed);
        }
    }
}