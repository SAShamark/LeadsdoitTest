using Cinemachine;
using UnityEngine;

namespace Entities.Camera
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _cinemachineVirtualCamera;

        public void Follow(Transform following)
        {
            _cinemachineVirtualCamera.Follow = following;
        }
    }
}