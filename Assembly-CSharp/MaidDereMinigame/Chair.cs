using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200059D RID: 1437
	public class Chair : MonoBehaviour
	{
		// Token: 0x17000527 RID: 1319
		// (get) Token: 0x06002476 RID: 9334 RVA: 0x001FF82C File Offset: 0x001FDA2C
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

		// Token: 0x17000528 RID: 1320
		// (get) Token: 0x06002477 RID: 9335 RVA: 0x001FF880 File Offset: 0x001FDA80
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

		// Token: 0x06002478 RID: 9336 RVA: 0x001FF908 File Offset: 0x001FDB08
		private void OnDestroy()
		{
			Chair.chairs = null;
		}

		// Token: 0x04004CD5 RID: 19669
		private static Chairs chairs;

		// Token: 0x04004CD6 RID: 19670
		public bool available = true;
	}
}
