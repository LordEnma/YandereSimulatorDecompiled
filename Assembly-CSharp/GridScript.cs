using System;
using UnityEngine;

// Token: 0x0200030C RID: 780
public class GridScript : MonoBehaviour
{
	// Token: 0x0600184F RID: 6223 RVA: 0x000E6F10 File Offset: 0x000E5110
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

	// Token: 0x04002366 RID: 9062
	public GameObject Tile;

	// Token: 0x04002367 RID: 9063
	public int Row;

	// Token: 0x04002368 RID: 9064
	public int Column;

	// Token: 0x04002369 RID: 9065
	public int Rows = 25;

	// Token: 0x0400236A RID: 9066
	public int Columns = 25;

	// Token: 0x0400236B RID: 9067
	public int ID;
}
