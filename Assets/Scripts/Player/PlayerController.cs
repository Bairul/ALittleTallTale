using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayerStats))]
public class PlayerController : MonoBehaviour
{
    // inspector fields
    [SerializeField] private PlayerAnimate animate;

    // private fields
    private PlayerStats playerStats;
    private Rigidbody2D rgbd2d;
    public Rigidbody2D Rigidbody { get => rgbd2d; }
    private Vector2 mvt;

    [HideInInspector] public bool canMove;

    // Awake is called before Start. Frequently used to get internal components and initialize fields
    void Awake()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
        playerStats = GetComponent<PlayerStats>();

        canMove = true;
    }

    // Start is used when referencing other game objects and their components or just after Awake
    void Start()
    {

    }

    void PlayerMovement()
    {
        mvt.x = Input.GetAxisRaw("Horizontal");
        mvt.y = Input.GetAxisRaw("Vertical");

        animate.vertical = (int)mvt.y;
        animate.horizontal = (int)mvt.x;
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

        rgbd2d.velocity = mvt.normalized * playerStats.currentMovementSpeed;
    }
}