using System;
using System.Collections.Generic;

// Token: 0x02000405 RID: 1029
[Serializable]
public class TaskSaveData
{
	// Token: 0x06001C18 RID: 7192 RVA: 0x0014720C File Offset: 0x0014540C
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

	// Token: 0x06001C19 RID: 7193 RVA: 0x001472DC File Offset: 0x001454DC
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

	// Token: 0x04003174 RID: 12660
	public IntHashSet guitarPhoto = new IntHashSet();

	// Token: 0x04003175 RID: 12661
	public IntHashSet kittenPhoto = new IntHashSet();

	// Token: 0x04003176 RID: 12662
	public IntHashSet horudaPhoto = new IntHashSet();

	// Token: 0x04003177 RID: 12663
	public IntAndIntDictionary taskStatus = new IntAndIntDictionary();
}
