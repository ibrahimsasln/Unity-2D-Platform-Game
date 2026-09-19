using UnityEngine;

public class SlimeMovement : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    Rigidbody2D slimeRB;
    private void Awake()
    {
        slimeRB = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        slimeRB.linearVelocity = new Vector2(speed, 0f);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        speed = -speed;
        transform.localScale = new Vector2(-(Mathf.Sign(slimeRB.linearVelocityX)), 1.0f);
    }
}
