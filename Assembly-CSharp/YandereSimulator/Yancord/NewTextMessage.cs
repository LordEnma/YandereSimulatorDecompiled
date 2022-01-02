using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x02000518 RID: 1304
	[Serializable]
	public class NewTextMessage
	{
		// Token: 0x040048EE RID: 18670
		public string Message;

		// Token: 0x040048EF RID: 18671
		public bool isQuestion;

		// Token: 0x040048F0 RID: 18672
		public bool sentByPlayer;

		// Token: 0x040048F1 RID: 18673
		public bool isSystemMessage;

		// Token: 0x040048F2 RID: 18674
		[Header("== Question Related ==")]
		public string OptionQ;

		// Token: 0x040048F3 RID: 18675
		public string OptionR;

		// Token: 0x040048F4 RID: 18676
		public string OptionF;

		// Token: 0x040048F5 RID: 18677
		[Space(20f)]
		public string ReactionQ;

		// Token: 0x040048F6 RID: 18678
		public string ReactionR;

		// Token: 0x040048F7 RID: 18679
		public string ReactionF;
	}
}
