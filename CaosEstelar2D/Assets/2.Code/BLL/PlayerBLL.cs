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

        #endregion

        private void Awake()
        {
            RigidBodyPlayer = GetComponent<Rigidbody2D>();
            PlayerInputI = GetComponent<PlayerInput>();


            PlayerInputI.actions["Movement"].performed += ctx => MoveInput = ctx.ReadValue<float>();
            PlayerInputI.actions["Movement"].canceled += ctx => MoveInput = 0f;
        }

        private void Update()
        {
            PlayerMovement();
        }

        #region Methods
        public void PlayerMovement()
        {
            if (RigidBodyPlayer != null)
            {
                Vector2 currentVelocity = RigidBodyPlayer.velocity;
                RigidBodyPlayer.velocity = new Vector2(_moveInput * PlayerBE.SpeedMovement, currentVelocity.y);
            }
        }

        public void PlayerJumpWhenPressButton(InputAction.CallbackContext callbackContext)
        {
            if (RigidBodyPlayer != null && callbackContext.performed)
            {
                RigidBodyPlayer.bodyType = RigidbodyType2D.Dynamic;
                RigidBodyPlayer.velocity = new Vector2(RigidBodyPlayer.velocity.x, PlayerBE.JumpForce);
            }
        }
        #endregion
    }
}