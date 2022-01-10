using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004F7 RID: 1271
public class PlayerMove : MonoBehaviour
{
	// Token: 0x060020F8 RID: 8440 RVA: 0x001E3C11 File Offset: 0x001E1E11
	private void Awake()
	{
		this.charController = base.GetComponent<CharacterController>();
	}

	// Token: 0x060020F9 RID: 8441 RVA: 0x001E3C1F File Offset: 0x001E1E1F
	private void Update()
	{
		this.PlayerMovement();
	}

	// Token: 0x060020FA RID: 8442 RVA: 0x001E3C28 File Offset: 0x001E1E28
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

	// Token: 0x060020FB RID: 8443 RVA: 0x001E3D00 File Offset: 0x001E1F00
	private void SetMovementSpeed()
	{
		if (Input.GetKey(this.runKey))
		{
			this.movementSpeed = Mathf.Lerp(this.movementSpeed, this.runSpeed, Time.deltaTime * this.runBuildUpSpeed);
			return;
		}
		this.movementSpeed = Mathf.Lerp(this.movementSpeed, this.walkSpeed, Time.deltaTime * this.runBuildUpSpeed);
	}

	// Token: 0x060020FC RID: 8444 RVA: 0x001E3D64 File Offset: 0x001E1F64
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

	// Token: 0x060020FD RID: 8445 RVA: 0x001E3DCC File Offset: 0x001E1FCC
	private void JumpInput()
	{
		if (Input.GetKeyDown(this.jumpKey) && !this.isJumping)
		{
			this.isJumping = true;
			base.StartCoroutine(this.JumpEvent());
		}
	}

	// Token: 0x060020FE RID: 8446 RVA: 0x001E3DF7 File Offset: 0x001E1FF7
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

	// Token: 0x04004884 RID: 18564
	[SerializeField]
	private string horizontalInputName;

	// Token: 0x04004885 RID: 18565
	[SerializeField]
	private string verticalInputName;

	// Token: 0x04004886 RID: 18566
	[SerializeField]
	private float walkSpeed;

	// Token: 0x04004887 RID: 18567
	[SerializeField]
	private float runSpeed;

	// Token: 0x04004888 RID: 18568
	[SerializeField]
	private float runBuildUpSpeed;

	// Token: 0x04004889 RID: 18569
	[SerializeField]
	private KeyCode runKey;

	// Token: 0x0400488A RID: 18570
	private float movementSpeed;

	// Token: 0x0400488B RID: 18571
	[SerializeField]
	private float slopeForce;

	// Token: 0x0400488C RID: 18572
	[SerializeField]
	private float slopeForceRayLength;

	// Token: 0x0400488D RID: 18573
	private CharacterController charController;

	// Token: 0x0400488E RID: 18574
	[SerializeField]
	private AnimationCurve jumpFallOff;

	// Token: 0x0400488F RID: 18575
	[SerializeField]
	private float jumpMultiplier;

	// Token: 0x04004890 RID: 18576
	[SerializeField]
	private KeyCode jumpKey;

	// Token: 0x04004891 RID: 18577
	private bool isJumping;
}
