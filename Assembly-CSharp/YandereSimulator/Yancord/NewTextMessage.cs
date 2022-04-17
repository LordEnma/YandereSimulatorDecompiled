using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x02000528 RID: 1320
	[Serializable]
	public class NewTextMessage
	{
		// Token: 0x040049FA RID: 18938
		public string Message;

		// Token: 0x040049FB RID: 18939
		public bool isQuestion;

		// Token: 0x040049FC RID: 18940
		public bool sentByPlayer;

		// Token: 0x040049FD RID: 18941
		public bool isSystemMessage;

		// Token: 0x040049FE RID: 18942
		[Header("== Question Related ==")]
		public string OptionQ;

		// Token: 0x040049FF RID: 18943
		public string OptionR;

		// Token: 0x04004A00 RID: 18944
		public string OptionF;

		// Token: 0x04004A01 RID: 18945
		[Space(20f)]
		public string ReactionQ;

		// Token: 0x04004A02 RID: 18946
		public string ReactionR;

		// Token: 0x04004A03 RID: 18947
		public string ReactionF;
	}
}
