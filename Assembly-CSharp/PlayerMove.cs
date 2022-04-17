using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000505 RID: 1285
public class PlayerMove : MonoBehaviour
{
	// Token: 0x06002150 RID: 8528 RVA: 0x001EB86D File Offset: 0x001E9A6D
	private void Awake()
	{
		this.charController = base.GetComponent<CharacterController>();
	}

	// Token: 0x06002151 RID: 8529 RVA: 0x001EB87B File Offset: 0x001E9A7B
	private void Update()
	{
		this.PlayerMovement();
	}

	// Token: 0x06002152 RID: 8530 RVA: 0x001EB884 File Offset: 0x001E9A84
	private void PlayerMovement()
	{
		float axis = Input.GetAxis(this.horizontalInputName);
		float axis2 = Input.GetAxis(this.verticalInputName);
		Vector3 a = base.transform.forward * axis2;
		Vector3 b = base.transform.right * axis;
		this.charController.SimpleMove(Vector3.ClampMagnitude(a + b, 1f) * this.movementSpeed);
		if ((axis2 != 0f || axis != 0f) && this.OnSlope())
		{
			this.charController.Move(Vector3.down * this.charController.height / 2f * this.slopeForce * Time.deltaTime);
		}
		this.SetMovementSpeed();
		this.JumpInput();
	}

	// Token: 0x06002153 RID: 8531 RVA: 0x001EB95C File Offset: 0x001E9B5C
	private void SetMovementSpeed()
	{
		if (Input.GetKey(this.runKey))
		{
			this.movementSpeed = Mathf.Lerp(this.movementSpeed, this.runSpeed, Time.deltaTime * this.runBuildUpSpeed);
			return;
		}
		this.movementSpeed = Mathf.Lerp(this.movementSpeed, this.walkSpeed, Time.deltaTime * this.runBuildUpSpeed);
	}

	// Token: 0x06002154 RID: 8532 RVA: 0x001EB9C0 File Offset: 0x001E9BC0
	private bool OnSlope()
	{
		if (this.isJumping)
		{
			return false;
		}
		RaycastHit raycastHit;
		if (Physics.Raycast(base.transform.position, Vector3.down, out raycastHit, this.charController.height / 2f * this.slopeForceRayLength) && raycastHit.normal != Vector3.up)
		{
			MonoBehaviour.print("OnSlope");
			return true;
		}
		return false;
	}

	// Token: 0x06002155 RID: 8533 RVA: 0x001EBA28 File Offset: 0x001E9C28
	private void JumpInput()
	{
		if (Input.GetKeyDown(this.jumpKey) && !this.isJumping)
		{
			this.isJumping = true;
			base.StartCoroutine(this.JumpEvent());
		}
	}

	// Token: 0x06002156 RID: 8534 RVA: 0x001EBA53 File Offset: 0x001E9C53
	private IEnumerator JumpEvent()
	{
		this.charController.slopeLimit = 90f;
		float timeInAir = 0f;
		do
		{
			float d = this.jumpFallOff.Evaluate(timeInAir);
			this.charController.Move(Vector3.up * d * this.jumpMultiplier * Time.deltaTime);
			timeInAir += Time.deltaTime;
			yield return null;
		}
		while (!this.charController.isGrounded && this.charController.collisionFlags != CollisionFlags.Above);
		this.charController.slopeLimit = 45f;
		this.isJumping = false;
		yield break;
	}

	// Token: 0x0400497C RID: 18812
	[SerializeField]
	private string horizontalInputName;

	// Token: 0x0400497D RID: 18813
	[SerializeField]
	private string verticalInputName;

	// Token: 0x0400497E RID: 18814
	[SerializeField]
	private float walkSpeed;

	// Token: 0x0400497F RID: 18815
	[SerializeField]
	private float runSpeed;

	// Token: 0x04004980 RID: 18816
	[SerializeField]
	private float runBuildUpSpeed;

	// Token: 0x04004981 RID: 18817
	[SerializeField]
	private KeyCode runKey;

	// Token: 0x04004982 RID: 18818
	private float movementSpeed;

	// Token: 0x04004983 RID: 18819
	[SerializeField]
	private float slopeForce;

	// Token: 0x04004984 RID: 18820
	[SerializeField]
	private float slopeForceRayLength;

	// Token: 0x04004985 RID: 18821
	private CharacterController charController;

	// Token: 0x04004986 RID: 18822
	[SerializeField]
	private AnimationCurve jumpFallOff;

	// Token: 0x04004987 RID: 18823
	[SerializeField]
	private float jumpMultiplier;

	// Token: 0x04004988 RID: 18824
	[SerializeField]
	private KeyCode jumpKey;

	// Token: 0x04004989 RID: 18825
	private bool isJumping;
}
