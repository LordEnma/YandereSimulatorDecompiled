using System;
using System.Collections.Generic;

// Token: 0x02000402 RID: 1026
[Serializable]
public class TaskSaveData
{
	// Token: 0x06001C0F RID: 7183 RVA: 0x00145790 File Offset: 0x00143990
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

	// Token: 0x06001C10 RID: 7184 RVA: 0x00145860 File Offset: 0x00143A60
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

	// Token: 0x04003169 RID: 12649
	public IntHashSet guitarPhoto = new IntHashSet();

	// Token: 0x0400316A RID: 12650
	public IntHashSet kittenPhoto = new IntHashSet();

	// Token: 0x0400316B RID: 12651
	public IntHashSet horudaPhoto = new IntHashSet();

	// Token: 0x0400316C RID: 12652
	public IntAndIntDictionary taskStatus = new IntAndIntDictionary();
}
