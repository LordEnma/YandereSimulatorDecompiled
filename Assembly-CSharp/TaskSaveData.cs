using System;
using System.Collections.Generic;

// Token: 0x02000404 RID: 1028
[Serializable]
public class TaskSaveData
{
	// Token: 0x06001C16 RID: 7190 RVA: 0x00145B04 File Offset: 0x00143D04
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

	// Token: 0x06001C17 RID: 7191 RVA: 0x00145BD4 File Offset: 0x00143DD4
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

	// Token: 0x0400316F RID: 12655
	public IntHashSet guitarPhoto = new IntHashSet();

	// Token: 0x04003170 RID: 12656
	public IntHashSet kittenPhoto = new IntHashSet();

	// Token: 0x04003171 RID: 12657
	public IntHashSet horudaPhoto = new IntHashSet();

	// Token: 0x04003172 RID: 12658
	public IntAndIntDictionary taskStatus = new IntAndIntDictionary();
}
