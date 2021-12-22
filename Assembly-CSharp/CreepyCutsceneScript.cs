using System;
using UnityEngine;

// Token: 0x02000268 RID: 616
public class CreepyCutsceneScript : MonoBehaviour
{
	// Token: 0x060012FF RID: 4863 RVA: 0x000A7CA4 File Offset: 0x000A5EA4
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

	// Token: 0x04001AFF RID: 6911
	public StreetShopInterfaceScript ShopInterface;

	// Token: 0x04001B00 RID: 6912
	public TypewriterEffect Typewriter;

	// Token: 0x04001B01 RID: 6913
	public GameObject Jukebox;

	// Token: 0x04001B02 RID: 6914
	public UILabel Label;

	// Token: 0x04001B03 RID: 6915
	public string[] Lines;

	// Token: 0x04001B04 RID: 6916
	public int ID;
}
