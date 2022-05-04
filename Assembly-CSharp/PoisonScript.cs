using System;
using UnityEngine;

// Token: 0x020003B0 RID: 944
public class PoisonScript : MonoBehaviour
{
	// Token: 0x06001AE6 RID: 6886 RVA: 0x00124BE8 File Offset: 0x00122DE8
	public void Start()
	{
		if (this.Yandere.Class.ChemistryGrade + this.Yandere.Class.ChemistryBonus < 1 && ClassGlobals.ChemistryGrade + ClassGlobals.ChemistryGrade < 1)
		{
			base.gameObject.SetActive(false);
			return;
		}
		base.gameObject.SetActive(true);
	}

	// Token: 0x06001AE7 RID: 6887 RVA: 0x00124C40 File Offset: 0x00122E40
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

	// Token: 0x04002D0A RID: 11530
	public YandereScript Yandere;

	// Token: 0x04002D0B RID: 11531
	public PromptScript Prompt;

	// Token: 0x04002D0C RID: 11532
	public GameObject Bottle;
}
