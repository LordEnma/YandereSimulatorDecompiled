using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000529 RID: 1321
	public class SkidTrail : MonoBehaviour
	{
		// Token: 0x060021A3 RID: 8611 RVA: 0x001EBABE File Offset: 0x001E9CBE
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

		// Token: 0x040049B6 RID: 18870
		[SerializeField]
		private float m_PersistTime;
	}
}
