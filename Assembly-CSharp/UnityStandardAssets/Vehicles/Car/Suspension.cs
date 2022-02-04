using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000529 RID: 1321
	public class Suspension : MonoBehaviour
	{
		// Token: 0x0600219B RID: 8603 RVA: 0x001EB41D File Offset: 0x001E961D
		private void Start()
		{
			this.m_TargetOriginalPosition = this.wheel.transform.localPosition;
			this.m_Origin = base.transform.localPosition;
		}

		// Token: 0x0600219C RID: 8604 RVA: 0x001EB446 File Offset: 0x001E9646
		private void Update()
		{
			base.transform.localPosition = this.m_Origin + (this.wheel.transform.localPosition - this.m_TargetOriginalPosition);
		}

		// Token: 0x040049AB RID: 18859
		public GameObject wheel;

		// Token: 0x040049AC RID: 18860
		private Vector3 m_TargetOriginalPosition;

		// Token: 0x040049AD RID: 18861
		private Vector3 m_Origin;
	}
}
