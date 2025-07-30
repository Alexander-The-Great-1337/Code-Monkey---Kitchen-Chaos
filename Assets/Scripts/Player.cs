using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;

    private readonly float  rotateSpeed = 10f;
    private void Update()
    {
        Vector3 moveDir = GetMoveDir(GetInput());

        MovePlayer(moveDir);
        RotateAnimation(moveDir);
    }

    private void MovePlayer(Vector3 moveDir)
    {
        transform.position += moveSpeed * Time.deltaTime * moveDir;
    }

    private void RotateAnimation(Vector3 moveDir)
    {
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
    }

    private Vector2 GetInput()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");

        Vector2 vector2 = new(horizontalAxis, verticalAxis);

        return vector2.normalized;
    }

    private Vector3 GetMoveDir(Vector2 input)
    {
        return new Vector3(input.x, 0f, input.y);
    }
}
