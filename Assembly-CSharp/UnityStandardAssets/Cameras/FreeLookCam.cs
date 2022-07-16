// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.Cameras.FreeLookCam
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Cameras
{
  public class FreeLookCam : PivotBasedCameraRig
  {
    [SerializeField]
    private float m_MoveSpeed = 1f;
    [Range(0.0f, 10f)]
    [SerializeField]
    private float m_TurnSpeed = 1.5f;
    [SerializeField]
    private float m_TurnSmoothing;
    [SerializeField]
    private float m_TiltMax = 75f;
    [SerializeField]
    private float m_TiltMin = 45f;
    [SerializeField]
    private bool m_LockCursor;
    [SerializeField]
    private bool m_VerticalAutoReturn;
    private float m_LookAngle;
    private float m_TiltAngle;
    private const float k_LookDistance = 100f;
    private Vector3 m_PivotEulers;
    private Quaternion m_PivotTargetRot;
    private Quaternion m_TransformTargetRot;

    protected override void Awake()
    {
      base.Awake();
      Cursor.lockState = this.m_LockCursor ? CursorLockMode.Locked : CursorLockMode.None;
      Cursor.visible = !this.m_LockCursor;
      this.m_PivotEulers = this.m_Pivot.rotation.eulerAngles;
      this.m_PivotTargetRot = this.m_Pivot.transform.localRotation;
      this.m_TransformTargetRot = this.transform.localRotation;
    }

    protected void Update()
    {
      this.HandleRotationMovement();
      if (!this.m_LockCursor || !Input.GetMouseButtonUp(0))
        return;
      Cursor.lockState = this.m_LockCursor ? CursorLockMode.Locked : CursorLockMode.None;
      Cursor.visible = !this.m_LockCursor;
    }

    private void OnDisable()
    {
      Cursor.lockState = CursorLockMode.None;
      Cursor.visible = true;
    }

    protected override void FollowTarget(float deltaTime)
    {
      if ((Object) this.m_Target == (Object) null)
        return;
      this.transform.position = Vector3.Lerp(this.transform.position, this.m_Target.position, deltaTime * this.m_MoveSpeed);
    }

    private void HandleRotationMovement()
    {
      if ((double) Time.timeScale < 1.40129846432482E-45)
        return;
      float axis1 = CrossPlatformInputManager.GetAxis("Mouse X");
      float axis2 = CrossPlatformInputManager.GetAxis("Mouse Y");
      this.m_LookAngle += axis1 * this.m_TurnSpeed;
      this.m_TransformTargetRot = Quaternion.Euler(0.0f, this.m_LookAngle, 0.0f);
      if (this.m_VerticalAutoReturn)
      {
        this.m_TiltAngle = (double) axis2 > 0.0 ? Mathf.Lerp(0.0f, -this.m_TiltMin, axis2) : Mathf.Lerp(0.0f, this.m_TiltMax, -axis2);
      }
      else
      {
        this.m_TiltAngle -= axis2 * this.m_TurnSpeed;
        this.m_TiltAngle = Mathf.Clamp(this.m_TiltAngle, -this.m_TiltMin, this.m_TiltMax);
      }
      this.m_PivotTargetRot = Quaternion.Euler(this.m_TiltAngle, this.m_PivotEulers.y, this.m_PivotEulers.z);
      if ((double) this.m_TurnSmoothing > 0.0)
      {
        this.m_Pivot.localRotation = Quaternion.Slerp(this.m_Pivot.localRotation, this.m_PivotTargetRot, this.m_TurnSmoothing * Time.deltaTime);
        this.transform.localRotation = Quaternion.Slerp(this.transform.localRotation, this.m_TransformTargetRot, this.m_TurnSmoothing * Time.deltaTime);
      }
      else
      {
        this.m_Pivot.localRotation = this.m_PivotTargetRot;
        this.transform.localRotation = this.m_TransformTargetRot;
      }
    }
  }
}
