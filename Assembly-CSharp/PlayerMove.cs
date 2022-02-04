using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004F8 RID: 1272
public class PlayerMove : MonoBehaviour
{
	// Token: 0x06002100 RID: 8448 RVA: 0x001E5499 File Offset: 0x001E3699
	private void Awake()
	{
		this.charController = base.GetComponent<CharacterController>();
	}

	// Token: 0x06002101 RID: 8449 RVA: 0x001E54A7 File Offset: 0x001E36A7
	private void Update()
	{
		this.PlayerMovement();
	}

	// Token: 0x06002102 RID: 8450 RVA: 0x001E54B0 File Offset: 0x001E36B0
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

	// Token: 0x06002103 RID: 8451 RVA: 0x001E5588 File Offset: 0x001E3788
	private void SetMovementSpeed()
	{
		if (Input.GetKey(this.runKey))
		{
			this.movementSpeed = Mathf.Lerp(this.movementSpeed, this.runSpeed, Time.deltaTime * this.runBuildUpSpeed);
			return;
		}
		this.movementSpeed = Mathf.Lerp(this.movementSpeed, this.walkSpeed, Time.deltaTime * this.runBuildUpSpeed);
	}

	// Token: 0x06002104 RID: 8452 RVA: 0x001E55EC File Offset: 0x001E37EC
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

	// Token: 0x06002105 RID: 8453 RVA: 0x001E5654 File Offset: 0x001E3854
	private void JumpInput()
	{
		if (Input.GetKeyDown(this.jumpKey) && !this.isJumping)
		{
			this.isJumping = true;
			base.StartCoroutine(this.JumpEvent());
		}
	}

	// Token: 0x06002106 RID: 8454 RVA: 0x001E567F File Offset: 0x001E387F
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

	// Token: 0x0400489C RID: 18588
	[SerializeField]
	private string horizontalInputName;

	// Token: 0x0400489D RID: 18589
	[SerializeField]
	private string verticalInputName;

	// Token: 0x0400489E RID: 18590
	[SerializeField]
	private float walkSpeed;

	// Token: 0x0400489F RID: 18591
	[SerializeField]
	private float runSpeed;

	// Token: 0x040048A0 RID: 18592
	[SerializeField]
	private float runBuildUpSpeed;

	// Token: 0x040048A1 RID: 18593
	[SerializeField]
	private KeyCode runKey;

	// Token: 0x040048A2 RID: 18594
	private float movementSpeed;

	// Token: 0x040048A3 RID: 18595
	[SerializeField]
	private float slopeForce;

	// Token: 0x040048A4 RID: 18596
	[SerializeField]
	private float slopeForceRayLength;

	// Token: 0x040048A5 RID: 18597
	private CharacterController charController;

	// Token: 0x040048A6 RID: 18598
	[SerializeField]
	private AnimationCurve jumpFallOff;

	// Token: 0x040048A7 RID: 18599
	[SerializeField]
	private float jumpMultiplier;

	// Token: 0x040048A8 RID: 18600
	[SerializeField]
	private KeyCode jumpKey;

	// Token: 0x040048A9 RID: 18601
	private bool isJumping;
}
