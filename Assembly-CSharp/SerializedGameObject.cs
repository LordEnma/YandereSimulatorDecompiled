using System;

// Token: 0x02000507 RID: 1287
[Serializable]
public struct SerializedGameObject
{
	// Token: 0x040048D5 RID: 18645
	public bool ActiveInHierarchy;

	// Token: 0x040048D6 RID: 18646
	public bool ActiveSelf;

	// Token: 0x040048D7 RID: 18647
	public bool IsStatic;

	// Token: 0x040048D8 RID: 18648
	public int Layer;

	// Token: 0x040048D9 RID: 18649
	public string Tag;

	// Token: 0x040048DA RID: 18650
	public string Name;

	// Token: 0x040048DB RID: 18651
	public string ObjectID;

	// Token: 0x040048DC RID: 18652
	public SerializedComponent[] SerializedComponents;
}
