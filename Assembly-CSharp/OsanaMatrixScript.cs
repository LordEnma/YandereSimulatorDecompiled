using System;
using UnityEngine;

// Token: 0x02000383 RID: 899
public class OsanaMatrixScript : MonoBehaviour
{
	// Token: 0x06001A11 RID: 6673 RVA: 0x00112D6C File Offset: 0x00110F6C
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

	// Token: 0x04002A66 RID: 10854
	public CameraFilterPack_3D_Matrix MatrixEffect;

	// Token: 0x04002A67 RID: 10855
	public GameObject Rivals;

	// Token: 0x04002A68 RID: 10856
	public int Phase = 1;
}
