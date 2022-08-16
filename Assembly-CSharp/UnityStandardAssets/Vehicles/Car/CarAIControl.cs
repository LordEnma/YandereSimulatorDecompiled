// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.Vehicles.Car.CarAIControl
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
  [RequireComponent(typeof (CarController))]
  public class CarAIControl : MonoBehaviour
  {
    [SerializeField]
    [Range(0.0f, 1f)]
    private float m_CautiousSpeedFactor = 0.05f;
    [SerializeField]
    [Range(0.0f, 180f)]
    private float m_CautiousMaxAngle = 50f;
    [SerializeField]
    private float m_CautiousMaxDistance = 100f;
    [SerializeField]
    private float m_CautiousAngularVelocityFactor = 30f;
    [SerializeField]
    private float m_SteerSensitivity = 0.05f;
    [SerializeField]
    private float m_AccelSensitivity = 0.04f;
    [SerializeField]
    private float m_BrakeSensitivity = 1f;
    [SerializeField]
    private float m_LateralWanderDistance = 3f;
    [SerializeField]
    private float m_LateralWanderSpeed = 0.1f;
    [SerializeField]
    [Range(0.0f, 1f)]
    private float m_AccelWanderAmount = 0.1f;
    [SerializeField]
    private float m_AccelWanderSpeed = 0.1f;
    [SerializeField]
    private CarAIControl.BrakeCondition m_BrakeCondition = CarAIControl.BrakeCondition.TargetDistance;
    [SerializeField]
    private bool m_Driving;
    [SerializeField]
    private Transform m_Target;
    [SerializeField]
    private bool m_StopWhenTargetReached;
    [SerializeField]
    private float m_ReachTargetThreshold = 2f;
    private float m_RandomPerlin;
    private CarController m_CarController;
    private float m_AvoidOtherCarTime;
    private float m_AvoidOtherCarSlowdown;
    private float m_AvoidPathOffset;
    private Rigidbody m_Rigidbody;

    private void Awake()
    {
      this.m_CarController = this.GetComponent<CarController>();
      this.m_RandomPerlin = Random.value * 100f;
      this.m_Rigidbody = this.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
      if ((Object) this.m_Target == (Object) null || !this.m_Driving)
      {
        this.m_CarController.Move(0.0f, 0.0f, -1f, 1f);
      }
      else
      {
        Vector3 to = this.transform.forward;
        if ((double) this.m_Rigidbody.velocity.magnitude > (double) this.m_CarController.MaxSpeed * 0.10000000149011612)
          to = this.m_Rigidbody.velocity;
        float num1 = this.m_CarController.MaxSpeed;
        switch (this.m_BrakeCondition)
        {
          case CarAIControl.BrakeCondition.TargetDirectionDifference:
            num1 = Mathf.Lerp(this.m_CarController.MaxSpeed, this.m_CarController.MaxSpeed * this.m_CautiousSpeedFactor, Mathf.InverseLerp(0.0f, this.m_CautiousMaxAngle, Mathf.Max(this.m_Rigidbody.angularVelocity.magnitude * this.m_CautiousAngularVelocityFactor, Vector3.Angle(this.m_Target.forward, to))));
            break;
          case CarAIControl.BrakeCondition.TargetDistance:
            float b = Mathf.InverseLerp(this.m_CautiousMaxDistance, 0.0f, (this.m_Target.position - this.transform.position).magnitude);
            num1 = Mathf.Lerp(this.m_CarController.MaxSpeed, this.m_CarController.MaxSpeed * this.m_CautiousSpeedFactor, Mathf.Max(Mathf.InverseLerp(0.0f, this.m_CautiousMaxAngle, this.m_Rigidbody.angularVelocity.magnitude * this.m_CautiousAngularVelocityFactor), b));
            break;
        }
        Vector3 position1 = this.m_Target.position;
        Vector3 position2;
        if ((double) Time.time < (double) this.m_AvoidOtherCarTime)
        {
          num1 *= this.m_AvoidOtherCarSlowdown;
          position2 = position1 + this.m_Target.right * this.m_AvoidPathOffset;
        }
        else
          position2 = position1 + this.m_Target.right * (float) ((double) Mathf.PerlinNoise(Time.time * this.m_LateralWanderSpeed, this.m_RandomPerlin) * 2.0 - 1.0) * this.m_LateralWanderDistance;
        float num2 = (double) num1 < (double) this.m_CarController.CurrentSpeed ? this.m_BrakeSensitivity : this.m_AccelSensitivity;
        float num3 = Mathf.Clamp((num1 - this.m_CarController.CurrentSpeed) * num2, -1f, 1f) * (float) (1.0 - (double) this.m_AccelWanderAmount + (double) Mathf.PerlinNoise(Time.time * this.m_AccelWanderSpeed, this.m_RandomPerlin) * (double) this.m_AccelWanderAmount);
        Vector3 vector3 = this.transform.InverseTransformPoint(position2);
        this.m_CarController.Move(Mathf.Clamp(Mathf.Atan2(vector3.x, vector3.z) * 57.29578f * this.m_SteerSensitivity, -1f, 1f) * Mathf.Sign(this.m_CarController.CurrentSpeed), num3, num3, 0.0f);
        if (!this.m_StopWhenTargetReached || (double) vector3.magnitude >= (double) this.m_ReachTargetThreshold)
          return;
        this.m_Driving = false;
      }
    }

    private void OnCollisionStay(Collision col)
    {
      if (!((Object) col.rigidbody != (Object) null))
        return;
      CarAIControl component = col.rigidbody.GetComponent<CarAIControl>();
      if (!((Object) component != (Object) null))
        return;
      this.m_AvoidOtherCarTime = Time.time + 1f;
      this.m_AvoidOtherCarSlowdown = (double) Vector3.Angle(this.transform.forward, component.transform.position - this.transform.position) >= 90.0 ? 1f : 0.5f;
      Vector3 vector3 = this.transform.InverseTransformPoint(component.transform.position);
      this.m_AvoidPathOffset = this.m_LateralWanderDistance * -Mathf.Sign(Mathf.Atan2(vector3.x, vector3.z));
    }

    public void SetTarget(Transform target)
    {
      this.m_Target = target;
      this.m_Driving = true;
    }

    public enum BrakeCondition
    {
      NeverBrake,
      TargetDirectionDifference,
      TargetDistance,
    }
  }
}
