using System;
using UnityEngine;

// Token: 0x0200028E RID: 654
public class DramaticPanUpScript : MonoBehaviour
{
	// Token: 0x060013B4 RID: 5044 RVA: 0x000BA464 File Offset: 0x000B8664
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

	// Token: 0x04001D46 RID: 7494
	public bool Pan;

	// Token: 0x04001D47 RID: 7495
	public float Height;

	// Token: 0x04001D48 RID: 7496
	public float Power;
}
