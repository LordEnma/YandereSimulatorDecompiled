using System;

[Serializable]
public class ConversationSaveData
{
	public IntHashSet topicDiscovered = new IntHashSet();

	public IntAndIntPairHashSet topicLearnedByStudent = new IntAndIntPairHashSet();

	public static ConversationSaveData ReadFromGlobals()
	{
		ConversationSaveData conversationSaveData = new ConversationSaveData();
		int[] array = ConversationGlobals.KeysOfTopicDiscovered();
		foreach (int num in array)
		{
			if (ConversationGlobals.GetTopicDiscovered(num))
			{
				conversationSaveData.topicDiscovered.Add(num);
			}
		}
		IntAndIntPair[] array2 = ConversationGlobals.KeysOfTopicLearnedByStudent();
		foreach (IntAndIntPair intAndIntPair in array2)
		{
			if (ConversationGlobals.GetTopicLearnedByStudent(intAndIntPair.first, intAndIntPair.second))
			{
				conversationSaveData.topicLearnedByStudent.Add(intAndIntPair);
			}
		}
		return conversationSaveData;
	}

	public static void WriteToGlobals(ConversationSaveData data)
	{
		foreach (int item in data.topicDiscovered)
		{
			ConversationGlobals.SetTopicDiscovered(item, value: true);
		}
		foreach (IntAndIntPair item2 in data.topicLearnedByStudent)
		{
			ConversationGlobals.SetTopicLearnedByStudent(item2.first, item2.second, value: true);
		}
	}
}
