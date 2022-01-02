using System;
using System.Collections.Generic;

// Token: 0x020003F9 RID: 1017
[Serializable]
public class MissionModeSaveData
{
	// Token: 0x06001BF4 RID: 7156 RVA: 0x00143F5C File Offset: 0x0014215C
	public static MissionModeSaveData ReadFromGlobals()
	{
		MissionModeSaveData missionModeSaveData = new MissionModeSaveData();
		foreach (int num in MissionModeGlobals.KeysOfMissionCondition())
		{
			missionModeSaveData.missionCondition.Add(num, MissionModeGlobals.GetMissionCondition(num));
		}
		missionModeSaveData.missionDifficulty = MissionModeGlobals.MissionDifficulty;
		missionModeSaveData.missionMode = MissionModeGlobals.MissionMode;
		missionModeSaveData.missionRequiredClothing = MissionModeGlobals.MissionRequiredClothing;
		missionModeSaveData.missionRequiredDisposal = MissionModeGlobals.MissionRequiredDisposal;
		missionModeSaveData.missionRequiredWeapon = MissionModeGlobals.MissionRequiredWeapon;
		missionModeSaveData.missionTarget = MissionModeGlobals.MissionTarget;
		missionModeSaveData.missionTargetName = MissionModeGlobals.MissionTargetName;
		missionModeSaveData.nemesisDifficulty = MissionModeGlobals.NemesisDifficulty;
		return missionModeSaveData;
	}

	// Token: 0x06001BF5 RID: 7157 RVA: 0x00143FF4 File Offset: 0x001421F4
	public static void WriteToGlobals(MissionModeSaveData data)
	{
		foreach (KeyValuePair<int, int> keyValuePair in data.missionCondition)
		{
			MissionModeGlobals.SetMissionCondition(keyValuePair.Key, keyValuePair.Value);
		}
		MissionModeGlobals.MissionDifficulty = data.missionDifficulty;
		MissionModeGlobals.MissionMode = data.missionMode;
		MissionModeGlobals.MissionRequiredClothing = data.missionRequiredClothing;
		MissionModeGlobals.MissionRequiredDisposal = data.missionRequiredDisposal;
		MissionModeGlobals.MissionRequiredWeapon = data.missionRequiredWeapon;
		MissionModeGlobals.MissionTarget = data.missionTarget;
		MissionModeGlobals.MissionTargetName = data.missionTargetName;
		MissionModeGlobals.NemesisDifficulty = data.nemesisDifficulty;
	}

	// Token: 0x04003105 RID: 12549
	public IntAndIntDictionary missionCondition = new IntAndIntDictionary();

	// Token: 0x04003106 RID: 12550
	public int missionDifficulty;

	// Token: 0x04003107 RID: 12551
	public bool missionMode;

	// Token: 0x04003108 RID: 12552
	public int missionRequiredClothing;

	// Token: 0x04003109 RID: 12553
	public int missionRequiredDisposal;

	// Token: 0x0400310A RID: 12554
	public int missionRequiredWeapon;

	// Token: 0x0400310B RID: 12555
	public int missionTarget;

	// Token: 0x0400310C RID: 12556
	public string missionTargetName = string.Empty;

	// Token: 0x0400310D RID: 12557
	public int nemesisDifficulty;
}
