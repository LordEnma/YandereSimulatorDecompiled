using System;

// Token: 0x020003FD RID: 1021
[Serializable]
public class ConversationSaveData
{
	// Token: 0x06001C21 RID: 7201 RVA: 0x00148E34 File Offset: 0x00147034
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

	// Token: 0x06001C22 RID: 7202 RVA: 0x00148EB4 File Offset: 0x001470B4
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

	// Token: 0x0400318A RID: 12682
	public IntHashSet topicDiscovered = new IntHashSet();

	// Token: 0x0400318B RID: 12683
	public IntAndIntPairHashSet topicLearnedByStudent = new IntAndIntPairHashSet();
}
