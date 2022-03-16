using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000526 RID: 1318
	public class BrakeLight : MonoBehaviour
	{
		// Token: 0x06002196 RID: 8598 RVA: 0x001EDBE5 File Offset: 0x001EBDE5
		private void Start()
		{
			this.m_Renderer = base.GetComponent<Renderer>();
		}

		// Token: 0x06002197 RID: 8599 RVA: 0x001EDBF3 File Offset: 0x001EBDF3
		private void Update()
		{
			this.m_Renderer.enabled = (this.car.BrakeInput > 0f);
		}

		// Token: 0x040049EA RID: 18922
		public CarController car;

		// Token: 0x040049EB RID: 18923
		private Renderer m_Renderer;
	}
}
