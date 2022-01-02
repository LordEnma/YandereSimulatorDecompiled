using System;
using UnityEngine;

// Token: 0x02000286 RID: 646
public class DoItScript : MonoBehaviour
{
	// Token: 0x06001392 RID: 5010 RVA: 0x000B77DB File Offset: 0x000B59DB
	private void Start()
	{
		this.MyLabel.fontSize = UnityEngine.Random.Range(50, 100);
	}

	// Token: 0x06001393 RID: 5011 RVA: 0x000B77F4 File Offset: 0x000B59F4
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

	// Token: 0x04001CFA RID: 7418
	public UILabel MyLabel;

	// Token: 0x04001CFB RID: 7419
	public bool Fade;
}
