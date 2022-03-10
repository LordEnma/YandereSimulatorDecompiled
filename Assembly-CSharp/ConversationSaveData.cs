using System;

// Token: 0x020003F8 RID: 1016
[Serializable]
public class ConversationSaveData
{
	// Token: 0x06001C00 RID: 7168 RVA: 0x00146DE0 File Offset: 0x00144FE0
	public static ConversationSaveData ReadFromGlobals()
	{
		ConversationSaveData conversationSaveData = new ConversationSaveData();
		foreach (int num in ConversationGlobals.KeysOfTopicDiscovered())
		{
			if (ConversationGlobals.GetTopicDiscovered(num))
			{
				conversationSaveData.topicDiscovered.Add(num);
			}
		}
		foreach (IntAndIntPair intAndIntPair in ConversationGlobals.KeysOfTopicLearnedByStudent())
		{
			if (ConversationGlobals.GetTopicLearnedByStudent(intAndIntPair.first, intAndIntPair.second))
			{
				conversationSaveData.topicLearnedByStudent.Add(intAndIntPair);
			}
		}
		return conversationSaveData;
	}

	// Token: 0x06001C01 RID: 7169 RVA: 0x00146E60 File Offset: 0x00145060
	public static void WriteToGlobals(ConversationSaveData data)
	{
		foreach (int topicID in data.topicDiscovered)
		{
			ConversationGlobals.SetTopicDiscovered(topicID, true);
		}
		foreach (IntAndIntPair intAndIntPair in data.topicLearnedByStudent)
		{
			ConversationGlobals.SetTopicLearnedByStudent(intAndIntPair.first, intAndIntPair.second, true);
		}
	}

	// Token: 0x0400312F RID: 12591
	public IntHashSet topicDiscovered = new IntHashSet();

	// Token: 0x04003130 RID: 12592
	public IntAndIntPairHashSet topicLearnedByStudent = new IntAndIntPairHashSet();
}
