using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x0200051D RID: 1309
	[RequireComponent(typeof(CarController))]
	public class CarAIControl : MonoBehaviour
	{
		// Token: 0x06002155 RID: 8533 RVA: 0x001E7E1A File Offset: 0x001E601A
		private void Awake()
		{
			this.m_CarController = base.GetComponent<CarController>();
			this.m_RandomPerlin = UnityEngine.Random.value * 100f;
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
		}

		// Token: 0x06002156 RID: 8534 RVA: 0x001E7E48 File Offset: 0x001E6048
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

		// Token: 0x06002157 RID: 8535 RVA: 0x001E8178 File Offset: 0x001E6378
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

		// Token: 0x06002158 RID: 8536 RVA: 0x001E8246 File Offset: 0x001E6446
		public void SetTarget(Transform target)
		{
			this.m_Target = target;
			this.m_Driving = true;
		}

		// Token: 0x04004928 RID: 18728
		[SerializeField]
		[Range(0f, 1f)]
		private float m_CautiousSpeedFactor = 0.05f;

		// Token: 0x04004929 RID: 18729
		[SerializeField]
		[Range(0f, 180f)]
		private float m_CautiousMaxAngle = 50f;

		// Token: 0x0400492A RID: 18730
		[SerializeField]
		private float m_CautiousMaxDistance = 100f;

		// Token: 0x0400492B RID: 18731
		[SerializeField]
		private float m_CautiousAngularVelocityFactor = 30f;

		// Token: 0x0400492C RID: 18732
		[SerializeField]
		private float m_SteerSensitivity = 0.05f;

		// Token: 0x0400492D RID: 18733
		[SerializeField]
		private float m_AccelSensitivity = 0.04f;

		// Token: 0x0400492E RID: 18734
		[SerializeField]
		private float m_BrakeSensitivity = 1f;

		// Token: 0x0400492F RID: 18735
		[SerializeField]
		private float m_LateralWanderDistance = 3f;

		// Token: 0x04004930 RID: 18736
		[SerializeField]
		private float m_LateralWanderSpeed = 0.1f;

		// Token: 0x04004931 RID: 18737
		[SerializeField]
		[Range(0f, 1f)]
		private float m_AccelWanderAmount = 0.1f;

		// Token: 0x04004932 RID: 18738
		[SerializeField]
		private float m_AccelWanderSpeed = 0.1f;

		// Token: 0x04004933 RID: 18739
		[SerializeField]
		private CarAIControl.BrakeCondition m_BrakeCondition = CarAIControl.BrakeCondition.TargetDistance;

		// Token: 0x04004934 RID: 18740
		[SerializeField]
		private bool m_Driving;

		// Token: 0x04004935 RID: 18741
		[SerializeField]
		private Transform m_Target;

		// Token: 0x04004936 RID: 18742
		[SerializeField]
		private bool m_StopWhenTargetReached;

		// Token: 0x04004937 RID: 18743
		[SerializeField]
		private float m_ReachTargetThreshold = 2f;

		// Token: 0x04004938 RID: 18744
		private float m_RandomPerlin;

		// Token: 0x04004939 RID: 18745
		private CarController m_CarController;

		// Token: 0x0400493A RID: 18746
		private float m_AvoidOtherCarTime;

		// Token: 0x0400493B RID: 18747
		private float m_AvoidOtherCarSlowdown;

		// Token: 0x0400493C RID: 18748
		private float m_AvoidPathOffset;

		// Token: 0x0400493D RID: 18749
		private Rigidbody m_Rigidbody;

		// Token: 0x0200067E RID: 1662
		public enum BrakeCondition
		{
			// Token: 0x04004FB5 RID: 20405
			NeverBrake,
			// Token: 0x04004FB6 RID: 20406
			TargetDirectionDifference,
			// Token: 0x04004FB7 RID: 20407
			TargetDistance
		}
	}
}
