using System;
using UnityEngine;

// Token: 0x0200024F RID: 591
public class ClothingScript : MonoBehaviour
{
	// Token: 0x0600127A RID: 4730 RVA: 0x00091182 File Offset: 0x0008F382
	private void Start()
	{
		this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
	}

	// Token: 0x0600127B RID: 4731 RVA: 0x0009119C File Offset: 0x0008F39C
	private void Update()
	{
		if (this.CanPickUp)
		{
			if (this.Yandere.Bloodiness == 0f)
			{
				this.CanPickUp = false;
				this.Prompt.Hide();
				this.Prompt.enabled = false;
			}
		}
		else if (this.Yandere.Bloodiness > 0f)
		{
			this.CanPickUp = true;
			this.Prompt.enabled = true;
		}
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Bloodiness = 0f;
			UnityEngine.Object.Instantiate<GameObject>(this.FoldedUniform, base.transform.position + Vector3.up, Quaternion.identity);
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040017D0 RID: 6096
	public YandereScript Yandere;

	// Token: 0x040017D1 RID: 6097
	public PromptScript Prompt;

	// Token: 0x040017D2 RID: 6098
	public GameObject FoldedUniform;

	// Token: 0x040017D3 RID: 6099
	public bool CanPickUp;
}
