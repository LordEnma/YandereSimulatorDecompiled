using System;

// Token: 0x020003F9 RID: 1017
[Serializable]
public class ConversationSaveData
{
	// Token: 0x06001C0D RID: 7181 RVA: 0x00147C84 File Offset: 0x00145E84
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

	// Token: 0x06001C0E RID: 7182 RVA: 0x00147D04 File Offset: 0x00145F04
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

	// Token: 0x04003163 RID: 12643
	public IntHashSet topicDiscovered = new IntHashSet();

	// Token: 0x04003164 RID: 12644
	public IntAndIntPairHashSet topicLearnedByStudent = new IntAndIntPairHashSet();
}
