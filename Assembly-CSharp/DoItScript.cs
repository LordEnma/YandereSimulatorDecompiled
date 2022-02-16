using System;
using UnityEngine;

// Token: 0x02000288 RID: 648
public class DoItScript : MonoBehaviour
{
	// Token: 0x0600139A RID: 5018 RVA: 0x000B7A40 File Offset: 0x000B5C40
	private void Start()
	{
		this.MyLabel.fontSize = UnityEngine.Random.Range(50, 100);
	}

	// Token: 0x0600139B RID: 5019 RVA: 0x000B7A58 File Offset: 0x000B5C58
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

	// Token: 0x04001D06 RID: 7430
	public UILabel MyLabel;

	// Token: 0x04001D07 RID: 7431
	public bool Fade;
}
