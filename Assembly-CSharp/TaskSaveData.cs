using System;
using System.Collections.Generic;

// Token: 0x02000406 RID: 1030
[Serializable]
public class TaskSaveData
{
	// Token: 0x06001C22 RID: 7202 RVA: 0x00147BEC File Offset: 0x00145DEC
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

	// Token: 0x06001C23 RID: 7203 RVA: 0x00147CBC File Offset: 0x00145EBC
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

	// Token: 0x04003184 RID: 12676
	public IntHashSet guitarPhoto = new IntHashSet();

	// Token: 0x04003185 RID: 12677
	public IntHashSet kittenPhoto = new IntHashSet();

	// Token: 0x04003186 RID: 12678
	public IntHashSet horudaPhoto = new IntHashSet();

	// Token: 0x04003187 RID: 12679
	public IntAndIntDictionary taskStatus = new IntAndIntDictionary();
}
