using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x0200052B RID: 1323
	public class SkidTrail : MonoBehaviour
	{
		// Token: 0x060021B2 RID: 8626 RVA: 0x001ED076 File Offset: 0x001EB276
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

		// Token: 0x040049E3 RID: 18915
		[SerializeField]
		private float m_PersistTime;
	}
}
