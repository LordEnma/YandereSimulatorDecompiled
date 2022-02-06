using System;

// Token: 0x02000505 RID: 1285
[Serializable]
public struct YanSaveData
{
	// Token: 0x040048D0 RID: 18640
	public string LoadedLevelName;

	// Token: 0x040048D1 RID: 18641
	public SerializedGameObject[] SerializedGameObjects;

	// Token: 0x040048D2 RID: 18642
	public SerializedStaticClass[] SerializedStaticClasses;

	// Token: 0x040048D3 RID: 18643
	public ValueDict SerializedPlayerPrefs;
}
