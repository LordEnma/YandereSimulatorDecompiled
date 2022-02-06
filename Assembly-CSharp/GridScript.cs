using System;
using UnityEngine;

// Token: 0x02000307 RID: 775
public class GridScript : MonoBehaviour
{
	// Token: 0x06001821 RID: 6177 RVA: 0x000E4B20 File Offset: 0x000E2D20
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

	// Token: 0x04002304 RID: 8964
	public GameObject Tile;

	// Token: 0x04002305 RID: 8965
	public int Row;

	// Token: 0x04002306 RID: 8966
	public int Column;

	// Token: 0x04002307 RID: 8967
	public int Rows = 25;

	// Token: 0x04002308 RID: 8968
	public int Columns = 25;

	// Token: 0x04002309 RID: 8969
	public int ID;
}
