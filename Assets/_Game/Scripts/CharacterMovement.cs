using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    float moveSpeed = 10;
    bool isMoving;
    Direction currentDirection;


    // Update is called once per frame
    void Update()
    {
        currentDirection = GetComponent<InputHandler>().GetDirection();
        if (!isMoving)
        {
            CheckCanMove(currentDirection);
        }
        else
        {

        }
    }

    private void CheckCanMove(Direction direction)
    {

    }

    Vector3 GetMoveDir(Direction direction)
    {
        switch (direction)
        {
            case Direction.Up: 
                return Vector3.forward;
            case Direction.Down: 
                return Vector3.back;
            case Direction.Right: 
                return Vector3.right;
            case Direction.Left: 
                return Vector3.left;
            default: 
                return Vector3.zero;
        }
    }
}
