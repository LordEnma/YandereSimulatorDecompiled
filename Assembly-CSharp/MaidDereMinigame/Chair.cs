using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200058F RID: 1423
	public class Chair : MonoBehaviour
	{
		// Token: 0x17000523 RID: 1315
		// (get) Token: 0x0600241E RID: 9246 RVA: 0x001F7BD0 File Offset: 0x001F5DD0
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
		// (get) Token: 0x0600241F RID: 9247 RVA: 0x001F7C24 File Offset: 0x001F5E24
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

		// Token: 0x06002420 RID: 9248 RVA: 0x001F7CAC File Offset: 0x001F5EAC
		private void OnDestroy()
		{
			Chair.chairs = null;
		}

		// Token: 0x04004BDD RID: 19421
		private static Chairs chairs;

		// Token: 0x04004BDE RID: 19422
		public bool available = true;
	}
}
