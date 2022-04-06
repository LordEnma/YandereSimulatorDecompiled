using System;
using UnityEngine;

// Token: 0x020003B0 RID: 944
public class PoisonScript : MonoBehaviour
{
	// Token: 0x06001ADE RID: 6878 RVA: 0x001241FC File Offset: 0x001223FC
	public void Start()
	{
		if (this.Yandere.Class.ChemistryGrade + this.Yandere.Class.ChemistryBonus < 1 && ClassGlobals.ChemistryGrade + ClassGlobals.ChemistryGrade < 1)
		{
			base.gameObject.SetActive(false);
			return;
		}
		base.gameObject.SetActive(true);
	}

	// Token: 0x06001ADF RID: 6879 RVA: 0x00124254 File Offset: 0x00122454
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

	// Token: 0x04002CF7 RID: 11511
	public YandereScript Yandere;

	// Token: 0x04002CF8 RID: 11512
	public PromptScript Prompt;

	// Token: 0x04002CF9 RID: 11513
	public GameObject Bottle;
}
