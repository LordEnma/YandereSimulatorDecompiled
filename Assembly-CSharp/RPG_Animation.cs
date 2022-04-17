using System;
using UnityEngine;

// Token: 0x020000BA RID: 186
public class RPG_Animation : MonoBehaviour
{
	// Token: 0x0600096A RID: 2410 RVA: 0x0004B59E File Offset: 0x0004979E
	private void Awake()
	{
		RPG_Animation.instance = this;
	}

	// Token: 0x0600096B RID: 2411 RVA: 0x0004B5A6 File Offset: 0x000497A6
	private void Update()
	{
		this.SetCurrentState();
		this.StartAnimation();
	}

	// Token: 0x0600096C RID: 2412 RVA: 0x0004B5B4 File Offset: 0x000497B4
	public void SetCurrentMoveDir(Vector3 playerDir)
	{
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		if (playerDir.z > 0f)
		{
			flag = true;
		}
		if (playerDir.z < 0f)
		{
			flag2 = true;
		}
		if (playerDir.x < 0f)
		{
			flag3 = true;
		}
		if (playerDir.x > 0f)
		{
			flag4 = true;
		}
		if (flag)
		{
			if (flag3)
			{
				this.currentMoveDir = RPG_Animation.CharacterMoveDirection.StrafeForwardLeft;
				return;
			}
			if (flag4)
			{
				this.currentMoveDir = RPG_Animation.CharacterMoveDirection.StrafeForwardRight;
				return;
			}
			this.currentMoveDir = RPG_Animation.CharacterMoveDirection.Forward;
			return;
		}
		else if (flag2)
		{
			if (flag3)
			{
				this.currentMoveDir = RPG_Animation.CharacterMoveDirection.StrafeBackLeft;
				return;
			}
			if (flag4)
			{
				this.currentMoveDir = RPG_Animation.CharacterMoveDirection.StrafeBackRight;
				return;
			}
			this.currentMoveDir = RPG_Animation.CharacterMoveDirection.Backward;
			return;
		}
		else
		{
			if (flag3)
			{
				this.currentMoveDir = RPG_Animation.CharacterMoveDirection.StrafeLeft;
				return;
			}
			if (flag4)
			{
				this.currentMoveDir = RPG_Animation.CharacterMoveDirection.StrafeRight;
				return;
			}
			this.currentMoveDir = RPG_Animation.CharacterMoveDirection.None;
			return;
		}
	}

	// Token: 0x0600096D RID: 2413 RVA: 0x0004B664 File Offset: 0x00049864
	public void SetCurrentState()
	{
		if (RPG_Controller.instance.characterController.isGrounded)
		{
			switch (this.currentMoveDir)
			{
			case RPG_Animation.CharacterMoveDirection.None:
				this.currentState = RPG_Animation.CharacterState.Idle;
				return;
			case RPG_Animation.CharacterMoveDirection.Forward:
				this.currentState = RPG_Animation.CharacterState.Walk;
				return;
			case RPG_Animation.CharacterMoveDirection.Backward:
				this.currentState = RPG_Animation.CharacterState.WalkBack;
				return;
			case RPG_Animation.CharacterMoveDirection.StrafeLeft:
				this.currentState = RPG_Animation.CharacterState.StrafeLeft;
				return;
			case RPG_Animation.CharacterMoveDirection.StrafeRight:
				this.currentState = RPG_Animation.CharacterState.StrafeRight;
				break;
			case RPG_Animation.CharacterMoveDirection.StrafeForwardLeft:
				this.currentState = RPG_Animation.CharacterState.Walk;
				return;
			case RPG_Animation.CharacterMoveDirection.StrafeForwardRight:
				this.currentState = RPG_Animation.CharacterState.Walk;
				return;
			case RPG_Animation.CharacterMoveDirection.StrafeBackLeft:
				this.currentState = RPG_Animation.CharacterState.WalkBack;
				return;
			case RPG_Animation.CharacterMoveDirection.StrafeBackRight:
				this.currentState = RPG_Animation.CharacterState.WalkBack;
				return;
			default:
				return;
			}
		}
	}

	// Token: 0x0600096E RID: 2414 RVA: 0x0004B6FC File Offset: 0x000498FC
	public void StartAnimation()
	{
		switch (this.currentState)
		{
		case RPG_Animation.CharacterState.Idle:
			this.Idle();
			return;
		case RPG_Animation.CharacterState.Walk:
			if (this.currentMoveDir == RPG_Animation.CharacterMoveDirection.StrafeForwardLeft)
			{
				this.StrafeForwardLeft();
				return;
			}
			if (this.currentMoveDir == RPG_Animation.CharacterMoveDirection.StrafeForwardRight)
			{
				this.StrafeForwardRight();
				return;
			}
			this.Walk();
			return;
		case RPG_Animation.CharacterState.WalkBack:
			if (this.currentMoveDir == RPG_Animation.CharacterMoveDirection.StrafeBackLeft)
			{
				this.StrafeBackLeft();
				return;
			}
			if (this.currentMoveDir == RPG_Animation.CharacterMoveDirection.StrafeBackRight)
			{
				this.StrafeBackRight();
				return;
			}
			this.WalkBack();
			return;
		case RPG_Animation.CharacterState.StrafeLeft:
			this.StrafeLeft();
			return;
		case RPG_Animation.CharacterState.StrafeRight:
			this.StrafeRight();
			return;
		default:
			return;
		}
	}

	// Token: 0x0600096F RID: 2415 RVA: 0x0004B78D File Offset: 0x0004998D
	private void Idle()
	{
		base.GetComponent<Animation>().CrossFade("idle");
	}

	// Token: 0x06000970 RID: 2416 RVA: 0x0004B79F File Offset: 0x0004999F
	private void Walk()
	{
		base.GetComponent<Animation>().CrossFade("walk");
	}

	// Token: 0x06000971 RID: 2417 RVA: 0x0004B7B1 File Offset: 0x000499B1
	private void StrafeForwardLeft()
	{
		base.GetComponent<Animation>().CrossFade("strafeforwardleft");
	}

	// Token: 0x06000972 RID: 2418 RVA: 0x0004B7C3 File Offset: 0x000499C3
	private void StrafeForwardRight()
	{
		base.GetComponent<Animation>().CrossFade("strafeforwardright");
	}

	// Token: 0x06000973 RID: 2419 RVA: 0x0004B7D5 File Offset: 0x000499D5
	private void WalkBack()
	{
		base.GetComponent<Animation>().CrossFade("walkback");
	}

	// Token: 0x06000974 RID: 2420 RVA: 0x0004B7E7 File Offset: 0x000499E7
	private void StrafeBackLeft()
	{
		base.GetComponent<Animation>().CrossFade("strafebackleft");
	}

	// Token: 0x06000975 RID: 2421 RVA: 0x0004B7F9 File Offset: 0x000499F9
	private void StrafeBackRight()
	{
		base.GetComponent<Animation>().CrossFade("strafebackright");
	}

	// Token: 0x06000976 RID: 2422 RVA: 0x0004B80B File Offset: 0x00049A0B
	private void StrafeLeft()
	{
		base.GetComponent<Animation>().CrossFade("strafeleft");
	}

	// Token: 0x06000977 RID: 2423 RVA: 0x0004B81D File Offset: 0x00049A1D
	private void StrafeRight()
	{
		base.GetComponent<Animation>().CrossFade("straferight");
	}

	// Token: 0x06000978 RID: 2424 RVA: 0x0004B82F File Offset: 0x00049A2F
	public void Jump()
	{
		this.currentState = RPG_Animation.CharacterState.Jump;
		if (base.GetComponent<Animation>().IsPlaying("jump"))
		{
			base.GetComponent<Animation>().Stop("jump");
		}
		base.GetComponent<Animation>().CrossFade("jump");
	}

	// Token: 0x04000810 RID: 2064
	public static RPG_Animation instance;

	// Token: 0x04000811 RID: 2065
	public RPG_Animation.CharacterMoveDirection currentMoveDir;

	// Token: 0x04000812 RID: 2066
	public RPG_Animation.CharacterState currentState;

	// Token: 0x02000652 RID: 1618
	public enum CharacterMoveDirection
	{
		// Token: 0x04004F64 RID: 20324
		None,
		// Token: 0x04004F65 RID: 20325
		Forward,
		// Token: 0x04004F66 RID: 20326
		Backward,
		// Token: 0x04004F67 RID: 20327
		StrafeLeft,
		// Token: 0x04004F68 RID: 20328
		StrafeRight,
		// Token: 0x04004F69 RID: 20329
		StrafeForwardLeft,
		// Token: 0x04004F6A RID: 20330
		StrafeForwardRight,
		// Token: 0x04004F6B RID: 20331
		StrafeBackLeft,
		// Token: 0x04004F6C RID: 20332
		StrafeBackRight
	}

	// Token: 0x02000653 RID: 1619
	public enum CharacterState
	{
		// Token: 0x04004F6E RID: 20334
		Idle,
		// Token: 0x04004F6F RID: 20335
		Walk,
		// Token: 0x04004F70 RID: 20336
		WalkBack,
		// Token: 0x04004F71 RID: 20337
		StrafeLeft,
		// Token: 0x04004F72 RID: 20338
		StrafeRight,
		// Token: 0x04004F73 RID: 20339
		Jump
	}
}
