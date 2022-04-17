using System;
using UnityEngine;

// Token: 0x02000389 RID: 905
public class OsanaMatrixScript : MonoBehaviour
{
	// Token: 0x06001A4D RID: 6733 RVA: 0x00116A20 File Offset: 0x00114C20
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

	// Token: 0x04002B1A RID: 11034
	public CameraFilterPack_3D_Matrix MatrixEffect;

	// Token: 0x04002B1B RID: 11035
	public GameObject Rivals;

	// Token: 0x04002B1C RID: 11036
	public int Phase = 1;
}
