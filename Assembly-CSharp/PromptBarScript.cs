using System;
using UnityEngine;

// Token: 0x020003BD RID: 957
public class PromptBarScript : MonoBehaviour
{
	// Token: 0x06001B04 RID: 6916 RVA: 0x0012C374 File Offset: 0x0012A574
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

	// Token: 0x06001B05 RID: 6917 RVA: 0x0012C3F4 File Offset: 0x0012A5F4
	private void Start()
	{
		this.UpdateButtons();
	}

	// Token: 0x06001B06 RID: 6918 RVA: 0x0012C3FC File Offset: 0x0012A5FC
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

	// Token: 0x06001B07 RID: 6919 RVA: 0x0012C530 File Offset: 0x0012A730
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

	// Token: 0x06001B08 RID: 6920 RVA: 0x0012C5D8 File Offset: 0x0012A7D8
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

	// Token: 0x04002DB8 RID: 11704
	public UISprite[] Button;

	// Token: 0x04002DB9 RID: 11705
	public UILabel[] Label;

	// Token: 0x04002DBA RID: 11706
	public UILabel[] ButtonLabel;

	// Token: 0x04002DBB RID: 11707
	public UIPanel Panel;

	// Token: 0x04002DBC RID: 11708
	public bool Show;

	// Token: 0x04002DBD RID: 11709
	public int ID;
}
