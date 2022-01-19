using System;

// Token: 0x020003F6 RID: 1014
[Serializable]
public class ConversationSaveData
{
	// Token: 0x06001BEB RID: 7147 RVA: 0x0014544C File Offset: 0x0014364C
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

	// Token: 0x06001BEC RID: 7148 RVA: 0x001454CC File Offset: 0x001436CC
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

	// Token: 0x040030F9 RID: 12537
	public IntHashSet topicDiscovered = new IntHashSet();

	// Token: 0x040030FA RID: 12538
	public IntAndIntPairHashSet topicLearnedByStudent = new IntAndIntPairHashSet();
}
