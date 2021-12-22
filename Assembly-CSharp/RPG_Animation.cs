using System;
using UnityEngine;

// Token: 0x020000BA RID: 186
public class RPG_Animation : MonoBehaviour
{
	// Token: 0x0600096A RID: 2410 RVA: 0x0004B3F6 File Offset: 0x000495F6
	private void Awake()
	{
		RPG_Animation.instance = this;
	}

	// Token: 0x0600096B RID: 2411 RVA: 0x0004B3FE File Offset: 0x000495FE
	private void Update()
	{
		this.SetCurrentState();
		this.StartAnimation();
	}

	// Token: 0x0600096C RID: 2412 RVA: 0x0004B40C File Offset: 0x0004960C
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

	// Token: 0x0600096D RID: 2413 RVA: 0x0004B4BC File Offset: 0x000496BC
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

	// Token: 0x0600096E RID: 2414 RVA: 0x0004B554 File Offset: 0x00049754
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

	// Token: 0x0600096F RID: 2415 RVA: 0x0004B5E5 File Offset: 0x000497E5
	private void Idle()
	{
		base.GetComponent<Animation>().CrossFade("idle");
	}

	// Token: 0x06000970 RID: 2416 RVA: 0x0004B5F7 File Offset: 0x000497F7
	private void Walk()
	{
		base.GetComponent<Animation>().CrossFade("walk");
	}

	// Token: 0x06000971 RID: 2417 RVA: 0x0004B609 File Offset: 0x00049809
	private void StrafeForwardLeft()
	{
		base.GetComponent<Animation>().CrossFade("strafeforwardleft");
	}

	// Token: 0x06000972 RID: 2418 RVA: 0x0004B61B File Offset: 0x0004981B
	private void StrafeForwardRight()
	{
		base.GetComponent<Animation>().CrossFade("strafeforwardright");
	}

	// Token: 0x06000973 RID: 2419 RVA: 0x0004B62D File Offset: 0x0004982D
	private void WalkBack()
	{
		base.GetComponent<Animation>().CrossFade("walkback");
	}

	// Token: 0x06000974 RID: 2420 RVA: 0x0004B63F File Offset: 0x0004983F
	private void StrafeBackLeft()
	{
		base.GetComponent<Animation>().CrossFade("strafebackleft");
	}

	// Token: 0x06000975 RID: 2421 RVA: 0x0004B651 File Offset: 0x00049851
	private void StrafeBackRight()
	{
		base.GetComponent<Animation>().CrossFade("strafebackright");
	}

	// Token: 0x06000976 RID: 2422 RVA: 0x0004B663 File Offset: 0x00049863
	private void StrafeLeft()
	{
		base.GetComponent<Animation>().CrossFade("strafeleft");
	}

	// Token: 0x06000977 RID: 2423 RVA: 0x0004B675 File Offset: 0x00049875
	private void StrafeRight()
	{
		base.GetComponent<Animation>().CrossFade("straferight");
	}

	// Token: 0x06000978 RID: 2424 RVA: 0x0004B687 File Offset: 0x00049887
	public void Jump()
	{
		this.currentState = RPG_Animation.CharacterState.Jump;
		if (base.GetComponent<Animation>().IsPlaying("jump"))
		{
			base.GetComponent<Animation>().Stop("jump");
		}
		base.GetComponent<Animation>().CrossFade("jump");
	}

	// Token: 0x04000805 RID: 2053
	public static RPG_Animation instance;

	// Token: 0x04000806 RID: 2054
	public RPG_Animation.CharacterMoveDirection currentMoveDir;

	// Token: 0x04000807 RID: 2055
	public RPG_Animation.CharacterState currentState;

	// Token: 0x02000648 RID: 1608
	public enum CharacterMoveDirection
	{
		// Token: 0x04004E7D RID: 20093
		None,
		// Token: 0x04004E7E RID: 20094
		Forward,
		// Token: 0x04004E7F RID: 20095
		Backward,
		// Token: 0x04004E80 RID: 20096
		StrafeLeft,
		// Token: 0x04004E81 RID: 20097
		StrafeRight,
		// Token: 0x04004E82 RID: 20098
		StrafeForwardLeft,
		// Token: 0x04004E83 RID: 20099
		StrafeForwardRight,
		// Token: 0x04004E84 RID: 20100
		StrafeBackLeft,
		// Token: 0x04004E85 RID: 20101
		StrafeBackRight
	}

	// Token: 0x02000649 RID: 1609
	public enum CharacterState
	{
		// Token: 0x04004E87 RID: 20103
		Idle,
		// Token: 0x04004E88 RID: 20104
		Walk,
		// Token: 0x04004E89 RID: 20105
		WalkBack,
		// Token: 0x04004E8A RID: 20106
		StrafeLeft,
		// Token: 0x04004E8B RID: 20107
		StrafeRight,
		// Token: 0x04004E8C RID: 20108
		Jump
	}
}
