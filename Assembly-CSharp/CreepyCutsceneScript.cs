using System;
using UnityEngine;

// Token: 0x02000267 RID: 615
public class CreepyCutsceneScript : MonoBehaviour
{
	// Token: 0x060012F8 RID: 4856 RVA: 0x000A7800 File Offset: 0x000A5A00
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

	// Token: 0x04001AE6 RID: 6886
	public StreetShopInterfaceScript ShopInterface;

	// Token: 0x04001AE7 RID: 6887
	public TypewriterEffect Typewriter;

	// Token: 0x04001AE8 RID: 6888
	public GameObject Jukebox;

	// Token: 0x04001AE9 RID: 6889
	public UILabel Label;

	// Token: 0x04001AEA RID: 6890
	public string[] Lines;

	// Token: 0x04001AEB RID: 6891
	public int ID;
}
