using System;
using UnityEngine;

// Token: 0x0200041D RID: 1053
public class ShoePairScript : MonoBehaviour
{
	// Token: 0x06001C66 RID: 7270 RVA: 0x0014A51B File Offset: 0x0014871B
	private void Start()
	{
		this.Police = GameObject.Find("Police").GetComponent<PoliceScript>();
		this.Note.SetActive(false);
	}

	// Token: 0x06001C67 RID: 7271 RVA: 0x0014A540 File Offset: 0x00148740
	private void Update()
	{
		if (this.Prompt.Yandere.Class.LanguageGrade + this.Prompt.Yandere.Class.LanguageBonus < 1)
		{
			this.Prompt.enabled = false;
		}
		else
		{
			this.Prompt.enabled = true;
		}
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			this.Police.SuicideNote = true;
			this.Note.SetActive(true);
			base.enabled = false;
		}
	}

	// Token: 0x04003262 RID: 12898
	public PoliceScript Police;

	// Token: 0x04003263 RID: 12899
	public PromptScript Prompt;

	// Token: 0x04003264 RID: 12900
	public GameObject Note;
}
