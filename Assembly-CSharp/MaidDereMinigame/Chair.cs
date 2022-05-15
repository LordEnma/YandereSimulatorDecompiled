using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200059F RID: 1439
	public class Chair : MonoBehaviour
	{
		// Token: 0x17000528 RID: 1320
		// (get) Token: 0x0600248A RID: 9354 RVA: 0x00202454 File Offset: 0x00200654
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
		// (get) Token: 0x0600248B RID: 9355 RVA: 0x002024A8 File Offset: 0x002006A8
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

		// Token: 0x0600248C RID: 9356 RVA: 0x00202530 File Offset: 0x00200730
		private void OnDestroy()
		{
			Chair.chairs = null;
		}

		// Token: 0x04004D15 RID: 19733
		private static Chairs chairs;

		// Token: 0x04004D16 RID: 19734
		public bool available = true;
	}
}
