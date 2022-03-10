using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004FB RID: 1275
public class PlayerMove : MonoBehaviour
{
	// Token: 0x06002119 RID: 8473 RVA: 0x001E7109 File Offset: 0x001E5309
	private void Awake()
	{
		this.charController = base.GetComponent<CharacterController>();
	}

	// Token: 0x0600211A RID: 8474 RVA: 0x001E7117 File Offset: 0x001E5317
	private void Update()
	{
		this.PlayerMovement();
	}

	// Token: 0x0600211B RID: 8475 RVA: 0x001E7120 File Offset: 0x001E5320
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

	// Token: 0x0600211C RID: 8476 RVA: 0x001E71F8 File Offset: 0x001E53F8
	private void SetMovementSpeed()
	{
		if (Input.GetKey(this.runKey))
		{
			this.movementSpeed = Mathf.Lerp(this.movementSpeed, this.runSpeed, Time.deltaTime * this.runBuildUpSpeed);
			return;
		}
		this.movementSpeed = Mathf.Lerp(this.movementSpeed, this.walkSpeed, Time.deltaTime * this.runBuildUpSpeed);
	}

	// Token: 0x0600211D RID: 8477 RVA: 0x001E725C File Offset: 0x001E545C
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

	// Token: 0x0600211E RID: 8478 RVA: 0x001E72C4 File Offset: 0x001E54C4
	private void JumpInput()
	{
		if (Input.GetKeyDown(this.jumpKey) && !this.isJumping)
		{
			this.isJumping = true;
			base.StartCoroutine(this.JumpEvent());
		}
	}

	// Token: 0x0600211F RID: 8479 RVA: 0x001E72EF File Offset: 0x001E54EF
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

	// Token: 0x040048D5 RID: 18645
	[SerializeField]
	private string horizontalInputName;

	// Token: 0x040048D6 RID: 18646
	[SerializeField]
	private string verticalInputName;

	// Token: 0x040048D7 RID: 18647
	[SerializeField]
	private float walkSpeed;

	// Token: 0x040048D8 RID: 18648
	[SerializeField]
	private float runSpeed;

	// Token: 0x040048D9 RID: 18649
	[SerializeField]
	private float runBuildUpSpeed;

	// Token: 0x040048DA RID: 18650
	[SerializeField]
	private KeyCode runKey;

	// Token: 0x040048DB RID: 18651
	private float movementSpeed;

	// Token: 0x040048DC RID: 18652
	[SerializeField]
	private float slopeForce;

	// Token: 0x040048DD RID: 18653
	[SerializeField]
	private float slopeForceRayLength;

	// Token: 0x040048DE RID: 18654
	private CharacterController charController;

	// Token: 0x040048DF RID: 18655
	[SerializeField]
	private AnimationCurve jumpFallOff;

	// Token: 0x040048E0 RID: 18656
	[SerializeField]
	private float jumpMultiplier;

	// Token: 0x040048E1 RID: 18657
	[SerializeField]
	private KeyCode jumpKey;

	// Token: 0x040048E2 RID: 18658
	private bool isJumping;
}
