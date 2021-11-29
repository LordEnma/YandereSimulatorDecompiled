using System;
using UnityEngine;

// Token: 0x0200024D RID: 589
public class ClothingScript : MonoBehaviour
{
	// Token: 0x0600126F RID: 4719 RVA: 0x000900AA File Offset: 0x0008E2AA
	private void Start()
	{
		this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
	}

	// Token: 0x06001270 RID: 4720 RVA: 0x000900C4 File Offset: 0x0008E2C4
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

	// Token: 0x040017AC RID: 6060
	public YandereScript Yandere;

	// Token: 0x040017AD RID: 6061
	public PromptScript Prompt;

	// Token: 0x040017AE RID: 6062
	public GameObject FoldedUniform;

	// Token: 0x040017AF RID: 6063
	public bool CanPickUp;
}
