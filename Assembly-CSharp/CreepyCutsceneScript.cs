using System;
using UnityEngine;

// Token: 0x02000269 RID: 617
public class CreepyCutsceneScript : MonoBehaviour
{
	// Token: 0x06001304 RID: 4868 RVA: 0x000A838C File Offset: 0x000A658C
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

	// Token: 0x04001B16 RID: 6934
	public StreetShopInterfaceScript ShopInterface;

	// Token: 0x04001B17 RID: 6935
	public TypewriterEffect Typewriter;

	// Token: 0x04001B18 RID: 6936
	public GameObject Jukebox;

	// Token: 0x04001B19 RID: 6937
	public UILabel Label;

	// Token: 0x04001B1A RID: 6938
	public string[] Lines;

	// Token: 0x04001B1B RID: 6939
	public int ID;
}
