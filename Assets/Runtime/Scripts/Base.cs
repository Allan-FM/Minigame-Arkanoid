using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float impulseForce = 0.5f;

    // Update is called once per frame
    void Update()
    {
        ProcessMovement();
    }

    private void ProcessMovement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            var rbBall = GetComponent<Rigidbody2D>();
            if (rbBall != null)
            {
                rbBall.AddForce(Vector2.up * impulseForce, ForceMode2D.Impulse);
            }
            if (other.gameObject.transform.position.x > 0)
            {
                if (rbBall != null)
                {
                    rbBall.AddForce(Vector2.right * impulseForce, ForceMode2D.Impulse);
                }
            }
            if (other.gameObject.transform.position.x >= 0)
            {
                if (rbBall != null)
                {
                    rbBall.AddForce(Vector2.left * impulseForce, ForceMode2D.Impulse);
                }
            }
        }
    }
}
