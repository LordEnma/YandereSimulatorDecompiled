using System;
using UnityEngine;

// Token: 0x02000286 RID: 646
public class DoItScript : MonoBehaviour
{
	// Token: 0x06001392 RID: 5010 RVA: 0x000B75AB File Offset: 0x000B57AB
	private void Start()
	{
		this.MyLabel.fontSize = UnityEngine.Random.Range(50, 100);
	}

	// Token: 0x06001393 RID: 5011 RVA: 0x000B75C4 File Offset: 0x000B57C4
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

	// Token: 0x04001CF7 RID: 7415
	public UILabel MyLabel;

	// Token: 0x04001CF8 RID: 7416
	public bool Fade;
}
