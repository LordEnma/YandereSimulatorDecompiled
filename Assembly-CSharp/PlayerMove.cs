using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004FA RID: 1274
public class PlayerMove : MonoBehaviour
{
	// Token: 0x06002113 RID: 8467 RVA: 0x001E6731 File Offset: 0x001E4931
	private void Awake()
	{
		this.charController = base.GetComponent<CharacterController>();
	}

	// Token: 0x06002114 RID: 8468 RVA: 0x001E673F File Offset: 0x001E493F
	private void Update()
	{
		this.PlayerMovement();
	}

	// Token: 0x06002115 RID: 8469 RVA: 0x001E6748 File Offset: 0x001E4948
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

	// Token: 0x06002116 RID: 8470 RVA: 0x001E6820 File Offset: 0x001E4A20
	private void SetMovementSpeed()
	{
		if (Input.GetKey(this.runKey))
		{
			this.movementSpeed = Mathf.Lerp(this.movementSpeed, this.runSpeed, Time.deltaTime * this.runBuildUpSpeed);
			return;
		}
		this.movementSpeed = Mathf.Lerp(this.movementSpeed, this.walkSpeed, Time.deltaTime * this.runBuildUpSpeed);
	}

	// Token: 0x06002117 RID: 8471 RVA: 0x001E6884 File Offset: 0x001E4A84
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

	// Token: 0x06002118 RID: 8472 RVA: 0x001E68EC File Offset: 0x001E4AEC
	private void JumpInput()
	{
		if (Input.GetKeyDown(this.jumpKey) && !this.isJumping)
		{
			this.isJumping = true;
			base.StartCoroutine(this.JumpEvent());
		}
	}

	// Token: 0x06002119 RID: 8473 RVA: 0x001E6917 File Offset: 0x001E4B17
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

	// Token: 0x040048B8 RID: 18616
	[SerializeField]
	private string horizontalInputName;

	// Token: 0x040048B9 RID: 18617
	[SerializeField]
	private string verticalInputName;

	// Token: 0x040048BA RID: 18618
	[SerializeField]
	private float walkSpeed;

	// Token: 0x040048BB RID: 18619
	[SerializeField]
	private float runSpeed;

	// Token: 0x040048BC RID: 18620
	[SerializeField]
	private float runBuildUpSpeed;

	// Token: 0x040048BD RID: 18621
	[SerializeField]
	private KeyCode runKey;

	// Token: 0x040048BE RID: 18622
	private float movementSpeed;

	// Token: 0x040048BF RID: 18623
	[SerializeField]
	private float slopeForce;

	// Token: 0x040048C0 RID: 18624
	[SerializeField]
	private float slopeForceRayLength;

	// Token: 0x040048C1 RID: 18625
	private CharacterController charController;

	// Token: 0x040048C2 RID: 18626
	[SerializeField]
	private AnimationCurve jumpFallOff;

	// Token: 0x040048C3 RID: 18627
	[SerializeField]
	private float jumpMultiplier;

	// Token: 0x040048C4 RID: 18628
	[SerializeField]
	private KeyCode jumpKey;

	// Token: 0x040048C5 RID: 18629
	private bool isJumping;
}
