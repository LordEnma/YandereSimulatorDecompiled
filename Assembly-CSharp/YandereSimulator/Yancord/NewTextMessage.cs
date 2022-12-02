using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	[Serializable]
	public class NewTextMessage
	{
		public string Message;

		public bool isQuestion;

		public bool sentByPlayer;

		public bool isSystemMessage;

		[Header("== Question Related ==")]
		public string OptionQ;

		public string OptionR;

		public string OptionF;

		[Space(20f)]
		public string ReactionQ;

		public string ReactionR;

		public string ReactionF;
	}
}
