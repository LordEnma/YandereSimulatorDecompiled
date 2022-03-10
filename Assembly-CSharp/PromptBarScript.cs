using System;
using UnityEngine;

// Token: 0x020003BE RID: 958
public class PromptBarScript : MonoBehaviour
{
	// Token: 0x06001B0E RID: 6926 RVA: 0x0012D18C File Offset: 0x0012B38C
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

	// Token: 0x06001B0F RID: 6927 RVA: 0x0012D20C File Offset: 0x0012B40C
	private void Start()
	{
		this.UpdateButtons();
	}

	// Token: 0x06001B10 RID: 6928 RVA: 0x0012D214 File Offset: 0x0012B414
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

	// Token: 0x06001B11 RID: 6929 RVA: 0x0012D348 File Offset: 0x0012B548
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

	// Token: 0x06001B12 RID: 6930 RVA: 0x0012D3F0 File Offset: 0x0012B5F0
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

	// Token: 0x04002DDE RID: 11742
	public UISprite[] Button;

	// Token: 0x04002DDF RID: 11743
	public UILabel[] Label;

	// Token: 0x04002DE0 RID: 11744
	public UILabel[] ButtonLabel;

	// Token: 0x04002DE1 RID: 11745
	public UIPanel Panel;

	// Token: 0x04002DE2 RID: 11746
	public bool Show;

	// Token: 0x04002DE3 RID: 11747
	public int ID;
}
