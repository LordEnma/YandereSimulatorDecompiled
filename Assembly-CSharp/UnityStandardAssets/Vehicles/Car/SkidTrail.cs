using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000528 RID: 1320
	public class SkidTrail : MonoBehaviour
	{
		// Token: 0x0600219C RID: 8604 RVA: 0x001EB60A File Offset: 0x001E980A
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

		// Token: 0x040049AD RID: 18861
		[SerializeField]
		private float m_PersistTime;
	}
}
