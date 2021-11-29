using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000523 RID: 1315
	public class SkidTrail : MonoBehaviour
	{
		// Token: 0x06002172 RID: 8562 RVA: 0x001E74BA File Offset: 0x001E56BA
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

		// Token: 0x04004936 RID: 18742
		[SerializeField]
		private float m_PersistTime;
	}
}
