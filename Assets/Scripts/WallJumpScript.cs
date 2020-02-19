using UnityEngine;

public class WallJumpScript : MonoBehaviour
{
    [HideInInspector]
    public bool canWallJump = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canWallJump = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canWallJump = false;
        }
    }

}
