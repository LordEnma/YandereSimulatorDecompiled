using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	public class Suspension : MonoBehaviour
	{
		public GameObject wheel;

		private Vector3 m_TargetOriginalPosition;

		private Vector3 m_Origin;

		private void Start()
		{
			m_TargetOriginalPosition = wheel.transform.localPosition;
			m_Origin = base.transform.localPosition;
		}

		private void Update()
		{
			base.transform.localPosition = m_Origin + (wheel.transform.localPosition - m_TargetOriginalPosition);
		}
	}
}
