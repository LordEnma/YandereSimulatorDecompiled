using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000528 RID: 1320
	public class SkidTrail : MonoBehaviour
	{
		// Token: 0x06002199 RID: 8601 RVA: 0x001EB406 File Offset: 0x001E9606
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

		// Token: 0x040049AA RID: 18858
		[SerializeField]
		private float m_PersistTime;
	}
}
