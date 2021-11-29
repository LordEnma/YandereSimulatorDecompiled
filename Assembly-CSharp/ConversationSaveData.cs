using System;

// Token: 0x020003F2 RID: 1010
[Serializable]
public class ConversationSaveData
{
	// Token: 0x06001BD8 RID: 7128 RVA: 0x00142D14 File Offset: 0x00140F14
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

	// Token: 0x06001BD9 RID: 7129 RVA: 0x00142D94 File Offset: 0x00140F94
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

	// Token: 0x040030BD RID: 12477
	public IntHashSet topicDiscovered = new IntHashSet();

	// Token: 0x040030BE RID: 12478
	public IntAndIntPairHashSet topicLearnedByStudent = new IntAndIntPairHashSet();
}
