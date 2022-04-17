using System;
using System.Collections.Generic;

// Token: 0x0200040C RID: 1036
[Serializable]
public class TaskSaveData
{
	// Token: 0x06001C4E RID: 7246 RVA: 0x0014ABF4 File Offset: 0x00148DF4
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

	// Token: 0x06001C4F RID: 7247 RVA: 0x0014ACC4 File Offset: 0x00148EC4
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

	// Token: 0x04003205 RID: 12805
	public IntHashSet guitarPhoto = new IntHashSet();

	// Token: 0x04003206 RID: 12806
	public IntHashSet kittenPhoto = new IntHashSet();

	// Token: 0x04003207 RID: 12807
	public IntHashSet horudaPhoto = new IntHashSet();

	// Token: 0x04003208 RID: 12808
	public IntAndIntDictionary taskStatus = new IntAndIntDictionary();
}
