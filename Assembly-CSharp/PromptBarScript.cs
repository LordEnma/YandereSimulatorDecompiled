using System;
using UnityEngine;

// Token: 0x020003BC RID: 956
public class PromptBarScript : MonoBehaviour
{
	// Token: 0x06001AFA RID: 6906 RVA: 0x0012B964 File Offset: 0x00129B64
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

	// Token: 0x06001AFB RID: 6907 RVA: 0x0012B9E4 File Offset: 0x00129BE4
	private void Start()
	{
		this.UpdateButtons();
	}

	// Token: 0x06001AFC RID: 6908 RVA: 0x0012B9EC File Offset: 0x00129BEC
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

	// Token: 0x06001AFD RID: 6909 RVA: 0x0012BB20 File Offset: 0x00129D20
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

	// Token: 0x06001AFE RID: 6910 RVA: 0x0012BBC8 File Offset: 0x00129DC8
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

	// Token: 0x04002DA8 RID: 11688
	public UISprite[] Button;

	// Token: 0x04002DA9 RID: 11689
	public UILabel[] Label;

	// Token: 0x04002DAA RID: 11690
	public UILabel[] ButtonLabel;

	// Token: 0x04002DAB RID: 11691
	public UIPanel Panel;

	// Token: 0x04002DAC RID: 11692
	public bool Show;

	// Token: 0x04002DAD RID: 11693
	public int ID;
}
