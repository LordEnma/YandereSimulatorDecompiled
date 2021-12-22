using System;

// Token: 0x020003F3 RID: 1011
[Serializable]
public class ConversationSaveData
{
	// Token: 0x06001BE0 RID: 7136 RVA: 0x001435D4 File Offset: 0x001417D4
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

	// Token: 0x06001BE1 RID: 7137 RVA: 0x00143654 File Offset: 0x00141854
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

	// Token: 0x040030E7 RID: 12519
	public IntHashSet topicDiscovered = new IntHashSet();

	// Token: 0x040030E8 RID: 12520
	public IntAndIntPairHashSet topicLearnedByStudent = new IntAndIntPairHashSet();
}
