using System.Collections;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	[SerializeField]
	private string horizontalInputName;

	[SerializeField]
	private string verticalInputName;

	[SerializeField]
	private float walkSpeed;

	[SerializeField]
	private float runSpeed;

	[SerializeField]
	private float runBuildUpSpeed;

	[SerializeField]
	private KeyCode runKey;

	private float movementSpeed;

	[SerializeField]
	private float slopeForce;

	[SerializeField]
	private float slopeForceRayLength;

	private CharacterController charController;

	[SerializeField]
	private AnimationCurve jumpFallOff;

	[SerializeField]
	private float jumpMultiplier;

	[SerializeField]
	private KeyCode jumpKey;

	private bool isJumping;

	private void Awake()
	{
		charController = GetComponent<CharacterController>();
	}

	private void Update()
	{
		PlayerMovement();
	}

	private void PlayerMovement()
	{
		float axis = Input.GetAxis(horizontalInputName);
		float axis2 = Input.GetAxis(verticalInputName);
		Vector3 vector = base.transform.forward * axis2;
		Vector3 vector2 = base.transform.right * axis;
		charController.SimpleMove(Vector3.ClampMagnitude(vector + vector2, 1f) * movementSpeed);
		if ((axis2 != 0f || axis != 0f) && OnSlope())
		{
			charController.Move(Vector3.down * charController.height / 2f * slopeForce * Time.deltaTime);
		}
		SetMovementSpeed();
		JumpInput();
	}

	private void SetMovementSpeed()
	{
		if (Input.GetKey(runKey))
		{
			movementSpeed = Mathf.Lerp(movementSpeed, runSpeed, Time.deltaTime * runBuildUpSpeed);
		}
		else
		{
			movementSpeed = Mathf.Lerp(movementSpeed, walkSpeed, Time.deltaTime * runBuildUpSpeed);
		}
	}

	private bool OnSlope()
	{
		if (isJumping)
		{
			return false;
		}
		if (Physics.Raycast(base.transform.position, Vector3.down, out var hitInfo, charController.height / 2f * slopeForceRayLength) && hitInfo.normal != Vector3.up)
		{
			MonoBehaviour.print("OnSlope");
			return true;
		}
		return false;
	}

	private void JumpInput()
	{
		if (Input.GetKeyDown(jumpKey) && !isJumping)
		{
			isJumping = true;
			StartCoroutine(JumpEvent());
		}
	}

	private IEnumerator JumpEvent()
	{
		charController.slopeLimit = 90f;
		float timeInAir = 0f;
		do
		{
			float num = jumpFallOff.Evaluate(timeInAir);
			charController.Move(Vector3.up * num * jumpMultiplier * Time.deltaTime);
			timeInAir += Time.deltaTime;
			yield return null;
		}
		while (!charController.isGrounded && charController.collisionFlags != CollisionFlags.Above);
		charController.slopeLimit = 45f;
		isJumping = false;
	}
}
