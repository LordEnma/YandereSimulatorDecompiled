using System;
using UnityEngine;

// Token: 0x02000290 RID: 656
public class DramaticPanUpScript : MonoBehaviour
{
	// Token: 0x060013CB RID: 5067 RVA: 0x000BBB2C File Offset: 0x000B9D2C
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

	// Token: 0x04001D7C RID: 7548
	public bool Pan;

	// Token: 0x04001D7D RID: 7549
	public float Height;

	// Token: 0x04001D7E RID: 7550
	public float Power;
}
