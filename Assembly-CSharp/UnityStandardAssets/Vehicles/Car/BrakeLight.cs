using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x0200052C RID: 1324
	public class BrakeLight : MonoBehaviour
	{
		// Token: 0x060021AE RID: 8622 RVA: 0x001EF985 File Offset: 0x001EDB85
		private void Start()
		{
			this.m_Renderer = base.GetComponent<Renderer>();
		}

		// Token: 0x060021AF RID: 8623 RVA: 0x001EF993 File Offset: 0x001EDB93
		private void Update()
		{
			this.m_Renderer.enabled = (this.car.BrakeInput > 0f);
		}

		// Token: 0x04004A20 RID: 18976
		public CarController car;

		// Token: 0x04004A21 RID: 18977
		private Renderer m_Renderer;
	}
}
