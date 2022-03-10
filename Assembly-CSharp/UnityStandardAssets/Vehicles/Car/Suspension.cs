using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x0200052C RID: 1324
	public class Suspension : MonoBehaviour
	{
		// Token: 0x060021B4 RID: 8628 RVA: 0x001ED08D File Offset: 0x001EB28D
		private void Start()
		{
			this.m_TargetOriginalPosition = this.wheel.transform.localPosition;
			this.m_Origin = base.transform.localPosition;
		}

		// Token: 0x060021B5 RID: 8629 RVA: 0x001ED0B6 File Offset: 0x001EB2B6
		private void Update()
		{
			base.transform.localPosition = this.m_Origin + (this.wheel.transform.localPosition - this.m_TargetOriginalPosition);
		}

		// Token: 0x040049E4 RID: 18916
		public GameObject wheel;

		// Token: 0x040049E5 RID: 18917
		private Vector3 m_TargetOriginalPosition;

		// Token: 0x040049E6 RID: 18918
		private Vector3 m_Origin;
	}
}
