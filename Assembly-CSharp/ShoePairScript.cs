using System;
using UnityEngine;

// Token: 0x02000423 RID: 1059
public class ShoePairScript : MonoBehaviour
{
	// Token: 0x06001C8E RID: 7310 RVA: 0x0014E62B File Offset: 0x0014C82B
	private void Start()
	{
		this.Police = GameObject.Find("Police").GetComponent<PoliceScript>();
		this.Note.SetActive(false);
	}

	// Token: 0x06001C8F RID: 7311 RVA: 0x0014E650 File Offset: 0x0014C850
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

	// Token: 0x040032D5 RID: 13013
	public PoliceScript Police;

	// Token: 0x040032D6 RID: 13014
	public PromptScript Prompt;

	// Token: 0x040032D7 RID: 13015
	public GameObject Note;
}
