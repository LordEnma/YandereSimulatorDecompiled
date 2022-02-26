using System;

// Token: 0x02000509 RID: 1289
[Serializable]
public struct SerializedGameObject
{
	// Token: 0x040048F7 RID: 18679
	public bool ActiveInHierarchy;

	// Token: 0x040048F8 RID: 18680
	public bool ActiveSelf;

	// Token: 0x040048F9 RID: 18681
	public bool IsStatic;

	// Token: 0x040048FA RID: 18682
	public int Layer;

	// Token: 0x040048FB RID: 18683
	public string Tag;

	// Token: 0x040048FC RID: 18684
	public string Name;

	// Token: 0x040048FD RID: 18685
	public string ObjectID;

	// Token: 0x040048FE RID: 18686
	public SerializedComponent[] SerializedComponents;
}
