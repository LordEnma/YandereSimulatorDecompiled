using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000506 RID: 1286
public class PlayerMove : MonoBehaviour
{
	// Token: 0x0600215A RID: 8538 RVA: 0x001ECDF5 File Offset: 0x001EAFF5
	private void Awake()
	{
		this.charController = base.GetComponent<CharacterController>();
	}

	// Token: 0x0600215B RID: 8539 RVA: 0x001ECE03 File Offset: 0x001EB003
	private void Update()
	{
		this.PlayerMovement();
	}

	// Token: 0x0600215C RID: 8540 RVA: 0x001ECE0C File Offset: 0x001EB00C
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

	// Token: 0x0600215D RID: 8541 RVA: 0x001ECEE4 File Offset: 0x001EB0E4
	private void SetMovementSpeed()
	{
		if (Input.GetKey(this.runKey))
		{
			this.movementSpeed = Mathf.Lerp(this.movementSpeed, this.runSpeed, Time.deltaTime * this.runBuildUpSpeed);
			return;
		}
		this.movementSpeed = Mathf.Lerp(this.movementSpeed, this.walkSpeed, Time.deltaTime * this.runBuildUpSpeed);
	}

	// Token: 0x0600215E RID: 8542 RVA: 0x001ECF48 File Offset: 0x001EB148
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

	// Token: 0x0600215F RID: 8543 RVA: 0x001ECFB0 File Offset: 0x001EB1B0
	private void JumpInput()
	{
		if (Input.GetKeyDown(this.jumpKey) && !this.isJumping)
		{
			this.isJumping = true;
			base.StartCoroutine(this.JumpEvent());
		}
	}

	// Token: 0x06002160 RID: 8544 RVA: 0x001ECFDB File Offset: 0x001EB1DB
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

	// Token: 0x04004992 RID: 18834
	[SerializeField]
	private string horizontalInputName;

	// Token: 0x04004993 RID: 18835
	[SerializeField]
	private string verticalInputName;

	// Token: 0x04004994 RID: 18836
	[SerializeField]
	private float walkSpeed;

	// Token: 0x04004995 RID: 18837
	[SerializeField]
	private float runSpeed;

	// Token: 0x04004996 RID: 18838
	[SerializeField]
	private float runBuildUpSpeed;

	// Token: 0x04004997 RID: 18839
	[SerializeField]
	private KeyCode runKey;

	// Token: 0x04004998 RID: 18840
	private float movementSpeed;

	// Token: 0x04004999 RID: 18841
	[SerializeField]
	private float slopeForce;

	// Token: 0x0400499A RID: 18842
	[SerializeField]
	private float slopeForceRayLength;

	// Token: 0x0400499B RID: 18843
	private CharacterController charController;

	// Token: 0x0400499C RID: 18844
	[SerializeField]
	private AnimationCurve jumpFallOff;

	// Token: 0x0400499D RID: 18845
	[SerializeField]
	private float jumpMultiplier;

	// Token: 0x0400499E RID: 18846
	[SerializeField]
	private KeyCode jumpKey;

	// Token: 0x0400499F RID: 18847
	private bool isJumping;
}
