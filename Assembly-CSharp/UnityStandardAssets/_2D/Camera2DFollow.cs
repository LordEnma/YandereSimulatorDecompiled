using UnityEngine;

namespace UnityStandardAssets._2D
{
	public class Camera2DFollow : MonoBehaviour
	{
		public Transform target;

		public float damping = 1f;

		public float lookAheadFactor = 3f;

		public float lookAheadReturnSpeed = 0.5f;

		public float lookAheadMoveThreshold = 0.1f;

		private float m_OffsetZ;

		private Vector3 m_LastTargetPosition;

		private Vector3 m_CurrentVelocity;

		private Vector3 m_LookAheadPos;

		private void Start()
		{
			m_LastTargetPosition = target.position;
			m_OffsetZ = (base.transform.position - target.position).z;
			base.transform.parent = null;
		}

		private void Update()
		{
			float x = (target.position - m_LastTargetPosition).x;
			if (Mathf.Abs(x) > lookAheadMoveThreshold)
			{
				m_LookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign(x);
			}
			else
			{
				m_LookAheadPos = Vector3.MoveTowards(m_LookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);
			}
			Vector3 vector = target.position + m_LookAheadPos + Vector3.forward * m_OffsetZ;
			Vector3 position = Vector3.SmoothDamp(base.transform.position, vector, ref m_CurrentVelocity, damping);
			base.transform.position = position;
			m_LastTargetPosition = target.position;
		}
	}
}
