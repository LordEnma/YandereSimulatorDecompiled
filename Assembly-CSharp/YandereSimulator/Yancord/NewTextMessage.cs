using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x0200051B RID: 1307
	[Serializable]
	public class NewTextMessage
	{
		// Token: 0x0400491A RID: 18714
		public string Message;

		// Token: 0x0400491B RID: 18715
		public bool isQuestion;

		// Token: 0x0400491C RID: 18716
		public bool sentByPlayer;

		// Token: 0x0400491D RID: 18717
		public bool isSystemMessage;

		// Token: 0x0400491E RID: 18718
		[Header("== Question Related ==")]
		public string OptionQ;

		// Token: 0x0400491F RID: 18719
		public string OptionR;

		// Token: 0x04004920 RID: 18720
		public string OptionF;

		// Token: 0x04004921 RID: 18721
		[Space(20f)]
		public string ReactionQ;

		// Token: 0x04004922 RID: 18722
		public string ReactionR;

		// Token: 0x04004923 RID: 18723
		public string ReactionF;
	}
}
