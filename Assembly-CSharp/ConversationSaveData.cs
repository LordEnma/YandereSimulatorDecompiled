using System;

// Token: 0x020003F3 RID: 1011
[Serializable]
public class ConversationSaveData
{
	// Token: 0x06001BE2 RID: 7138 RVA: 0x001439D0 File Offset: 0x00141BD0
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

	// Token: 0x06001BE3 RID: 7139 RVA: 0x00143A50 File Offset: 0x00141C50
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

	// Token: 0x040030EE RID: 12526
	public IntHashSet topicDiscovered = new IntHashSet();

	// Token: 0x040030EF RID: 12527
	public IntAndIntPairHashSet topicLearnedByStudent = new IntAndIntPairHashSet();
}
