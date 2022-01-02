using System;

// Token: 0x02000502 RID: 1282
[Serializable]
public struct YanSaveData
{
	// Token: 0x040048A1 RID: 18593
	public string LoadedLevelName;

	// Token: 0x040048A2 RID: 18594
	public SerializedGameObject[] SerializedGameObjects;

	// Token: 0x040048A3 RID: 18595
	public SerializedStaticClass[] SerializedStaticClasses;

	// Token: 0x040048A4 RID: 18596
	public ValueDict SerializedPlayerPrefs;
}
