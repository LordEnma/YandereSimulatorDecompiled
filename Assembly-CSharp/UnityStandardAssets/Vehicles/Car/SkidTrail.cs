using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000535 RID: 1333
	public class SkidTrail : MonoBehaviour
	{
		// Token: 0x060021E2 RID: 8674 RVA: 0x001F0D7E File Offset: 0x001EEF7E
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

		// Token: 0x04004A78 RID: 19064
		[SerializeField]
		private float m_PersistTime;
	}
}
