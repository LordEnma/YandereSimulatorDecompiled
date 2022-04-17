using System;
using UnityEngine;

// Token: 0x0200030B RID: 779
public class GridScript : MonoBehaviour
{
	// Token: 0x06001846 RID: 6214 RVA: 0x000E65CC File Offset: 0x000E47CC
	private void Start()
	{
		while (this.ID < this.Rows * this.Columns)
		{
			UnityEngine.Object.Instantiate<GameObject>(this.Tile, new Vector3((float)this.Row, 0f, (float)this.Column), Quaternion.identity).transform.parent = base.transform;
			this.Row++;
			if (this.Row > this.Rows)
			{
				this.Row = 1;
				this.Column++;
			}
			this.ID++;
		}
		base.transform.localScale = new Vector3(4f, 4f, 4f);
		base.transform.position = new Vector3(-52f, 0f, -52f);
	}

	// Token: 0x04002351 RID: 9041
	public GameObject Tile;

	// Token: 0x04002352 RID: 9042
	public int Row;

	// Token: 0x04002353 RID: 9043
	public int Column;

	// Token: 0x04002354 RID: 9044
	public int Rows = 25;

	// Token: 0x04002355 RID: 9045
	public int Columns = 25;

	// Token: 0x04002356 RID: 9046
	public int ID;
}
