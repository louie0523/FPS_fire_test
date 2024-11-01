using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpHeight = 2f;
    public float gravity = -9.81f;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    // 애니메이터 추가
    private Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>(); // Animator 컴포넌트 가져오기
    }

    void Update()
    {
        // 땅에 닿았는지 확인
        isGrounded = controller.isGrounded;

        // 중력 초기화
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        // WASD 입력으로 이동
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // 이동 애니메이션 처리
        if (move.magnitude > 0) // 이동 중
        {
            if (Input.GetKey(KeyCode.LeftShift)) // 달릴 때
            {
                controller.Move(move * (moveSpeed * 1.5f) * Time.deltaTime);
                animator.SetBool("Run", true); // Run 애니메이션 활성화
                animator.SetBool("Walk", false); // Walk 애니메이션 비활성화
            }
            else // 걸을 때
            {
                controller.Move(move * moveSpeed * Time.deltaTime);
                animator.SetBool("Walk", true); // Walk 애니메이션 활성화
                animator.SetBool("Run", false); // Run 애니메이션 비활성화
            }
        }
        else // 정지 상태
        {
            animator.SetBool("Walk", false); // Walk 애니메이션 비활성화
            animator.SetBool("Run", false); // Run 애니메이션 비활성화
        }

        // 점프
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // 중력 적용
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    public void SetRotationY(float yRotation)
    {
        transform.localRotation = Quaternion.Euler(0, yRotation, 0);
    }
}
