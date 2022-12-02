using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	public class BrakeLight : MonoBehaviour
	{
		public CarController car;

		private Renderer m_Renderer;

		private void Start()
		{
			m_Renderer = GetComponent<Renderer>();
		}

		private void Update()
		{
			m_Renderer.enabled = car.BrakeInput > 0f;
		}
	}
}
