using UnityEngine;

public class FootprintScript : MonoBehaviour
{
	public YandereScript Yandere;

	public Texture Footprint;

	public Texture Flower;

	public int StudentBloodID;

	private void Start()
	{
		if (Yandere.Schoolwear == 0 || Yandere.Schoolwear == 2 || (Yandere.ClubAttire && Yandere.Club == ClubType.MartialArts) || Yandere.Hungry || Yandere.LucyHelmet.activeInHierarchy)
		{
			GetComponent<Renderer>().material.mainTexture = Footprint;
		}
		if (GameGlobals.CensorBlood)
		{
			GetComponent<Renderer>().material.mainTexture = Flower;
			base.transform.localScale = new Vector3(0.2f, 0.2f, 1f);
		}
	}
}
