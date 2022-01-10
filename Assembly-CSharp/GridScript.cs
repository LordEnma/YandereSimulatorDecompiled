using System;
using UnityEngine;

// Token: 0x02000307 RID: 775
public class GridScript : MonoBehaviour
{
	// Token: 0x0600181E RID: 6174 RVA: 0x000E4474 File Offset: 0x000E2674
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

	// Token: 0x040022F8 RID: 8952
	public GameObject Tile;

	// Token: 0x040022F9 RID: 8953
	public int Row;

	// Token: 0x040022FA RID: 8954
	public int Column;

	// Token: 0x040022FB RID: 8955
	public int Rows = 25;

	// Token: 0x040022FC RID: 8956
	public int Columns = 25;

	// Token: 0x040022FD RID: 8957
	public int ID;
}
