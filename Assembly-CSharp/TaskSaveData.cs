using System;
using System.Collections.Generic;

// Token: 0x0200040E RID: 1038
[Serializable]
public class TaskSaveData
{
	// Token: 0x06001C5B RID: 7259 RVA: 0x0014C0B0 File Offset: 0x0014A2B0
	public static TaskSaveData ReadFromGlobals()
	{
		TaskSaveData taskSaveData = new TaskSaveData();
		foreach (int num in TaskGlobals.KeysOfGuitarPhoto())
		{
			if (TaskGlobals.GetGuitarPhoto(num))
			{
				taskSaveData.guitarPhoto.Add(num);
			}
		}
		foreach (int num2 in TaskGlobals.KeysOfKittenPhoto())
		{
			if (TaskGlobals.GetKittenPhoto(num2))
			{
				taskSaveData.kittenPhoto.Add(num2);
			}
		}
		foreach (int num3 in TaskGlobals.KeysOfHorudaPhoto())
		{
			if (TaskGlobals.GetHorudaPhoto(num3))
			{
				taskSaveData.horudaPhoto.Add(num3);
			}
		}
		foreach (int num4 in TaskGlobals.KeysOfTaskStatus())
		{
			taskSaveData.taskStatus.Add(num4, TaskGlobals.GetTaskStatus(num4));
		}
		return taskSaveData;
	}

	// Token: 0x06001C5C RID: 7260 RVA: 0x0014C180 File Offset: 0x0014A380
	public static void WriteToGlobals(TaskSaveData data)
	{
		foreach (int photoID in data.kittenPhoto)
		{
			TaskGlobals.SetKittenPhoto(photoID, true);
		}
		foreach (int photoID2 in data.guitarPhoto)
		{
			TaskGlobals.SetGuitarPhoto(photoID2, true);
		}
		foreach (KeyValuePair<int, int> keyValuePair in data.taskStatus)
		{
			TaskGlobals.SetTaskStatus(keyValuePair.Key, keyValuePair.Value);
		}
	}

	// Token: 0x04003229 RID: 12841
	public IntHashSet guitarPhoto = new IntHashSet();

	// Token: 0x0400322A RID: 12842
	public IntHashSet kittenPhoto = new IntHashSet();

	// Token: 0x0400322B RID: 12843
	public IntHashSet horudaPhoto = new IntHashSet();

	// Token: 0x0400322C RID: 12844
	public IntAndIntDictionary taskStatus = new IntAndIntDictionary();
}
