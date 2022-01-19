using System;
using UnityEngine;

// Token: 0x020000BA RID: 186
public class RPG_Animation : MonoBehaviour
{
	// Token: 0x0600096A RID: 2410 RVA: 0x0004B3EE File Offset: 0x000495EE
	private void Awake()
	{
		RPG_Animation.instance = this;
	}

	// Token: 0x0600096B RID: 2411 RVA: 0x0004B3F6 File Offset: 0x000495F6
	private void Update()
	{
		this.SetCurrentState();
		this.StartAnimation();
	}

	// Token: 0x0600096C RID: 2412 RVA: 0x0004B404 File Offset: 0x00049604
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

	// Token: 0x0600096D RID: 2413 RVA: 0x0004B4B4 File Offset: 0x000496B4
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

	// Token: 0x0600096E RID: 2414 RVA: 0x0004B54C File Offset: 0x0004974C
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

	// Token: 0x0600096F RID: 2415 RVA: 0x0004B5DD File Offset: 0x000497DD
	private void Idle()
	{
		base.GetComponent<Animation>().CrossFade("idle");
	}

	// Token: 0x06000970 RID: 2416 RVA: 0x0004B5EF File Offset: 0x000497EF
	private void Walk()
	{
		base.GetComponent<Animation>().CrossFade("walk");
	}

	// Token: 0x06000971 RID: 2417 RVA: 0x0004B601 File Offset: 0x00049801
	private void StrafeForwardLeft()
	{
		base.GetComponent<Animation>().CrossFade("strafeforwardleft");
	}

	// Token: 0x06000972 RID: 2418 RVA: 0x0004B613 File Offset: 0x00049813
	private void StrafeForwardRight()
	{
		base.GetComponent<Animation>().CrossFade("strafeforwardright");
	}

	// Token: 0x06000973 RID: 2419 RVA: 0x0004B625 File Offset: 0x00049825
	private void WalkBack()
	{
		base.GetComponent<Animation>().CrossFade("walkback");
	}

	// Token: 0x06000974 RID: 2420 RVA: 0x0004B637 File Offset: 0x00049837
	private void StrafeBackLeft()
	{
		base.GetComponent<Animation>().CrossFade("strafebackleft");
	}

	// Token: 0x06000975 RID: 2421 RVA: 0x0004B649 File Offset: 0x00049849
	private void StrafeBackRight()
	{
		base.GetComponent<Animation>().CrossFade("strafebackright");
	}

	// Token: 0x06000976 RID: 2422 RVA: 0x0004B65B File Offset: 0x0004985B
	private void StrafeLeft()
	{
		base.GetComponent<Animation>().CrossFade("strafeleft");
	}

	// Token: 0x06000977 RID: 2423 RVA: 0x0004B66D File Offset: 0x0004986D
	private void StrafeRight()
	{
		base.GetComponent<Animation>().CrossFade("straferight");
	}

	// Token: 0x06000978 RID: 2424 RVA: 0x0004B67F File Offset: 0x0004987F
	public void Jump()
	{
		this.currentState = RPG_Animation.CharacterState.Jump;
		if (base.GetComponent<Animation>().IsPlaying("jump"))
		{
			base.GetComponent<Animation>().Stop("jump");
		}
		base.GetComponent<Animation>().CrossFade("jump");
	}

	// Token: 0x04000806 RID: 2054
	public static RPG_Animation instance;

	// Token: 0x04000807 RID: 2055
	public RPG_Animation.CharacterMoveDirection currentMoveDir;

	// Token: 0x04000808 RID: 2056
	public RPG_Animation.CharacterState currentState;

	// Token: 0x0200064B RID: 1611
	public enum CharacterMoveDirection
	{
		// Token: 0x04004EA1 RID: 20129
		None,
		// Token: 0x04004EA2 RID: 20130
		Forward,
		// Token: 0x04004EA3 RID: 20131
		Backward,
		// Token: 0x04004EA4 RID: 20132
		StrafeLeft,
		// Token: 0x04004EA5 RID: 20133
		StrafeRight,
		// Token: 0x04004EA6 RID: 20134
		StrafeForwardLeft,
		// Token: 0x04004EA7 RID: 20135
		StrafeForwardRight,
		// Token: 0x04004EA8 RID: 20136
		StrafeBackLeft,
		// Token: 0x04004EA9 RID: 20137
		StrafeBackRight
	}

	// Token: 0x0200064C RID: 1612
	public enum CharacterState
	{
		// Token: 0x04004EAB RID: 20139
		Idle,
		// Token: 0x04004EAC RID: 20140
		Walk,
		// Token: 0x04004EAD RID: 20141
		WalkBack,
		// Token: 0x04004EAE RID: 20142
		StrafeLeft,
		// Token: 0x04004EAF RID: 20143
		StrafeRight,
		// Token: 0x04004EB0 RID: 20144
		Jump
	}
}
