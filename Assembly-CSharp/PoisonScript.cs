using System;
using UnityEngine;

// Token: 0x020003B0 RID: 944
public class PoisonScript : MonoBehaviour
{
	// Token: 0x06001AE2 RID: 6882 RVA: 0x00124608 File Offset: 0x00122808
	public void Start()
	{
		if (this.Yandere.Class.ChemistryGrade + this.Yandere.Class.ChemistryBonus < 1 && ClassGlobals.ChemistryGrade + ClassGlobals.ChemistryGrade < 1)
		{
			base.gameObject.SetActive(false);
			return;
		}
		base.gameObject.SetActive(true);
	}

	// Token: 0x06001AE3 RID: 6883 RVA: 0x00124660 File Offset: 0x00122860
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Yandere.Inventory.ChemicalPoison = true;
			this.Yandere.Inventory.LethalPoisons++;
			this.Yandere.StudentManager.UpdateAllBentos();
			UnityEngine.Object.Destroy(base.gameObject);
			UnityEngine.Object.Destroy(this.Bottle);
		}
	}

	// Token: 0x04002D01 RID: 11521
	public YandereScript Yandere;

	// Token: 0x04002D02 RID: 11522
	public PromptScript Prompt;

	// Token: 0x04002D03 RID: 11523
	public GameObject Bottle;
}
