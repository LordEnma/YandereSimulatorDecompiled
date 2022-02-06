using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000590 RID: 1424
	public class Chair : MonoBehaviour
	{
		// Token: 0x17000524 RID: 1316
		// (get) Token: 0x06002429 RID: 9257 RVA: 0x001F965C File Offset: 0x001F785C
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

		// Token: 0x17000525 RID: 1317
		// (get) Token: 0x0600242A RID: 9258 RVA: 0x001F96B0 File Offset: 0x001F78B0
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

		// Token: 0x0600242B RID: 9259 RVA: 0x001F9738 File Offset: 0x001F7938
		private void OnDestroy()
		{
			Chair.chairs = null;
		}

		// Token: 0x04004BF8 RID: 19448
		private static Chairs chairs;

		// Token: 0x04004BF9 RID: 19449
		public bool available = true;
	}
}
