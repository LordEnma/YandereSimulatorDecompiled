using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004F9 RID: 1273
public class PlayerMove : MonoBehaviour
{
	// Token: 0x0600210A RID: 8458 RVA: 0x001E5B51 File Offset: 0x001E3D51
	private void Awake()
	{
		this.charController = base.GetComponent<CharacterController>();
	}

	// Token: 0x0600210B RID: 8459 RVA: 0x001E5B5F File Offset: 0x001E3D5F
	private void Update()
	{
		this.PlayerMovement();
	}

	// Token: 0x0600210C RID: 8460 RVA: 0x001E5B68 File Offset: 0x001E3D68
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

	// Token: 0x0600210D RID: 8461 RVA: 0x001E5C40 File Offset: 0x001E3E40
	private void SetMovementSpeed()
	{
		if (Input.GetKey(this.runKey))
		{
			this.movementSpeed = Mathf.Lerp(this.movementSpeed, this.runSpeed, Time.deltaTime * this.runBuildUpSpeed);
			return;
		}
		this.movementSpeed = Mathf.Lerp(this.movementSpeed, this.walkSpeed, Time.deltaTime * this.runBuildUpSpeed);
	}

	// Token: 0x0600210E RID: 8462 RVA: 0x001E5CA4 File Offset: 0x001E3EA4
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

	// Token: 0x0600210F RID: 8463 RVA: 0x001E5D0C File Offset: 0x001E3F0C
	private void JumpInput()
	{
		if (Input.GetKeyDown(this.jumpKey) && !this.isJumping)
		{
			this.isJumping = true;
			base.StartCoroutine(this.JumpEvent());
		}
	}

	// Token: 0x06002110 RID: 8464 RVA: 0x001E5D37 File Offset: 0x001E3F37
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

	// Token: 0x040048A8 RID: 18600
	[SerializeField]
	private string horizontalInputName;

	// Token: 0x040048A9 RID: 18601
	[SerializeField]
	private string verticalInputName;

	// Token: 0x040048AA RID: 18602
	[SerializeField]
	private float walkSpeed;

	// Token: 0x040048AB RID: 18603
	[SerializeField]
	private float runSpeed;

	// Token: 0x040048AC RID: 18604
	[SerializeField]
	private float runBuildUpSpeed;

	// Token: 0x040048AD RID: 18605
	[SerializeField]
	private KeyCode runKey;

	// Token: 0x040048AE RID: 18606
	private float movementSpeed;

	// Token: 0x040048AF RID: 18607
	[SerializeField]
	private float slopeForce;

	// Token: 0x040048B0 RID: 18608
	[SerializeField]
	private float slopeForceRayLength;

	// Token: 0x040048B1 RID: 18609
	private CharacterController charController;

	// Token: 0x040048B2 RID: 18610
	[SerializeField]
	private AnimationCurve jumpFallOff;

	// Token: 0x040048B3 RID: 18611
	[SerializeField]
	private float jumpMultiplier;

	// Token: 0x040048B4 RID: 18612
	[SerializeField]
	private KeyCode jumpKey;

	// Token: 0x040048B5 RID: 18613
	private bool isJumping;
}
