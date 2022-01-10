using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000527 RID: 1319
	public class SkidTrail : MonoBehaviour
	{
		// Token: 0x06002191 RID: 8593 RVA: 0x001E9B7E File Offset: 0x001E7D7E
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

		// Token: 0x04004992 RID: 18834
		[SerializeField]
		private float m_PersistTime;
	}
}
