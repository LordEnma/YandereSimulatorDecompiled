using System;
using UnityEngine;

// Token: 0x0200042A RID: 1066
public class ShoePairScript : MonoBehaviour
{
	// Token: 0x06001CBE RID: 7358 RVA: 0x00151E7B File Offset: 0x0015007B
	private void Start()
	{
		this.Police = GameObject.Find("Police").GetComponent<PoliceScript>();
		this.Note.SetActive(false);
	}

	// Token: 0x06001CBF RID: 7359 RVA: 0x00151EA0 File Offset: 0x001500A0
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

	// Token: 0x0400335F RID: 13151
	public PoliceScript Police;

	// Token: 0x04003360 RID: 13152
	public PromptScript Prompt;

	// Token: 0x04003361 RID: 13153
	public GameObject Note;
}
