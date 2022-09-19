// Decompiled with JetBrains decompiler
// Type: PlayerMove
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
  [SerializeField]
  private string horizontalInputName;
  [SerializeField]
  private string verticalInputName;
  [SerializeField]
  private float walkSpeed;
  [SerializeField]
  private float runSpeed;
  [SerializeField]
  private float runBuildUpSpeed;
  [SerializeField]
  private KeyCode runKey;
  private float movementSpeed;
  [SerializeField]
  private float slopeForce;
  [SerializeField]
  private float slopeForceRayLength;
  private CharacterController charController;
  [SerializeField]
  private AnimationCurve jumpFallOff;
  [SerializeField]
  private float jumpMultiplier;
  [SerializeField]
  private KeyCode jumpKey;
  private bool isJumping;

  private void Awake() => this.charController = this.GetComponent<CharacterController>();

  private void Update() => this.PlayerMovement();

  private void PlayerMovement()
  {
    float axis1 = Input.GetAxis(this.horizontalInputName);
    float axis2 = Input.GetAxis(this.verticalInputName);
    this.charController.SimpleMove(Vector3.ClampMagnitude(this.transform.forward * axis2 + this.transform.right * axis1, 1f) * this.movementSpeed);
    if (((double) axis2 != 0.0 || (double) axis1 != 0.0) && this.OnSlope())
    {
      int num = (int) this.charController.Move(Vector3.down * this.charController.height / 2f * this.slopeForce * Time.deltaTime);
    }
    this.SetMovementSpeed();
    this.JumpInput();
  }

  private void SetMovementSpeed()
  {
    if (Input.GetKey(this.runKey))
      this.movementSpeed = Mathf.Lerp(this.movementSpeed, this.runSpeed, Time.deltaTime * this.runBuildUpSpeed);
    else
      this.movementSpeed = Mathf.Lerp(this.movementSpeed, this.walkSpeed, Time.deltaTime * this.runBuildUpSpeed);
  }

  private bool OnSlope()
  {
    RaycastHit hitInfo;
    if (this.isJumping || !Physics.Raycast(this.transform.position, Vector3.down, out hitInfo, this.charController.height / 2f * this.slopeForceRayLength) || !(hitInfo.normal != Vector3.up))
      return false;
    MonoBehaviour.print((object) nameof (OnSlope));
    return true;
  }

  private void JumpInput()
  {
    if (!Input.GetKeyDown(this.jumpKey) || this.isJumping)
      return;
    this.isJumping = true;
    this.StartCoroutine(this.JumpEvent());
  }

  private IEnumerator JumpEvent()
  {
    this.charController.slopeLimit = 90f;
    float timeInAir = 0.0f;
    do
    {
      int num = (int) this.charController.Move(Vector3.up * this.jumpFallOff.Evaluate(timeInAir) * this.jumpMultiplier * Time.deltaTime);
      timeInAir += Time.deltaTime;
      yield return (object) null;
    }
    while (!this.charController.isGrounded && this.charController.collisionFlags != CollisionFlags.Above);
    this.charController.slopeLimit = 45f;
    this.isJumping = false;
  }
}
