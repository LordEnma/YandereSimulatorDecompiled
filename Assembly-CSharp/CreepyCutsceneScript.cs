using System;
using UnityEngine;

// Token: 0x02000269 RID: 617
public class CreepyCutsceneScript : MonoBehaviour
{
	// Token: 0x06001308 RID: 4872 RVA: 0x000A88F8 File Offset: 0x000A6AF8
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

	// Token: 0x04001B24 RID: 6948
	public StreetShopInterfaceScript ShopInterface;

	// Token: 0x04001B25 RID: 6949
	public TypewriterEffect Typewriter;

	// Token: 0x04001B26 RID: 6950
	public GameObject Jukebox;

	// Token: 0x04001B27 RID: 6951
	public UILabel Label;

	// Token: 0x04001B28 RID: 6952
	public string[] Lines;

	// Token: 0x04001B29 RID: 6953
	public int ID;
}
