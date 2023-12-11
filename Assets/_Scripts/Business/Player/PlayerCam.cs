using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float smoothSpeed = 0.125f;
    [SerializeField] Vector3 offset;

    private void Start() => target = PlayerMovement.Instance.transform;

    void LateUpdate() => CamMovement();

    void CamMovement()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
