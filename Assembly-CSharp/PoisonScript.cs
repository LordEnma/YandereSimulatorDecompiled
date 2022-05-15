using System;
using UnityEngine;

// Token: 0x020003B1 RID: 945
public class PoisonScript : MonoBehaviour
{
	// Token: 0x06001AEC RID: 6892 RVA: 0x001255A8 File Offset: 0x001237A8
	public void Start()
	{
		if (this.Yandere.Class.ChemistryGrade + this.Yandere.Class.ChemistryBonus < 1 && ClassGlobals.ChemistryGrade + ClassGlobals.ChemistryGrade < 1)
		{
			base.gameObject.SetActive(false);
			return;
		}
		base.gameObject.SetActive(true);
	}

	// Token: 0x06001AED RID: 6893 RVA: 0x00125600 File Offset: 0x00123800
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

	// Token: 0x04002D1D RID: 11549
	public YandereScript Yandere;

	// Token: 0x04002D1E RID: 11550
	public PromptScript Prompt;

	// Token: 0x04002D1F RID: 11551
	public GameObject Bottle;
}
