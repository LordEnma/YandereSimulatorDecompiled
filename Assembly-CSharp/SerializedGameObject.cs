using System;

// Token: 0x0200050E RID: 1294
[Serializable]
public struct SerializedGameObject
{
	// Token: 0x04004973 RID: 18803
	public bool ActiveInHierarchy;

	// Token: 0x04004974 RID: 18804
	public bool ActiveSelf;

	// Token: 0x04004975 RID: 18805
	public bool IsStatic;

	// Token: 0x04004976 RID: 18806
	public int Layer;

	// Token: 0x04004977 RID: 18807
	public string Tag;

	// Token: 0x04004978 RID: 18808
	public string Name;

	// Token: 0x04004979 RID: 18809
	public string ObjectID;

	// Token: 0x0400497A RID: 18810
	public SerializedComponent[] SerializedComponents;
}
