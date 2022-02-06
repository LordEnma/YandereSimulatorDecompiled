using System;

// Token: 0x020000D5 RID: 213
[Serializable]
public class ArrayLayout
{
	// Token: 0x04000A87 RID: 2695
	public ArrayLayout.rowData[] rows = new ArrayLayout.rowData[6];

	// Token: 0x02000648 RID: 1608
	[Serializable]
	public struct rowData
	{
		// Token: 0x04004E9B RID: 20123
		public bool[] row;
	}
}
