using System;
using UnityEngine;

// Token: 0x0200028C RID: 652
public class DramaticPanUpScript : MonoBehaviour
{
	// Token: 0x060013AC RID: 5036 RVA: 0x000B9F38 File Offset: 0x000B8138
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

	// Token: 0x04001D36 RID: 7478
	public bool Pan;

	// Token: 0x04001D37 RID: 7479
	public float Height;

	// Token: 0x04001D38 RID: 7480
	public float Power;
}
