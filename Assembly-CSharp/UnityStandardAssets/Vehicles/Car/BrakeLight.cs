using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x0200051F RID: 1311
	public class BrakeLight : MonoBehaviour
	{
		// Token: 0x06002168 RID: 8552 RVA: 0x001EA211 File Offset: 0x001E8411
		private void Start()
		{
			this.m_Renderer = base.GetComponent<Renderer>();
		}

		// Token: 0x06002169 RID: 8553 RVA: 0x001EA21F File Offset: 0x001E841F
		private void Update()
		{
			this.m_Renderer.enabled = (this.car.BrakeInput > 0f);
		}

		// Token: 0x04004955 RID: 18773
		public CarController car;

		// Token: 0x04004956 RID: 18774
		private Renderer m_Renderer;
	}
}
