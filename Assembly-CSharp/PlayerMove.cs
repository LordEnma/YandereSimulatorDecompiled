using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004F3 RID: 1267
public class PlayerMove : MonoBehaviour
{
	// Token: 0x060020D9 RID: 8409 RVA: 0x001E154D File Offset: 0x001DF74D
	private void Awake()
	{
		this.charController = base.GetComponent<CharacterController>();
	}

	// Token: 0x060020DA RID: 8410 RVA: 0x001E155B File Offset: 0x001DF75B
	private void Update()
	{
		this.PlayerMovement();
	}

	// Token: 0x060020DB RID: 8411 RVA: 0x001E1564 File Offset: 0x001DF764
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

	// Token: 0x060020DC RID: 8412 RVA: 0x001E163C File Offset: 0x001DF83C
	private void SetMovementSpeed()
	{
		if (Input.GetKey(this.runKey))
		{
			this.movementSpeed = Mathf.Lerp(this.movementSpeed, this.runSpeed, Time.deltaTime * this.runBuildUpSpeed);
			return;
		}
		this.movementSpeed = Mathf.Lerp(this.movementSpeed, this.walkSpeed, Time.deltaTime * this.runBuildUpSpeed);
	}

	// Token: 0x060020DD RID: 8413 RVA: 0x001E16A0 File Offset: 0x001DF8A0
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

	// Token: 0x060020DE RID: 8414 RVA: 0x001E1708 File Offset: 0x001DF908
	private void JumpInput()
	{
		if (Input.GetKeyDown(this.jumpKey) && !this.isJumping)
		{
			this.isJumping = true;
			base.StartCoroutine(this.JumpEvent());
		}
	}

	// Token: 0x060020DF RID: 8415 RVA: 0x001E1733 File Offset: 0x001DF933
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

	// Token: 0x04004828 RID: 18472
	[SerializeField]
	private string horizontalInputName;

	// Token: 0x04004829 RID: 18473
	[SerializeField]
	private string verticalInputName;

	// Token: 0x0400482A RID: 18474
	[SerializeField]
	private float walkSpeed;

	// Token: 0x0400482B RID: 18475
	[SerializeField]
	private float runSpeed;

	// Token: 0x0400482C RID: 18476
	[SerializeField]
	private float runBuildUpSpeed;

	// Token: 0x0400482D RID: 18477
	[SerializeField]
	private KeyCode runKey;

	// Token: 0x0400482E RID: 18478
	private float movementSpeed;

	// Token: 0x0400482F RID: 18479
	[SerializeField]
	private float slopeForce;

	// Token: 0x04004830 RID: 18480
	[SerializeField]
	private float slopeForceRayLength;

	// Token: 0x04004831 RID: 18481
	private CharacterController charController;

	// Token: 0x04004832 RID: 18482
	[SerializeField]
	private AnimationCurve jumpFallOff;

	// Token: 0x04004833 RID: 18483
	[SerializeField]
	private float jumpMultiplier;

	// Token: 0x04004834 RID: 18484
	[SerializeField]
	private KeyCode jumpKey;

	// Token: 0x04004835 RID: 18485
	private bool isJumping;
}
