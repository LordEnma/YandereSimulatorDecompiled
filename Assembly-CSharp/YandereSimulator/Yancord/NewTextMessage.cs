using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x0200051B RID: 1307
	[Serializable]
	public class NewTextMessage
	{
		// Token: 0x0400491D RID: 18717
		public string Message;

		// Token: 0x0400491E RID: 18718
		public bool isQuestion;

		// Token: 0x0400491F RID: 18719
		public bool sentByPlayer;

		// Token: 0x04004920 RID: 18720
		public bool isSystemMessage;

		// Token: 0x04004921 RID: 18721
		[Header("== Question Related ==")]
		public string OptionQ;

		// Token: 0x04004922 RID: 18722
		public string OptionR;

		// Token: 0x04004923 RID: 18723
		public string OptionF;

		// Token: 0x04004924 RID: 18724
		[Space(20f)]
		public string ReactionQ;

		// Token: 0x04004925 RID: 18725
		public string ReactionR;

		// Token: 0x04004926 RID: 18726
		public string ReactionF;
	}
}
