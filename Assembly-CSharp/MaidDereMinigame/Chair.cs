using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200058B RID: 1419
	public class Chair : MonoBehaviour
	{
		// Token: 0x17000522 RID: 1314
		// (get) Token: 0x060023FF RID: 9215 RVA: 0x001F550C File Offset: 0x001F370C
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

		// Token: 0x17000523 RID: 1315
		// (get) Token: 0x06002400 RID: 9216 RVA: 0x001F5560 File Offset: 0x001F3760
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

		// Token: 0x06002401 RID: 9217 RVA: 0x001F55E8 File Offset: 0x001F37E8
		private void OnDestroy()
		{
			Chair.chairs = null;
		}

		// Token: 0x04004B81 RID: 19329
		private static Chairs chairs;

		// Token: 0x04004B82 RID: 19330
		public bool available = true;
	}
}
