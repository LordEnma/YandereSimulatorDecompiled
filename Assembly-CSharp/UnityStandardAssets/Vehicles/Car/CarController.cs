// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.Vehicles.Car.CarController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
  public class CarController : MonoBehaviour
  {
    [SerializeField]
    private CarDriveType m_CarDriveType = CarDriveType.FourWheelDrive;
    [SerializeField]
    private WheelCollider[] m_WheelColliders = new WheelCollider[4];
    [SerializeField]
    private GameObject[] m_WheelMeshes = new GameObject[4];
    [SerializeField]
    private WheelEffects[] m_WheelEffects = new WheelEffects[4];
    [SerializeField]
    private Vector3 m_CentreOfMassOffset;
    [SerializeField]
    private float m_MaximumSteerAngle;
    [Range(0.0f, 1f)]
    [SerializeField]
    private float m_SteerHelper;
    [Range(0.0f, 1f)]
    [SerializeField]
    private float m_TractionControl;
    [SerializeField]
    private float m_FullTorqueOverAllWheels;
    [SerializeField]
    private float m_ReverseTorque;
    [SerializeField]
    private float m_MaxHandbrakeTorque;
    [SerializeField]
    private float m_Downforce = 100f;
    [SerializeField]
    private SpeedType m_SpeedType;
    [SerializeField]
    private float m_Topspeed = 200f;
    [SerializeField]
    private static int NoOfGears = 5;
    [SerializeField]
    private float m_RevRangeBoundary = 1f;
    [SerializeField]
    private float m_SlipLimit;
    [SerializeField]
    private float m_BrakeTorque;
    private Quaternion[] m_WheelMeshLocalRotations;
    private Vector3 m_Prevpos;
    private Vector3 m_Pos;
    private float m_SteerAngle;
    private int m_GearNum;
    private float m_GearFactor;
    private float m_OldRotation;
    private float m_CurrentTorque;
    private Rigidbody m_Rigidbody;
    private const float k_ReversingThreshold = 0.01f;

    public bool Skidding { get; private set; }

    public float BrakeInput { get; private set; }

    public float CurrentSteerAngle => this.m_SteerAngle;

    public float CurrentSpeed => this.m_Rigidbody.velocity.magnitude * 2.236936f;

    public float MaxSpeed => this.m_Topspeed;

    public float Revs { get; private set; }

    public float AccelInput { get; private set; }

    private void Start()
    {
      this.m_WheelMeshLocalRotations = new Quaternion[4];
      for (int index = 0; index < 4; ++index)
        this.m_WheelMeshLocalRotations[index] = this.m_WheelMeshes[index].transform.localRotation;
      this.m_WheelColliders[0].attachedRigidbody.centerOfMass = this.m_CentreOfMassOffset;
      this.m_MaxHandbrakeTorque = float.MaxValue;
      this.m_Rigidbody = this.GetComponent<Rigidbody>();
      this.m_CurrentTorque = this.m_FullTorqueOverAllWheels - this.m_TractionControl * this.m_FullTorqueOverAllWheels;
    }

    private void GearChanging()
    {
      float num1 = Mathf.Abs(this.CurrentSpeed / this.MaxSpeed);
      float num2 = 1f / (float) CarController.NoOfGears * (float) (this.m_GearNum + 1);
      float num3 = 1f / (float) CarController.NoOfGears * (float) this.m_GearNum;
      if (this.m_GearNum > 0 && (double) num1 < (double) num3)
        --this.m_GearNum;
      if ((double) num1 <= (double) num2 || this.m_GearNum >= CarController.NoOfGears - 1)
        return;
      ++this.m_GearNum;
    }

    private static float CurveFactor(float factor) => (float) (1.0 - (1.0 - (double) factor) * (1.0 - (double) factor));

    private static float ULerp(float from, float to, float value) => (float) ((1.0 - (double) value) * (double) from + (double) value * (double) to);

    private void CalculateGearFactor()
    {
      float num = 1f / (float) CarController.NoOfGears;
      this.m_GearFactor = Mathf.Lerp(this.m_GearFactor, Mathf.InverseLerp(num * (float) this.m_GearNum, num * (float) (this.m_GearNum + 1), Mathf.Abs(this.CurrentSpeed / this.MaxSpeed)), Time.deltaTime * 5f);
    }

    private void CalculateRevs()
    {
      this.CalculateGearFactor();
      float factor = (float) this.m_GearNum / (float) CarController.NoOfGears;
      this.Revs = CarController.ULerp(CarController.ULerp(0.0f, this.m_RevRangeBoundary, CarController.CurveFactor(factor)), CarController.ULerp(this.m_RevRangeBoundary, 1f, factor), this.m_GearFactor);
    }

    public void Move(float steering, float accel, float footbrake, float handbrake)
    {
      for (int index = 0; index < 4; ++index)
      {
        Vector3 pos;
        Quaternion quat;
        this.m_WheelColliders[index].GetWorldPose(out pos, out quat);
        this.m_WheelMeshes[index].transform.position = pos;
        this.m_WheelMeshes[index].transform.rotation = quat;
      }
      steering = Mathf.Clamp(steering, -1f, 1f);
      this.AccelInput = accel = Mathf.Clamp(accel, 0.0f, 1f);
      this.BrakeInput = footbrake = -1f * Mathf.Clamp(footbrake, -1f, 0.0f);
      handbrake = Mathf.Clamp(handbrake, 0.0f, 1f);
      this.m_SteerAngle = steering * this.m_MaximumSteerAngle;
      this.m_WheelColliders[0].steerAngle = this.m_SteerAngle;
      this.m_WheelColliders[1].steerAngle = this.m_SteerAngle;
      this.SteerHelper();
      this.ApplyDrive(accel, footbrake);
      this.CapSpeed();
      if ((double) handbrake > 0.0)
      {
        float num = handbrake * this.m_MaxHandbrakeTorque;
        this.m_WheelColliders[2].brakeTorque = num;
        this.m_WheelColliders[3].brakeTorque = num;
      }
      this.CalculateRevs();
      this.GearChanging();
      this.AddDownForce();
      this.CheckForWheelSpin();
      this.TractionControl();
    }

    private void CapSpeed()
    {
      float magnitude = this.m_Rigidbody.velocity.magnitude;
      switch (this.m_SpeedType)
      {
        case SpeedType.MPH:
          if ((double) (magnitude * 2.236936f) <= (double) this.m_Topspeed)
            break;
          this.m_Rigidbody.velocity = this.m_Topspeed / 2.236936f * this.m_Rigidbody.velocity.normalized;
          break;
        case SpeedType.KPH:
          if ((double) (magnitude * 3.6f) <= (double) this.m_Topspeed)
            break;
          this.m_Rigidbody.velocity = this.m_Topspeed / 3.6f * this.m_Rigidbody.velocity.normalized;
          break;
      }
    }

    private void ApplyDrive(float accel, float footbrake)
    {
      switch (this.m_CarDriveType)
      {
        case CarDriveType.FrontWheelDrive:
          this.m_WheelColliders[0].motorTorque = this.m_WheelColliders[1].motorTorque = accel * (this.m_CurrentTorque / 2f);
          break;
        case CarDriveType.RearWheelDrive:
          this.m_WheelColliders[2].motorTorque = this.m_WheelColliders[3].motorTorque = accel * (this.m_CurrentTorque / 2f);
          break;
        case CarDriveType.FourWheelDrive:
          float num = accel * (this.m_CurrentTorque / 4f);
          for (int index = 0; index < 4; ++index)
            this.m_WheelColliders[index].motorTorque = num;
          break;
      }
      for (int index = 0; index < 4; ++index)
      {
        if ((double) this.CurrentSpeed > 5.0 && (double) Vector3.Angle(this.transform.forward, this.m_Rigidbody.velocity) < 50.0)
          this.m_WheelColliders[index].brakeTorque = this.m_BrakeTorque * footbrake;
        else if ((double) footbrake > 0.0)
        {
          this.m_WheelColliders[index].brakeTorque = 0.0f;
          this.m_WheelColliders[index].motorTorque = -this.m_ReverseTorque * footbrake;
        }
      }
    }

    private void SteerHelper()
    {
      for (int index = 0; index < 4; ++index)
      {
        WheelHit hit;
        this.m_WheelColliders[index].GetGroundHit(out hit);
        if (hit.normal == Vector3.zero)
          return;
      }
      if ((double) Mathf.Abs(this.m_OldRotation - this.transform.eulerAngles.y) < 10.0)
        this.m_Rigidbody.velocity = Quaternion.AngleAxis((this.transform.eulerAngles.y - this.m_OldRotation) * this.m_SteerHelper, Vector3.up) * this.m_Rigidbody.velocity;
      this.m_OldRotation = this.transform.eulerAngles.y;
    }

    private void AddDownForce() => this.m_WheelColliders[0].attachedRigidbody.AddForce(-this.transform.up * this.m_Downforce * this.m_WheelColliders[0].attachedRigidbody.velocity.magnitude);

    private void CheckForWheelSpin()
    {
      for (int index = 0; index < 4; ++index)
      {
        WheelHit hit;
        this.m_WheelColliders[index].GetGroundHit(out hit);
        if ((double) Mathf.Abs(hit.forwardSlip) >= (double) this.m_SlipLimit || (double) Mathf.Abs(hit.sidewaysSlip) >= (double) this.m_SlipLimit)
        {
          this.m_WheelEffects[index].EmitTyreSmoke();
          if (!this.AnySkidSoundPlaying())
            this.m_WheelEffects[index].PlayAudio();
        }
        else
        {
          if (this.m_WheelEffects[index].PlayingAudio)
            this.m_WheelEffects[index].StopAudio();
          this.m_WheelEffects[index].EndSkidTrail();
        }
      }
    }

    private void TractionControl()
    {
      switch (this.m_CarDriveType)
      {
        case CarDriveType.FrontWheelDrive:
          WheelHit hit1;
          this.m_WheelColliders[0].GetGroundHit(out hit1);
          this.AdjustTorque(hit1.forwardSlip);
          this.m_WheelColliders[1].GetGroundHit(out hit1);
          this.AdjustTorque(hit1.forwardSlip);
          break;
        case CarDriveType.RearWheelDrive:
          WheelHit hit2;
          this.m_WheelColliders[2].GetGroundHit(out hit2);
          this.AdjustTorque(hit2.forwardSlip);
          this.m_WheelColliders[3].GetGroundHit(out hit2);
          this.AdjustTorque(hit2.forwardSlip);
          break;
        case CarDriveType.FourWheelDrive:
          for (int index = 0; index < 4; ++index)
          {
            WheelHit hit3;
            this.m_WheelColliders[index].GetGroundHit(out hit3);
            this.AdjustTorque(hit3.forwardSlip);
          }
          break;
      }
    }

    private void AdjustTorque(float forwardSlip)
    {
      if ((double) forwardSlip >= (double) this.m_SlipLimit && (double) this.m_CurrentTorque >= 0.0)
      {
        this.m_CurrentTorque -= 10f * this.m_TractionControl;
      }
      else
      {
        this.m_CurrentTorque += 10f * this.m_TractionControl;
        if ((double) this.m_CurrentTorque <= (double) this.m_FullTorqueOverAllWheels)
          return;
        this.m_CurrentTorque = this.m_FullTorqueOverAllWheels;
      }
    }

    private bool AnySkidSoundPlaying()
    {
      for (int index = 0; index < 4; ++index)
      {
        if (this.m_WheelEffects[index].PlayingAudio)
          return true;
      }
      return false;
    }
  }
}
