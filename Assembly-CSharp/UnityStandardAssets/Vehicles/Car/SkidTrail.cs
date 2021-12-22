using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000525 RID: 1317
	public class SkidTrail : MonoBehaviour
	{
		// Token: 0x06002183 RID: 8579 RVA: 0x001E8BEE File Offset: 0x001E6DEE
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

		// Token: 0x04004975 RID: 18805
		[SerializeField]
		private float m_PersistTime;
	}
}
