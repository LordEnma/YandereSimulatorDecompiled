using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000522 RID: 1314
	[RequireComponent(typeof(CarController))]
	public class CarAIControl : MonoBehaviour
	{
		// Token: 0x0600217B RID: 8571 RVA: 0x001EB2DA File Offset: 0x001E94DA
		private void Awake()
		{
			this.m_CarController = base.GetComponent<CarController>();
			this.m_RandomPerlin = UnityEngine.Random.value * 100f;
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
		}

		// Token: 0x0600217C RID: 8572 RVA: 0x001EB308 File Offset: 0x001E9508
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

		// Token: 0x0600217D RID: 8573 RVA: 0x001EB638 File Offset: 0x001E9838
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

		// Token: 0x0600217E RID: 8574 RVA: 0x001EB706 File Offset: 0x001E9906
		public void SetTarget(Transform target)
		{
			this.m_Target = target;
			this.m_Driving = true;
		}

		// Token: 0x04004970 RID: 18800
		[SerializeField]
		[Range(0f, 1f)]
		private float m_CautiousSpeedFactor = 0.05f;

		// Token: 0x04004971 RID: 18801
		[SerializeField]
		[Range(0f, 180f)]
		private float m_CautiousMaxAngle = 50f;

		// Token: 0x04004972 RID: 18802
		[SerializeField]
		private float m_CautiousMaxDistance = 100f;

		// Token: 0x04004973 RID: 18803
		[SerializeField]
		private float m_CautiousAngularVelocityFactor = 30f;

		// Token: 0x04004974 RID: 18804
		[SerializeField]
		private float m_SteerSensitivity = 0.05f;

		// Token: 0x04004975 RID: 18805
		[SerializeField]
		private float m_AccelSensitivity = 0.04f;

		// Token: 0x04004976 RID: 18806
		[SerializeField]
		private float m_BrakeSensitivity = 1f;

		// Token: 0x04004977 RID: 18807
		[SerializeField]
		private float m_LateralWanderDistance = 3f;

		// Token: 0x04004978 RID: 18808
		[SerializeField]
		private float m_LateralWanderSpeed = 0.1f;

		// Token: 0x04004979 RID: 18809
		[SerializeField]
		[Range(0f, 1f)]
		private float m_AccelWanderAmount = 0.1f;

		// Token: 0x0400497A RID: 18810
		[SerializeField]
		private float m_AccelWanderSpeed = 0.1f;

		// Token: 0x0400497B RID: 18811
		[SerializeField]
		private CarAIControl.BrakeCondition m_BrakeCondition = CarAIControl.BrakeCondition.TargetDistance;

		// Token: 0x0400497C RID: 18812
		[SerializeField]
		private bool m_Driving;

		// Token: 0x0400497D RID: 18813
		[SerializeField]
		private Transform m_Target;

		// Token: 0x0400497E RID: 18814
		[SerializeField]
		private bool m_StopWhenTargetReached;

		// Token: 0x0400497F RID: 18815
		[SerializeField]
		private float m_ReachTargetThreshold = 2f;

		// Token: 0x04004980 RID: 18816
		private float m_RandomPerlin;

		// Token: 0x04004981 RID: 18817
		private CarController m_CarController;

		// Token: 0x04004982 RID: 18818
		private float m_AvoidOtherCarTime;

		// Token: 0x04004983 RID: 18819
		private float m_AvoidOtherCarSlowdown;

		// Token: 0x04004984 RID: 18820
		private float m_AvoidPathOffset;

		// Token: 0x04004985 RID: 18821
		private Rigidbody m_Rigidbody;

		// Token: 0x0200067F RID: 1663
		public enum BrakeCondition
		{
			// Token: 0x04004FD4 RID: 20436
			NeverBrake,
			// Token: 0x04004FD5 RID: 20437
			TargetDirectionDifference,
			// Token: 0x04004FD6 RID: 20438
			TargetDistance
		}
	}
}
