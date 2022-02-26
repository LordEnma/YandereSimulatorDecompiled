using System;

// Token: 0x020003F8 RID: 1016
[Serializable]
public class ConversationSaveData
{
	// Token: 0x06001BFE RID: 7166 RVA: 0x001468A4 File Offset: 0x00144AA4
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

	// Token: 0x06001BFF RID: 7167 RVA: 0x00146924 File Offset: 0x00144B24
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

	// Token: 0x04003119 RID: 12569
	public IntHashSet topicDiscovered = new IntHashSet();

	// Token: 0x0400311A RID: 12570
	public IntAndIntPairHashSet topicLearnedByStudent = new IntAndIntPairHashSet();
}
