using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x0200052F RID: 1327
	public class SkidTrail : MonoBehaviour
	{
		// Token: 0x060021CA RID: 8650 RVA: 0x001EEFDE File Offset: 0x001ED1DE
		private IEnumerator Start()
		{
			for (;;)
			{
				yield return null;
				if (base.transform.parent.parent == null)
				{
					UnityEngine.Object.Destroy(base.gameObject, this.m_PersistTime);
				}
			}
			yield break;
		}

		// Token: 0x04004A42 RID: 19010
		[SerializeField]
		private float m_PersistTime;
	}
}
