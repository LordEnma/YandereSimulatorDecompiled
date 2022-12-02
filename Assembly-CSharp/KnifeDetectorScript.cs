using UnityEngine;

public class KnifeDetectorScript : MonoBehaviour
{
	public BlowtorchScript[] Blowtorches;

	public Transform HeatingSpot;

	public Transform Torches;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public float Timer;

	private void Start()
	{
		Disable();
	}

	private void Update()
	{
		if (Blowtorches[1].transform.parent != Torches || Blowtorches[2].transform.parent != Torches || Blowtorches[3].transform.parent != Torches)
		{
			Prompt.Hide();
			Prompt.enabled = true;
			base.enabled = false;
		}
		if (Yandere.Armed)
		{
			if (Yandere.EquippedWeapon.WeaponID == 8)
			{
				Prompt.MyCollider.enabled = true;
				Prompt.enabled = true;
				if (Prompt.Circle[0].fillAmount == 0f)
				{
					Prompt.Circle[0].fillAmount = 1f;
					if (!Yandere.Chased && Yandere.Chasers == 0)
					{
						Yandere.CharacterAnimation.CrossFade("f02_heating_00");
						Yandere.CanMove = false;
						Timer = 5f;
						Blowtorches[1].enabled = true;
						Blowtorches[2].enabled = true;
						Blowtorches[3].enabled = true;
						Blowtorches[1].GetComponent<AudioSource>().Play();
						Blowtorches[2].GetComponent<AudioSource>().Play();
						Blowtorches[3].GetComponent<AudioSource>().Play();
					}
				}
			}
			else
			{
				Disable();
			}
		}
		else
		{
			Disable();
		}
		if (Timer > 0f)
		{
			Yandere.transform.rotation = Quaternion.Slerp(Yandere.transform.rotation, HeatingSpot.rotation, Time.deltaTime * 10f);
			Yandere.MoveTowardsTarget(HeatingSpot.position);
			WeaponScript equippedWeapon = Yandere.EquippedWeapon;
			Material material = equippedWeapon.MyRenderer.material;
			material.color = new Color(material.color.r, Mathf.MoveTowards(material.color.g, 0.5f, Time.deltaTime * 0.2f), Mathf.MoveTowards(material.color.b, 0.5f, Time.deltaTime * 0.2f), material.color.a);
			Timer = Mathf.MoveTowards(Timer, 0f, Time.deltaTime);
			if (Timer == 0f)
			{
				equippedWeapon.Heated = true;
				base.enabled = false;
				Disable();
			}
		}
	}

	private void Disable()
	{
		Prompt.Hide();
		Prompt.enabled = false;
		Prompt.MyCollider.enabled = false;
	}
}
