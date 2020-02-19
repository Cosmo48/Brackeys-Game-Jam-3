using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public JumpCheck jumpcheck;
    public WallJumpScript rightWalljumpcheck;
    public WallJumpScript leftWalljumpcheck;
    public GameObject bulletPrefab;

    Camera cam;
    public float jumpSpeed;
    public float wallJumpSpeed;
    public float moveSpeed;
    public float bulletSpeed;
    public float airControl;
    float moveDirection;
    Rigidbody2D rb2d;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = Input.GetAxis("Horizontal");

        Vector3 direction = transform.position - cam.ScreenToWorldPoint(Input.mousePosition);
        var lookAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;

        if (Input.GetMouseButtonDown(0))
        {
            Shoot(lookAngle);
        }

    }

    void FixedUpdate()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (rightWalljumpcheck.canWallJump)
            {
                rb2d.velocity = new Vector2(wallJumpSpeed * -1, jumpSpeed);
            }
            else if (leftWalljumpcheck.canWallJump)
            {
                rb2d.velocity = new Vector2(wallJumpSpeed, jumpSpeed);
            }
            else if (jumpcheck.canJump)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
            }
        }

        if (jumpcheck.canJump)
        {
            rb2d.velocity = moveDirection * Vector2.right * Time.deltaTime * moveSpeed + rb2d.velocity.y * Vector2.up;
        }
        else
        {
            rb2d.velocity = (moveDirection * Vector2.right * Time.deltaTime * moveSpeed) / airControl + ((rb2d.velocity.x * Vector2.right) * (airControl / 10)) + rb2d.velocity.y * Vector2.up;
        }


    }

    void Shoot(float angle)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, angle));
        Rigidbody2D bulletrb2d = bullet.GetComponent<Rigidbody2D>();
        bulletrb2d.rotation = angle;
        bulletrb2d.AddForce(bullet.transform.up * bulletSpeed);
    }
}