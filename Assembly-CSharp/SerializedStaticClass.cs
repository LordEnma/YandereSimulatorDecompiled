using System;

// Token: 0x0200050B RID: 1291
[Serializable]
public struct SerializedStaticClass
{
	// Token: 0x0400491C RID: 18716
	public string TypePath;

	// Token: 0x0400491D RID: 18717
	public ValueDict PropertyValues;

	// Token: 0x0400491E RID: 18718
	public ValueDict FieldValues;

	// Token: 0x0400491F RID: 18719
	public ReferenceDict PropertyReferences;

	// Token: 0x04004920 RID: 18720
	public ReferenceDict FieldReferences;

	// Token: 0x04004921 RID: 18721
	public ReferenceArrayDict PropertyReferenceArrays;

	// Token: 0x04004922 RID: 18722
	public ReferenceArrayDict FieldReferenceArrays;
}
