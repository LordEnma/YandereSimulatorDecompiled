using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000535 RID: 1333
	public class SkidTrail : MonoBehaviour
	{
		// Token: 0x060021E9 RID: 8681 RVA: 0x001F17DA File Offset: 0x001EF9DA
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

		// Token: 0x04004A8A RID: 19082
		[SerializeField]
		private float m_PersistTime;
	}
}
