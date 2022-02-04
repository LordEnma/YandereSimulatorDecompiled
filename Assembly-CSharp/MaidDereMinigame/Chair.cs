using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000590 RID: 1424
	public class Chair : MonoBehaviour
	{
		// Token: 0x17000523 RID: 1315
		// (get) Token: 0x06002426 RID: 9254 RVA: 0x001F9458 File Offset: 0x001F7658
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
		// (get) Token: 0x06002427 RID: 9255 RVA: 0x001F94AC File Offset: 0x001F76AC
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

		// Token: 0x06002428 RID: 9256 RVA: 0x001F9534 File Offset: 0x001F7734
		private void OnDestroy()
		{
			Chair.chairs = null;
		}

		// Token: 0x04004BF5 RID: 19445
		private static Chairs chairs;

		// Token: 0x04004BF6 RID: 19446
		public bool available = true;
	}
}
