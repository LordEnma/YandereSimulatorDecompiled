using System;

// Token: 0x0200050F RID: 1295
[Serializable]
public struct SerializedStaticClass
{
	// Token: 0x0400497B RID: 18811
	public string TypePath;

	// Token: 0x0400497C RID: 18812
	public ValueDict PropertyValues;

	// Token: 0x0400497D RID: 18813
	public ValueDict FieldValues;

	// Token: 0x0400497E RID: 18814
	public ReferenceDict PropertyReferences;

	// Token: 0x0400497F RID: 18815
	public ReferenceDict FieldReferences;

	// Token: 0x04004980 RID: 18816
	public ReferenceArrayDict PropertyReferenceArrays;

	// Token: 0x04004981 RID: 18817
	public ReferenceArrayDict FieldReferenceArrays;
}
