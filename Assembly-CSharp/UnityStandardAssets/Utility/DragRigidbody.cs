using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Utility
{
	public class DragRigidbody : MonoBehaviour
	{
		private const float k_Spring = 50f;

		private const float k_Damper = 5f;

		private const float k_Drag = 10f;

		private const float k_AngularDrag = 5f;

		private const float k_Distance = 0.2f;

		private const bool k_AttachToCenterOfMass = false;

		private SpringJoint m_SpringJoint;

		private void Update()
		{
			if (!Input.GetMouseButtonDown(0))
			{
				return;
			}
			Camera camera = FindCamera();
			RaycastHit hitInfo = default(RaycastHit);
			if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition).origin, camera.ScreenPointToRay(Input.mousePosition).direction, out hitInfo, 100f, -5) && (bool)hitInfo.rigidbody && !hitInfo.rigidbody.isKinematic)
			{
				if (!m_SpringJoint)
				{
					GameObject gameObject = new GameObject("Rigidbody dragger");
					Rigidbody rigidbody = gameObject.AddComponent<Rigidbody>();
					m_SpringJoint = gameObject.AddComponent<SpringJoint>();
					rigidbody.isKinematic = true;
				}
				m_SpringJoint.transform.position = hitInfo.point;
				m_SpringJoint.anchor = Vector3.zero;
				m_SpringJoint.spring = 50f;
				m_SpringJoint.damper = 5f;
				m_SpringJoint.maxDistance = 0.2f;
				m_SpringJoint.connectedBody = hitInfo.rigidbody;
				StartCoroutine("DragObject", hitInfo.distance);
			}
		}

		private IEnumerator DragObject(float distance)
		{
			float oldDrag = m_SpringJoint.connectedBody.linearDamping;
			float oldAngularDrag = m_SpringJoint.connectedBody.angularDamping;
			m_SpringJoint.connectedBody.linearDamping = 10f;
			m_SpringJoint.connectedBody.angularDamping = 5f;
			Camera mainCamera = FindCamera();
			while (Input.GetMouseButton(0))
			{
				Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
				m_SpringJoint.transform.position = ray.GetPoint(distance);
				yield return null;
			}
			if ((bool)m_SpringJoint.connectedBody)
			{
				m_SpringJoint.connectedBody.linearDamping = oldDrag;
				m_SpringJoint.connectedBody.angularDamping = oldAngularDrag;
				m_SpringJoint.connectedBody = null;
			}
		}

		private Camera FindCamera()
		{
			if ((bool)GetComponent<Camera>())
			{
				return GetComponent<Camera>();
			}
			return Camera.main;
		}
	}
}
