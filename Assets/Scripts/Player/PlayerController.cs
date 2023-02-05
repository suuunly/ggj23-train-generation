using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        private static readonly int NextLevelKey = Animator.StringToHash("next level");
        private static readonly int InAirKey = Animator.StringToHash("in air");
        [SerializeField] private float jumpForce;
        [SerializeField] private float runningSpeed;

        [SerializeField] private LayerMask groundMask;
        [SerializeField] private float groundRadiusCheck;
        [SerializeField] private Vector2 groundCheckOffset;

        [SerializeField] private Animator animator;

        private Rigidbody2D _body;

        private bool _isGrounded;
        private bool _isJumping;
        private Vector2 _restingPoint;

        private void Awake()
        {
            _body = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _restingPoint = transform.position;
        }

        private void FixedUpdate()
        {
            Vector2 dir = (_restingPoint - (Vector2) transform.position).normalized;

            Vector2 velocity = _body.velocity;
            velocity.x = dir.x * runningSpeed;
            _body.velocity = velocity;

            CalculateGroundCheck();
        }

        private void LateUpdate()
        {
            animator.SetBool(InAirKey, !_isGrounded);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position + (Vector3) groundCheckOffset, groundRadiusCheck);

            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(_restingPoint, Vector3.one);
        }

        private void CalculateGroundCheck()
        {
            Collider2D hit = Physics2D.OverlapCircle(
                (Vector2) transform.position + groundCheckOffset,
                groundRadiusCheck,
                groundMask
            );

            _isGrounded = hit != null;
        }

        public void SlowDown()
        {
            animator.SetTrigger(NextLevelKey);
        }


        private void OnJump()
        {
            if (GameState.GameIsOver)
            {
                return;
            }

            if (!_isGrounded)
            {
                return;
            }

            _body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}