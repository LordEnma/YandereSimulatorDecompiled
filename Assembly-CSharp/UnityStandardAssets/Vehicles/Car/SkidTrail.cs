using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000534 RID: 1332
	public class SkidTrail : MonoBehaviour
	{
		// Token: 0x060021DA RID: 8666 RVA: 0x001F084E File Offset: 0x001EEA4E
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

		// Token: 0x04004A74 RID: 19060
		[SerializeField]
		private float m_PersistTime;
	}
}
