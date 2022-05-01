using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000534 RID: 1332
	[RequireComponent(typeof(CarController))]
	public class CarUserControl : MonoBehaviour
	{
		// Token: 0x060021EC RID: 8684 RVA: 0x001F2BC6 File Offset: 0x001F0DC6
		private void Awake()
		{
			this.m_Car = base.GetComponent<CarController>();
		}

		// Token: 0x060021ED RID: 8685 RVA: 0x001F2BD4 File Offset: 0x001F0DD4
		private void FixedUpdate()
		{
			float axis = CrossPlatformInputManager.GetAxis("Horizontal");
			float axis2 = CrossPlatformInputManager.GetAxis("Vertical");
			float axis3 = CrossPlatformInputManager.GetAxis("Jump");
			this.m_Car.Move(axis, axis2, axis2, axis3);
		}

		// Token: 0x04004A9D RID: 19101
		private CarController m_Car;
	}
}
