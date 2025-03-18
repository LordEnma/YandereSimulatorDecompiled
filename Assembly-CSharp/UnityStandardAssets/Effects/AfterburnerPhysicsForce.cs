using UnityEngine;

namespace UnityStandardAssets.Effects
{
	[RequireComponent(typeof(SphereCollider))]
	public class AfterburnerPhysicsForce : MonoBehaviour
	{
		public float effectAngle = 15f;

		public float effectWidth = 1f;

		public float effectDistance = 10f;

		public float force = 10f;

		private Collider[] m_Cols;

		private SphereCollider m_Sphere;

		private void OnEnable()
		{
			m_Sphere = GetComponent<Collider>() as SphereCollider;
		}

		private void FixedUpdate()
		{
			m_Cols = Physics.OverlapSphere(base.transform.position + m_Sphere.center, m_Sphere.radius);
			for (int i = 0; i < m_Cols.Length; i++)
			{
				if (m_Cols[i].attachedRigidbody != null)
				{
					Vector3 current = base.transform.InverseTransformPoint(m_Cols[i].transform.position);
					current = Vector3.MoveTowards(current, new Vector3(0f, 0f, current.z), effectWidth * 0.5f);
					float value = Mathf.Abs(Mathf.Atan2(current.x, current.z) * 57.29578f);
					float num = Mathf.InverseLerp(effectDistance, 0f, current.magnitude);
					num *= Mathf.InverseLerp(effectAngle, 0f, value);
					Vector3 vector = m_Cols[i].transform.position - base.transform.position;
					m_Cols[i].attachedRigidbody.AddForceAtPosition(vector.normalized * force * num, Vector3.Lerp(m_Cols[i].transform.position, base.transform.TransformPoint(0f, 0f, current.z), 0.1f));
				}
			}
		}

		private void OnDrawGizmosSelected()
		{
			if (m_Sphere == null)
			{
				m_Sphere = GetComponent<Collider>() as SphereCollider;
			}
			m_Sphere.radius = effectDistance * 0.5f;
			m_Sphere.center = new Vector3(0f, 0f, effectDistance * 0.5f);
			Vector3[] array = new Vector3[4]
			{
				Vector3.up,
				-Vector3.up,
				Vector3.right,
				-Vector3.right
			};
			Vector3[] array2 = new Vector3[4]
			{
				-Vector3.right,
				Vector3.right,
				Vector3.up,
				-Vector3.up
			};
			Gizmos.color = new Color(0f, 1f, 0f, 0.5f);
			for (int i = 0; i < 4; i++)
			{
				Vector3 vector = base.transform.position + base.transform.rotation * array[i] * effectWidth * 0.5f;
				Vector3 vector2 = base.transform.TransformDirection(Quaternion.AngleAxis(effectAngle, array2[i]) * Vector3.forward);
				Gizmos.DrawLine(vector, vector + vector2 * m_Sphere.radius * 2f);
			}
		}
	}
}
