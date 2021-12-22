using System;
using UnityEngine;

// Token: 0x020003BA RID: 954
public class PromptBarScript : MonoBehaviour
{
	// Token: 0x06001AF1 RID: 6897 RVA: 0x0012B0B8 File Offset: 0x001292B8
	private void Awake()
	{
		base.transform.localPosition = new Vector3(base.transform.localPosition.x, -627f, base.transform.localPosition.z);
		this.ID = 0;
		while (this.ID < this.Label.Length)
		{
			this.Label[this.ID].text = string.Empty;
			this.ID++;
		}
	}

	// Token: 0x06001AF2 RID: 6898 RVA: 0x0012B138 File Offset: 0x00129338
	private void Start()
	{
		this.UpdateButtons();
	}

	// Token: 0x06001AF3 RID: 6899 RVA: 0x0012B140 File Offset: 0x00129340
	private void Update()
	{
		float t = Time.unscaledDeltaTime * 10f;
		if (!this.Show)
		{
			if (this.Panel.enabled)
			{
				base.transform.localPosition = new Vector3(base.transform.localPosition.x, Mathf.Lerp(base.transform.localPosition.y, -628f, t), base.transform.localPosition.z);
				if (base.transform.localPosition.y < -627f)
				{
					base.transform.localPosition = new Vector3(base.transform.localPosition.x, -628f, base.transform.localPosition.z);
					if (this.Panel != null)
					{
						this.Panel.enabled = false;
						return;
					}
				}
			}
		}
		else
		{
			base.transform.localPosition = new Vector3(base.transform.localPosition.x, Mathf.Lerp(base.transform.localPosition.y, -528.5f, t), base.transform.localPosition.z);
		}
	}

	// Token: 0x06001AF4 RID: 6900 RVA: 0x0012B274 File Offset: 0x00129474
	public void UpdateButtons()
	{
		if (this.Panel != null)
		{
			this.Panel.enabled = true;
		}
		this.ID = 0;
		while (this.ID < this.Label.Length)
		{
			this.Button[this.ID].enabled = (this.Label[this.ID].text.Length > 0);
			this.ButtonLabel[this.ID].enabled = (this.Label[this.ID].text.Length > 0);
			this.ID++;
		}
	}

	// Token: 0x06001AF5 RID: 6901 RVA: 0x0012B31C File Offset: 0x0012951C
	public void ClearButtons()
	{
		this.ID = 0;
		while (this.ID < this.Label.Length)
		{
			this.ButtonLabel[this.ID].enabled = false;
			this.Label[this.ID].text = string.Empty;
			this.Button[this.ID].enabled = false;
			this.ID++;
		}
	}

	// Token: 0x04002D99 RID: 11673
	public UISprite[] Button;

	// Token: 0x04002D9A RID: 11674
	public UILabel[] Label;

	// Token: 0x04002D9B RID: 11675
	public UILabel[] ButtonLabel;

	// Token: 0x04002D9C RID: 11676
	public UIPanel Panel;

	// Token: 0x04002D9D RID: 11677
	public bool Show;

	// Token: 0x04002D9E RID: 11678
	public int ID;
}
