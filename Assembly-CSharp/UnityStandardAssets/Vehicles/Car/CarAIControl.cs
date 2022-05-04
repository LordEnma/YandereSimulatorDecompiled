using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x0200052E RID: 1326
	[RequireComponent(typeof(CarController))]
	public class CarAIControl : MonoBehaviour
	{
		// Token: 0x060021C2 RID: 8642 RVA: 0x001F199E File Offset: 0x001EFB9E
		private void Awake()
		{
			this.m_CarController = base.GetComponent<CarController>();
			this.m_RandomPerlin = UnityEngine.Random.value * 100f;
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
		}

		// Token: 0x060021C3 RID: 8643 RVA: 0x001F19CC File Offset: 0x001EFBCC
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

		// Token: 0x060021C4 RID: 8644 RVA: 0x001F1CFC File Offset: 0x001EFEFC
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

		// Token: 0x060021C5 RID: 8645 RVA: 0x001F1DCA File Offset: 0x001EFFCA
		public void SetTarget(Transform target)
		{
			this.m_Target = target;
			this.m_Driving = true;
		}

		// Token: 0x04004A4A RID: 19018
		[SerializeField]
		[Range(0f, 1f)]
		private float m_CautiousSpeedFactor = 0.05f;

		// Token: 0x04004A4B RID: 19019
		[SerializeField]
		[Range(0f, 180f)]
		private float m_CautiousMaxAngle = 50f;

		// Token: 0x04004A4C RID: 19020
		[SerializeField]
		private float m_CautiousMaxDistance = 100f;

		// Token: 0x04004A4D RID: 19021
		[SerializeField]
		private float m_CautiousAngularVelocityFactor = 30f;

		// Token: 0x04004A4E RID: 19022
		[SerializeField]
		private float m_SteerSensitivity = 0.05f;

		// Token: 0x04004A4F RID: 19023
		[SerializeField]
		private float m_AccelSensitivity = 0.04f;

		// Token: 0x04004A50 RID: 19024
		[SerializeField]
		private float m_BrakeSensitivity = 1f;

		// Token: 0x04004A51 RID: 19025
		[SerializeField]
		private float m_LateralWanderDistance = 3f;

		// Token: 0x04004A52 RID: 19026
		[SerializeField]
		private float m_LateralWanderSpeed = 0.1f;

		// Token: 0x04004A53 RID: 19027
		[SerializeField]
		[Range(0f, 1f)]
		private float m_AccelWanderAmount = 0.1f;

		// Token: 0x04004A54 RID: 19028
		[SerializeField]
		private float m_AccelWanderSpeed = 0.1f;

		// Token: 0x04004A55 RID: 19029
		[SerializeField]
		private CarAIControl.BrakeCondition m_BrakeCondition = CarAIControl.BrakeCondition.TargetDistance;

		// Token: 0x04004A56 RID: 19030
		[SerializeField]
		private bool m_Driving;

		// Token: 0x04004A57 RID: 19031
		[SerializeField]
		private Transform m_Target;

		// Token: 0x04004A58 RID: 19032
		[SerializeField]
		private bool m_StopWhenTargetReached;

		// Token: 0x04004A59 RID: 19033
		[SerializeField]
		private float m_ReachTargetThreshold = 2f;

		// Token: 0x04004A5A RID: 19034
		private float m_RandomPerlin;

		// Token: 0x04004A5B RID: 19035
		private CarController m_CarController;

		// Token: 0x04004A5C RID: 19036
		private float m_AvoidOtherCarTime;

		// Token: 0x04004A5D RID: 19037
		private float m_AvoidOtherCarSlowdown;

		// Token: 0x04004A5E RID: 19038
		private float m_AvoidPathOffset;

		// Token: 0x04004A5F RID: 19039
		private Rigidbody m_Rigidbody;

		// Token: 0x0200068B RID: 1675
		public enum BrakeCondition
		{
			// Token: 0x040050B6 RID: 20662
			NeverBrake,
			// Token: 0x040050B7 RID: 20663
			TargetDirectionDifference,
			// Token: 0x040050B8 RID: 20664
			TargetDistance
		}
	}
}
