using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004F5 RID: 1269
public class PlayerMove : MonoBehaviour
{
	// Token: 0x060020ED RID: 8429 RVA: 0x001E3271 File Offset: 0x001E1471
	private void Awake()
	{
		this.charController = base.GetComponent<CharacterController>();
	}

	// Token: 0x060020EE RID: 8430 RVA: 0x001E327F File Offset: 0x001E147F
	private void Update()
	{
		this.PlayerMovement();
	}

	// Token: 0x060020EF RID: 8431 RVA: 0x001E3288 File Offset: 0x001E1488
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

	// Token: 0x060020F0 RID: 8432 RVA: 0x001E3360 File Offset: 0x001E1560
	private void SetMovementSpeed()
	{
		if (Input.GetKey(this.runKey))
		{
			this.movementSpeed = Mathf.Lerp(this.movementSpeed, this.runSpeed, Time.deltaTime * this.runBuildUpSpeed);
			return;
		}
		this.movementSpeed = Mathf.Lerp(this.movementSpeed, this.walkSpeed, Time.deltaTime * this.runBuildUpSpeed);
	}

	// Token: 0x060020F1 RID: 8433 RVA: 0x001E33C4 File Offset: 0x001E15C4
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

	// Token: 0x060020F2 RID: 8434 RVA: 0x001E342C File Offset: 0x001E162C
	private void JumpInput()
	{
		if (Input.GetKeyDown(this.jumpKey) && !this.isJumping)
		{
			this.isJumping = true;
			base.StartCoroutine(this.JumpEvent());
		}
	}

	// Token: 0x060020F3 RID: 8435 RVA: 0x001E3457 File Offset: 0x001E1657
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

	// Token: 0x04004870 RID: 18544
	[SerializeField]
	private string horizontalInputName;

	// Token: 0x04004871 RID: 18545
	[SerializeField]
	private string verticalInputName;

	// Token: 0x04004872 RID: 18546
	[SerializeField]
	private float walkSpeed;

	// Token: 0x04004873 RID: 18547
	[SerializeField]
	private float runSpeed;

	// Token: 0x04004874 RID: 18548
	[SerializeField]
	private float runBuildUpSpeed;

	// Token: 0x04004875 RID: 18549
	[SerializeField]
	private KeyCode runKey;

	// Token: 0x04004876 RID: 18550
	private float movementSpeed;

	// Token: 0x04004877 RID: 18551
	[SerializeField]
	private float slopeForce;

	// Token: 0x04004878 RID: 18552
	[SerializeField]
	private float slopeForceRayLength;

	// Token: 0x04004879 RID: 18553
	private CharacterController charController;

	// Token: 0x0400487A RID: 18554
	[SerializeField]
	private AnimationCurve jumpFallOff;

	// Token: 0x0400487B RID: 18555
	[SerializeField]
	private float jumpMultiplier;

	// Token: 0x0400487C RID: 18556
	[SerializeField]
	private KeyCode jumpKey;

	// Token: 0x0400487D RID: 18557
	private bool isJumping;
}
