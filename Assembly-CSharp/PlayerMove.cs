using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000507 RID: 1287
public class PlayerMove : MonoBehaviour
{
	// Token: 0x06002164 RID: 8548 RVA: 0x001EE445 File Offset: 0x001EC645
	private void Awake()
	{
		this.charController = base.GetComponent<CharacterController>();
	}

	// Token: 0x06002165 RID: 8549 RVA: 0x001EE453 File Offset: 0x001EC653
	private void Update()
	{
		this.PlayerMovement();
	}

	// Token: 0x06002166 RID: 8550 RVA: 0x001EE45C File Offset: 0x001EC65C
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

	// Token: 0x06002167 RID: 8551 RVA: 0x001EE534 File Offset: 0x001EC734
	private void SetMovementSpeed()
	{
		if (Input.GetKey(this.runKey))
		{
			this.movementSpeed = Mathf.Lerp(this.movementSpeed, this.runSpeed, Time.deltaTime * this.runBuildUpSpeed);
			return;
		}
		this.movementSpeed = Mathf.Lerp(this.movementSpeed, this.walkSpeed, Time.deltaTime * this.runBuildUpSpeed);
	}

	// Token: 0x06002168 RID: 8552 RVA: 0x001EE598 File Offset: 0x001EC798
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

	// Token: 0x06002169 RID: 8553 RVA: 0x001EE600 File Offset: 0x001EC800
	private void JumpInput()
	{
		if (Input.GetKeyDown(this.jumpKey) && !this.isJumping)
		{
			this.isJumping = true;
			base.StartCoroutine(this.JumpEvent());
		}
	}

	// Token: 0x0600216A RID: 8554 RVA: 0x001EE62B File Offset: 0x001EC82B
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

	// Token: 0x040049B9 RID: 18873
	[SerializeField]
	private string horizontalInputName;

	// Token: 0x040049BA RID: 18874
	[SerializeField]
	private string verticalInputName;

	// Token: 0x040049BB RID: 18875
	[SerializeField]
	private float walkSpeed;

	// Token: 0x040049BC RID: 18876
	[SerializeField]
	private float runSpeed;

	// Token: 0x040049BD RID: 18877
	[SerializeField]
	private float runBuildUpSpeed;

	// Token: 0x040049BE RID: 18878
	[SerializeField]
	private KeyCode runKey;

	// Token: 0x040049BF RID: 18879
	private float movementSpeed;

	// Token: 0x040049C0 RID: 18880
	[SerializeField]
	private float slopeForce;

	// Token: 0x040049C1 RID: 18881
	[SerializeField]
	private float slopeForceRayLength;

	// Token: 0x040049C2 RID: 18882
	private CharacterController charController;

	// Token: 0x040049C3 RID: 18883
	[SerializeField]
	private AnimationCurve jumpFallOff;

	// Token: 0x040049C4 RID: 18884
	[SerializeField]
	private float jumpMultiplier;

	// Token: 0x040049C5 RID: 18885
	[SerializeField]
	private KeyCode jumpKey;

	// Token: 0x040049C6 RID: 18886
	private bool isJumping;
}
