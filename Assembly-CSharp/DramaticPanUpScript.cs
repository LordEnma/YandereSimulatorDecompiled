using System;
using UnityEngine;

// Token: 0x0200028F RID: 655
public class DramaticPanUpScript : MonoBehaviour
{
	// Token: 0x060013C0 RID: 5056 RVA: 0x000BB324 File Offset: 0x000B9524
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

	// Token: 0x04001D6D RID: 7533
	public bool Pan;

	// Token: 0x04001D6E RID: 7534
	public float Height;

	// Token: 0x04001D6F RID: 7535
	public float Power;
}
