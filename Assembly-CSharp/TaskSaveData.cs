using System;
using System.Collections.Generic;

// Token: 0x02000408 RID: 1032
[Serializable]
public class TaskSaveData
{
	// Token: 0x06001C3A RID: 7226 RVA: 0x00149A44 File Offset: 0x00147C44
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

	// Token: 0x06001C3B RID: 7227 RVA: 0x00149B14 File Offset: 0x00147D14
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

	// Token: 0x040031DE RID: 12766
	public IntHashSet guitarPhoto = new IntHashSet();

	// Token: 0x040031DF RID: 12767
	public IntHashSet kittenPhoto = new IntHashSet();

	// Token: 0x040031E0 RID: 12768
	public IntHashSet horudaPhoto = new IntHashSet();

	// Token: 0x040031E1 RID: 12769
	public IntAndIntDictionary taskStatus = new IntAndIntDictionary();
}
