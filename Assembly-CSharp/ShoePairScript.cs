using System;
using UnityEngine;

// Token: 0x02000421 RID: 1057
public class ShoePairScript : MonoBehaviour
{
	// Token: 0x06001C79 RID: 7289 RVA: 0x0014CCAF File Offset: 0x0014AEAF
	private void Start()
	{
		this.Police = GameObject.Find("Police").GetComponent<PoliceScript>();
		this.Note.SetActive(false);
	}

	// Token: 0x06001C7A RID: 7290 RVA: 0x0014CCD4 File Offset: 0x0014AED4
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

	// Token: 0x0400329F RID: 12959
	public PoliceScript Police;

	// Token: 0x040032A0 RID: 12960
	public PromptScript Prompt;

	// Token: 0x040032A1 RID: 12961
	public GameObject Note;
}
