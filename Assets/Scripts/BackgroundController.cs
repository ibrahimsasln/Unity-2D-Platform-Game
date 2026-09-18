using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private float startXPos;
    private float bgLength;
    [SerializeField] GameObject cam;
    [SerializeField] float parallaxSpeed;
    private void Awake()
    {
        startXPos = transform.position.x;
        bgLength = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void FixedUpdate()
    {
        float distance = cam.transform.position.x * parallaxSpeed;
        float movement = cam.transform.position.x * (1 - parallaxSpeed);

        transform.position = new Vector2(startXPos + distance, transform.position.y);

        if (movement > startXPos + bgLength)
        {
            startXPos += bgLength;
        }
        else if (movement < startXPos - bgLength)
        {
            startXPos -= bgLength;
        }
    }
}
