using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	[RequireComponent(typeof(CarController))]
	public class CarAIControl : MonoBehaviour
	{
		public enum BrakeCondition
		{
			NeverBrake = 0,
			TargetDirectionDifference = 1,
			TargetDistance = 2
		}

		[SerializeField]
		[Range(0f, 1f)]
		private float m_CautiousSpeedFactor = 0.05f;

		[SerializeField]
		[Range(0f, 180f)]
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
		[Range(0f, 1f)]
		private float m_AccelWanderAmount = 0.1f;

		[SerializeField]
		private float m_AccelWanderSpeed = 0.1f;

		[SerializeField]
		private BrakeCondition m_BrakeCondition = BrakeCondition.TargetDistance;

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
			m_CarController = GetComponent<CarController>();
			m_RandomPerlin = Random.value * 100f;
			m_Rigidbody = GetComponent<Rigidbody>();
		}

		private void FixedUpdate()
		{
			if (m_Target == null || !m_Driving)
			{
				m_CarController.Move(0f, 0f, -1f, 1f);
				return;
			}
			Vector3 to = base.transform.forward;
			if (m_Rigidbody.linearVelocity.magnitude > m_CarController.MaxSpeed * 0.1f)
			{
				to = m_Rigidbody.linearVelocity;
			}
			float num = m_CarController.MaxSpeed;
			switch (m_BrakeCondition)
			{
			case BrakeCondition.TargetDirectionDifference:
			{
				float b2 = Vector3.Angle(m_Target.forward, to);
				float a = m_Rigidbody.angularVelocity.magnitude * m_CautiousAngularVelocityFactor;
				float t2 = Mathf.InverseLerp(0f, m_CautiousMaxAngle, Mathf.Max(a, b2));
				num = Mathf.Lerp(m_CarController.MaxSpeed, m_CarController.MaxSpeed * m_CautiousSpeedFactor, t2);
				break;
			}
			case BrakeCondition.TargetDistance:
			{
				Vector3 vector = m_Target.position - base.transform.position;
				float b = Mathf.InverseLerp(m_CautiousMaxDistance, 0f, vector.magnitude);
				float value = m_Rigidbody.angularVelocity.magnitude * m_CautiousAngularVelocityFactor;
				float t = Mathf.Max(Mathf.InverseLerp(0f, m_CautiousMaxAngle, value), b);
				num = Mathf.Lerp(m_CarController.MaxSpeed, m_CarController.MaxSpeed * m_CautiousSpeedFactor, t);
				break;
			}
			}
			Vector3 position = m_Target.position;
			if (Time.time < m_AvoidOtherCarTime)
			{
				num *= m_AvoidOtherCarSlowdown;
				position += m_Target.right * m_AvoidPathOffset;
			}
			else
			{
				position += m_Target.right * (Mathf.PerlinNoise(Time.time * m_LateralWanderSpeed, m_RandomPerlin) * 2f - 1f) * m_LateralWanderDistance;
			}
			float num2 = ((num < m_CarController.CurrentSpeed) ? m_BrakeSensitivity : m_AccelSensitivity);
			float num3 = Mathf.Clamp((num - m_CarController.CurrentSpeed) * num2, -1f, 1f);
			num3 *= 1f - m_AccelWanderAmount + Mathf.PerlinNoise(Time.time * m_AccelWanderSpeed, m_RandomPerlin) * m_AccelWanderAmount;
			Vector3 vector2 = base.transform.InverseTransformPoint(position);
			float steering = Mathf.Clamp(Mathf.Atan2(vector2.x, vector2.z) * 57.29578f * m_SteerSensitivity, -1f, 1f) * Mathf.Sign(m_CarController.CurrentSpeed);
			m_CarController.Move(steering, num3, num3, 0f);
			if (m_StopWhenTargetReached && vector2.magnitude < m_ReachTargetThreshold)
			{
				m_Driving = false;
			}
		}

		private void OnCollisionStay(Collision col)
		{
			if (!(col.rigidbody != null))
			{
				return;
			}
			CarAIControl component = col.rigidbody.GetComponent<CarAIControl>();
			if (component != null)
			{
				m_AvoidOtherCarTime = Time.time + 1f;
				if (Vector3.Angle(base.transform.forward, component.transform.position - base.transform.position) < 90f)
				{
					m_AvoidOtherCarSlowdown = 0.5f;
				}
				else
				{
					m_AvoidOtherCarSlowdown = 1f;
				}
				Vector3 vector = base.transform.InverseTransformPoint(component.transform.position);
				float f = Mathf.Atan2(vector.x, vector.z);
				m_AvoidPathOffset = m_LateralWanderDistance * (0f - Mathf.Sign(f));
			}
		}

		public void SetTarget(Transform target)
		{
			m_Target = target;
			m_Driving = true;
		}
	}
}
