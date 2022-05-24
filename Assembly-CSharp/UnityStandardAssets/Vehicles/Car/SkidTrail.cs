using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000537 RID: 1335
	public class SkidTrail : MonoBehaviour
	{
		// Token: 0x060021FE RID: 8702 RVA: 0x001F491A File Offset: 0x001F2B1A
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

		// Token: 0x04004AD0 RID: 19152
		[SerializeField]
		private float m_PersistTime;
	}
}
