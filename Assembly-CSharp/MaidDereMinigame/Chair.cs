using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200058D RID: 1421
	public class Chair : MonoBehaviour
	{
		// Token: 0x17000523 RID: 1315
		// (get) Token: 0x06002413 RID: 9235 RVA: 0x001F7230 File Offset: 0x001F5430
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

		// Token: 0x17000524 RID: 1316
		// (get) Token: 0x06002414 RID: 9236 RVA: 0x001F7284 File Offset: 0x001F5484
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

		// Token: 0x06002415 RID: 9237 RVA: 0x001F730C File Offset: 0x001F550C
		private void OnDestroy()
		{
			Chair.chairs = null;
		}

		// Token: 0x04004BC9 RID: 19401
		private static Chairs chairs;

		// Token: 0x04004BCA RID: 19402
		public bool available = true;
	}
}
