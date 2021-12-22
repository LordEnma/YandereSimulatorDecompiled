using System;
using System.Collections.Generic;

// Token: 0x02000402 RID: 1026
[Serializable]
public class TaskSaveData
{
	// Token: 0x06001C0D RID: 7181 RVA: 0x00145394 File Offset: 0x00143594
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

	// Token: 0x06001C0E RID: 7182 RVA: 0x00145464 File Offset: 0x00143664
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

	// Token: 0x04003162 RID: 12642
	public IntHashSet guitarPhoto = new IntHashSet();

	// Token: 0x04003163 RID: 12643
	public IntHashSet kittenPhoto = new IntHashSet();

	// Token: 0x04003164 RID: 12644
	public IntHashSet horudaPhoto = new IntHashSet();

	// Token: 0x04003165 RID: 12645
	public IntAndIntDictionary taskStatus = new IntAndIntDictionary();
}
