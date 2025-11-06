using UnityEngine;

public class CubeSquareMover : MonoBehaviour
{
    [Header("Ustawienia ruchu")]
    public float speed = 2f;           // prędkość ruchu
    public float rotationSpeed = 90f;  // prędkość obrotu (stopnie/sekunda)
    public float sideLength = 10f;     // długość boku kwadratu

    private Vector3 startPos;
    private Vector3 targetPos;
    private Quaternion targetRotation;
    private int sideIndex = 0;
    private bool isTurning = false;

    void Start()
    {
        startPos = transform.position;
        targetPos = startPos + transform.forward * sideLength;
        targetRotation = transform.rotation;
    }

    void Update()
    {
        if (!isTurning)
        {
            MoveForward();
        }
        else
        {
            RotateToNextDirection();
        }
    }

    void MoveForward()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        // Kiedy osiągniemy cel pozycji
        if (Vector3.Distance(transform.position, targetPos) < 0.01f)
        {
            isTurning = true;

            // Zapamiętujemy stały kąt docelowy tylko raz
            targetRotation = Quaternion.Euler(0, transform.eulerAngles.y + 90f, 0);
        }
    }

    void RotateToNextDirection()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Kiedy zakończymy obrót (kąt bliski 0)
        if (Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
        {
            transform.rotation = targetRotation;
            isTurning = false;

            // Ustaw nowy cel ruchu w nowym kierunku
            targetPos = transform.position + transform.forward * sideLength;

            // Dla informacji – kolejny bok
            sideIndex = (sideIndex + 1) % 4;
        }
    }
}
