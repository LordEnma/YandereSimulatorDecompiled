using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200059D RID: 1437
	public class Chair : MonoBehaviour
	{
		// Token: 0x17000526 RID: 1318
		// (get) Token: 0x0600246F RID: 9327 RVA: 0x001FEDD0 File Offset: 0x001FCFD0
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
		// (get) Token: 0x06002470 RID: 9328 RVA: 0x001FEE24 File Offset: 0x001FD024
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

		// Token: 0x06002471 RID: 9329 RVA: 0x001FEEAC File Offset: 0x001FD0AC
		private void OnDestroy()
		{
			Chair.chairs = null;
		}

		// Token: 0x04004CC3 RID: 19651
		private static Chairs chairs;

		// Token: 0x04004CC4 RID: 19652
		public bool available = true;
	}
}
