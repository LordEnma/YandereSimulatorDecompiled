using System;
using UnityEngine;

// Token: 0x020003C3 RID: 963
public class PromptBarScript : MonoBehaviour
{
	// Token: 0x06001B35 RID: 6965 RVA: 0x0012FD2C File Offset: 0x0012DF2C
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

	// Token: 0x06001B36 RID: 6966 RVA: 0x0012FDAC File Offset: 0x0012DFAC
	private void Start()
	{
		this.UpdateButtons();
	}

	// Token: 0x06001B37 RID: 6967 RVA: 0x0012FDB4 File Offset: 0x0012DFB4
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

	// Token: 0x06001B38 RID: 6968 RVA: 0x0012FEE8 File Offset: 0x0012E0E8
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

	// Token: 0x06001B39 RID: 6969 RVA: 0x0012FF90 File Offset: 0x0012E190
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

	// Token: 0x04002E50 RID: 11856
	public UISprite[] Button;

	// Token: 0x04002E51 RID: 11857
	public UILabel[] Label;

	// Token: 0x04002E52 RID: 11858
	public UILabel[] ButtonLabel;

	// Token: 0x04002E53 RID: 11859
	public UIPanel Panel;

	// Token: 0x04002E54 RID: 11860
	public bool Show;

	// Token: 0x04002E55 RID: 11861
	public int ID;
}
