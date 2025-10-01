using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovementHandler : MonoBehaviour
{
    [Header("Run")]
    [SerializeField] private bool canRun;
    [SerializeField] private Vector2 velocity;

    [Header("Jump")]
    [SerializeField] private bool canJump;
    [SerializeField] private int jumpCount;

    [Header("OnGround")]
    [SerializeField] private LayerMask GroundMask;

    [Header("Slide")]
    [SerializeField] private Vector2 originOffset;
    [SerializeField] private Vector2 originSize;
    [SerializeField] private Vector2 slideOffset;
    [SerializeField] private Vector2 slideSize;

    private CapsuleCollider2D playerCollider;
    private Player player;

    private void Awake()
    {
        playerCollider = GetComponentInChildren<CapsuleCollider2D>();
    }

    private void FixedUpdate()
    {
        if (canRun) Run();
        if (canJump) Jump();

        AddGravity();
    }

    public void Init(Player player)
    {
        this.player = player;
        player.EventHandler.OnJump += CheckJumpCount;
        player.EventHandler.OnSlide += CheckSlide;

        originOffset = playerCollider.offset;
        originSize = playerCollider.size;
    }

    #region Run
    /// <summary>
    /// 플레이어의 x축만 이동(y축 => 점프시 값 바뀌므로 현재 Rigidbody의 y값 적용)
    /// </summary>
    private void Run()
    {
        velocity = player.Rigidbody.velocity;
        velocity.x = player.StatHandler.GetSpeed();
        player.Rigidbody.velocity = velocity;
    }

    public void StartRun() => canRun = true;
    public void StopRun() => canRun = false;

    #endregion

    #region Jump
    /// <summary>
    /// 점프 카운트에 따라 State를 바꿔주고, Jump 관련 로직을 수행하는 메서드
    /// </summary>
    private void CheckJumpCount()
    {
        if (jumpCount == 0)
        {
            Debug.Log("Jump!");
            player.StateMachine.ChangeState(player.StateMachine.SingleJumpState);
        }
        else if (jumpCount == 1)
        {
            Debug.Log("Double Jump!");
            player.StateMachine.ChangeState(player.StateMachine.DoubleJumpState);
        }

        jumpCount++;
        canJump = true;
    }

    /// <summary>
    /// jumpForce 만큼 점프
    /// </summary>
    private void Jump()
    {
        float jumpForce = player.Data.JumpForce;

        player.Rigidbody.velocity = Vector2.zero;
        player.Rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        canJump = false;
    }

    /// <summary>
    /// 점프 후 하강할 때 중력을 더해 더 빠르게 떨어지게 함
    /// </summary>
    private void AddGravity()
    {
        float yVelocity = player.Rigidbody.velocity.y;

        if (yVelocity < 0) // 낙하 중이면
            player.Rigidbody.velocity += Vector2.up * Physics2D.gravity.y * (2.5f - 1) * Time.fixedDeltaTime;
    }
    #endregion

    #region OnGround
    /// <summary>
    /// 플레이어와 Ground 레이어 충돌 시 OnGround = True 처리
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((GroundMask.value & (1 << collision.transform.gameObject.layer)) > 0)
        {
            Debug.Log("Ground 충돌");
            player.EventHandler.CallOnGroundEvent(true);
            player.StateMachine.ChangeState(player.StateMachine.RunState);
            jumpCount = 0;
        }
    }
    #endregion

    #region Slide
    /// <summary>
    /// 슬라이드 상태에 따라 FSM 전환 및 Slide 관련 로직을 수행하는 메서드
    /// </summary>
    /// <param name="onSlide">슬라이드 모션을 시작할 것인지 = OnSlide==true </param>
    private void CheckSlide(bool onSlide)
    {
        if (onSlide)
            player.StateMachine.ChangeState(player.StateMachine.SlideState);
        else
            player.StateMachine.ChangeState(player.StateMachine.RunState);

        Slide(onSlide);
    }

    /// <summary>
    /// 실제 플레이어 슬라이드(콜라이더 크기를 바꿈)를 구현하는 메서드
    /// </summary>
    /// <param name="onSlide"></param>
    private void Slide(bool onSlide)
    {
        if (!onSlide)
        {
            playerCollider.direction = CapsuleDirection2D.Vertical;
            playerCollider.offset = originOffset;
            playerCollider.size = originSize;
        }
        else
        {
            playerCollider.direction = CapsuleDirection2D.Horizontal;
            playerCollider.offset = slideOffset;
            playerCollider.size = slideSize;
        }
    }
    #endregion
}
