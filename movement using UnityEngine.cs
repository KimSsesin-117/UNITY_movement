using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float jumpForce = 5f;

    private Rigidbody rb;
    private bool isJumping = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // 키 입력 받기
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        bool jump = Input.GetButtonDown("Jump");

        // 이동 처리
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        rb.velocity = movement * movementSpeed;

        // 점프 처리
        if (jump && !isJumping)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 점프 중이 아닐 때만 점프 가능하도록 설정
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}
