using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000590 RID: 1424
	public class Chair : MonoBehaviour
	{
		// Token: 0x17000523 RID: 1315
		// (get) Token: 0x06002420 RID: 9248 RVA: 0x001F88A0 File Offset: 0x001F6AA0
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
		// (get) Token: 0x06002421 RID: 9249 RVA: 0x001F88F4 File Offset: 0x001F6AF4
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

		// Token: 0x06002422 RID: 9250 RVA: 0x001F897C File Offset: 0x001F6B7C
		private void OnDestroy()
		{
			Chair.chairs = null;
		}

		// Token: 0x04004BE4 RID: 19428
		private static Chairs chairs;

		// Token: 0x04004BE5 RID: 19429
		public bool available = true;
	}
}
