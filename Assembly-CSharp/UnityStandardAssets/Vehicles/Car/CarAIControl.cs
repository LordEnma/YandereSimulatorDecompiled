using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x0200052D RID: 1325
	[RequireComponent(typeof(CarController))]
	public class CarAIControl : MonoBehaviour
	{
		// Token: 0x060021B8 RID: 8632 RVA: 0x001F0416 File Offset: 0x001EE616
		private void Awake()
		{
			this.m_CarController = base.GetComponent<CarController>();
			this.m_RandomPerlin = UnityEngine.Random.value * 100f;
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
		}

		// Token: 0x060021B9 RID: 8633 RVA: 0x001F0444 File Offset: 0x001EE644
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

		// Token: 0x060021BA RID: 8634 RVA: 0x001F0774 File Offset: 0x001EE974
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

		// Token: 0x060021BB RID: 8635 RVA: 0x001F0842 File Offset: 0x001EEA42
		public void SetTarget(Transform target)
		{
			this.m_Target = target;
			this.m_Driving = true;
		}

		// Token: 0x04004A34 RID: 18996
		[SerializeField]
		[Range(0f, 1f)]
		private float m_CautiousSpeedFactor = 0.05f;

		// Token: 0x04004A35 RID: 18997
		[SerializeField]
		[Range(0f, 180f)]
		private float m_CautiousMaxAngle = 50f;

		// Token: 0x04004A36 RID: 18998
		[SerializeField]
		private float m_CautiousMaxDistance = 100f;

		// Token: 0x04004A37 RID: 18999
		[SerializeField]
		private float m_CautiousAngularVelocityFactor = 30f;

		// Token: 0x04004A38 RID: 19000
		[SerializeField]
		private float m_SteerSensitivity = 0.05f;

		// Token: 0x04004A39 RID: 19001
		[SerializeField]
		private float m_AccelSensitivity = 0.04f;

		// Token: 0x04004A3A RID: 19002
		[SerializeField]
		private float m_BrakeSensitivity = 1f;

		// Token: 0x04004A3B RID: 19003
		[SerializeField]
		private float m_LateralWanderDistance = 3f;

		// Token: 0x04004A3C RID: 19004
		[SerializeField]
		private float m_LateralWanderSpeed = 0.1f;

		// Token: 0x04004A3D RID: 19005
		[SerializeField]
		[Range(0f, 1f)]
		private float m_AccelWanderAmount = 0.1f;

		// Token: 0x04004A3E RID: 19006
		[SerializeField]
		private float m_AccelWanderSpeed = 0.1f;

		// Token: 0x04004A3F RID: 19007
		[SerializeField]
		private CarAIControl.BrakeCondition m_BrakeCondition = CarAIControl.BrakeCondition.TargetDistance;

		// Token: 0x04004A40 RID: 19008
		[SerializeField]
		private bool m_Driving;

		// Token: 0x04004A41 RID: 19009
		[SerializeField]
		private Transform m_Target;

		// Token: 0x04004A42 RID: 19010
		[SerializeField]
		private bool m_StopWhenTargetReached;

		// Token: 0x04004A43 RID: 19011
		[SerializeField]
		private float m_ReachTargetThreshold = 2f;

		// Token: 0x04004A44 RID: 19012
		private float m_RandomPerlin;

		// Token: 0x04004A45 RID: 19013
		private CarController m_CarController;

		// Token: 0x04004A46 RID: 19014
		private float m_AvoidOtherCarTime;

		// Token: 0x04004A47 RID: 19015
		private float m_AvoidOtherCarSlowdown;

		// Token: 0x04004A48 RID: 19016
		private float m_AvoidPathOffset;

		// Token: 0x04004A49 RID: 19017
		private Rigidbody m_Rigidbody;

		// Token: 0x0200068A RID: 1674
		public enum BrakeCondition
		{
			// Token: 0x04005098 RID: 20632
			NeverBrake,
			// Token: 0x04005099 RID: 20633
			TargetDirectionDifference,
			// Token: 0x0400509A RID: 20634
			TargetDistance
		}
	}
}
