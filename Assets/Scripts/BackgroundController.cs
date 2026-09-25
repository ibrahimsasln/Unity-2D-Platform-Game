using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] float parallaxSpeed;
    Transform cam;
    private float startXPos;
    private float bgLength;

    private void Awake()
    {
        cam = Camera.main.transform;
        startXPos = transform.position.x;
        bgLength = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void LateUpdate()
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
