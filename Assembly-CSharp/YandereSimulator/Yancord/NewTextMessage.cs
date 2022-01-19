using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x0200051B RID: 1307
	[Serializable]
	public class NewTextMessage
	{
		// Token: 0x04004909 RID: 18697
		public string Message;

		// Token: 0x0400490A RID: 18698
		public bool isQuestion;

		// Token: 0x0400490B RID: 18699
		public bool sentByPlayer;

		// Token: 0x0400490C RID: 18700
		public bool isSystemMessage;

		// Token: 0x0400490D RID: 18701
		[Header("== Question Related ==")]
		public string OptionQ;

		// Token: 0x0400490E RID: 18702
		public string OptionR;

		// Token: 0x0400490F RID: 18703
		public string OptionF;

		// Token: 0x04004910 RID: 18704
		[Space(20f)]
		public string ReactionQ;

		// Token: 0x04004911 RID: 18705
		public string ReactionR;

		// Token: 0x04004912 RID: 18706
		public string ReactionF;
	}
}
