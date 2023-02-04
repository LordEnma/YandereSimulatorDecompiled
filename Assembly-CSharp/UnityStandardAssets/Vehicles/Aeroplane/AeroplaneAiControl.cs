using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	[RequireComponent(typeof(AeroplaneController))]
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
			m_AeroplaneController = GetComponent<AeroplaneController>();
			m_RandomPerlin = UnityEngine.Random.Range(0f, 100f);
		}

		public void Reset()
		{
			m_TakenOff = false;
		}

		private void FixedUpdate()
		{
			if (m_Target != null)
			{
				Vector3 position = m_Target.position + base.transform.right * (Mathf.PerlinNoise(Time.time * m_LateralWanderSpeed, m_RandomPerlin) * 2f - 1f) * m_LateralWanderDistance;
				Vector3 vector = base.transform.InverseTransformPoint(position);
				float num = Mathf.Atan2(vector.x, vector.z);
				float num2 = (Mathf.Clamp(0f - Mathf.Atan2(vector.y, vector.z), (0f - m_MaxClimbAngle) * ((float)Math.PI / 180f), m_MaxClimbAngle * ((float)Math.PI / 180f)) - m_AeroplaneController.PitchAngle) * m_PitchSensitivity;
				float num3 = Mathf.Clamp(num, (0f - m_MaxRollAngle) * ((float)Math.PI / 180f), m_MaxRollAngle * ((float)Math.PI / 180f));
				float num4 = 0f;
				float num5 = 0f;
				if (!m_TakenOff)
				{
					if (m_AeroplaneController.Altitude > m_TakeoffHeight)
					{
						m_TakenOff = true;
					}
				}
				else
				{
					num4 = num;
					num5 = (0f - (m_AeroplaneController.RollAngle - num3)) * m_RollSensitivity;
				}
				float num6 = 1f + m_AeroplaneController.ForwardSpeed * m_SpeedEffect;
				num5 *= num6;
				num2 *= num6;
				num4 *= num6;
				m_AeroplaneController.Move(num5, num2, num4, 0.5f, airBrakes: false);
			}
			else
			{
				m_AeroplaneController.Move(0f, 0f, 0f, 0f, airBrakes: false);
			}
		}

		public void SetTarget(Transform target)
		{
			m_Target = target;
		}
	}
}
