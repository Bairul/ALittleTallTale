using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    // inspector fields
    [SerializeField] private PlayerAnimate animate;

    // private fields
    private Rigidbody2D rgbd2d;
    private Vector2 mvt;

    public bool canMove;
    public bool isFacingRight;

    // Awake is called before Start. Frequently used to get internal components and initialize fields
    void Awake()
    {
        rgbd2d = GetComponent<Rigidbody2D>();

        canMove = true;
    }

    // Start is used when referencing other objects and their components or after Awake
    void Start()
    {
        
    }

    void PlayerMovement()
    {
        mvt.x = Input.GetAxisRaw("Horizontal");
        mvt.y = Input.GetAxisRaw("Vertical");

        animate.vertical = (int) mvt.y;
        animate.horizontal = (int) mvt.x;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    // FixedUpdate is called at fixed intervals
    void FixedUpdate()
    {
        if (!canMove) return;

        rgbd2d.velocity = mvt.normalized * 4F;
    }
}
