    using TMPro;
    using Unity.VisualScripting;
    using UnityEngine;
    using UnityEngine.InputSystem;

    [RequireComponent(typeof(PlayerMotor))]
    public class InputManager : MonoBehaviour
    {
        public  PlayerActions playerActions;
        private PlayerMotor playerMotor;
        private CameraLook cameraLook;

        private void Awake()
        {
            playerActions = new PlayerActions();
            playerMotor = GetComponent<PlayerMotor>();
            cameraLook = GetComponentInChildren<CameraLook>();
            playerActions.OnFoot.Jump.performed += ctx => playerMotor.Jump();
            playerActions.OnFoot.Sprint.started += ctx => playerMotor.Sprint();
            playerActions.OnFoot.Sprint.canceled += ctx => playerMotor.Sprint();
        }

        private void OnEnable()
        {
            playerActions.OnFoot.Enable();

        }

        private void OnDisable()
        {
            playerActions.OnFoot.Disable();
        }

        private void FixedUpdate()
        {
            playerMotor.Move(playerActions.OnFoot.Movement.ReadValue<Vector2>());

        }

        private void LateUpdate()
        {
            cameraLook.Look(playerActions.OnFoot.Look.ReadValue<Vector2>());
        }
    }
