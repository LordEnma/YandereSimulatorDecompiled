using System;
using UnityEngine;

// Token: 0x020003BC RID: 956
public class PromptBarScript : MonoBehaviour
{
	// Token: 0x06001AFB RID: 6907 RVA: 0x0012BED4 File Offset: 0x0012A0D4
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

	// Token: 0x06001AFC RID: 6908 RVA: 0x0012BF54 File Offset: 0x0012A154
	private void Start()
	{
		this.UpdateButtons();
	}

	// Token: 0x06001AFD RID: 6909 RVA: 0x0012BF5C File Offset: 0x0012A15C
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

	// Token: 0x06001AFE RID: 6910 RVA: 0x0012C090 File Offset: 0x0012A290
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

	// Token: 0x06001AFF RID: 6911 RVA: 0x0012C138 File Offset: 0x0012A338
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

	// Token: 0x04002DAF RID: 11695
	public UISprite[] Button;

	// Token: 0x04002DB0 RID: 11696
	public UILabel[] Label;

	// Token: 0x04002DB1 RID: 11697
	public UILabel[] ButtonLabel;

	// Token: 0x04002DB2 RID: 11698
	public UIPanel Panel;

	// Token: 0x04002DB3 RID: 11699
	public bool Show;

	// Token: 0x04002DB4 RID: 11700
	public int ID;
}
