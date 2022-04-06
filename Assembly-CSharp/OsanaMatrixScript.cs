using System;
using UnityEngine;

// Token: 0x02000389 RID: 905
public class OsanaMatrixScript : MonoBehaviour
{
	// Token: 0x06001A49 RID: 6729 RVA: 0x00116718 File Offset: 0x00114918
	private void Update()
	{
		if (Input.GetKeyDown("z"))
		{
			this.Phase++;
		}
		if (this.Phase == 2)
		{
			this.MatrixEffect.Fade = Mathf.MoveTowards(this.MatrixEffect.Fade, 1f, Time.deltaTime);
			return;
		}
		if (this.Phase == 3)
		{
			this.MatrixEffect.Fade = Mathf.MoveTowards(this.MatrixEffect.Fade, 0f, Time.deltaTime);
			return;
		}
		if (this.Phase == 4)
		{
			this.Rivals.SetActive(true);
		}
	}

	// Token: 0x04002B12 RID: 11026
	public CameraFilterPack_3D_Matrix MatrixEffect;

	// Token: 0x04002B13 RID: 11027
	public GameObject Rivals;

	// Token: 0x04002B14 RID: 11028
	public int Phase = 1;
}
