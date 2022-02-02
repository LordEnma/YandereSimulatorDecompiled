using System;
using System.Collections.Generic;

// Token: 0x02000405 RID: 1029
[Serializable]
public class TaskSaveData
{
	// Token: 0x06001C19 RID: 7193 RVA: 0x00147650 File Offset: 0x00145850
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

	// Token: 0x06001C1A RID: 7194 RVA: 0x00147720 File Offset: 0x00145920
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

	// Token: 0x0400317A RID: 12666
	public IntHashSet guitarPhoto = new IntHashSet();

	// Token: 0x0400317B RID: 12667
	public IntHashSet kittenPhoto = new IntHashSet();

	// Token: 0x0400317C RID: 12668
	public IntHashSet horudaPhoto = new IntHashSet();

	// Token: 0x0400317D RID: 12669
	public IntAndIntDictionary taskStatus = new IntAndIntDictionary();
}
