using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x0200052A RID: 1322
	public class SkidTrail : MonoBehaviour
	{
		// Token: 0x060021AC RID: 8620 RVA: 0x001EC69E File Offset: 0x001EA89E
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

		// Token: 0x040049C6 RID: 18886
		[SerializeField]
		private float m_PersistTime;
	}
}
