using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;
    public enum Mode { Lerp, SmoothDamp }
    public Mode mode = Mode.Lerp;

    [Header("Lerp Settings")]
    public float lerpSpeed = 5f;

    [Header("SmoothDamp Settings")]
    public float smoothTime = 0.3f;
    private Vector3 currentVelocity = Vector3.zero;

    void Update()
    {
        if (target == null) return;

        if (mode == Mode.Lerp)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, lerpSpeed * Time.deltaTime);
        }
        else if (mode == Mode.SmoothDamp)
        {
            transform.position = Vector3.SmoothDamp(transform.position, target.position, ref currentVelocity, smoothTime);
        }
    }
}
