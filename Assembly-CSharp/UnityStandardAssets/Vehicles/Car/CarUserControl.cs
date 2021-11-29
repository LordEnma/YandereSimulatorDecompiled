using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000521 RID: 1313
	[RequireComponent(typeof(CarController))]
	public class CarUserControl : MonoBehaviour
	{
		// Token: 0x0600216C RID: 8556 RVA: 0x001E741A File Offset: 0x001E561A
		private void Awake()
		{
			this.m_Car = base.GetComponent<CarController>();
		}

		// Token: 0x0600216D RID: 8557 RVA: 0x001E7428 File Offset: 0x001E5628
		private void FixedUpdate()
		{
			float axis = CrossPlatformInputManager.GetAxis("Horizontal");
			float axis2 = CrossPlatformInputManager.GetAxis("Vertical");
			float axis3 = CrossPlatformInputManager.GetAxis("Jump");
			this.m_Car.Move(axis, axis2, axis2, axis3);
		}

		// Token: 0x04004933 RID: 18739
		private CarController m_Car;
	}
}
