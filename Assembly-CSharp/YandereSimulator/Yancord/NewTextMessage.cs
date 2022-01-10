using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x0200051A RID: 1306
	[Serializable]
	public class NewTextMessage
	{
		// Token: 0x04004902 RID: 18690
		public string Message;

		// Token: 0x04004903 RID: 18691
		public bool isQuestion;

		// Token: 0x04004904 RID: 18692
		public bool sentByPlayer;

		// Token: 0x04004905 RID: 18693
		public bool isSystemMessage;

		// Token: 0x04004906 RID: 18694
		[Header("== Question Related ==")]
		public string OptionQ;

		// Token: 0x04004907 RID: 18695
		public string OptionR;

		// Token: 0x04004908 RID: 18696
		public string OptionF;

		// Token: 0x04004909 RID: 18697
		[Space(20f)]
		public string ReactionQ;

		// Token: 0x0400490A RID: 18698
		public string ReactionR;

		// Token: 0x0400490B RID: 18699
		public string ReactionF;
	}
}
