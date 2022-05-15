using System;

// Token: 0x020003FF RID: 1023
[Serializable]
public class ConversationSaveData
{
	// Token: 0x06001C2E RID: 7214 RVA: 0x0014A2F0 File Offset: 0x001484F0
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

	// Token: 0x06001C2F RID: 7215 RVA: 0x0014A370 File Offset: 0x00148570
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

	// Token: 0x040031AE RID: 12718
	public IntHashSet topicDiscovered = new IntHashSet();

	// Token: 0x040031AF RID: 12719
	public IntAndIntPairHashSet topicLearnedByStudent = new IntAndIntPairHashSet();
}
