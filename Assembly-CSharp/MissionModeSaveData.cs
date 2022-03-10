using System;
using System.Collections.Generic;

// Token: 0x020003FE RID: 1022
[Serializable]
public class MissionModeSaveData
{
	// Token: 0x06001C12 RID: 7186 RVA: 0x0014736C File Offset: 0x0014556C
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

	// Token: 0x06001C13 RID: 7187 RVA: 0x00147404 File Offset: 0x00145604
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

	// Token: 0x04003146 RID: 12614
	public IntAndIntDictionary missionCondition = new IntAndIntDictionary();

	// Token: 0x04003147 RID: 12615
	public int missionDifficulty;

	// Token: 0x04003148 RID: 12616
	public bool missionMode;

	// Token: 0x04003149 RID: 12617
	public int missionRequiredClothing;

	// Token: 0x0400314A RID: 12618
	public int missionRequiredDisposal;

	// Token: 0x0400314B RID: 12619
	public int missionRequiredWeapon;

	// Token: 0x0400314C RID: 12620
	public int missionTarget;

	// Token: 0x0400314D RID: 12621
	public string missionTargetName = string.Empty;

	// Token: 0x0400314E RID: 12622
	public int nemesisDifficulty;
}
