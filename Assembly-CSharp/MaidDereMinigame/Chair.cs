using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200059C RID: 1436
	public class Chair : MonoBehaviour
	{
		// Token: 0x17000526 RID: 1318
		// (get) Token: 0x06002467 RID: 9319 RVA: 0x001FE8A0 File Offset: 0x001FCAA0
		public static Chairs AllChairs
		{
			get
			{
				if (Chair.chairs == null || Chair.chairs.Count == 0)
				{
					Chair.chairs = new Chairs();
					foreach (Chair item in UnityEngine.Object.FindObjectsOfType<Chair>())
					{
						Chair.chairs.Add(item);
					}
				}
				return Chair.chairs;
			}
		}

		// Token: 0x17000527 RID: 1319
		// (get) Token: 0x06002468 RID: 9320 RVA: 0x001FE8F4 File Offset: 0x001FCAF4
		public static Chair RandomChair
		{
			get
			{
				Chairs chairs = new Chairs();
				foreach (Chair chair in Chair.AllChairs)
				{
					if (chair.available)
					{
						chairs.Add(chair);
					}
				}
				if (chairs.Count > 0)
				{
					int index = UnityEngine.Random.Range(0, chairs.Count);
					chairs[index].available = false;
					return chairs[index];
				}
				return null;
			}
		}

		// Token: 0x06002469 RID: 9321 RVA: 0x001FE97C File Offset: 0x001FCB7C
		private void OnDestroy()
		{
			Chair.chairs = null;
		}

		// Token: 0x04004CBF RID: 19647
		private static Chairs chairs;

		// Token: 0x04004CC0 RID: 19648
		public bool available = true;
	}
}
