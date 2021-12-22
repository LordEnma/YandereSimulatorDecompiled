using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x02000518 RID: 1304
	[Serializable]
	public class NewTextMessage
	{
		// Token: 0x040048E5 RID: 18661
		public string Message;

		// Token: 0x040048E6 RID: 18662
		public bool isQuestion;

		// Token: 0x040048E7 RID: 18663
		public bool sentByPlayer;

		// Token: 0x040048E8 RID: 18664
		public bool isSystemMessage;

		// Token: 0x040048E9 RID: 18665
		[Header("== Question Related ==")]
		public string OptionQ;

		// Token: 0x040048EA RID: 18666
		public string OptionR;

		// Token: 0x040048EB RID: 18667
		public string OptionF;

		// Token: 0x040048EC RID: 18668
		[Space(20f)]
		public string ReactionQ;

		// Token: 0x040048ED RID: 18669
		public string ReactionR;

		// Token: 0x040048EE RID: 18670
		public string ReactionF;
	}
}
