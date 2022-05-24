using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x0200052A RID: 1322
	[Serializable]
	public class NewTextMessage
	{
		// Token: 0x04004A40 RID: 19008
		public string Message;

		// Token: 0x04004A41 RID: 19009
		public bool isQuestion;

		// Token: 0x04004A42 RID: 19010
		public bool sentByPlayer;

		// Token: 0x04004A43 RID: 19011
		public bool isSystemMessage;

		// Token: 0x04004A44 RID: 19012
		[Header("== Question Related ==")]
		public string OptionQ;

		// Token: 0x04004A45 RID: 19013
		public string OptionR;

		// Token: 0x04004A46 RID: 19014
		public string OptionF;

		// Token: 0x04004A47 RID: 19015
		[Space(20f)]
		public string ReactionQ;

		// Token: 0x04004A48 RID: 19016
		public string ReactionR;

		// Token: 0x04004A49 RID: 19017
		public string ReactionF;
	}
}
