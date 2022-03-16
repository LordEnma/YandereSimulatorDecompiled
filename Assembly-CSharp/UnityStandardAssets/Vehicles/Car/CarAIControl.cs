using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000527 RID: 1319
	[RequireComponent(typeof(CarController))]
	public class CarAIControl : MonoBehaviour
	{
		// Token: 0x06002199 RID: 8601 RVA: 0x001EDC1A File Offset: 0x001EBE1A
		private void Awake()
		{
			this.m_CarController = base.GetComponent<CarController>();
			this.m_RandomPerlin = UnityEngine.Random.value * 100f;
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
		}

		// Token: 0x0600219A RID: 8602 RVA: 0x001EDC48 File Offset: 0x001EBE48
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

		// Token: 0x0600219B RID: 8603 RVA: 0x001EDF78 File Offset: 0x001EC178
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

		// Token: 0x0600219C RID: 8604 RVA: 0x001EE046 File Offset: 0x001EC246
		public void SetTarget(Transform target)
		{
			this.m_Target = target;
			this.m_Driving = true;
		}

		// Token: 0x040049EC RID: 18924
		[SerializeField]
		[Range(0f, 1f)]
		private float m_CautiousSpeedFactor = 0.05f;

		// Token: 0x040049ED RID: 18925
		[SerializeField]
		[Range(0f, 180f)]
		private float m_CautiousMaxAngle = 50f;

		// Token: 0x040049EE RID: 18926
		[SerializeField]
		private float m_CautiousMaxDistance = 100f;

		// Token: 0x040049EF RID: 18927
		[SerializeField]
		private float m_CautiousAngularVelocityFactor = 30f;

		// Token: 0x040049F0 RID: 18928
		[SerializeField]
		private float m_SteerSensitivity = 0.05f;

		// Token: 0x040049F1 RID: 18929
		[SerializeField]
		private float m_AccelSensitivity = 0.04f;

		// Token: 0x040049F2 RID: 18930
		[SerializeField]
		private float m_BrakeSensitivity = 1f;

		// Token: 0x040049F3 RID: 18931
		[SerializeField]
		private float m_LateralWanderDistance = 3f;

		// Token: 0x040049F4 RID: 18932
		[SerializeField]
		private float m_LateralWanderSpeed = 0.1f;

		// Token: 0x040049F5 RID: 18933
		[SerializeField]
		[Range(0f, 1f)]
		private float m_AccelWanderAmount = 0.1f;

		// Token: 0x040049F6 RID: 18934
		[SerializeField]
		private float m_AccelWanderSpeed = 0.1f;

		// Token: 0x040049F7 RID: 18935
		[SerializeField]
		private CarAIControl.BrakeCondition m_BrakeCondition = CarAIControl.BrakeCondition.TargetDistance;

		// Token: 0x040049F8 RID: 18936
		[SerializeField]
		private bool m_Driving;

		// Token: 0x040049F9 RID: 18937
		[SerializeField]
		private Transform m_Target;

		// Token: 0x040049FA RID: 18938
		[SerializeField]
		private bool m_StopWhenTargetReached;

		// Token: 0x040049FB RID: 18939
		[SerializeField]
		private float m_ReachTargetThreshold = 2f;

		// Token: 0x040049FC RID: 18940
		private float m_RandomPerlin;

		// Token: 0x040049FD RID: 18941
		private CarController m_CarController;

		// Token: 0x040049FE RID: 18942
		private float m_AvoidOtherCarTime;

		// Token: 0x040049FF RID: 18943
		private float m_AvoidOtherCarSlowdown;

		// Token: 0x04004A00 RID: 18944
		private float m_AvoidPathOffset;

		// Token: 0x04004A01 RID: 18945
		private Rigidbody m_Rigidbody;

		// Token: 0x02000684 RID: 1668
		public enum BrakeCondition
		{
			// Token: 0x04005050 RID: 20560
			NeverBrake,
			// Token: 0x04005051 RID: 20561
			TargetDirectionDifference,
			// Token: 0x04005052 RID: 20562
			TargetDistance
		}
	}
}
