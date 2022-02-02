using System;
using UnityEngine;

// Token: 0x02000421 RID: 1057
public class ShoePairScript : MonoBehaviour
{
	// Token: 0x06001C7A RID: 7290 RVA: 0x0014D0E3 File Offset: 0x0014B2E3
	private void Start()
	{
		this.Police = GameObject.Find("Police").GetComponent<PoliceScript>();
		this.Note.SetActive(false);
	}

	// Token: 0x06001C7B RID: 7291 RVA: 0x0014D108 File Offset: 0x0014B308
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

	// Token: 0x040032A5 RID: 12965
	public PoliceScript Police;

	// Token: 0x040032A6 RID: 12966
	public PromptScript Prompt;

	// Token: 0x040032A7 RID: 12967
	public GameObject Note;
}
