using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed = 50;
    bool isMoving = false;
    void Update()
    {
        if (isMoving)
        {
            return;
        }

        if (Input.GetKey(KeyCode.D)){
            StartCoroutine(Roll(Vector3.right));
        }
        else if (Input.GetKey(KeyCode.A)) {
            StartCoroutine(Roll(Vector3.left));
        }
        else if (Input.GetKey(KeyCode.W)) {
            StartCoroutine(Roll(Vector3.forward));
        }
        else if (Input.GetKey(KeyCode.S)){
            StartCoroutine(Roll(Vector3.back));
        }
    }

    IEnumerator Roll(Vector3 direction)
    {
        isMoving = true;
        float remainingAngle = 90;
        Vector3 rotationCenter = transform.position + direction / 2 + Vector3.down / 2;
        Vector3 rotationAxis = Vector3.Cross(Vector3.up, direction);

        while (remainingAngle > 0)
        {
            float rotationAngle = Mathf.Min(Time.deltaTime * speed, remainingAngle);
            transform.RotateAround(rotationCenter, rotationAxis, rotationAngle);
            remainingAngle -= rotationAngle;
            yield return null;
        }

        isMoving = false;
    }
}