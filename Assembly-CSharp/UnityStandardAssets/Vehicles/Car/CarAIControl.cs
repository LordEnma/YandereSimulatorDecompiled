using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x0200052D RID: 1325
	[RequireComponent(typeof(CarController))]
	public class CarAIControl : MonoBehaviour
	{
		// Token: 0x060021B1 RID: 8625 RVA: 0x001EF9BA File Offset: 0x001EDBBA
		private void Awake()
		{
			this.m_CarController = base.GetComponent<CarController>();
			this.m_RandomPerlin = UnityEngine.Random.value * 100f;
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
		}

		// Token: 0x060021B2 RID: 8626 RVA: 0x001EF9E8 File Offset: 0x001EDBE8
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

		// Token: 0x060021B3 RID: 8627 RVA: 0x001EFD18 File Offset: 0x001EDF18
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

		// Token: 0x060021B4 RID: 8628 RVA: 0x001EFDE6 File Offset: 0x001EDFE6
		public void SetTarget(Transform target)
		{
			this.m_Target = target;
			this.m_Driving = true;
		}

		// Token: 0x04004A22 RID: 18978
		[SerializeField]
		[Range(0f, 1f)]
		private float m_CautiousSpeedFactor = 0.05f;

		// Token: 0x04004A23 RID: 18979
		[SerializeField]
		[Range(0f, 180f)]
		private float m_CautiousMaxAngle = 50f;

		// Token: 0x04004A24 RID: 18980
		[SerializeField]
		private float m_CautiousMaxDistance = 100f;

		// Token: 0x04004A25 RID: 18981
		[SerializeField]
		private float m_CautiousAngularVelocityFactor = 30f;

		// Token: 0x04004A26 RID: 18982
		[SerializeField]
		private float m_SteerSensitivity = 0.05f;

		// Token: 0x04004A27 RID: 18983
		[SerializeField]
		private float m_AccelSensitivity = 0.04f;

		// Token: 0x04004A28 RID: 18984
		[SerializeField]
		private float m_BrakeSensitivity = 1f;

		// Token: 0x04004A29 RID: 18985
		[SerializeField]
		private float m_LateralWanderDistance = 3f;

		// Token: 0x04004A2A RID: 18986
		[SerializeField]
		private float m_LateralWanderSpeed = 0.1f;

		// Token: 0x04004A2B RID: 18987
		[SerializeField]
		[Range(0f, 1f)]
		private float m_AccelWanderAmount = 0.1f;

		// Token: 0x04004A2C RID: 18988
		[SerializeField]
		private float m_AccelWanderSpeed = 0.1f;

		// Token: 0x04004A2D RID: 18989
		[SerializeField]
		private CarAIControl.BrakeCondition m_BrakeCondition = CarAIControl.BrakeCondition.TargetDistance;

		// Token: 0x04004A2E RID: 18990
		[SerializeField]
		private bool m_Driving;

		// Token: 0x04004A2F RID: 18991
		[SerializeField]
		private Transform m_Target;

		// Token: 0x04004A30 RID: 18992
		[SerializeField]
		private bool m_StopWhenTargetReached;

		// Token: 0x04004A31 RID: 18993
		[SerializeField]
		private float m_ReachTargetThreshold = 2f;

		// Token: 0x04004A32 RID: 18994
		private float m_RandomPerlin;

		// Token: 0x04004A33 RID: 18995
		private CarController m_CarController;

		// Token: 0x04004A34 RID: 18996
		private float m_AvoidOtherCarTime;

		// Token: 0x04004A35 RID: 18997
		private float m_AvoidOtherCarSlowdown;

		// Token: 0x04004A36 RID: 18998
		private float m_AvoidPathOffset;

		// Token: 0x04004A37 RID: 18999
		private Rigidbody m_Rigidbody;

		// Token: 0x0200068A RID: 1674
		public enum BrakeCondition
		{
			// Token: 0x04005086 RID: 20614
			NeverBrake,
			// Token: 0x04005087 RID: 20615
			TargetDirectionDifference,
			// Token: 0x04005088 RID: 20616
			TargetDistance
		}
	}
}
