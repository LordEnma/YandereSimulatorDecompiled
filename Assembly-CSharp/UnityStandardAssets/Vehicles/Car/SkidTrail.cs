using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000536 RID: 1334
	public class SkidTrail : MonoBehaviour
	{
		// Token: 0x060021F2 RID: 8690 RVA: 0x001F2C66 File Offset: 0x001F0E66
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

		// Token: 0x04004AA0 RID: 19104
		[SerializeField]
		private float m_PersistTime;
	}
}
