using System;
using System.Collections.Generic;

// Token: 0x02000404 RID: 1028
[Serializable]
public class MissionModeSaveData
{
	// Token: 0x06001C3A RID: 7226 RVA: 0x00149BFC File Offset: 0x00147DFC
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

	// Token: 0x06001C3B RID: 7227 RVA: 0x00149C94 File Offset: 0x00147E94
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

	// Token: 0x040031B0 RID: 12720
	public IntAndIntDictionary missionCondition = new IntAndIntDictionary();

	// Token: 0x040031B1 RID: 12721
	public int missionDifficulty;

	// Token: 0x040031B2 RID: 12722
	public bool missionMode;

	// Token: 0x040031B3 RID: 12723
	public int missionRequiredClothing;

	// Token: 0x040031B4 RID: 12724
	public int missionRequiredDisposal;

	// Token: 0x040031B5 RID: 12725
	public int missionRequiredWeapon;

	// Token: 0x040031B6 RID: 12726
	public int missionTarget;

	// Token: 0x040031B7 RID: 12727
	public string missionTargetName = string.Empty;

	// Token: 0x040031B8 RID: 12728
	public int nemesisDifficulty;
}
