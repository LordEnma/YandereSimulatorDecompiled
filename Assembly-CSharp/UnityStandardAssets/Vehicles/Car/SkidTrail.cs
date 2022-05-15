using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000537 RID: 1335
	public class SkidTrail : MonoBehaviour
	{
		// Token: 0x060021FD RID: 8701 RVA: 0x001F43B2 File Offset: 0x001F25B2
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

		// Token: 0x04004AC7 RID: 19143
		[SerializeField]
		private float m_PersistTime;
	}
}
