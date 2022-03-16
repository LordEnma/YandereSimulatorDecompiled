using System;

// Token: 0x0200050C RID: 1292
[Serializable]
public struct YanSaveData
{
	// Token: 0x04004965 RID: 18789
	public string LoadedLevelName;

	// Token: 0x04004966 RID: 18790
	public SerializedGameObject[] SerializedGameObjects;

	// Token: 0x04004967 RID: 18791
	public SerializedStaticClass[] SerializedStaticClasses;

	// Token: 0x04004968 RID: 18792
	public ValueDict SerializedPlayerPrefs;
}
