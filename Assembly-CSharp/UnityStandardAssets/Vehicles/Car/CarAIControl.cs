using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000521 RID: 1313
	[RequireComponent(typeof(CarController))]
	public class CarAIControl : MonoBehaviour
	{
		// Token: 0x06002172 RID: 8562 RVA: 0x001EA6FA File Offset: 0x001E88FA
		private void Awake()
		{
			this.m_CarController = base.GetComponent<CarController>();
			this.m_RandomPerlin = UnityEngine.Random.value * 100f;
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
		}

		// Token: 0x06002173 RID: 8563 RVA: 0x001EA728 File Offset: 0x001E8928
		private void FixedUpdate()
		{
			if (this.m_Target == null || !this.m_Driving)
			{
				this.m_CarController.Move(0f, 0f, -1f, 1f);
				return;
			}
			Vector3 to = base.transform.forward;
			if (this.m_Rigidbody.velocity.magnitude > this.m_CarController.MaxSpeed * 0.1f)
			{
				to = this.m_Rigidbody.velocity;
			}
			float num = this.m_CarController.MaxSpeed;
			switch (this.m_BrakeCondition)
			{
			case CarAIControl.BrakeCondition.TargetDirectionDifference:
			{
				float b = Vector3.Angle(this.m_Target.forward, to);
				float a = this.m_Rigidbody.angularVelocity.magnitude * this.m_CautiousAngularVelocityFactor;
				float t = Mathf.InverseLerp(0f, this.m_CautiousMaxAngle, Mathf.Max(a, b));
				num = Mathf.Lerp(this.m_CarController.MaxSpeed, this.m_CarController.MaxSpeed * this.m_CautiousSpeedFactor, t);
				break;
			}
			case CarAIControl.BrakeCondition.TargetDistance:
			{
				Vector3 vector = this.m_Target.position - base.transform.position;
				float b2 = Mathf.InverseLerp(this.m_CautiousMaxDistance, 0f, vector.magnitude);
				float value = this.m_Rigidbody.angularVelocity.magnitude * this.m_CautiousAngularVelocityFactor;
				float t2 = Mathf.Max(Mathf.InverseLerp(0f, this.m_CautiousMaxAngle, value), b2);
				num = Mathf.Lerp(this.m_CarController.MaxSpeed, this.m_CarController.MaxSpeed * this.m_CautiousSpeedFactor, t2);
				break;
			}
			}
			Vector3 vector2 = this.m_Target.position;
			if (Time.time < this.m_AvoidOtherCarTime)
			{
				num *= this.m_AvoidOtherCarSlowdown;
				vector2 += this.m_Target.right * this.m_AvoidPathOffset;
			}
			else
			{
				vector2 += this.m_Target.right * (Mathf.PerlinNoise(Time.time * this.m_LateralWanderSpeed, this.m_RandomPerlin) * 2f - 1f) * this.m_LateralWanderDistance;
			}
			float num2 = (num < this.m_CarController.CurrentSpeed) ? this.m_BrakeSensitivity : this.m_AccelSensitivity;
			float num3 = Mathf.Clamp((num - this.m_CarController.CurrentSpeed) * num2, -1f, 1f);
			num3 *= 1f - this.m_AccelWanderAmount + Mathf.PerlinNoise(Time.time * this.m_AccelWanderSpeed, this.m_RandomPerlin) * this.m_AccelWanderAmount;
			Vector3 vector3 = base.transform.InverseTransformPoint(vector2);
			float steering = Mathf.Clamp(Mathf.Atan2(vector3.x, vector3.z) * 57.29578f * this.m_SteerSensitivity, -1f, 1f) * Mathf.Sign(this.m_CarController.CurrentSpeed);
			this.m_CarController.Move(steering, num3, num3, 0f);
			if (this.m_StopWhenTargetReached && vector3.magnitude < this.m_ReachTargetThreshold)
			{
				this.m_Driving = false;
			}
		}

		// Token: 0x06002174 RID: 8564 RVA: 0x001EAA58 File Offset: 0x001E8C58
		private void OnCollisionStay(Collision col)
		{
			if (col.rigidbody != null)
			{
				CarAIControl component = col.rigidbody.GetComponent<CarAIControl>();
				if (component != null)
				{
					this.m_AvoidOtherCarTime = Time.time + 1f;
					if (Vector3.Angle(base.transform.forward, component.transform.position - base.transform.position) < 90f)
					{
						this.m_AvoidOtherCarSlowdown = 0.5f;
					}
					else
					{
						this.m_AvoidOtherCarSlowdown = 1f;
					}
					Vector3 vector = base.transform.InverseTransformPoint(component.transform.position);
					float f = Mathf.Atan2(vector.x, vector.z);
					this.m_AvoidPathOffset = this.m_LateralWanderDistance * -Mathf.Sign(f);
				}
			}
		}

		// Token: 0x06002175 RID: 8565 RVA: 0x001EAB26 File Offset: 0x001E8D26
		public void SetTarget(Transform target)
		{
			this.m_Target = target;
			this.m_Driving = true;
		}

		// Token: 0x04004960 RID: 18784
		[SerializeField]
		[Range(0f, 1f)]
		private float m_CautiousSpeedFactor = 0.05f;

		// Token: 0x04004961 RID: 18785
		[SerializeField]
		[Range(0f, 180f)]
		private float m_CautiousMaxAngle = 50f;

		// Token: 0x04004962 RID: 18786
		[SerializeField]
		private float m_CautiousMaxDistance = 100f;

		// Token: 0x04004963 RID: 18787
		[SerializeField]
		private float m_CautiousAngularVelocityFactor = 30f;

		// Token: 0x04004964 RID: 18788
		[SerializeField]
		private float m_SteerSensitivity = 0.05f;

		// Token: 0x04004965 RID: 18789
		[SerializeField]
		private float m_AccelSensitivity = 0.04f;

		// Token: 0x04004966 RID: 18790
		[SerializeField]
		private float m_BrakeSensitivity = 1f;

		// Token: 0x04004967 RID: 18791
		[SerializeField]
		private float m_LateralWanderDistance = 3f;

		// Token: 0x04004968 RID: 18792
		[SerializeField]
		private float m_LateralWanderSpeed = 0.1f;

		// Token: 0x04004969 RID: 18793
		[SerializeField]
		[Range(0f, 1f)]
		private float m_AccelWanderAmount = 0.1f;

		// Token: 0x0400496A RID: 18794
		[SerializeField]
		private float m_AccelWanderSpeed = 0.1f;

		// Token: 0x0400496B RID: 18795
		[SerializeField]
		private CarAIControl.BrakeCondition m_BrakeCondition = CarAIControl.BrakeCondition.TargetDistance;

		// Token: 0x0400496C RID: 18796
		[SerializeField]
		private bool m_Driving;

		// Token: 0x0400496D RID: 18797
		[SerializeField]
		private Transform m_Target;

		// Token: 0x0400496E RID: 18798
		[SerializeField]
		private bool m_StopWhenTargetReached;

		// Token: 0x0400496F RID: 18799
		[SerializeField]
		private float m_ReachTargetThreshold = 2f;

		// Token: 0x04004970 RID: 18800
		private float m_RandomPerlin;

		// Token: 0x04004971 RID: 18801
		private CarController m_CarController;

		// Token: 0x04004972 RID: 18802
		private float m_AvoidOtherCarTime;

		// Token: 0x04004973 RID: 18803
		private float m_AvoidOtherCarSlowdown;

		// Token: 0x04004974 RID: 18804
		private float m_AvoidPathOffset;

		// Token: 0x04004975 RID: 18805
		private Rigidbody m_Rigidbody;

		// Token: 0x0200067C RID: 1660
		public enum BrakeCondition
		{
			// Token: 0x04004FBF RID: 20415
			NeverBrake,
			// Token: 0x04004FC0 RID: 20416
			TargetDirectionDifference,
			// Token: 0x04004FC1 RID: 20417
			TargetDistance
		}
	}
}
