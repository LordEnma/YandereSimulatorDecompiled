using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x0200051E RID: 1310
	[Serializable]
	public class NewTextMessage
	{
		// Token: 0x04004953 RID: 18771
		public string Message;

		// Token: 0x04004954 RID: 18772
		public bool isQuestion;

		// Token: 0x04004955 RID: 18773
		public bool sentByPlayer;

		// Token: 0x04004956 RID: 18774
		public bool isSystemMessage;

		// Token: 0x04004957 RID: 18775
		[Header("== Question Related ==")]
		public string OptionQ;

		// Token: 0x04004958 RID: 18776
		public string OptionR;

		// Token: 0x04004959 RID: 18777
		public string OptionF;

		// Token: 0x0400495A RID: 18778
		[Space(20f)]
		public string ReactionQ;

		// Token: 0x0400495B RID: 18779
		public string ReactionR;

		// Token: 0x0400495C RID: 18780
		public string ReactionF;
	}
}
