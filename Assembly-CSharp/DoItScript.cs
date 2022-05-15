using System;
using UnityEngine;

// Token: 0x0200028B RID: 651
public class DoItScript : MonoBehaviour
{
	// Token: 0x060013B3 RID: 5043 RVA: 0x000B9334 File Offset: 0x000B7534
	private void Start()
	{
		this.MyLabel.fontSize = UnityEngine.Random.Range(50, 100);
	}

	// Token: 0x060013B4 RID: 5044 RVA: 0x000B934C File Offset: 0x000B754C
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

	// Token: 0x04001D41 RID: 7489
	public UILabel MyLabel;

	// Token: 0x04001D42 RID: 7490
	public bool Fade;
}
