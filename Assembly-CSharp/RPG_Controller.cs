using UnityEngine;

public class RPG_Controller : MonoBehaviour
{
	public static RPG_Controller instance;

	public CharacterController characterController;

	public float walkSpeed = 10f;

	public float turnSpeed = 2.5f;

	public float jumpHeight = 10f;

	public float gravity = 20f;

	public float fallingThreshold = -6f;

	private Vector3 playerDir;

	private Vector3 playerDirWorld;

	private Vector3 rotation = Vector3.zero;

	private Camera MainCamera;

	private void Awake()
	{
		instance = this;
		characterController = GetComponent("CharacterController") as CharacterController;
		RPG_Camera.CameraSetup();
		MainCamera = Camera.main;
	}

	private void Update()
	{
		if (!(MainCamera == null))
		{
			if (characterController == null)
			{
				Debug.Log("Error: No Character Controller component found! Please add one to the GameObject which has this script attached.");
				return;
			}
			GetInput();
			StartMotor();
		}
	}

	private void GetInput()
	{
		float num = 0f;
		float num2 = 0f;
		if (Input.GetButton("Horizontal Strafe"))
		{
			num = ((Input.GetAxis("Horizontal Strafe") < 0f) ? (-1f) : ((Input.GetAxis("Horizontal Strafe") > 0f) ? 1f : 0f));
		}
		if (Input.GetButton("Vertical"))
		{
			num2 = ((Input.GetAxis("Vertical") < 0f) ? (-1f) : ((Input.GetAxis("Vertical") > 0f) ? 1f : 0f));
		}
		if (Input.GetMouseButton(0) && Input.GetMouseButton(1))
		{
			num2 = 1f;
		}
		playerDir = num * Vector3.right + num2 * Vector3.forward;
		if (RPG_Animation.instance != null)
		{
			RPG_Animation.instance.SetCurrentMoveDir(playerDir);
		}
		if (characterController.isGrounded)
		{
			playerDirWorld = base.transform.TransformDirection(playerDir);
			if (Mathf.Abs(playerDir.x) + Mathf.Abs(playerDir.z) > 1f)
			{
				playerDirWorld.Normalize();
			}
			playerDirWorld *= walkSpeed;
			playerDirWorld.y = fallingThreshold;
			if (Input.GetButtonDown("Jump"))
			{
				playerDirWorld.y = jumpHeight;
				if (RPG_Animation.instance != null)
				{
					RPG_Animation.instance.Jump();
				}
			}
		}
		rotation.y = Input.GetAxis("Horizontal") * turnSpeed;
	}

	private void StartMotor()
	{
		playerDirWorld.y -= gravity * Time.deltaTime;
		characterController.Move(playerDirWorld * Time.deltaTime);
		base.transform.Rotate(rotation);
		if (!Input.GetMouseButton(0))
		{
			RPG_Camera.instance.RotateWithCharacter();
		}
	}
}
