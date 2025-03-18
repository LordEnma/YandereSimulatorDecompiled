using UnityEngine;

namespace UnityStandardAssets.Utility
{
	public class TimedObjectDestructor : MonoBehaviour
	{
		[SerializeField]
		private float m_TimeOut = 1f;

		[SerializeField]
		private bool m_DetachChildren;

		private void Awake()
		{
			Invoke("DestroyNow", m_TimeOut);
		}

		private void DestroyNow()
		{
			if (m_DetachChildren)
			{
				base.transform.DetachChildren();
			}
			Object.Destroy(base.gameObject);
		}
	}
}
