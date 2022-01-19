using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004F8 RID: 1272
public class PlayerMove : MonoBehaviour
{
	// Token: 0x060020FA RID: 8442 RVA: 0x001E48E1 File Offset: 0x001E2AE1
	private void Awake()
	{
		this.charController = base.GetComponent<CharacterController>();
	}

	// Token: 0x060020FB RID: 8443 RVA: 0x001E48EF File Offset: 0x001E2AEF
	private void Update()
	{
		this.PlayerMovement();
	}

	// Token: 0x060020FC RID: 8444 RVA: 0x001E48F8 File Offset: 0x001E2AF8
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

	// Token: 0x060020FD RID: 8445 RVA: 0x001E49D0 File Offset: 0x001E2BD0
	private void SetMovementSpeed()
	{
		if (Input.GetKey(this.runKey))
		{
			this.movementSpeed = Mathf.Lerp(this.movementSpeed, this.runSpeed, Time.deltaTime * this.runBuildUpSpeed);
			return;
		}
		this.movementSpeed = Mathf.Lerp(this.movementSpeed, this.walkSpeed, Time.deltaTime * this.runBuildUpSpeed);
	}

	// Token: 0x060020FE RID: 8446 RVA: 0x001E4A34 File Offset: 0x001E2C34
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

	// Token: 0x060020FF RID: 8447 RVA: 0x001E4A9C File Offset: 0x001E2C9C
	private void JumpInput()
	{
		if (Input.GetKeyDown(this.jumpKey) && !this.isJumping)
		{
			this.isJumping = true;
			base.StartCoroutine(this.JumpEvent());
		}
	}

	// Token: 0x06002100 RID: 8448 RVA: 0x001E4AC7 File Offset: 0x001E2CC7
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

	// Token: 0x0400488B RID: 18571
	[SerializeField]
	private string horizontalInputName;

	// Token: 0x0400488C RID: 18572
	[SerializeField]
	private string verticalInputName;

	// Token: 0x0400488D RID: 18573
	[SerializeField]
	private float walkSpeed;

	// Token: 0x0400488E RID: 18574
	[SerializeField]
	private float runSpeed;

	// Token: 0x0400488F RID: 18575
	[SerializeField]
	private float runBuildUpSpeed;

	// Token: 0x04004890 RID: 18576
	[SerializeField]
	private KeyCode runKey;

	// Token: 0x04004891 RID: 18577
	private float movementSpeed;

	// Token: 0x04004892 RID: 18578
	[SerializeField]
	private float slopeForce;

	// Token: 0x04004893 RID: 18579
	[SerializeField]
	private float slopeForceRayLength;

	// Token: 0x04004894 RID: 18580
	private CharacterController charController;

	// Token: 0x04004895 RID: 18581
	[SerializeField]
	private AnimationCurve jumpFallOff;

	// Token: 0x04004896 RID: 18582
	[SerializeField]
	private float jumpMultiplier;

	// Token: 0x04004897 RID: 18583
	[SerializeField]
	private KeyCode jumpKey;

	// Token: 0x04004898 RID: 18584
	private bool isJumping;
}
