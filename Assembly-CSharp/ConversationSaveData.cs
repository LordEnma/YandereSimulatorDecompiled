using System;

// Token: 0x020003FC RID: 1020
[Serializable]
public class ConversationSaveData
{
	// Token: 0x06001C17 RID: 7191 RVA: 0x00148740 File Offset: 0x00146940
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

	// Token: 0x06001C18 RID: 7192 RVA: 0x001487C0 File Offset: 0x001469C0
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

	// Token: 0x0400317C RID: 12668
	public IntHashSet topicDiscovered = new IntHashSet();

	// Token: 0x0400317D RID: 12669
	public IntAndIntPairHashSet topicLearnedByStudent = new IntAndIntPairHashSet();
}
