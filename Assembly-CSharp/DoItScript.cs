using System;
using UnityEngine;

// Token: 0x0200028A RID: 650
public class DoItScript : MonoBehaviour
{
	// Token: 0x060013AD RID: 5037 RVA: 0x000B8AD8 File Offset: 0x000B6CD8
	private void Start()
	{
		this.MyLabel.fontSize = UnityEngine.Random.Range(50, 100);
	}

	// Token: 0x060013AE RID: 5038 RVA: 0x000B8AF0 File Offset: 0x000B6CF0
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

	// Token: 0x04001D31 RID: 7473
	public UILabel MyLabel;

	// Token: 0x04001D32 RID: 7474
	public bool Fade;
}
