using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x0200052C RID: 1324
	public class BrakeLight : MonoBehaviour
	{
		// Token: 0x060021B5 RID: 8629 RVA: 0x001F03E1 File Offset: 0x001EE5E1
		private void Start()
		{
			this.m_Renderer = base.GetComponent<Renderer>();
		}

		// Token: 0x060021B6 RID: 8630 RVA: 0x001F03EF File Offset: 0x001EE5EF
		private void Update()
		{
			this.m_Renderer.enabled = (this.car.BrakeInput > 0f);
		}

		// Token: 0x04004A32 RID: 18994
		public CarController car;

		// Token: 0x04004A33 RID: 18995
		private Renderer m_Renderer;
	}
}
