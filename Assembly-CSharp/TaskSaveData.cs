using System;
using System.Collections.Generic;

// Token: 0x02000401 RID: 1025
[Serializable]
public class TaskSaveData
{
	// Token: 0x06001C05 RID: 7173 RVA: 0x00144AD4 File Offset: 0x00142CD4
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

	// Token: 0x06001C06 RID: 7174 RVA: 0x00144BA4 File Offset: 0x00142DA4
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

	// Token: 0x04003138 RID: 12600
	public IntHashSet guitarPhoto = new IntHashSet();

	// Token: 0x04003139 RID: 12601
	public IntHashSet kittenPhoto = new IntHashSet();

	// Token: 0x0400313A RID: 12602
	public IntHashSet horudaPhoto = new IntHashSet();

	// Token: 0x0400313B RID: 12603
	public IntAndIntDictionary taskStatus = new IntAndIntDictionary();
}
