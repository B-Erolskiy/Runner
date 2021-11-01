using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    [SerializeField] private Vector3 distance;
    [SerializeField] private Transform target;

    private void Update()
    {
        transform.position = target.position + distance;
    }
}