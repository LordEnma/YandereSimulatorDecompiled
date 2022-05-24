using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200059F RID: 1439
	public class Chair : MonoBehaviour
	{
		// Token: 0x17000528 RID: 1320
		// (get) Token: 0x0600248B RID: 9355 RVA: 0x002029BC File Offset: 0x00200BBC
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

		// Token: 0x17000529 RID: 1321
		// (get) Token: 0x0600248C RID: 9356 RVA: 0x00202A10 File Offset: 0x00200C10
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

		// Token: 0x0600248D RID: 9357 RVA: 0x00202A98 File Offset: 0x00200C98
		private void OnDestroy()
		{
			Chair.chairs = null;
		}

		// Token: 0x04004D1E RID: 19742
		private static Chairs chairs;

		// Token: 0x04004D1F RID: 19743
		public bool available = true;
	}
}
