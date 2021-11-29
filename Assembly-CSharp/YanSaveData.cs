using System;

// Token: 0x02000500 RID: 1280
[Serializable]
public struct YanSaveData
{
	// Token: 0x04004859 RID: 18521
	public string LoadedLevelName;

	// Token: 0x0400485A RID: 18522
	public SerializedGameObject[] SerializedGameObjects;

	// Token: 0x0400485B RID: 18523
	public SerializedStaticClass[] SerializedStaticClasses;

	// Token: 0x0400485C RID: 18524
	public ValueDict SerializedPlayerPrefs;
}
