using System;

// Token: 0x02000505 RID: 1285
[Serializable]
public struct YanSaveData
{
	// Token: 0x040048CD RID: 18637
	public string LoadedLevelName;

	// Token: 0x040048CE RID: 18638
	public SerializedGameObject[] SerializedGameObjects;

	// Token: 0x040048CF RID: 18639
	public SerializedStaticClass[] SerializedStaticClasses;

	// Token: 0x040048D0 RID: 18640
	public ValueDict SerializedPlayerPrefs;
}
