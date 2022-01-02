using System;
using UnityEngine;

// Token: 0x0200028C RID: 652
public class DramaticPanUpScript : MonoBehaviour
{
	// Token: 0x060013AC RID: 5036 RVA: 0x000BA180 File Offset: 0x000B8380
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

	// Token: 0x04001D39 RID: 7481
	public bool Pan;

	// Token: 0x04001D3A RID: 7482
	public float Height;

	// Token: 0x04001D3B RID: 7483
	public float Power;
}
