using System;
using UnityEngine;

// Token: 0x020000BA RID: 186
public class RPG_Animation : MonoBehaviour
{
	// Token: 0x0600096A RID: 2410 RVA: 0x0004B6DE File Offset: 0x000498DE
	private void Awake()
	{
		RPG_Animation.instance = this;
	}

	// Token: 0x0600096B RID: 2411 RVA: 0x0004B6E6 File Offset: 0x000498E6
	private void Update()
	{
		this.SetCurrentState();
		this.StartAnimation();
	}

	// Token: 0x0600096C RID: 2412 RVA: 0x0004B6F4 File Offset: 0x000498F4
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

	// Token: 0x0600096D RID: 2413 RVA: 0x0004B7A4 File Offset: 0x000499A4
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

	// Token: 0x0600096E RID: 2414 RVA: 0x0004B83C File Offset: 0x00049A3C
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

	// Token: 0x0600096F RID: 2415 RVA: 0x0004B8CD File Offset: 0x00049ACD
	private void Idle()
	{
		base.GetComponent<Animation>().CrossFade("idle");
	}

	// Token: 0x06000970 RID: 2416 RVA: 0x0004B8DF File Offset: 0x00049ADF
	private void Walk()
	{
		base.GetComponent<Animation>().CrossFade("walk");
	}

	// Token: 0x06000971 RID: 2417 RVA: 0x0004B8F1 File Offset: 0x00049AF1
	private void StrafeForwardLeft()
	{
		base.GetComponent<Animation>().CrossFade("strafeforwardleft");
	}

	// Token: 0x06000972 RID: 2418 RVA: 0x0004B903 File Offset: 0x00049B03
	private void StrafeForwardRight()
	{
		base.GetComponent<Animation>().CrossFade("strafeforwardright");
	}

	// Token: 0x06000973 RID: 2419 RVA: 0x0004B915 File Offset: 0x00049B15
	private void WalkBack()
	{
		base.GetComponent<Animation>().CrossFade("walkback");
	}

	// Token: 0x06000974 RID: 2420 RVA: 0x0004B927 File Offset: 0x00049B27
	private void StrafeBackLeft()
	{
		base.GetComponent<Animation>().CrossFade("strafebackleft");
	}

	// Token: 0x06000975 RID: 2421 RVA: 0x0004B939 File Offset: 0x00049B39
	private void StrafeBackRight()
	{
		base.GetComponent<Animation>().CrossFade("strafebackright");
	}

	// Token: 0x06000976 RID: 2422 RVA: 0x0004B94B File Offset: 0x00049B4B
	private void StrafeLeft()
	{
		base.GetComponent<Animation>().CrossFade("strafeleft");
	}

	// Token: 0x06000977 RID: 2423 RVA: 0x0004B95D File Offset: 0x00049B5D
	private void StrafeRight()
	{
		base.GetComponent<Animation>().CrossFade("straferight");
	}

	// Token: 0x06000978 RID: 2424 RVA: 0x0004B96F File Offset: 0x00049B6F
	public void Jump()
	{
		this.currentState = RPG_Animation.CharacterState.Jump;
		if (base.GetComponent<Animation>().IsPlaying("jump"))
		{
			base.GetComponent<Animation>().Stop("jump");
		}
		base.GetComponent<Animation>().CrossFade("jump");
	}

	// Token: 0x04000812 RID: 2066
	public static RPG_Animation instance;

	// Token: 0x04000813 RID: 2067
	public RPG_Animation.CharacterMoveDirection currentMoveDir;

	// Token: 0x04000814 RID: 2068
	public RPG_Animation.CharacterState currentState;

	// Token: 0x02000654 RID: 1620
	public enum CharacterMoveDirection
	{
		// Token: 0x04004FA9 RID: 20393
		None,
		// Token: 0x04004FAA RID: 20394
		Forward,
		// Token: 0x04004FAB RID: 20395
		Backward,
		// Token: 0x04004FAC RID: 20396
		StrafeLeft,
		// Token: 0x04004FAD RID: 20397
		StrafeRight,
		// Token: 0x04004FAE RID: 20398
		StrafeForwardLeft,
		// Token: 0x04004FAF RID: 20399
		StrafeForwardRight,
		// Token: 0x04004FB0 RID: 20400
		StrafeBackLeft,
		// Token: 0x04004FB1 RID: 20401
		StrafeBackRight
	}

	// Token: 0x02000655 RID: 1621
	public enum CharacterState
	{
		// Token: 0x04004FB3 RID: 20403
		Idle,
		// Token: 0x04004FB4 RID: 20404
		Walk,
		// Token: 0x04004FB5 RID: 20405
		WalkBack,
		// Token: 0x04004FB6 RID: 20406
		StrafeLeft,
		// Token: 0x04004FB7 RID: 20407
		StrafeRight,
		// Token: 0x04004FB8 RID: 20408
		Jump
	}
}
