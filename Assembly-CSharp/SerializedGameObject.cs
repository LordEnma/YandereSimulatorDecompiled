using System;

// Token: 0x02000507 RID: 1287
[Serializable]
public struct SerializedGameObject
{
	// Token: 0x040048CA RID: 18634
	public bool ActiveInHierarchy;

	// Token: 0x040048CB RID: 18635
	public bool ActiveSelf;

	// Token: 0x040048CC RID: 18636
	public bool IsStatic;

	// Token: 0x040048CD RID: 18637
	public int Layer;

	// Token: 0x040048CE RID: 18638
	public string Tag;

	// Token: 0x040048CF RID: 18639
	public string Name;

	// Token: 0x040048D0 RID: 18640
	public string ObjectID;

	// Token: 0x040048D1 RID: 18641
	public SerializedComponent[] SerializedComponents;
}
