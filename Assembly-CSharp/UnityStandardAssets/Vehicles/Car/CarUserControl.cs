using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000526 RID: 1318
	[RequireComponent(typeof(CarController))]
	public class CarUserControl : MonoBehaviour
	{
		// Token: 0x0600218D RID: 8589 RVA: 0x001EA7AE File Offset: 0x001E89AE
		private void Awake()
		{
			this.m_Car = base.GetComponent<CarController>();
		}

		// Token: 0x0600218E RID: 8590 RVA: 0x001EA7BC File Offset: 0x001E89BC
		private void FixedUpdate()
		{
			float axis = CrossPlatformInputManager.GetAxis("Horizontal");
			float axis2 = CrossPlatformInputManager.GetAxis("Vertical");
			float axis3 = CrossPlatformInputManager.GetAxis("Jump");
			this.m_Car.Move(axis, axis2, axis2, axis3);
		}

		// Token: 0x04004996 RID: 18838
		private CarController m_Car;
	}
}
