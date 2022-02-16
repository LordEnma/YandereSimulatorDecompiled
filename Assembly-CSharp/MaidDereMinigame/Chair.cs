using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000591 RID: 1425
	public class Chair : MonoBehaviour
	{
		// Token: 0x17000525 RID: 1317
		// (get) Token: 0x06002430 RID: 9264 RVA: 0x001F9B10 File Offset: 0x001F7D10
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

		// Token: 0x17000526 RID: 1318
		// (get) Token: 0x06002431 RID: 9265 RVA: 0x001F9B64 File Offset: 0x001F7D64
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

		// Token: 0x06002432 RID: 9266 RVA: 0x001F9BEC File Offset: 0x001F7DEC
		private void OnDestroy()
		{
			Chair.chairs = null;
		}

		// Token: 0x04004C01 RID: 19457
		private static Chairs chairs;

		// Token: 0x04004C02 RID: 19458
		public bool available = true;
	}
}
