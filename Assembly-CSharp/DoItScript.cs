using System;
using UnityEngine;

// Token: 0x02000289 RID: 649
public class DoItScript : MonoBehaviour
{
	// Token: 0x060013A3 RID: 5027 RVA: 0x000B84E8 File Offset: 0x000B66E8
	private void Start()
	{
		this.MyLabel.fontSize = UnityEngine.Random.Range(50, 100);
	}

	// Token: 0x060013A4 RID: 5028 RVA: 0x000B8500 File Offset: 0x000B6700
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

	// Token: 0x04001D1E RID: 7454
	public UILabel MyLabel;

	// Token: 0x04001D1F RID: 7455
	public bool Fade;
}
