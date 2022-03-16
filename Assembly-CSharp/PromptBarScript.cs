using System;
using UnityEngine;

// Token: 0x020003BE RID: 958
public class PromptBarScript : MonoBehaviour
{
	// Token: 0x06001B18 RID: 6936 RVA: 0x0012DE3C File Offset: 0x0012C03C
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

	// Token: 0x06001B19 RID: 6937 RVA: 0x0012DEBC File Offset: 0x0012C0BC
	private void Start()
	{
		this.UpdateButtons();
	}

	// Token: 0x06001B1A RID: 6938 RVA: 0x0012DEC4 File Offset: 0x0012C0C4
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

	// Token: 0x06001B1B RID: 6939 RVA: 0x0012DFF8 File Offset: 0x0012C1F8
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

	// Token: 0x06001B1C RID: 6940 RVA: 0x0012E0A0 File Offset: 0x0012C2A0
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

	// Token: 0x04002E0B RID: 11787
	public UISprite[] Button;

	// Token: 0x04002E0C RID: 11788
	public UILabel[] Label;

	// Token: 0x04002E0D RID: 11789
	public UILabel[] ButtonLabel;

	// Token: 0x04002E0E RID: 11790
	public UIPanel Panel;

	// Token: 0x04002E0F RID: 11791
	public bool Show;

	// Token: 0x04002E10 RID: 11792
	public int ID;
}
