using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004F5 RID: 1269
public class PlayerMove : MonoBehaviour
{
	// Token: 0x060020EA RID: 8426 RVA: 0x001E2C81 File Offset: 0x001E0E81
	private void Awake()
	{
		this.charController = base.GetComponent<CharacterController>();
	}

	// Token: 0x060020EB RID: 8427 RVA: 0x001E2C8F File Offset: 0x001E0E8F
	private void Update()
	{
		this.PlayerMovement();
	}

	// Token: 0x060020EC RID: 8428 RVA: 0x001E2C98 File Offset: 0x001E0E98
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

	// Token: 0x060020ED RID: 8429 RVA: 0x001E2D70 File Offset: 0x001E0F70
	private void SetMovementSpeed()
	{
		if (Input.GetKey(this.runKey))
		{
			this.movementSpeed = Mathf.Lerp(this.movementSpeed, this.runSpeed, Time.deltaTime * this.runBuildUpSpeed);
			return;
		}
		this.movementSpeed = Mathf.Lerp(this.movementSpeed, this.walkSpeed, Time.deltaTime * this.runBuildUpSpeed);
	}

	// Token: 0x060020EE RID: 8430 RVA: 0x001E2DD4 File Offset: 0x001E0FD4
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

	// Token: 0x060020EF RID: 8431 RVA: 0x001E2E3C File Offset: 0x001E103C
	private void JumpInput()
	{
		if (Input.GetKeyDown(this.jumpKey) && !this.isJumping)
		{
			this.isJumping = true;
			base.StartCoroutine(this.JumpEvent());
		}
	}

	// Token: 0x060020F0 RID: 8432 RVA: 0x001E2E67 File Offset: 0x001E1067
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

	// Token: 0x04004867 RID: 18535
	[SerializeField]
	private string horizontalInputName;

	// Token: 0x04004868 RID: 18536
	[SerializeField]
	private string verticalInputName;

	// Token: 0x04004869 RID: 18537
	[SerializeField]
	private float walkSpeed;

	// Token: 0x0400486A RID: 18538
	[SerializeField]
	private float runSpeed;

	// Token: 0x0400486B RID: 18539
	[SerializeField]
	private float runBuildUpSpeed;

	// Token: 0x0400486C RID: 18540
	[SerializeField]
	private KeyCode runKey;

	// Token: 0x0400486D RID: 18541
	private float movementSpeed;

	// Token: 0x0400486E RID: 18542
	[SerializeField]
	private float slopeForce;

	// Token: 0x0400486F RID: 18543
	[SerializeField]
	private float slopeForceRayLength;

	// Token: 0x04004870 RID: 18544
	private CharacterController charController;

	// Token: 0x04004871 RID: 18545
	[SerializeField]
	private AnimationCurve jumpFallOff;

	// Token: 0x04004872 RID: 18546
	[SerializeField]
	private float jumpMultiplier;

	// Token: 0x04004873 RID: 18547
	[SerializeField]
	private KeyCode jumpKey;

	// Token: 0x04004874 RID: 18548
	private bool isJumping;
}
