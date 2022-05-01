using System;
using UnityEngine;

// Token: 0x0200028A RID: 650
public class DoItScript : MonoBehaviour
{
	// Token: 0x060013B1 RID: 5041 RVA: 0x000B90F4 File Offset: 0x000B72F4
	private void Start()
	{
		this.MyLabel.fontSize = UnityEngine.Random.Range(50, 100);
	}

	// Token: 0x060013B2 RID: 5042 RVA: 0x000B910C File Offset: 0x000B730C
	private void Update()
	{
		base.transform.localScale += new Vector3(Time.deltaTime, Time.deltaTime, Time.deltaTime);
		if (!this.Fade)
		{
			this.MyLabel.alpha += Time.deltaTime;
			if (this.MyLabel.alpha >= 1f)
			{
				this.Fade = true;
				return;
			}
		}
		else
		{
			this.MyLabel.alpha -= Time.deltaTime;
			if (this.MyLabel.alpha <= 0f)
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}
	}

	// Token: 0x04001D3A RID: 7482
	public UILabel MyLabel;

	// Token: 0x04001D3B RID: 7483
	public bool Fade;
}
