using System;
using System.Collections.Generic;

// Token: 0x02000405 RID: 1029
[Serializable]
public class MissionModeSaveData
{
	// Token: 0x06001C40 RID: 7232 RVA: 0x0014A87C File Offset: 0x00148A7C
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

	// Token: 0x06001C41 RID: 7233 RVA: 0x0014A914 File Offset: 0x00148B14
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

	// Token: 0x040031C5 RID: 12741
	public IntAndIntDictionary missionCondition = new IntAndIntDictionary();

	// Token: 0x040031C6 RID: 12742
	public int missionDifficulty;

	// Token: 0x040031C7 RID: 12743
	public bool missionMode;

	// Token: 0x040031C8 RID: 12744
	public int missionRequiredClothing;

	// Token: 0x040031C9 RID: 12745
	public int missionRequiredDisposal;

	// Token: 0x040031CA RID: 12746
	public int missionRequiredWeapon;

	// Token: 0x040031CB RID: 12747
	public int missionTarget;

	// Token: 0x040031CC RID: 12748
	public string missionTargetName = string.Empty;

	// Token: 0x040031CD RID: 12749
	public int nemesisDifficulty;
}
