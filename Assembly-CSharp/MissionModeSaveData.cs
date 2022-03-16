using System;
using System.Collections.Generic;

// Token: 0x020003FF RID: 1023
[Serializable]
public class MissionModeSaveData
{
	// Token: 0x06001C1F RID: 7199 RVA: 0x00148210 File Offset: 0x00146410
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

	// Token: 0x06001C20 RID: 7200 RVA: 0x001482A8 File Offset: 0x001464A8
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

	// Token: 0x0400317A RID: 12666
	public IntAndIntDictionary missionCondition = new IntAndIntDictionary();

	// Token: 0x0400317B RID: 12667
	public int missionDifficulty;

	// Token: 0x0400317C RID: 12668
	public bool missionMode;

	// Token: 0x0400317D RID: 12669
	public int missionRequiredClothing;

	// Token: 0x0400317E RID: 12670
	public int missionRequiredDisposal;

	// Token: 0x0400317F RID: 12671
	public int missionRequiredWeapon;

	// Token: 0x04003180 RID: 12672
	public int missionTarget;

	// Token: 0x04003181 RID: 12673
	public string missionTargetName = string.Empty;

	// Token: 0x04003182 RID: 12674
	public int nemesisDifficulty;
}
