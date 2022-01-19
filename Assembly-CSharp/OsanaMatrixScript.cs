using System;
using UnityEngine;

// Token: 0x02000385 RID: 901
public class OsanaMatrixScript : MonoBehaviour
{
	// Token: 0x06001A1F RID: 6687 RVA: 0x00113D1C File Offset: 0x00111F1C
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

	// Token: 0x04002A9D RID: 10909
	public CameraFilterPack_3D_Matrix MatrixEffect;

	// Token: 0x04002A9E RID: 10910
	public GameObject Rivals;

	// Token: 0x04002A9F RID: 10911
	public int Phase = 1;
}
