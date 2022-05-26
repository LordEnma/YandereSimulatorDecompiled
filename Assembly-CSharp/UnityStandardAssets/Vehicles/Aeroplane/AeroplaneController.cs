// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.Vehicles.Aeroplane.AeroplaneController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
  [RequireComponent(typeof (Rigidbody))]
  public class AeroplaneController : MonoBehaviour
  {
    [SerializeField]
    private float m_MaxEnginePower = 40f;
    [SerializeField]
    private float m_Lift = 1f / 500f;
    [SerializeField]
    private float m_ZeroLiftSpeed = 300f;
    [SerializeField]
    private float m_RollEffect = 1f;
    [SerializeField]
    private float m_PitchEffect = 1f;
    [SerializeField]
    private float m_YawEffect = 0.2f;
    [SerializeField]
    private float m_BankedTurnEffect = 0.5f;
    [SerializeField]
    private float m_AerodynamicEffect = 0.02f;
    [SerializeField]
    private float m_AutoTurnPitch = 0.5f;
    [SerializeField]
    private float m_AutoRollLevel = 0.2f;
    [SerializeField]
    private float m_AutoPitchLevel = 0.2f;
    [SerializeField]
    private float m_AirBrakesEffect = 3f;
    [SerializeField]
    private float m_ThrottleChangeSpeed = 0.3f;
    [SerializeField]
    private float m_DragIncreaseFactor = 1f / 1000f;
    private float m_OriginalDrag;
    private float m_OriginalAngularDrag;
    private float m_AeroFactor;
    private bool m_Immobilized;
    private float m_BankedTurnAmount;
    private Rigidbody m_Rigidbody;
    private WheelCollider[] m_WheelColliders;

    public float Altitude { get; private set; }

    public float Throttle { get; private set; }

    public bool AirBrakes { get; private set; }

    public float ForwardSpeed { get; private set; }

    public float EnginePower { get; private set; }

    public float MaxEnginePower => this.m_MaxEnginePower;

    public float RollAngle { get; private set; }

    public float PitchAngle { get; private set; }

    public float RollInput { get; private set; }

    public float PitchInput { get; private set; }

    public float YawInput { get; private set; }

    public float ThrottleInput { get; private set; }

    private void Start()
    {
      this.m_Rigidbody = this.GetComponent<Rigidbody>();
      this.m_OriginalDrag = this.m_Rigidbody.drag;
      this.m_OriginalAngularDrag = this.m_Rigidbody.angularDrag;
      for (int index = 0; index < this.transform.childCount; ++index)
      {
        foreach (WheelCollider componentsInChild in this.transform.GetChild(index).GetComponentsInChildren<WheelCollider>())
          componentsInChild.motorTorque = 0.18f;
      }
    }

    public void Move(
      float rollInput,
      float pitchInput,
      float yawInput,
      float throttleInput,
      bool airBrakes)
    {
      this.RollInput = rollInput;
      this.PitchInput = pitchInput;
      this.YawInput = yawInput;
      this.ThrottleInput = throttleInput;
      this.AirBrakes = airBrakes;
      this.ClampInputs();
      this.CalculateRollAndPitchAngles();
      this.AutoLevel();
      this.CalculateForwardSpeed();
      this.ControlThrottle();
      this.CalculateDrag();
      this.CaluclateAerodynamicEffect();
      this.CalculateLinearForces();
      this.CalculateTorque();
      this.CalculateAltitude();
    }

    private void ClampInputs()
    {
      this.RollInput = Mathf.Clamp(this.RollInput, -1f, 1f);
      this.PitchInput = Mathf.Clamp(this.PitchInput, -1f, 1f);
      this.YawInput = Mathf.Clamp(this.YawInput, -1f, 1f);
      this.ThrottleInput = Mathf.Clamp(this.ThrottleInput, -1f, 1f);
    }

    private void CalculateRollAndPitchAngles()
    {
      Vector3 forward = this.transform.forward with
      {
        y = 0.0f
      };
      if ((double) forward.sqrMagnitude <= 0.0)
        return;
      forward.Normalize();
      Vector3 vector3_1 = this.transform.InverseTransformDirection(forward);
      this.PitchAngle = Mathf.Atan2(vector3_1.y, vector3_1.z);
      Vector3 vector3_2 = this.transform.InverseTransformDirection(Vector3.Cross(Vector3.up, forward));
      this.RollAngle = Mathf.Atan2(vector3_2.y, vector3_2.x);
    }

    private void AutoLevel()
    {
      this.m_BankedTurnAmount = Mathf.Sin(this.RollAngle);
      if ((double) this.RollInput == 0.0)
        this.RollInput = -this.RollAngle * this.m_AutoRollLevel;
      if ((double) this.PitchInput != 0.0)
        return;
      this.PitchInput = -this.PitchAngle * this.m_AutoPitchLevel;
      this.PitchInput -= Mathf.Abs(this.m_BankedTurnAmount * this.m_BankedTurnAmount * this.m_AutoTurnPitch);
    }

    private void CalculateForwardSpeed() => this.ForwardSpeed = Mathf.Max(0.0f, this.transform.InverseTransformDirection(this.m_Rigidbody.velocity).z);

    private void ControlThrottle()
    {
      if (this.m_Immobilized)
        this.ThrottleInput = -0.5f;
      this.Throttle = Mathf.Clamp01(this.Throttle + this.ThrottleInput * Time.deltaTime * this.m_ThrottleChangeSpeed);
      this.EnginePower = this.Throttle * this.m_MaxEnginePower;
    }

    private void CalculateDrag()
    {
      float num = this.m_Rigidbody.velocity.magnitude * this.m_DragIncreaseFactor;
      this.m_Rigidbody.drag = this.AirBrakes ? (this.m_OriginalDrag + num) * this.m_AirBrakesEffect : this.m_OriginalDrag + num;
      this.m_Rigidbody.angularDrag = this.m_OriginalAngularDrag * this.ForwardSpeed;
    }

    private void CaluclateAerodynamicEffect()
    {
      if ((double) this.m_Rigidbody.velocity.magnitude <= 0.0)
        return;
      this.m_AeroFactor = Vector3.Dot(this.transform.forward, this.m_Rigidbody.velocity.normalized);
      this.m_AeroFactor *= this.m_AeroFactor;
      this.m_Rigidbody.velocity = Vector3.Lerp(this.m_Rigidbody.velocity, this.transform.forward * this.ForwardSpeed, this.m_AeroFactor * this.ForwardSpeed * this.m_AerodynamicEffect * Time.deltaTime);
      this.m_Rigidbody.rotation = Quaternion.Slerp(this.m_Rigidbody.rotation, Quaternion.LookRotation(this.m_Rigidbody.velocity, this.transform.up), this.m_AerodynamicEffect * Time.deltaTime);
    }

    private void CalculateLinearForces()
    {
      Vector3 vector3 = Vector3.zero + this.EnginePower * this.transform.forward;
      Vector3 normalized = Vector3.Cross(this.m_Rigidbody.velocity, this.transform.right).normalized;
      float num = this.ForwardSpeed * this.ForwardSpeed * this.m_Lift * Mathf.InverseLerp(this.m_ZeroLiftSpeed, 0.0f, this.ForwardSpeed) * this.m_AeroFactor;
      this.m_Rigidbody.AddForce(vector3 + num * normalized);
    }

    private void CalculateTorque() => this.m_Rigidbody.AddTorque((Vector3.zero + this.PitchInput * this.m_PitchEffect * this.transform.right + this.YawInput * this.m_YawEffect * this.transform.up + -this.RollInput * this.m_RollEffect * this.transform.forward + this.m_BankedTurnAmount * this.m_BankedTurnEffect * this.transform.up) * this.ForwardSpeed * this.m_AeroFactor);

    private void CalculateAltitude()
    {
      RaycastHit hitInfo;
      this.Altitude = Physics.Raycast(new Ray(this.transform.position - Vector3.up * 10f, -Vector3.up), out hitInfo) ? hitInfo.distance + 10f : this.transform.position.y;
    }

    public void Immobilize() => this.m_Immobilized = true;

    public void Reset() => this.m_Immobilized = false;
  }
}
