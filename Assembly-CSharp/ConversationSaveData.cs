using System;

// Token: 0x020003FE RID: 1022
[Serializable]
public class ConversationSaveData
{
	// Token: 0x06001C28 RID: 7208 RVA: 0x0014963C File Offset: 0x0014783C
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

	// Token: 0x06001C29 RID: 7209 RVA: 0x001496BC File Offset: 0x001478BC
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

	// Token: 0x04003199 RID: 12697
	public IntHashSet topicDiscovered = new IntHashSet();

	// Token: 0x0400319A RID: 12698
	public IntAndIntPairHashSet topicLearnedByStudent = new IntAndIntPairHashSet();
}
