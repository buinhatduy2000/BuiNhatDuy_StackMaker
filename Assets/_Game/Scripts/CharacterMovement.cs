using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public static CharacterMovement Instance;

    public GameObject BrickParent;
    public GameObject PrevBrick;
    public Transform CheckBrick;
    public LayerMask mask;

    private Rigidbody rb;
    [SerializeField] private float moveSpeed = 10;
    [SerializeField] private bool isMoving;

    Direction moveDirection;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        moveDirection = InputHandler.Instance.GetDirection();

        DoRotate(moveDirection);
        if (isMoving)
        {
            DoMove(moveDirection);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }

    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(CheckBrick.transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity, mask))
        {
            Debug.DrawRay(CheckBrick.transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.red);

            if (hit.collider.gameObject.layer == 7)
            {
                isMoving = false;
            }
            else
            {
                isMoving = true;
            }

        }
    }

    public void PickBrich(GameObject brick)
    {
        brick.transform.SetParent(BrickParent.transform);
        Vector3 pos = PrevBrick.transform.localPosition;
        Quaternion rote = PrevBrick.transform.rotation;
        pos.y -= 0.25f;
        brick.transform.localPosition = pos;
        brick.transform.rotation = rote;

        Vector3 CharacterPos = transform.localPosition;

        CharacterPos.y += 0.25f;
        transform.localPosition = CharacterPos;

        PrevBrick = brick;
        PrevBrick.GetComponent<BoxCollider>().isTrigger = false;
    }

    public void DropBrick(GameObject brick)
    {

    }

    private void DoMove(Direction moveDirection)
    {
        if (rb.velocity == Vector3.zero)
        {
            switch (moveDirection)
            {
                case Direction.Up:
                    rb.velocity = Vector3.forward * moveSpeed * Time.deltaTime;
                    Debug.Log("Move up");
                    break;
                case Direction.Down:
                    rb.velocity = -Vector3.forward * moveSpeed * Time.deltaTime;
                    Debug.Log("Move down");
                    break;
                case Direction.Left:
                    rb.velocity = Vector3.left * moveSpeed * Time.deltaTime;
                    Debug.Log("Move left");
                    break;
                case Direction.Right:
                    rb.velocity = Vector3.right * moveSpeed * Time.deltaTime;
                    Debug.Log("Move right");
                    break;
            }
        }
    }

    private void DoRotate(Direction moveDirection)
    {
        if (rb.velocity == Vector3.zero)
        {
            switch (moveDirection)
            {
                case Direction.Up:
                    transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
                    break;
                case Direction.Down:
                    transform.eulerAngles = new Vector3(0.0f, -180.0f, 0.0f);
                    break;
                case Direction.Left:
                    transform.eulerAngles = new Vector3(0.0f, -90.0f, 0.0f);
                    break;
                case Direction.Right:
                    transform.eulerAngles = new Vector3(0.0f, 90.0f, 0.0f);
                    break;
            }
        }
    }
}
