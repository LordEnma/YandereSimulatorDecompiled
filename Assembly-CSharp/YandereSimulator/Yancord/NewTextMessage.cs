using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x02000516 RID: 1302
	[Serializable]
	public class NewTextMessage
	{
		// Token: 0x040048A6 RID: 18598
		public string Message;

		// Token: 0x040048A7 RID: 18599
		public bool isQuestion;

		// Token: 0x040048A8 RID: 18600
		public bool sentByPlayer;

		// Token: 0x040048A9 RID: 18601
		public bool isSystemMessage;

		// Token: 0x040048AA RID: 18602
		[Header("== Question Related ==")]
		public string OptionQ;

		// Token: 0x040048AB RID: 18603
		public string OptionR;

		// Token: 0x040048AC RID: 18604
		public string OptionF;

		// Token: 0x040048AD RID: 18605
		[Space(20f)]
		public string ReactionQ;

		// Token: 0x040048AE RID: 18606
		public string ReactionR;

		// Token: 0x040048AF RID: 18607
		public string ReactionF;
	}
}
