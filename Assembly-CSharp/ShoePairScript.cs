using System;
using UnityEngine;

// Token: 0x02000420 RID: 1056
public class ShoePairScript : MonoBehaviour
{
	// Token: 0x06001C77 RID: 7287 RVA: 0x0014B59B File Offset: 0x0014979B
	private void Start()
	{
		this.Police = GameObject.Find("Police").GetComponent<PoliceScript>();
		this.Note.SetActive(false);
	}

	// Token: 0x06001C78 RID: 7288 RVA: 0x0014B5C0 File Offset: 0x001497C0
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

	// Token: 0x0400329A RID: 12954
	public PoliceScript Police;

	// Token: 0x0400329B RID: 12955
	public PromptScript Prompt;

	// Token: 0x0400329C RID: 12956
	public GameObject Note;
}
