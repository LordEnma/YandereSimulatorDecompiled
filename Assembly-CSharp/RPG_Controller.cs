// Decompiled with JetBrains decompiler
// Type: RPG_Controller
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class RPG_Controller : MonoBehaviour
{
  public static RPG_Controller instance;
  public CharacterController characterController;
  public float walkSpeed = 10f;
  public float turnSpeed = 2.5f;
  public float jumpHeight = 10f;
  public float gravity = 20f;
  public float fallingThreshold = -6f;
  private Vector3 playerDir;
  private Vector3 playerDirWorld;
  private Vector3 rotation = Vector3.zero;
  private Camera MainCamera;

  private void Awake()
  {
    RPG_Controller.instance = this;
    this.characterController = this.GetComponent("CharacterController") as CharacterController;
    RPG_Camera.CameraSetup();
    this.MainCamera = Camera.main;
  }

  private void Update()
  {
    if ((Object) this.MainCamera == (Object) null)
      return;
    if ((Object) this.characterController == (Object) null)
    {
      Debug.Log((object) "Error: No Character Controller component found! Please add one to the GameObject which has this script attached.");
    }
    else
    {
      this.GetInput();
      this.StartMotor();
    }
  }

  private void GetInput()
  {
    float num1 = 0.0f;
    float num2 = 0.0f;
    if (Input.GetButton("Horizontal Strafe"))
      num1 = (double) Input.GetAxis("Horizontal Strafe") < 0.0 ? -1f : ((double) Input.GetAxis("Horizontal Strafe") > 0.0 ? 1f : 0.0f);
    if (Input.GetButton("Vertical"))
      num2 = (double) Input.GetAxis("Vertical") < 0.0 ? -1f : ((double) Input.GetAxis("Vertical") > 0.0 ? 1f : 0.0f);
    if (Input.GetMouseButton(0) && Input.GetMouseButton(1))
      num2 = 1f;
    this.playerDir = num1 * Vector3.right + num2 * Vector3.forward;
    if ((Object) RPG_Animation.instance != (Object) null)
      RPG_Animation.instance.SetCurrentMoveDir(this.playerDir);
    if (this.characterController.isGrounded)
    {
      this.playerDirWorld = this.transform.TransformDirection(this.playerDir);
      if ((double) Mathf.Abs(this.playerDir.x) + (double) Mathf.Abs(this.playerDir.z) > 1.0)
        this.playerDirWorld.Normalize();
      this.playerDirWorld *= this.walkSpeed;
      this.playerDirWorld.y = this.fallingThreshold;
      if (Input.GetButtonDown("Jump"))
      {
        this.playerDirWorld.y = this.jumpHeight;
        if ((Object) RPG_Animation.instance != (Object) null)
          RPG_Animation.instance.Jump();
      }
    }
    this.rotation.y = Input.GetAxis("Horizontal") * this.turnSpeed;
  }

  private void StartMotor()
  {
    this.playerDirWorld.y -= this.gravity * Time.deltaTime;
    int num = (int) this.characterController.Move(this.playerDirWorld * Time.deltaTime);
    this.transform.Rotate(this.rotation);
    if (Input.GetMouseButton(0))
      return;
    RPG_Camera.instance.RotateWithCharacter();
  }
}
