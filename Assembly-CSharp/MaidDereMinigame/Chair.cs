using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200058D RID: 1421
	public class Chair : MonoBehaviour
	{
		// Token: 0x17000522 RID: 1314
		// (get) Token: 0x06002410 RID: 9232 RVA: 0x001F6C40 File Offset: 0x001F4E40
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
		// (get) Token: 0x06002411 RID: 9233 RVA: 0x001F6C94 File Offset: 0x001F4E94
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

		// Token: 0x06002412 RID: 9234 RVA: 0x001F6D1C File Offset: 0x001F4F1C
		private void OnDestroy()
		{
			Chair.chairs = null;
		}

		// Token: 0x04004BC0 RID: 19392
		private static Chairs chairs;

		// Token: 0x04004BC1 RID: 19393
		public bool available = true;
	}
}
