using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000528 RID: 1320
	public class SkidTrail : MonoBehaviour
	{
		// Token: 0x06002193 RID: 8595 RVA: 0x001EA84E File Offset: 0x001E8A4E
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

		// Token: 0x04004999 RID: 18841
		[SerializeField]
		private float m_PersistTime;
	}
}
