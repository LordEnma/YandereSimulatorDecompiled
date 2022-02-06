using System;

// Token: 0x020003F6 RID: 1014
[Serializable]
public class ConversationSaveData
{
	// Token: 0x06001BEE RID: 7150 RVA: 0x00145B2C File Offset: 0x00143D2C
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

	// Token: 0x06001BEF RID: 7151 RVA: 0x00145BAC File Offset: 0x00143DAC
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

	// Token: 0x04003103 RID: 12547
	public IntHashSet topicDiscovered = new IntHashSet();

	// Token: 0x04003104 RID: 12548
	public IntAndIntPairHashSet topicLearnedByStudent = new IntAndIntPairHashSet();
}
