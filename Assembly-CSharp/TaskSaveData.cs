using System;
using System.Collections.Generic;

// Token: 0x02000407 RID: 1031
[Serializable]
public class TaskSaveData
{
	// Token: 0x06001C2D RID: 7213 RVA: 0x00148BA0 File Offset: 0x00146DA0
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

	// Token: 0x06001C2E RID: 7214 RVA: 0x00148C70 File Offset: 0x00146E70
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

	// Token: 0x040031AA RID: 12714
	public IntHashSet guitarPhoto = new IntHashSet();

	// Token: 0x040031AB RID: 12715
	public IntHashSet kittenPhoto = new IntHashSet();

	// Token: 0x040031AC RID: 12716
	public IntHashSet horudaPhoto = new IntHashSet();

	// Token: 0x040031AD RID: 12717
	public IntAndIntDictionary taskStatus = new IntAndIntDictionary();
}
