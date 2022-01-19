using System;
using UnityEngine;

// Token: 0x0200024E RID: 590
public class ClothingScript : MonoBehaviour
{
	// Token: 0x06001274 RID: 4724 RVA: 0x00090326 File Offset: 0x0008E526
	private void Start()
	{
		this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
	}

	// Token: 0x06001275 RID: 4725 RVA: 0x00090340 File Offset: 0x0008E540
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

	// Token: 0x040017B1 RID: 6065
	public YandereScript Yandere;

	// Token: 0x040017B2 RID: 6066
	public PromptScript Prompt;

	// Token: 0x040017B3 RID: 6067
	public GameObject FoldedUniform;

	// Token: 0x040017B4 RID: 6068
	public bool CanPickUp;
}
