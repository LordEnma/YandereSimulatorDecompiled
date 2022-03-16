using System;
using UnityEngine;

// Token: 0x02000289 RID: 649
public class DoItScript : MonoBehaviour
{
	// Token: 0x060013A6 RID: 5030 RVA: 0x000B88C4 File Offset: 0x000B6AC4
	private void Start()
	{
		this.MyLabel.fontSize = UnityEngine.Random.Range(50, 100);
	}

	// Token: 0x060013A7 RID: 5031 RVA: 0x000B88DC File Offset: 0x000B6ADC
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

	// Token: 0x04001D2C RID: 7468
	public UILabel MyLabel;

	// Token: 0x04001D2D RID: 7469
	public bool Fade;
}
