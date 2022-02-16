using System;

// Token: 0x020003F7 RID: 1015
[Serializable]
public class ConversationSaveData
{
	// Token: 0x06001BF5 RID: 7157 RVA: 0x00145E2C File Offset: 0x0014402C
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

	// Token: 0x06001BF6 RID: 7158 RVA: 0x00145EAC File Offset: 0x001440AC
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

	// Token: 0x04003109 RID: 12553
	public IntHashSet topicDiscovered = new IntHashSet();

	// Token: 0x0400310A RID: 12554
	public IntAndIntPairHashSet topicLearnedByStudent = new IntAndIntPairHashSet();
}
