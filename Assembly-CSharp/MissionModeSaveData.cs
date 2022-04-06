using System;
using System.Collections.Generic;

// Token: 0x02000403 RID: 1027
[Serializable]
public class MissionModeSaveData
{
	// Token: 0x06001C2F RID: 7215 RVA: 0x00148FB0 File Offset: 0x001471B0
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

	// Token: 0x06001C30 RID: 7216 RVA: 0x00149048 File Offset: 0x00147248
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

	// Token: 0x04003196 RID: 12694
	public IntAndIntDictionary missionCondition = new IntAndIntDictionary();

	// Token: 0x04003197 RID: 12695
	public int missionDifficulty;

	// Token: 0x04003198 RID: 12696
	public bool missionMode;

	// Token: 0x04003199 RID: 12697
	public int missionRequiredClothing;

	// Token: 0x0400319A RID: 12698
	public int missionRequiredDisposal;

	// Token: 0x0400319B RID: 12699
	public int missionRequiredWeapon;

	// Token: 0x0400319C RID: 12700
	public int missionTarget;

	// Token: 0x0400319D RID: 12701
	public string missionTargetName = string.Empty;

	// Token: 0x0400319E RID: 12702
	public int nemesisDifficulty;
}
