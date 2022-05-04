using System;
using System.Collections.Generic;

// Token: 0x0200040D RID: 1037
[Serializable]
public class TaskSaveData
{
	// Token: 0x06001C55 RID: 7253 RVA: 0x0014B3FC File Offset: 0x001495FC
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

	// Token: 0x06001C56 RID: 7254 RVA: 0x0014B4CC File Offset: 0x001496CC
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

	// Token: 0x04003214 RID: 12820
	public IntHashSet guitarPhoto = new IntHashSet();

	// Token: 0x04003215 RID: 12821
	public IntHashSet kittenPhoto = new IntHashSet();

	// Token: 0x04003216 RID: 12822
	public IntHashSet horudaPhoto = new IntHashSet();

	// Token: 0x04003217 RID: 12823
	public IntAndIntDictionary taskStatus = new IntAndIntDictionary();
}
