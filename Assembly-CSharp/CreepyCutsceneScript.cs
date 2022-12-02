using UnityEngine;

public class CreepyCutsceneScript : MonoBehaviour
{
	public StreetShopInterfaceScript ShopInterface;

	public TypewriterEffect Typewriter;

	public GameObject Jukebox;

	public UILabel Label;

	public string[] Lines;

	public int ID;

	private void Update()
	{
		if (Input.GetButtonDown("A"))
		{
			if (Typewriter.mCurrentOffset < Typewriter.mFullText.Length)
			{
				Typewriter.Finish();
			}
			else
			{
				ID++;
				if (ID < Lines.Length)
				{
					Typewriter.ResetToBeginning();
					Label.text = "";
					Typewriter.mFullText = Lines[ID];
				}
				else
				{
					GameGlobals.MetBarber = true;
					base.gameObject.SetActive(false);
					Jukebox.SetActive(true);
					ShopInterface.TransitionToCreepyCutscene = false;
					ShopInterface.Salon.EightiesBarber();
					ShopInterface.TransitionTimer = 0f;
					ShopInterface.Jukebox.Play();
					ShopInterface.Shopkeeper.transform.localPosition = new Vector3(ShopInterface.ShopkeeperPosition, 0f, 0f);
					ShopInterface.Shopkeeper.transform.localScale = new Vector3(1.128f, 1.128f, 1.128f);
				}
			}
		}
		Label.alpha = 1f;
	}
}
