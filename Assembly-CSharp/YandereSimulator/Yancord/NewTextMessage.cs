using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x0200051D RID: 1309
	[Serializable]
	public class NewTextMessage
	{
		// Token: 0x04004936 RID: 18742
		public string Message;

		// Token: 0x04004937 RID: 18743
		public bool isQuestion;

		// Token: 0x04004938 RID: 18744
		public bool sentByPlayer;

		// Token: 0x04004939 RID: 18745
		public bool isSystemMessage;

		// Token: 0x0400493A RID: 18746
		[Header("== Question Related ==")]
		public string OptionQ;

		// Token: 0x0400493B RID: 18747
		public string OptionR;

		// Token: 0x0400493C RID: 18748
		public string OptionF;

		// Token: 0x0400493D RID: 18749
		[Space(20f)]
		public string ReactionQ;

		// Token: 0x0400493E RID: 18750
		public string ReactionR;

		// Token: 0x0400493F RID: 18751
		public string ReactionF;
	}
}
