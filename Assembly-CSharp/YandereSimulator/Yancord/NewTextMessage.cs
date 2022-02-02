using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x0200051B RID: 1307
	[Serializable]
	public class NewTextMessage
	{
		// Token: 0x04004914 RID: 18708
		public string Message;

		// Token: 0x04004915 RID: 18709
		public bool isQuestion;

		// Token: 0x04004916 RID: 18710
		public bool sentByPlayer;

		// Token: 0x04004917 RID: 18711
		public bool isSystemMessage;

		// Token: 0x04004918 RID: 18712
		[Header("== Question Related ==")]
		public string OptionQ;

		// Token: 0x04004919 RID: 18713
		public string OptionR;

		// Token: 0x0400491A RID: 18714
		public string OptionF;

		// Token: 0x0400491B RID: 18715
		[Space(20f)]
		public string ReactionQ;

		// Token: 0x0400491C RID: 18716
		public string ReactionR;

		// Token: 0x0400491D RID: 18717
		public string ReactionF;
	}
}
