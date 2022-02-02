using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004F8 RID: 1272
public class PlayerMove : MonoBehaviour
{
	// Token: 0x060020FE RID: 8446 RVA: 0x001E5181 File Offset: 0x001E3381
	private void Awake()
	{
		this.charController = base.GetComponent<CharacterController>();
	}

	// Token: 0x060020FF RID: 8447 RVA: 0x001E518F File Offset: 0x001E338F
	private void Update()
	{
		this.PlayerMovement();
	}

	// Token: 0x06002100 RID: 8448 RVA: 0x001E5198 File Offset: 0x001E3398
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

	// Token: 0x06002101 RID: 8449 RVA: 0x001E5270 File Offset: 0x001E3470
	private void SetMovementSpeed()
	{
		if (Input.GetKey(this.runKey))
		{
			this.movementSpeed = Mathf.Lerp(this.movementSpeed, this.runSpeed, Time.deltaTime * this.runBuildUpSpeed);
			return;
		}
		this.movementSpeed = Mathf.Lerp(this.movementSpeed, this.walkSpeed, Time.deltaTime * this.runBuildUpSpeed);
	}

	// Token: 0x06002102 RID: 8450 RVA: 0x001E52D4 File Offset: 0x001E34D4
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

	// Token: 0x06002103 RID: 8451 RVA: 0x001E533C File Offset: 0x001E353C
	private void JumpInput()
	{
		if (Input.GetKeyDown(this.jumpKey) && !this.isJumping)
		{
			this.isJumping = true;
			base.StartCoroutine(this.JumpEvent());
		}
	}

	// Token: 0x06002104 RID: 8452 RVA: 0x001E5367 File Offset: 0x001E3567
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

	// Token: 0x04004896 RID: 18582
	[SerializeField]
	private string horizontalInputName;

	// Token: 0x04004897 RID: 18583
	[SerializeField]
	private string verticalInputName;

	// Token: 0x04004898 RID: 18584
	[SerializeField]
	private float walkSpeed;

	// Token: 0x04004899 RID: 18585
	[SerializeField]
	private float runSpeed;

	// Token: 0x0400489A RID: 18586
	[SerializeField]
	private float runBuildUpSpeed;

	// Token: 0x0400489B RID: 18587
	[SerializeField]
	private KeyCode runKey;

	// Token: 0x0400489C RID: 18588
	private float movementSpeed;

	// Token: 0x0400489D RID: 18589
	[SerializeField]
	private float slopeForce;

	// Token: 0x0400489E RID: 18590
	[SerializeField]
	private float slopeForceRayLength;

	// Token: 0x0400489F RID: 18591
	private CharacterController charController;

	// Token: 0x040048A0 RID: 18592
	[SerializeField]
	private AnimationCurve jumpFallOff;

	// Token: 0x040048A1 RID: 18593
	[SerializeField]
	private float jumpMultiplier;

	// Token: 0x040048A2 RID: 18594
	[SerializeField]
	private KeyCode jumpKey;

	// Token: 0x040048A3 RID: 18595
	private bool isJumping;
}
