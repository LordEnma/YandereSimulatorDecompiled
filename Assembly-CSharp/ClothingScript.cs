using System;
using UnityEngine;

// Token: 0x0200024E RID: 590
public class ClothingScript : MonoBehaviour
{
	// Token: 0x06001278 RID: 4728 RVA: 0x00090F12 File Offset: 0x0008F112
	private void Start()
	{
		this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
	}

	// Token: 0x06001279 RID: 4729 RVA: 0x00090F2C File Offset: 0x0008F12C
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

	// Token: 0x040017CA RID: 6090
	public YandereScript Yandere;

	// Token: 0x040017CB RID: 6091
	public PromptScript Prompt;

	// Token: 0x040017CC RID: 6092
	public GameObject FoldedUniform;

	// Token: 0x040017CD RID: 6093
	public bool CanPickUp;
}
