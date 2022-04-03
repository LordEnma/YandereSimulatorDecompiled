using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000504 RID: 1284
public class PlayerMove : MonoBehaviour
{
	// Token: 0x06002141 RID: 8513 RVA: 0x001EA8E1 File Offset: 0x001E8AE1
	private void Awake()
	{
		this.charController = base.GetComponent<CharacterController>();
	}

	// Token: 0x06002142 RID: 8514 RVA: 0x001EA8EF File Offset: 0x001E8AEF
	private void Update()
	{
		this.PlayerMovement();
	}

	// Token: 0x06002143 RID: 8515 RVA: 0x001EA8F8 File Offset: 0x001E8AF8
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

	// Token: 0x06002144 RID: 8516 RVA: 0x001EA9D0 File Offset: 0x001E8BD0
	private void SetMovementSpeed()
	{
		if (Input.GetKey(this.runKey))
		{
			this.movementSpeed = Mathf.Lerp(this.movementSpeed, this.runSpeed, Time.deltaTime * this.runBuildUpSpeed);
			return;
		}
		this.movementSpeed = Mathf.Lerp(this.movementSpeed, this.walkSpeed, Time.deltaTime * this.runBuildUpSpeed);
	}

	// Token: 0x06002145 RID: 8517 RVA: 0x001EAA34 File Offset: 0x001E8C34
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

	// Token: 0x06002146 RID: 8518 RVA: 0x001EAA9C File Offset: 0x001E8C9C
	private void JumpInput()
	{
		if (Input.GetKeyDown(this.jumpKey) && !this.isJumping)
		{
			this.isJumping = true;
			base.StartCoroutine(this.JumpEvent());
		}
	}

	// Token: 0x06002147 RID: 8519 RVA: 0x001EAAC7 File Offset: 0x001E8CC7
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

	// Token: 0x04004966 RID: 18790
	[SerializeField]
	private string horizontalInputName;

	// Token: 0x04004967 RID: 18791
	[SerializeField]
	private string verticalInputName;

	// Token: 0x04004968 RID: 18792
	[SerializeField]
	private float walkSpeed;

	// Token: 0x04004969 RID: 18793
	[SerializeField]
	private float runSpeed;

	// Token: 0x0400496A RID: 18794
	[SerializeField]
	private float runBuildUpSpeed;

	// Token: 0x0400496B RID: 18795
	[SerializeField]
	private KeyCode runKey;

	// Token: 0x0400496C RID: 18796
	private float movementSpeed;

	// Token: 0x0400496D RID: 18797
	[SerializeField]
	private float slopeForce;

	// Token: 0x0400496E RID: 18798
	[SerializeField]
	private float slopeForceRayLength;

	// Token: 0x0400496F RID: 18799
	private CharacterController charController;

	// Token: 0x04004970 RID: 18800
	[SerializeField]
	private AnimationCurve jumpFallOff;

	// Token: 0x04004971 RID: 18801
	[SerializeField]
	private float jumpMultiplier;

	// Token: 0x04004972 RID: 18802
	[SerializeField]
	private KeyCode jumpKey;

	// Token: 0x04004973 RID: 18803
	private bool isJumping;
}
