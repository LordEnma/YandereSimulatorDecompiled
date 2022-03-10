using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000529 RID: 1321
	[RequireComponent(typeof(CarController))]
	public class CarUserControl : MonoBehaviour
	{
		// Token: 0x060021AC RID: 8620 RVA: 0x001ECFD6 File Offset: 0x001EB1D6
		private void Awake()
		{
			this.m_Car = base.GetComponent<CarController>();
		}

		// Token: 0x060021AD RID: 8621 RVA: 0x001ECFE4 File Offset: 0x001EB1E4
		private void FixedUpdate()
		{
			float axis = CrossPlatformInputManager.GetAxis("Horizontal");
			float axis2 = CrossPlatformInputManager.GetAxis("Vertical");
			float axis3 = CrossPlatformInputManager.GetAxis("Jump");
			this.m_Car.Move(axis, axis2, axis2, axis3);
		}

		// Token: 0x040049E0 RID: 18912
		private CarController m_Car;
	}
}
