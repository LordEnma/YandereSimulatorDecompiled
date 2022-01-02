using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000525 RID: 1317
	public class SkidTrail : MonoBehaviour
	{
		// Token: 0x06002186 RID: 8582 RVA: 0x001E91DE File Offset: 0x001E73DE
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

		// Token: 0x0400497E RID: 18814
		[SerializeField]
		private float m_PersistTime;
	}
}
