using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	public class Mudguard : MonoBehaviour
	{
		public CarController carController;

		private Quaternion m_OriginalRotation;

		private void Start()
		{
			m_OriginalRotation = base.transform.localRotation;
		}

		private void Update()
		{
			base.transform.localRotation = m_OriginalRotation * Quaternion.Euler(0f, carController.CurrentSteerAngle, 0f);
		}
	}
}
