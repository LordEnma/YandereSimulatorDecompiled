using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000590 RID: 1424
	public class Chair : MonoBehaviour
	{
		// Token: 0x17000523 RID: 1315
		// (get) Token: 0x06002424 RID: 9252 RVA: 0x001F9140 File Offset: 0x001F7340
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
		// (get) Token: 0x06002425 RID: 9253 RVA: 0x001F9194 File Offset: 0x001F7394
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

		// Token: 0x06002426 RID: 9254 RVA: 0x001F921C File Offset: 0x001F741C
		private void OnDestroy()
		{
			Chair.chairs = null;
		}

		// Token: 0x04004BEF RID: 19439
		private static Chairs chairs;

		// Token: 0x04004BF0 RID: 19440
		public bool available = true;
	}
}
