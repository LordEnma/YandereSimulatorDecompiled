using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000505 RID: 1285
public class PlayerMove : MonoBehaviour
{
	// Token: 0x06002149 RID: 8521 RVA: 0x001EAE11 File Offset: 0x001E9011
	private void Awake()
	{
		this.charController = base.GetComponent<CharacterController>();
	}

	// Token: 0x0600214A RID: 8522 RVA: 0x001EAE1F File Offset: 0x001E901F
	private void Update()
	{
		this.PlayerMovement();
	}

	// Token: 0x0600214B RID: 8523 RVA: 0x001EAE28 File Offset: 0x001E9028
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

	// Token: 0x0600214C RID: 8524 RVA: 0x001EAF00 File Offset: 0x001E9100
	private void SetMovementSpeed()
	{
		if (Input.GetKey(this.runKey))
		{
			this.movementSpeed = Mathf.Lerp(this.movementSpeed, this.runSpeed, Time.deltaTime * this.runBuildUpSpeed);
			return;
		}
		this.movementSpeed = Mathf.Lerp(this.movementSpeed, this.walkSpeed, Time.deltaTime * this.runBuildUpSpeed);
	}

	// Token: 0x0600214D RID: 8525 RVA: 0x001EAF64 File Offset: 0x001E9164
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

	// Token: 0x0600214E RID: 8526 RVA: 0x001EAFCC File Offset: 0x001E91CC
	private void JumpInput()
	{
		if (Input.GetKeyDown(this.jumpKey) && !this.isJumping)
		{
			this.isJumping = true;
			base.StartCoroutine(this.JumpEvent());
		}
	}

	// Token: 0x0600214F RID: 8527 RVA: 0x001EAFF7 File Offset: 0x001E91F7
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

	// Token: 0x0400496A RID: 18794
	[SerializeField]
	private string horizontalInputName;

	// Token: 0x0400496B RID: 18795
	[SerializeField]
	private string verticalInputName;

	// Token: 0x0400496C RID: 18796
	[SerializeField]
	private float walkSpeed;

	// Token: 0x0400496D RID: 18797
	[SerializeField]
	private float runSpeed;

	// Token: 0x0400496E RID: 18798
	[SerializeField]
	private float runBuildUpSpeed;

	// Token: 0x0400496F RID: 18799
	[SerializeField]
	private KeyCode runKey;

	// Token: 0x04004970 RID: 18800
	private float movementSpeed;

	// Token: 0x04004971 RID: 18801
	[SerializeField]
	private float slopeForce;

	// Token: 0x04004972 RID: 18802
	[SerializeField]
	private float slopeForceRayLength;

	// Token: 0x04004973 RID: 18803
	private CharacterController charController;

	// Token: 0x04004974 RID: 18804
	[SerializeField]
	private AnimationCurve jumpFallOff;

	// Token: 0x04004975 RID: 18805
	[SerializeField]
	private float jumpMultiplier;

	// Token: 0x04004976 RID: 18806
	[SerializeField]
	private KeyCode jumpKey;

	// Token: 0x04004977 RID: 18807
	private bool isJumping;
}
