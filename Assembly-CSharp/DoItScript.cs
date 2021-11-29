using System;
using UnityEngine;

// Token: 0x02000285 RID: 645
public class DoItScript : MonoBehaviour
{
	// Token: 0x0600138B RID: 5003 RVA: 0x000B700F File Offset: 0x000B520F
	private void Start()
	{
		this.MyLabel.fontSize = UnityEngine.Random.Range(50, 100);
	}

	// Token: 0x0600138C RID: 5004 RVA: 0x000B7028 File Offset: 0x000B5228
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

	// Token: 0x04001CD7 RID: 7383
	public UILabel MyLabel;

	// Token: 0x04001CD8 RID: 7384
	public bool Fade;
}
