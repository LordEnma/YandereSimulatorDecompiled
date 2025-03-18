using UnityEngine;

namespace UnityStandardAssets.Utility
{
	public class CameraRefocus
	{
		public Camera Camera;

		public Vector3 Lookatpoint;

		public Transform Parent;

		private Vector3 m_OrigCameraPos;

		private bool m_Refocus;

		public CameraRefocus(Camera camera, Transform parent, Vector3 origCameraPos)
		{
			m_OrigCameraPos = origCameraPos;
			Camera = camera;
			Parent = parent;
		}

		public void ChangeCamera(Camera camera)
		{
			Camera = camera;
		}

		public void ChangeParent(Transform parent)
		{
			Parent = parent;
		}

		public void GetFocusPoint()
		{
			if (Physics.Raycast(Parent.transform.position + m_OrigCameraPos, Parent.transform.forward, out var hitInfo, 100f))
			{
				Lookatpoint = hitInfo.point;
				m_Refocus = true;
			}
			else
			{
				m_Refocus = false;
			}
		}

		public void SetFocusPoint()
		{
			if (m_Refocus)
			{
				Camera.transform.LookAt(Lookatpoint);
			}
		}
	}
}
