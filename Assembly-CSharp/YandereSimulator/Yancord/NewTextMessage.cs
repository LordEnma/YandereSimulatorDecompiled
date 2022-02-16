using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x0200051C RID: 1308
	[Serializable]
	public class NewTextMessage
	{
		// Token: 0x04004926 RID: 18726
		public string Message;

		// Token: 0x04004927 RID: 18727
		public bool isQuestion;

		// Token: 0x04004928 RID: 18728
		public bool sentByPlayer;

		// Token: 0x04004929 RID: 18729
		public bool isSystemMessage;

		// Token: 0x0400492A RID: 18730
		[Header("== Question Related ==")]
		public string OptionQ;

		// Token: 0x0400492B RID: 18731
		public string OptionR;

		// Token: 0x0400492C RID: 18732
		public string OptionF;

		// Token: 0x0400492D RID: 18733
		[Space(20f)]
		public string ReactionQ;

		// Token: 0x0400492E RID: 18734
		public string ReactionR;

		// Token: 0x0400492F RID: 18735
		public string ReactionF;
	}
}
