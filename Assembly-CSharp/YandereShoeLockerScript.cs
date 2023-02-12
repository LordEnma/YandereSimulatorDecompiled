using UnityEngine;

public class YandereShoeLockerScript : MonoBehaviour
{
	public PromptScript Prompt;

	public YandereScript Yandere;

	public bool CheckedForMod;

	public bool Outdoors = true;

	private void Update()
	{
		if (!(Yandere.transform.position.y < 1f) || !Yandere.CanMove || Yandere.Schoolwear != 1 || Yandere.ClubAttire || Yandere.Egg || Yandere.WearingRaincoat || Yandere.CanCloak)
		{
			return;
		}
		if (Outdoors)
		{
			if ((!(Yandere.transform.position.x > -30f) || !(Yandere.transform.position.x < 30f) || !(Yandere.transform.position.z < 30f) || !(Yandere.transform.position.z > 0f)) && (!(Yandere.transform.position.x > -6f) || !(Yandere.transform.position.x < 6f) || !(Yandere.transform.position.z > -34f) || !(Yandere.transform.position.z < 30f)))
			{
				return;
			}
			if (!CheckedForMod)
			{
				if (Yandere.MyRenderer.materials[0].mainTexture != Yandere.TextureToUse)
				{
					base.enabled = false;
				}
				CheckedForMod = true;
			}
			else
			{
				Outdoors = false;
				UpdateShoes();
			}
		}
		else if (Yandere.transform.position.z > 30f || (Yandere.transform.position.z < -34f && Yandere.transform.position.x > -6f && Yandere.transform.position.x < 6f))
		{
			Outdoors = true;
			UpdateShoes();
		}
	}

	private void UpdateShoes()
	{
		int bloodiness = Yandere.RightFootprintSpawner.Bloodiness;
		int bloodiness2 = Yandere.LeftFootprintSpawner.Bloodiness;
		Yandere.Casual = Outdoors;
		Yandere.ChangeSchoolwear();
		Yandere.CanMove = true;
		Yandere.RightFootprintSpawner.Bloodiness = bloodiness;
		Yandere.LeftFootprintSpawner.Bloodiness = bloodiness2;
	}
}
