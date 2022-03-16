using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x02000522 RID: 1314
	[Serializable]
	public class NewTextMessage
	{
		// Token: 0x040049B2 RID: 18866
		public string Message;

		// Token: 0x040049B3 RID: 18867
		public bool isQuestion;

		// Token: 0x040049B4 RID: 18868
		public bool sentByPlayer;

		// Token: 0x040049B5 RID: 18869
		public bool isSystemMessage;

		// Token: 0x040049B6 RID: 18870
		[Header("== Question Related ==")]
		public string OptionQ;

		// Token: 0x040049B7 RID: 18871
		public string OptionR;

		// Token: 0x040049B8 RID: 18872
		public string OptionF;

		// Token: 0x040049B9 RID: 18873
		[Space(20f)]
		public string ReactionQ;

		// Token: 0x040049BA RID: 18874
		public string ReactionR;

		// Token: 0x040049BB RID: 18875
		public string ReactionF;
	}
}
