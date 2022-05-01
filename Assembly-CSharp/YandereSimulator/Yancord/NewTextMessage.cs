using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x02000529 RID: 1321
	[Serializable]
	public class NewTextMessage
	{
		// Token: 0x04004A10 RID: 18960
		public string Message;

		// Token: 0x04004A11 RID: 18961
		public bool isQuestion;

		// Token: 0x04004A12 RID: 18962
		public bool sentByPlayer;

		// Token: 0x04004A13 RID: 18963
		public bool isSystemMessage;

		// Token: 0x04004A14 RID: 18964
		[Header("== Question Related ==")]
		public string OptionQ;

		// Token: 0x04004A15 RID: 18965
		public string OptionR;

		// Token: 0x04004A16 RID: 18966
		public string OptionF;

		// Token: 0x04004A17 RID: 18967
		[Space(20f)]
		public string ReactionQ;

		// Token: 0x04004A18 RID: 18968
		public string ReactionR;

		// Token: 0x04004A19 RID: 18969
		public string ReactionF;
	}
}
