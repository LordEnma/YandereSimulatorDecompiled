using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000536 RID: 1334
	public class SkidTrail : MonoBehaviour
	{
		// Token: 0x060021F3 RID: 8691 RVA: 0x001F2D62 File Offset: 0x001F0F62
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
