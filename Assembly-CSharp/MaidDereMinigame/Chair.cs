using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000597 RID: 1431
	public class Chair : MonoBehaviour
	{
		// Token: 0x17000526 RID: 1318
		// (get) Token: 0x06002457 RID: 9303 RVA: 0x001FD030 File Offset: 0x001FB230
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
		// (get) Token: 0x06002458 RID: 9304 RVA: 0x001FD084 File Offset: 0x001FB284
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

		// Token: 0x06002459 RID: 9305 RVA: 0x001FD10C File Offset: 0x001FB30C
		private void OnDestroy()
		{
			Chair.chairs = null;
		}

		// Token: 0x04004C8D RID: 19597
		private static Chairs chairs;

		// Token: 0x04004C8E RID: 19598
		public bool available = true;
	}
}
