using System;
using Photon.Pun;
using UnityEngine;


namespace Duel.Models
{
    public class Dice : MonoBehaviour
    {
        [SerializeField] 
        private Material _otherDiceMaterial;
        
        private void Start()
        {
            var photonView = GetComponent<PhotonView>();

            if (!photonView.IsMine)
            {
                var meshRenderer = GetComponentInChildren<MeshRenderer>();
                for (var i = 0; i < meshRenderer.materials.Length; i++)
                {
                    Debug.Log(meshRenderer.materials[i]);
                    meshRenderer.materials[i] = _otherDiceMaterial;
                }
            }
        }
    }
}