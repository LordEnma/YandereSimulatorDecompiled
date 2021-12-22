using System;
using UnityEngine;

// Token: 0x020003A8 RID: 936
public class PoisonScript : MonoBehaviour
{
	// Token: 0x06001AA8 RID: 6824 RVA: 0x00120D68 File Offset: 0x0011EF68
	public void Start()
	{
		if (this.Yandere.Class.ChemistryGrade + this.Yandere.Class.ChemistryBonus < 1 && ClassGlobals.ChemistryGrade + ClassGlobals.ChemistryGrade < 1)
		{
			base.gameObject.SetActive(false);
			return;
		}
		base.gameObject.SetActive(true);
	}

	// Token: 0x06001AA9 RID: 6825 RVA: 0x00120DC0 File Offset: 0x0011EFC0
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Yandere.Inventory.ChemicalPoison = true;
			this.Yandere.StudentManager.UpdateAllBentos();
			UnityEngine.Object.Destroy(base.gameObject);
			UnityEngine.Object.Destroy(this.Bottle);
		}
	}

	// Token: 0x04002C6D RID: 11373
	public YandereScript Yandere;

	// Token: 0x04002C6E RID: 11374
	public PromptScript Prompt;

	// Token: 0x04002C6F RID: 11375
	public GameObject Bottle;
}
