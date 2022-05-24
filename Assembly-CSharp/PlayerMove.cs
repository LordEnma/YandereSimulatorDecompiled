using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000507 RID: 1287
public class PlayerMove : MonoBehaviour
{
	// Token: 0x06002165 RID: 8549 RVA: 0x001EE9AD File Offset: 0x001ECBAD
	private void Awake()
	{
		this.charController = base.GetComponent<CharacterController>();
	}

	// Token: 0x06002166 RID: 8550 RVA: 0x001EE9BB File Offset: 0x001ECBBB
	private void Update()
	{
		this.PlayerMovement();
	}

	// Token: 0x06002167 RID: 8551 RVA: 0x001EE9C4 File Offset: 0x001ECBC4
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

	// Token: 0x06002168 RID: 8552 RVA: 0x001EEA9C File Offset: 0x001ECC9C
	private void SetMovementSpeed()
	{
		if (Input.GetKey(this.runKey))
		{
			this.movementSpeed = Mathf.Lerp(this.movementSpeed, this.runSpeed, Time.deltaTime * this.runBuildUpSpeed);
			return;
		}
		this.movementSpeed = Mathf.Lerp(this.movementSpeed, this.walkSpeed, Time.deltaTime * this.runBuildUpSpeed);
	}

	// Token: 0x06002169 RID: 8553 RVA: 0x001EEB00 File Offset: 0x001ECD00
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

	// Token: 0x0600216A RID: 8554 RVA: 0x001EEB68 File Offset: 0x001ECD68
	private void JumpInput()
	{
		if (Input.GetKeyDown(this.jumpKey) && !this.isJumping)
		{
			this.isJumping = true;
			base.StartCoroutine(this.JumpEvent());
		}
	}

	// Token: 0x0600216B RID: 8555 RVA: 0x001EEB93 File Offset: 0x001ECD93
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

	// Token: 0x040049C2 RID: 18882
	[SerializeField]
	private string horizontalInputName;

	// Token: 0x040049C3 RID: 18883
	[SerializeField]
	private string verticalInputName;

	// Token: 0x040049C4 RID: 18884
	[SerializeField]
	private float walkSpeed;

	// Token: 0x040049C5 RID: 18885
	[SerializeField]
	private float runSpeed;

	// Token: 0x040049C6 RID: 18886
	[SerializeField]
	private float runBuildUpSpeed;

	// Token: 0x040049C7 RID: 18887
	[SerializeField]
	private KeyCode runKey;

	// Token: 0x040049C8 RID: 18888
	private float movementSpeed;

	// Token: 0x040049C9 RID: 18889
	[SerializeField]
	private float slopeForce;

	// Token: 0x040049CA RID: 18890
	[SerializeField]
	private float slopeForceRayLength;

	// Token: 0x040049CB RID: 18891
	private CharacterController charController;

	// Token: 0x040049CC RID: 18892
	[SerializeField]
	private AnimationCurve jumpFallOff;

	// Token: 0x040049CD RID: 18893
	[SerializeField]
	private float jumpMultiplier;

	// Token: 0x040049CE RID: 18894
	[SerializeField]
	private KeyCode jumpKey;

	// Token: 0x040049CF RID: 18895
	private bool isJumping;
}
