using System;
using UnityEngine;

// Token: 0x02000421 RID: 1057
public class ShoePairScript : MonoBehaviour
{
	// Token: 0x06001C7C RID: 7292 RVA: 0x0014D37F File Offset: 0x0014B57F
	private void Start()
	{
		this.Police = GameObject.Find("Police").GetComponent<PoliceScript>();
		this.Note.SetActive(false);
	}

	// Token: 0x06001C7D RID: 7293 RVA: 0x0014D3A4 File Offset: 0x0014B5A4
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

	// Token: 0x040032A9 RID: 12969
	public PoliceScript Police;

	// Token: 0x040032AA RID: 12970
	public PromptScript Prompt;

	// Token: 0x040032AB RID: 12971
	public GameObject Note;
}
