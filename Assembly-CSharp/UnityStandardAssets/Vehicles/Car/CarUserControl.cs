using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
	[RequireComponent(typeof(CarController))]
	public class CarUserControl : MonoBehaviour
	{
		private CarController m_Car;

		private void Awake()
		{
			m_Car = GetComponent<CarController>();
		}

		private void FixedUpdate()
		{
			float axis = CrossPlatformInputManager.GetAxis("Horizontal");
			float axis2 = CrossPlatformInputManager.GetAxis("Vertical");
			float axis3 = CrossPlatformInputManager.GetAxis("Jump");
			m_Car.Move(axis, axis2, axis2, axis3);
		}
	}
}
