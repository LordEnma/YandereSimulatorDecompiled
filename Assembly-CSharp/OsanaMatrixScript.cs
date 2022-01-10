using System;
using UnityEngine;

// Token: 0x02000385 RID: 901
public class OsanaMatrixScript : MonoBehaviour
{
	// Token: 0x06001A1F RID: 6687 RVA: 0x00113BB4 File Offset: 0x00111DB4
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

	// Token: 0x04002A9A RID: 10906
	public CameraFilterPack_3D_Matrix MatrixEffect;

	// Token: 0x04002A9B RID: 10907
	public GameObject Rivals;

	// Token: 0x04002A9C RID: 10908
	public int Phase = 1;
}
