using System;
using UnityEngine;

// Token: 0x020003AC RID: 940
public class PoisonScript : MonoBehaviour
{
	// Token: 0x06001AC5 RID: 6853 RVA: 0x00122CBC File Offset: 0x00120EBC
	public void Start()
	{
		if (this.Yandere.Class.ChemistryGrade + this.Yandere.Class.ChemistryBonus < 1 && ClassGlobals.ChemistryGrade + ClassGlobals.ChemistryGrade < 1)
		{
			base.gameObject.SetActive(false);
			return;
		}
		base.gameObject.SetActive(true);
	}

	// Token: 0x06001AC6 RID: 6854 RVA: 0x00122D14 File Offset: 0x00120F14
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

	// Token: 0x04002CB0 RID: 11440
	public YandereScript Yandere;

	// Token: 0x04002CB1 RID: 11441
	public PromptScript Prompt;

	// Token: 0x04002CB2 RID: 11442
	public GameObject Bottle;
}
