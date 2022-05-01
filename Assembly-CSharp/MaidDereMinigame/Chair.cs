using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200059E RID: 1438
	public class Chair : MonoBehaviour
	{
		// Token: 0x17000527 RID: 1319
		// (get) Token: 0x0600247F RID: 9343 RVA: 0x00200D08 File Offset: 0x001FEF08
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
		// (get) Token: 0x06002480 RID: 9344 RVA: 0x00200D5C File Offset: 0x001FEF5C
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

		// Token: 0x06002481 RID: 9345 RVA: 0x00200DE4 File Offset: 0x001FEFE4
		private void OnDestroy()
		{
			Chair.chairs = null;
		}

		// Token: 0x04004CEE RID: 19694
		private static Chairs chairs;

		// Token: 0x04004CEF RID: 19695
		public bool available = true;
	}
}
