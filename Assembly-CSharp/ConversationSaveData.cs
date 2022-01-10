using System;

// Token: 0x020003F5 RID: 1013
[Serializable]
public class ConversationSaveData
{
	// Token: 0x06001BE9 RID: 7145 RVA: 0x00143D44 File Offset: 0x00141F44
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

	// Token: 0x06001BEA RID: 7146 RVA: 0x00143DC4 File Offset: 0x00141FC4
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

	// Token: 0x040030F4 RID: 12532
	public IntHashSet topicDiscovered = new IntHashSet();

	// Token: 0x040030F5 RID: 12533
	public IntAndIntPairHashSet topicLearnedByStudent = new IntAndIntPairHashSet();
}
