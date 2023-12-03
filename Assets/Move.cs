using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Move : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    float horizontal = 0f;
    float vertical = 0f;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 direction = Vector3.zero;
        if (Input.anyKey)
        {
            if (Input.GetKey(KeyCode.W)) direction += transform.forward;
            if (Input.GetKey(KeyCode.S)) direction -= transform.forward;
            if (Input.GetKey(KeyCode.D)) direction += transform.right;
            if (Input.GetKey(KeyCode.A)) direction -= transform.right;
            rb.velocity = speed * Time.deltaTime * direction.normalized;
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            float touchHorizontal = touch.deltaPosition.y;
            float touchVertical = touch.deltaPosition.x;

            horizontal = touchHorizontal;
            vertical = -touchVertical;
            direction = new Vector3(horizontal, 0f, vertical);
            rb.AddForce(direction * speed * 0.001f * Time.deltaTime, ForceMode.Impulse);
        }
    }
}