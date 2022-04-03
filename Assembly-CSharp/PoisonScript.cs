using System;
using UnityEngine;

// Token: 0x020003AF RID: 943
public class PoisonScript : MonoBehaviour
{
	// Token: 0x06001AD8 RID: 6872 RVA: 0x00124050 File Offset: 0x00122250
	public void Start()
	{
		if (this.Yandere.Class.ChemistryGrade + this.Yandere.Class.ChemistryBonus < 1 && ClassGlobals.ChemistryGrade + ClassGlobals.ChemistryGrade < 1)
		{
			base.gameObject.SetActive(false);
			return;
		}
		base.gameObject.SetActive(true);
	}

	// Token: 0x06001AD9 RID: 6873 RVA: 0x001240A8 File Offset: 0x001222A8
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

	// Token: 0x04002CF4 RID: 11508
	public YandereScript Yandere;

	// Token: 0x04002CF5 RID: 11509
	public PromptScript Prompt;

	// Token: 0x04002CF6 RID: 11510
	public GameObject Bottle;
}
