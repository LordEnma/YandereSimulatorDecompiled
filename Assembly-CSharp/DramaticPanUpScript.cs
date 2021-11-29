using System;
using UnityEngine;

// Token: 0x0200028B RID: 651
public class DramaticPanUpScript : MonoBehaviour
{
	// Token: 0x060013A5 RID: 5029 RVA: 0x000B999C File Offset: 0x000B7B9C
	private void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			this.Pan = true;
		}
		if (this.Pan)
		{
			this.Power += Time.deltaTime * 0.5f;
			this.Height = Mathf.Lerp(this.Height, 1.4f, this.Power * Time.deltaTime);
			base.transform.localPosition = new Vector3(0f, this.Height, 1f);
		}
	}

	// Token: 0x04001D16 RID: 7446
	public bool Pan;

	// Token: 0x04001D17 RID: 7447
	public float Height;

	// Token: 0x04001D18 RID: 7448
	public float Power;
}
