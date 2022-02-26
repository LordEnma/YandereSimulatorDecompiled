using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x0200052B RID: 1323
	public class Suspension : MonoBehaviour
	{
		// Token: 0x060021AE RID: 8622 RVA: 0x001EC6B5 File Offset: 0x001EA8B5
		private void Start()
		{
			this.m_TargetOriginalPosition = this.wheel.transform.localPosition;
			this.m_Origin = base.transform.localPosition;
		}

		// Token: 0x060021AF RID: 8623 RVA: 0x001EC6DE File Offset: 0x001EA8DE
		private void Update()
		{
			base.transform.localPosition = this.m_Origin + (this.wheel.transform.localPosition - this.m_TargetOriginalPosition);
		}

		// Token: 0x040049C7 RID: 18887
		public GameObject wheel;

		// Token: 0x040049C8 RID: 18888
		private Vector3 m_TargetOriginalPosition;

		// Token: 0x040049C9 RID: 18889
		private Vector3 m_Origin;
	}
}
