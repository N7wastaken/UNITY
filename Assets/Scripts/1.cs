using UnityEngine;

public class CubeMover : MonoBehaviour
{
    [Header("Prędkość ruchu")]
    public float speed = 2f;

    private Vector3 startPos;
    private Vector3 endPos;
    private bool movingForward = true;

    void Start()
    {
        startPos = transform.position;
        endPos = startPos + new Vector3(10f, 0f, 0f);
    }

    void Update()
    {
        Vector3 target = movingForward ? endPos : startPos;

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.001f)
        {
            movingForward = !movingForward;
        }
    }
}
