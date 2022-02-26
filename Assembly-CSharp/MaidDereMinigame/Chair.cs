using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000592 RID: 1426
	public class Chair : MonoBehaviour
	{
		// Token: 0x17000525 RID: 1317
		// (get) Token: 0x06002439 RID: 9273 RVA: 0x001FA6F0 File Offset: 0x001F88F0
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
		// (get) Token: 0x0600243A RID: 9274 RVA: 0x001FA744 File Offset: 0x001F8944
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

		// Token: 0x0600243B RID: 9275 RVA: 0x001FA7CC File Offset: 0x001F89CC
		private void OnDestroy()
		{
			Chair.chairs = null;
		}

		// Token: 0x04004C11 RID: 19473
		private static Chairs chairs;

		// Token: 0x04004C12 RID: 19474
		public bool available = true;
	}
}
