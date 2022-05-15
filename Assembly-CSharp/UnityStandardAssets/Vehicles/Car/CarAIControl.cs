using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x0200052F RID: 1327
	[RequireComponent(typeof(CarController))]
	public class CarAIControl : MonoBehaviour
	{
		// Token: 0x060021CC RID: 8652 RVA: 0x001F2FEE File Offset: 0x001F11EE
		private void Awake()
		{
			this.m_CarController = base.GetComponent<CarController>();
			this.m_RandomPerlin = UnityEngine.Random.value * 100f;
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
		}

		// Token: 0x060021CD RID: 8653 RVA: 0x001F301C File Offset: 0x001F121C
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

		// Token: 0x060021CE RID: 8654 RVA: 0x001F334C File Offset: 0x001F154C
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

		// Token: 0x060021CF RID: 8655 RVA: 0x001F341A File Offset: 0x001F161A
		public void SetTarget(Transform target)
		{
			this.m_Target = target;
			this.m_Driving = true;
		}

		// Token: 0x04004A71 RID: 19057
		[SerializeField]
		[Range(0f, 1f)]
		private float m_CautiousSpeedFactor = 0.05f;

		// Token: 0x04004A72 RID: 19058
		[SerializeField]
		[Range(0f, 180f)]
		private float m_CautiousMaxAngle = 50f;

		// Token: 0x04004A73 RID: 19059
		[SerializeField]
		private float m_CautiousMaxDistance = 100f;

		// Token: 0x04004A74 RID: 19060
		[SerializeField]
		private float m_CautiousAngularVelocityFactor = 30f;

		// Token: 0x04004A75 RID: 19061
		[SerializeField]
		private float m_SteerSensitivity = 0.05f;

		// Token: 0x04004A76 RID: 19062
		[SerializeField]
		private float m_AccelSensitivity = 0.04f;

		// Token: 0x04004A77 RID: 19063
		[SerializeField]
		private float m_BrakeSensitivity = 1f;

		// Token: 0x04004A78 RID: 19064
		[SerializeField]
		private float m_LateralWanderDistance = 3f;

		// Token: 0x04004A79 RID: 19065
		[SerializeField]
		private float m_LateralWanderSpeed = 0.1f;

		// Token: 0x04004A7A RID: 19066
		[SerializeField]
		[Range(0f, 1f)]
		private float m_AccelWanderAmount = 0.1f;

		// Token: 0x04004A7B RID: 19067
		[SerializeField]
		private float m_AccelWanderSpeed = 0.1f;

		// Token: 0x04004A7C RID: 19068
		[SerializeField]
		private CarAIControl.BrakeCondition m_BrakeCondition = CarAIControl.BrakeCondition.TargetDistance;

		// Token: 0x04004A7D RID: 19069
		[SerializeField]
		private bool m_Driving;

		// Token: 0x04004A7E RID: 19070
		[SerializeField]
		private Transform m_Target;

		// Token: 0x04004A7F RID: 19071
		[SerializeField]
		private bool m_StopWhenTargetReached;

		// Token: 0x04004A80 RID: 19072
		[SerializeField]
		private float m_ReachTargetThreshold = 2f;

		// Token: 0x04004A81 RID: 19073
		private float m_RandomPerlin;

		// Token: 0x04004A82 RID: 19074
		private CarController m_CarController;

		// Token: 0x04004A83 RID: 19075
		private float m_AvoidOtherCarTime;

		// Token: 0x04004A84 RID: 19076
		private float m_AvoidOtherCarSlowdown;

		// Token: 0x04004A85 RID: 19077
		private float m_AvoidPathOffset;

		// Token: 0x04004A86 RID: 19078
		private Rigidbody m_Rigidbody;

		// Token: 0x0200068C RID: 1676
		public enum BrakeCondition
		{
			// Token: 0x040050DD RID: 20701
			NeverBrake,
			// Token: 0x040050DE RID: 20702
			TargetDirectionDifference,
			// Token: 0x040050DF RID: 20703
			TargetDistance
		}
	}
}
