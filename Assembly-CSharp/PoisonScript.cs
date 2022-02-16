using System;
using UnityEngine;

// Token: 0x020003AB RID: 939
public class PoisonScript : MonoBehaviour
{
	// Token: 0x06001ABB RID: 6843 RVA: 0x00121ED0 File Offset: 0x001200D0
	public void Start()
	{
		if (this.Yandere.Class.ChemistryGrade + this.Yandere.Class.ChemistryBonus < 1 && ClassGlobals.ChemistryGrade + ClassGlobals.ChemistryGrade < 1)
		{
			base.gameObject.SetActive(false);
			return;
		}
		base.gameObject.SetActive(true);
	}

	// Token: 0x06001ABC RID: 6844 RVA: 0x00121F28 File Offset: 0x00120128
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

	// Token: 0x04002C8A RID: 11402
	public YandereScript Yandere;

	// Token: 0x04002C8B RID: 11403
	public PromptScript Prompt;

	// Token: 0x04002C8C RID: 11404
	public GameObject Bottle;
}
