using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000593 RID: 1427
	public class Chair : MonoBehaviour
	{
		// Token: 0x17000525 RID: 1317
		// (get) Token: 0x0600243F RID: 9279 RVA: 0x001FB0C8 File Offset: 0x001F92C8
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
		// (get) Token: 0x06002440 RID: 9280 RVA: 0x001FB11C File Offset: 0x001F931C
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

		// Token: 0x06002441 RID: 9281 RVA: 0x001FB1A4 File Offset: 0x001F93A4
		private void OnDestroy()
		{
			Chair.chairs = null;
		}

		// Token: 0x04004C2E RID: 19502
		private static Chairs chairs;

		// Token: 0x04004C2F RID: 19503
		public bool available = true;
	}
}
