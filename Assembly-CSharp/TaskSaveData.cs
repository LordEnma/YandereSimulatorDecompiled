using System;
using System.Collections.Generic;

// Token: 0x0200040E RID: 1038
[Serializable]
public class TaskSaveData
{
	// Token: 0x06001C5C RID: 7260 RVA: 0x0014C36C File Offset: 0x0014A56C
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

	// Token: 0x06001C5D RID: 7261 RVA: 0x0014C43C File Offset: 0x0014A63C
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

	// Token: 0x04003231 RID: 12849
	public IntHashSet guitarPhoto = new IntHashSet();

	// Token: 0x04003232 RID: 12850
	public IntHashSet kittenPhoto = new IntHashSet();

	// Token: 0x04003233 RID: 12851
	public IntHashSet horudaPhoto = new IntHashSet();

	// Token: 0x04003234 RID: 12852
	public IntAndIntDictionary taskStatus = new IntAndIntDictionary();
}
