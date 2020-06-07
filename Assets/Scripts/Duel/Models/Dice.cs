using System;
using Photon.Pun;
using UnityEngine;


namespace Duel.Models
{
    public class Dice : MonoBehaviour
    {
        [SerializeField] private Material _otherDiceMaterial;

        private void Start()
        {
            var photonView = GetComponent<PhotonView>();

            if (!photonView.IsMine)
            {
                var renderer = GetComponentInChildren<Renderer>();
                renderer.material = _otherDiceMaterial;
            }
        }
    }
}