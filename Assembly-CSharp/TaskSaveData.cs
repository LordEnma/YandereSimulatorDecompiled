using System;
using System.Collections.Generic;

// Token: 0x02000405 RID: 1029
[Serializable]
public class TaskSaveData
{
	// Token: 0x06001C1B RID: 7195 RVA: 0x001478EC File Offset: 0x00145AEC
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

	// Token: 0x06001C1C RID: 7196 RVA: 0x001479BC File Offset: 0x00145BBC
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

	// Token: 0x0400317E RID: 12670
	public IntHashSet guitarPhoto = new IntHashSet();

	// Token: 0x0400317F RID: 12671
	public IntHashSet kittenPhoto = new IntHashSet();

	// Token: 0x04003180 RID: 12672
	public IntHashSet horudaPhoto = new IntHashSet();

	// Token: 0x04003181 RID: 12673
	public IntAndIntDictionary taskStatus = new IntAndIntDictionary();
}
