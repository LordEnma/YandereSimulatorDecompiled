using System;

[Serializable]
public class ArrayLayout
{
	[Serializable]
	public struct rowData
	{
		public bool[] row;
	}

	public rowData[] rows = new rowData[6];
}
