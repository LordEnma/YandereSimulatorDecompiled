using System;

// Token: 0x020003F6 RID: 1014
[Serializable]
public class ConversationSaveData
{
	// Token: 0x06001BEC RID: 7148 RVA: 0x00145890 File Offset: 0x00143A90
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

	// Token: 0x06001BED RID: 7149 RVA: 0x00145910 File Offset: 0x00143B10
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

	// Token: 0x040030FF RID: 12543
	public IntHashSet topicDiscovered = new IntHashSet();

	// Token: 0x04003100 RID: 12544
	public IntAndIntPairHashSet topicLearnedByStudent = new IntAndIntPairHashSet();
}
