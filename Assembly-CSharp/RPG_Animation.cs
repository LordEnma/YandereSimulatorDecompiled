using UnityEngine;

public class RPG_Animation : MonoBehaviour
{
	public enum CharacterMoveDirection
	{
		None = 0,
		Forward = 1,
		Backward = 2,
		StrafeLeft = 3,
		StrafeRight = 4,
		StrafeForwardLeft = 5,
		StrafeForwardRight = 6,
		StrafeBackLeft = 7,
		StrafeBackRight = 8
	}

	public enum CharacterState
	{
		Idle = 0,
		Walk = 1,
		WalkBack = 2,
		StrafeLeft = 3,
		StrafeRight = 4,
		Jump = 5
	}

	public static RPG_Animation instance;

	public CharacterMoveDirection currentMoveDir;

	public CharacterState currentState;

	private void Awake()
	{
		instance = this;
	}

	private void Update()
	{
		SetCurrentState();
		StartAnimation();
	}

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
				currentMoveDir = CharacterMoveDirection.StrafeForwardLeft;
			}
			else if (flag4)
			{
				currentMoveDir = CharacterMoveDirection.StrafeForwardRight;
			}
			else
			{
				currentMoveDir = CharacterMoveDirection.Forward;
			}
		}
		else if (flag2)
		{
			if (flag3)
			{
				currentMoveDir = CharacterMoveDirection.StrafeBackLeft;
			}
			else if (flag4)
			{
				currentMoveDir = CharacterMoveDirection.StrafeBackRight;
			}
			else
			{
				currentMoveDir = CharacterMoveDirection.Backward;
			}
		}
		else if (flag3)
		{
			currentMoveDir = CharacterMoveDirection.StrafeLeft;
		}
		else if (flag4)
		{
			currentMoveDir = CharacterMoveDirection.StrafeRight;
		}
		else
		{
			currentMoveDir = CharacterMoveDirection.None;
		}
	}

	public void SetCurrentState()
	{
		if (RPG_Controller.instance.characterController.isGrounded)
		{
			switch (currentMoveDir)
			{
			case CharacterMoveDirection.None:
				currentState = CharacterState.Idle;
				break;
			case CharacterMoveDirection.Forward:
				currentState = CharacterState.Walk;
				break;
			case CharacterMoveDirection.StrafeForwardLeft:
				currentState = CharacterState.Walk;
				break;
			case CharacterMoveDirection.StrafeForwardRight:
				currentState = CharacterState.Walk;
				break;
			case CharacterMoveDirection.Backward:
				currentState = CharacterState.WalkBack;
				break;
			case CharacterMoveDirection.StrafeBackLeft:
				currentState = CharacterState.WalkBack;
				break;
			case CharacterMoveDirection.StrafeBackRight:
				currentState = CharacterState.WalkBack;
				break;
			case CharacterMoveDirection.StrafeLeft:
				currentState = CharacterState.StrafeLeft;
				break;
			case CharacterMoveDirection.StrafeRight:
				currentState = CharacterState.StrafeRight;
				break;
			}
		}
	}

	public void StartAnimation()
	{
		switch (currentState)
		{
		case CharacterState.Idle:
			Idle();
			break;
		case CharacterState.Walk:
			if (currentMoveDir == CharacterMoveDirection.StrafeForwardLeft)
			{
				StrafeForwardLeft();
			}
			else if (currentMoveDir == CharacterMoveDirection.StrafeForwardRight)
			{
				StrafeForwardRight();
			}
			else
			{
				Walk();
			}
			break;
		case CharacterState.WalkBack:
			if (currentMoveDir == CharacterMoveDirection.StrafeBackLeft)
			{
				StrafeBackLeft();
			}
			else if (currentMoveDir == CharacterMoveDirection.StrafeBackRight)
			{
				StrafeBackRight();
			}
			else
			{
				WalkBack();
			}
			break;
		case CharacterState.StrafeLeft:
			StrafeLeft();
			break;
		case CharacterState.StrafeRight:
			StrafeRight();
			break;
		}
	}

	private void Idle()
	{
		GetComponent<Animation>().CrossFade("idle");
	}

	private void Walk()
	{
		GetComponent<Animation>().CrossFade("walk");
	}

	private void StrafeForwardLeft()
	{
		GetComponent<Animation>().CrossFade("strafeforwardleft");
	}

	private void StrafeForwardRight()
	{
		GetComponent<Animation>().CrossFade("strafeforwardright");
	}

	private void WalkBack()
	{
		GetComponent<Animation>().CrossFade("walkback");
	}

	private void StrafeBackLeft()
	{
		GetComponent<Animation>().CrossFade("strafebackleft");
	}

	private void StrafeBackRight()
	{
		GetComponent<Animation>().CrossFade("strafebackright");
	}

	private void StrafeLeft()
	{
		GetComponent<Animation>().CrossFade("strafeleft");
	}

	private void StrafeRight()
	{
		GetComponent<Animation>().CrossFade("straferight");
	}

	public void Jump()
	{
		currentState = CharacterState.Jump;
		if (GetComponent<Animation>().IsPlaying("jump"))
		{
			GetComponent<Animation>().Stop("jump");
		}
		GetComponent<Animation>().CrossFade("jump");
	}
}
