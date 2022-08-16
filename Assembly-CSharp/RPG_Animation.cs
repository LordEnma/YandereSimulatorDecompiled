// Decompiled with JetBrains decompiler
// Type: RPG_Animation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class RPG_Animation : MonoBehaviour
{
  public static RPG_Animation instance;
  public RPG_Animation.CharacterMoveDirection currentMoveDir;
  public RPG_Animation.CharacterState currentState;

  private void Awake() => RPG_Animation.instance = this;

  private void Update()
  {
    this.SetCurrentState();
    this.StartAnimation();
  }

  public void SetCurrentMoveDir(Vector3 playerDir)
  {
    bool flag1 = false;
    bool flag2 = false;
    bool flag3 = false;
    bool flag4 = false;
    if ((double) playerDir.z > 0.0)
      flag1 = true;
    if ((double) playerDir.z < 0.0)
      flag2 = true;
    if ((double) playerDir.x < 0.0)
      flag3 = true;
    if ((double) playerDir.x > 0.0)
      flag4 = true;
    if (flag1)
    {
      if (flag3)
        this.currentMoveDir = RPG_Animation.CharacterMoveDirection.StrafeForwardLeft;
      else if (flag4)
        this.currentMoveDir = RPG_Animation.CharacterMoveDirection.StrafeForwardRight;
      else
        this.currentMoveDir = RPG_Animation.CharacterMoveDirection.Forward;
    }
    else if (flag2)
    {
      if (flag3)
        this.currentMoveDir = RPG_Animation.CharacterMoveDirection.StrafeBackLeft;
      else if (flag4)
        this.currentMoveDir = RPG_Animation.CharacterMoveDirection.StrafeBackRight;
      else
        this.currentMoveDir = RPG_Animation.CharacterMoveDirection.Backward;
    }
    else if (flag3)
      this.currentMoveDir = RPG_Animation.CharacterMoveDirection.StrafeLeft;
    else if (flag4)
      this.currentMoveDir = RPG_Animation.CharacterMoveDirection.StrafeRight;
    else
      this.currentMoveDir = RPG_Animation.CharacterMoveDirection.None;
  }

  public void SetCurrentState()
  {
    if (!RPG_Controller.instance.characterController.isGrounded)
      return;
    switch (this.currentMoveDir)
    {
      case RPG_Animation.CharacterMoveDirection.None:
        this.currentState = RPG_Animation.CharacterState.Idle;
        break;
      case RPG_Animation.CharacterMoveDirection.Forward:
        this.currentState = RPG_Animation.CharacterState.Walk;
        break;
      case RPG_Animation.CharacterMoveDirection.Backward:
        this.currentState = RPG_Animation.CharacterState.WalkBack;
        break;
      case RPG_Animation.CharacterMoveDirection.StrafeLeft:
        this.currentState = RPG_Animation.CharacterState.StrafeLeft;
        break;
      case RPG_Animation.CharacterMoveDirection.StrafeRight:
        this.currentState = RPG_Animation.CharacterState.StrafeRight;
        break;
      case RPG_Animation.CharacterMoveDirection.StrafeForwardLeft:
        this.currentState = RPG_Animation.CharacterState.Walk;
        break;
      case RPG_Animation.CharacterMoveDirection.StrafeForwardRight:
        this.currentState = RPG_Animation.CharacterState.Walk;
        break;
      case RPG_Animation.CharacterMoveDirection.StrafeBackLeft:
        this.currentState = RPG_Animation.CharacterState.WalkBack;
        break;
      case RPG_Animation.CharacterMoveDirection.StrafeBackRight:
        this.currentState = RPG_Animation.CharacterState.WalkBack;
        break;
    }
  }

  public void StartAnimation()
  {
    switch (this.currentState)
    {
      case RPG_Animation.CharacterState.Idle:
        this.Idle();
        break;
      case RPG_Animation.CharacterState.Walk:
        if (this.currentMoveDir == RPG_Animation.CharacterMoveDirection.StrafeForwardLeft)
        {
          this.StrafeForwardLeft();
          break;
        }
        if (this.currentMoveDir == RPG_Animation.CharacterMoveDirection.StrafeForwardRight)
        {
          this.StrafeForwardRight();
          break;
        }
        this.Walk();
        break;
      case RPG_Animation.CharacterState.WalkBack:
        if (this.currentMoveDir == RPG_Animation.CharacterMoveDirection.StrafeBackLeft)
        {
          this.StrafeBackLeft();
          break;
        }
        if (this.currentMoveDir == RPG_Animation.CharacterMoveDirection.StrafeBackRight)
        {
          this.StrafeBackRight();
          break;
        }
        this.WalkBack();
        break;
      case RPG_Animation.CharacterState.StrafeLeft:
        this.StrafeLeft();
        break;
      case RPG_Animation.CharacterState.StrafeRight:
        this.StrafeRight();
        break;
    }
  }

  private void Idle() => this.GetComponent<Animation>().CrossFade("idle");

  private void Walk() => this.GetComponent<Animation>().CrossFade("walk");

  private void StrafeForwardLeft() => this.GetComponent<Animation>().CrossFade("strafeforwardleft");

  private void StrafeForwardRight() => this.GetComponent<Animation>().CrossFade("strafeforwardright");

  private void WalkBack() => this.GetComponent<Animation>().CrossFade("walkback");

  private void StrafeBackLeft() => this.GetComponent<Animation>().CrossFade("strafebackleft");

  private void StrafeBackRight() => this.GetComponent<Animation>().CrossFade("strafebackright");

  private void StrafeLeft() => this.GetComponent<Animation>().CrossFade("strafeleft");

  private void StrafeRight() => this.GetComponent<Animation>().CrossFade("straferight");

  public void Jump()
  {
    this.currentState = RPG_Animation.CharacterState.Jump;
    if (this.GetComponent<Animation>().IsPlaying("jump"))
      this.GetComponent<Animation>().Stop("jump");
    this.GetComponent<Animation>().CrossFade("jump");
  }

  public enum CharacterMoveDirection
  {
    None,
    Forward,
    Backward,
    StrafeLeft,
    StrafeRight,
    StrafeForwardLeft,
    StrafeForwardRight,
    StrafeBackLeft,
    StrafeBackRight,
  }

  public enum CharacterState
  {
    Idle,
    Walk,
    WalkBack,
    StrafeLeft,
    StrafeRight,
    Jump,
  }
}
