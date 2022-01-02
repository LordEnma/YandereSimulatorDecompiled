using System;

// Token: 0x02000504 RID: 1284
[Serializable]
public struct SerializedGameObject
{
	// Token: 0x040048AF RID: 18607
	public bool ActiveInHierarchy;

	// Token: 0x040048B0 RID: 18608
	public bool ActiveSelf;

	// Token: 0x040048B1 RID: 18609
	public bool IsStatic;

	// Token: 0x040048B2 RID: 18610
	public int Layer;

	// Token: 0x040048B3 RID: 18611
	public string Tag;

	// Token: 0x040048B4 RID: 18612
	public string Name;

	// Token: 0x040048B5 RID: 18613
	public string ObjectID;

	// Token: 0x040048B6 RID: 18614
	public SerializedComponent[] SerializedComponents;
}
