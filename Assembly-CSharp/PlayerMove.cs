using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004FF RID: 1279
public class PlayerMove : MonoBehaviour
{
	// Token: 0x06002131 RID: 8497 RVA: 0x001E9071 File Offset: 0x001E7271
	private void Awake()
	{
		this.charController = base.GetComponent<CharacterController>();
	}

	// Token: 0x06002132 RID: 8498 RVA: 0x001E907F File Offset: 0x001E727F
	private void Update()
	{
		this.PlayerMovement();
	}

	// Token: 0x06002133 RID: 8499 RVA: 0x001E9088 File Offset: 0x001E7288
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

	// Token: 0x06002134 RID: 8500 RVA: 0x001E9160 File Offset: 0x001E7360
	private void SetMovementSpeed()
	{
		if (Input.GetKey(this.runKey))
		{
			this.movementSpeed = Mathf.Lerp(this.movementSpeed, this.runSpeed, Time.deltaTime * this.runBuildUpSpeed);
			return;
		}
		this.movementSpeed = Mathf.Lerp(this.movementSpeed, this.walkSpeed, Time.deltaTime * this.runBuildUpSpeed);
	}

	// Token: 0x06002135 RID: 8501 RVA: 0x001E91C4 File Offset: 0x001E73C4
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

	// Token: 0x06002136 RID: 8502 RVA: 0x001E922C File Offset: 0x001E742C
	private void JumpInput()
	{
		if (Input.GetKeyDown(this.jumpKey) && !this.isJumping)
		{
			this.isJumping = true;
			base.StartCoroutine(this.JumpEvent());
		}
	}

	// Token: 0x06002137 RID: 8503 RVA: 0x001E9257 File Offset: 0x001E7457
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

	// Token: 0x04004934 RID: 18740
	[SerializeField]
	private string horizontalInputName;

	// Token: 0x04004935 RID: 18741
	[SerializeField]
	private string verticalInputName;

	// Token: 0x04004936 RID: 18742
	[SerializeField]
	private float walkSpeed;

	// Token: 0x04004937 RID: 18743
	[SerializeField]
	private float runSpeed;

	// Token: 0x04004938 RID: 18744
	[SerializeField]
	private float runBuildUpSpeed;

	// Token: 0x04004939 RID: 18745
	[SerializeField]
	private KeyCode runKey;

	// Token: 0x0400493A RID: 18746
	private float movementSpeed;

	// Token: 0x0400493B RID: 18747
	[SerializeField]
	private float slopeForce;

	// Token: 0x0400493C RID: 18748
	[SerializeField]
	private float slopeForceRayLength;

	// Token: 0x0400493D RID: 18749
	private CharacterController charController;

	// Token: 0x0400493E RID: 18750
	[SerializeField]
	private AnimationCurve jumpFallOff;

	// Token: 0x0400493F RID: 18751
	[SerializeField]
	private float jumpMultiplier;

	// Token: 0x04004940 RID: 18752
	[SerializeField]
	private KeyCode jumpKey;

	// Token: 0x04004941 RID: 18753
	private bool isJumping;
}
