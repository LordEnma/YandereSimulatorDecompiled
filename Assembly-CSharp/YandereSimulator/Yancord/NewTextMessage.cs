using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x02000527 RID: 1319
	[Serializable]
	public class NewTextMessage
	{
		// Token: 0x040049E4 RID: 18916
		public string Message;

		// Token: 0x040049E5 RID: 18917
		public bool isQuestion;

		// Token: 0x040049E6 RID: 18918
		public bool sentByPlayer;

		// Token: 0x040049E7 RID: 18919
		public bool isSystemMessage;

		// Token: 0x040049E8 RID: 18920
		[Header("== Question Related ==")]
		public string OptionQ;

		// Token: 0x040049E9 RID: 18921
		public string OptionR;

		// Token: 0x040049EA RID: 18922
		public string OptionF;

		// Token: 0x040049EB RID: 18923
		[Space(20f)]
		public string ReactionQ;

		// Token: 0x040049EC RID: 18924
		public string ReactionR;

		// Token: 0x040049ED RID: 18925
		public string ReactionF;
	}
}
