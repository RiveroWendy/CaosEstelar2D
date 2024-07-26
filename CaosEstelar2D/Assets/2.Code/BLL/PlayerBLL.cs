using UnityEngine;
using BE;
using UnityEngine.InputSystem;


namespace BLL
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerBLL : MonoBehaviour
    {
        #region Properties
        private PlayerBE _playerBE = new PlayerBE();

        public PlayerBE PlayerBE
        {
            get { return _playerBE; }
            set { _playerBE = value; }
        }

        private PlayerInput _playerInputI;

        public PlayerInput PlayerInputI
        {
            get { return _playerInputI; }
            set { _playerInputI = value; }
        }

        private Rigidbody2D _rigidBodyPlayer;

        public Rigidbody2D RigidBodyPlayer
        {
            get { return _rigidBodyPlayer; }
            set { _rigidBodyPlayer = value; }
        }

        private float _moveInput;

        public float MoveInput
        {
            get { return _moveInput; }
            set { _moveInput = value; }
        }

        private int _remainingJumps;

        public int RemainingJumps
        {
            get { return _remainingJumps; }
            set { _remainingJumps = value; }
        }


        #endregion

        private void Awake()
        {
            RigidBodyPlayer = GetComponent<Rigidbody2D>();
            PlayerInputI = GetComponent<PlayerInput>();


            PlayerInputI.actions["Movement"].performed += ctx => MoveInput = ctx.ReadValue<float>();
            PlayerInputI.actions["Movement"].canceled += ctx => MoveInput = 0f;
            _remainingJumps = PlayerBE.LimitJumps;

        }

        private void Update()
        {
            PlayerMovement();
            CheckIfPlayerOnTheGround();
        }

        #region Methods
        public void PlayerMovement()
        {
            if (RigidBodyPlayer != null && RigidBodyPlayer.bodyType == RigidbodyType2D.Dynamic)
            {
                Vector2 currentVelocity = RigidBodyPlayer.velocity;
                RigidBodyPlayer.velocity = new Vector2(_moveInput * PlayerBE.SpeedMovement, currentVelocity.y);
            }
        }

        public void PlayerJumpWhenPressButton(InputAction.CallbackContext callbackContext)
        {
            if (RigidBodyPlayer != null && callbackContext.performed && _remainingJumps > 0)
            {
               // RigidBodyPlayer.bodyType = RigidbodyType2D.Dynamic;
                RigidBodyPlayer.velocity = new Vector2(RigidBodyPlayer.velocity.x, PlayerBE.JumpForce);
                _remainingJumps--;
            }
        }

        private void CheckIfPlayerOnTheGround()
        {

            if (Mathf.Abs(RigidBodyPlayer.velocity.y) < 0.01f)
            {
                PlayerBE.PlayerOnTheGround = true;
                _remainingJumps = PlayerBE.LimitJumps;
            }
            else
            {
                PlayerBE.PlayerOnTheGround = false;
            }
        }
        #endregion
    }
}