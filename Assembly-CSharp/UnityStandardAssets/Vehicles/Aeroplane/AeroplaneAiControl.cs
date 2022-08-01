// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.Vehicles.Aeroplane.AeroplaneAiControl
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
  [RequireComponent(typeof (AeroplaneController))]
  public class AeroplaneAiControl : MonoBehaviour
  {
    [SerializeField]
    private float m_RollSensitivity = 0.2f;
    [SerializeField]
    private float m_PitchSensitivity = 0.5f;
    [SerializeField]
    private float m_LateralWanderDistance = 5f;
    [SerializeField]
    private float m_LateralWanderSpeed = 0.11f;
    [SerializeField]
    private float m_MaxClimbAngle = 45f;
    [SerializeField]
    private float m_MaxRollAngle = 45f;
    [SerializeField]
    private float m_SpeedEffect = 0.01f;
    [SerializeField]
    private float m_TakeoffHeight = 20f;
    [SerializeField]
    private Transform m_Target;
    private AeroplaneController m_AeroplaneController;
    private float m_RandomPerlin;
    private bool m_TakenOff;

    private void Awake()
    {
      this.m_AeroplaneController = this.GetComponent<AeroplaneController>();
      this.m_RandomPerlin = UnityEngine.Random.Range(0.0f, 100f);
    }

    public void Reset() => this.m_TakenOff = false;

    private void FixedUpdate()
    {
      if ((UnityEngine.Object) this.m_Target != (UnityEngine.Object) null)
      {
        Vector3 vector3 = this.transform.InverseTransformPoint(this.m_Target.position + this.transform.right * (float) ((double) Mathf.PerlinNoise(Time.time * this.m_LateralWanderSpeed, this.m_RandomPerlin) * 2.0 - 1.0) * this.m_LateralWanderDistance);
        float num1 = Mathf.Atan2(vector3.x, vector3.z);
        float num2 = (Mathf.Clamp(-Mathf.Atan2(vector3.y, vector3.z), (float) (-(double) this.m_MaxClimbAngle * (Math.PI / 180.0)), this.m_MaxClimbAngle * ((float) Math.PI / 180f)) - this.m_AeroplaneController.PitchAngle) * this.m_PitchSensitivity;
        float num3 = Mathf.Clamp(num1, (float) (-(double) this.m_MaxRollAngle * (Math.PI / 180.0)), this.m_MaxRollAngle * ((float) Math.PI / 180f));
        float num4 = 0.0f;
        float num5 = 0.0f;
        if (!this.m_TakenOff)
        {
          if ((double) this.m_AeroplaneController.Altitude > (double) this.m_TakeoffHeight)
            this.m_TakenOff = true;
        }
        else
        {
          num4 = num1;
          num5 = (float) -((double) this.m_AeroplaneController.RollAngle - (double) num3) * this.m_RollSensitivity;
        }
        float num6 = (float) (1.0 + (double) this.m_AeroplaneController.ForwardSpeed * (double) this.m_SpeedEffect);
        this.m_AeroplaneController.Move(num5 * num6, num2 * num6, num4 * num6, 0.5f, false);
      }
      else
        this.m_AeroplaneController.Move(0.0f, 0.0f, 0.0f, 0.0f, false);
    }

    public void SetTarget(Transform target) => this.m_Target = target;
  }
}
