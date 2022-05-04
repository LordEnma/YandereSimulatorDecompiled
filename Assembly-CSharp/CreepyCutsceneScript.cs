using System;
using UnityEngine;

// Token: 0x02000269 RID: 617
public class CreepyCutsceneScript : MonoBehaviour
{
	// Token: 0x0600130C RID: 4876 RVA: 0x000A8ED4 File Offset: 0x000A70D4
	private void Update()
	{
		if (Input.GetButtonDown("A"))
		{
			if (this.Typewriter.mCurrentOffset < this.Typewriter.mFullText.Length)
			{
				this.Typewriter.Finish();
			}
			else
			{
				this.ID++;
				if (this.ID < this.Lines.Length)
				{
					this.Typewriter.ResetToBeginning();
					this.Label.text = "";
					this.Typewriter.mFullText = this.Lines[this.ID];
				}
				else
				{
					GameGlobals.MetBarber = true;
					base.gameObject.SetActive(false);
					this.Jukebox.SetActive(true);
					this.ShopInterface.TransitionToCreepyCutscene = false;
					this.ShopInterface.Salon.EightiesBarber();
					this.ShopInterface.TransitionTimer = 0f;
					this.ShopInterface.Jukebox.Play();
					this.ShopInterface.Shopkeeper.transform.localPosition = new Vector3((float)this.ShopInterface.ShopkeeperPosition, 0f, 0f);
					this.ShopInterface.Shopkeeper.transform.localScale = new Vector3(1.128f, 1.128f, 1.128f);
				}
			}
		}
		this.Label.alpha = 1f;
	}

	// Token: 0x04001B2D RID: 6957
	public StreetShopInterfaceScript ShopInterface;

	// Token: 0x04001B2E RID: 6958
	public TypewriterEffect Typewriter;

	// Token: 0x04001B2F RID: 6959
	public GameObject Jukebox;

	// Token: 0x04001B30 RID: 6960
	public UILabel Label;

	// Token: 0x04001B31 RID: 6961
	public string[] Lines;

	// Token: 0x04001B32 RID: 6962
	public int ID;
}
