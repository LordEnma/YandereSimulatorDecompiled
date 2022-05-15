using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x0200052A RID: 1322
	[Serializable]
	public class NewTextMessage
	{
		// Token: 0x04004A37 RID: 18999
		public string Message;

		// Token: 0x04004A38 RID: 19000
		public bool isQuestion;

		// Token: 0x04004A39 RID: 19001
		public bool sentByPlayer;

		// Token: 0x04004A3A RID: 19002
		public bool isSystemMessage;

		// Token: 0x04004A3B RID: 19003
		[Header("== Question Related ==")]
		public string OptionQ;

		// Token: 0x04004A3C RID: 19004
		public string OptionR;

		// Token: 0x04004A3D RID: 19005
		public string OptionF;

		// Token: 0x04004A3E RID: 19006
		[Space(20f)]
		public string ReactionQ;

		// Token: 0x04004A3F RID: 19007
		public string ReactionR;

		// Token: 0x04004A40 RID: 19008
		public string ReactionF;
	}
}
