using UnityEngine;

public class HallucinationScript : MonoBehaviour
{
	public SkinnedMeshRenderer YandereHairRenderer;

	public SkinnedMeshRenderer YandereRenderer;

	public SkinnedMeshRenderer RivalHairRenderer;

	public SkinnedMeshRenderer RivalRenderer;

	public Animation YandereAnimation;

	public Animation RivalAnimation;

	public YandereScript Yandere;

	public Material Black;

	public bool Hallucinate;

	public float Alpha;

	public float Timer;

	public int Weapon;

	public SkinnedMeshRenderer[] EightiesRivalHairRenderers;

	public Renderer[] WeaponRenderers;

	public Renderer RichGirlHairRenderer;

	public Renderer SawRenderer;

	public GameObject[] Weapons;

	public string[] WeaponName;

	public GameObject[] EightiesRivalHair;

	public GameObject[] RivalHair;

	public GameObject RyobaHair;

	public SkinnedMeshRenderer RyobaHairRenderer;

	public Mesh LongSleeveUniform;

	public GameObject HallucinatedYandere;

	public GameObject HallucinatedRival;

	private void Start()
	{
		int week = DateGlobals.Week;
		YandereHairRenderer.material = Black;
		RivalHairRenderer.material = Black;
		YandereRenderer.materials[0] = Black;
		YandereRenderer.materials[1] = Black;
		YandereRenderer.materials[2] = Black;
		RivalRenderer.materials[0] = Black;
		RivalRenderer.materials[1] = Black;
		RivalRenderer.materials[2] = Black;
		Renderer[] weaponRenderers = WeaponRenderers;
		foreach (Renderer renderer in weaponRenderers)
		{
			if (renderer != null)
			{
				renderer.material = Black;
			}
		}
		SawRenderer.material = Black;
		MakeTransparent();
		for (int j = 1; j < 11; j++)
		{
			EightiesRivalHair[j].SetActive(false);
		}
		if (GameGlobals.Eighties)
		{
			if (week > 0 && week < 11)
			{
				YandereHairRenderer.transform.parent.gameObject.SetActive(false);
				RivalHair[1].SetActive(false);
				EightiesRivalHair[week].SetActive(true);
				YandereHairRenderer = RyobaHairRenderer;
				RivalHairRenderer = EightiesRivalHairRenderers[week];
				YandereRenderer.sharedMesh = LongSleeveUniform;
				RivalRenderer.sharedMesh = LongSleeveUniform;
			}
		}
		else
		{
			RyobaHair.SetActive(false);
		}
		HallucinatedYandere.SetActive(false);
		HallucinatedRival.SetActive(false);
	}

	private void Update()
	{
		if (Yandere.Sanity < 33.33333f)
		{
			if (!Yandere.Aiming && Yandere.CanMove)
			{
				Timer += Time.deltaTime;
			}
			if (Timer > 6f)
			{
				HallucinatedYandere.SetActive(true);
				HallucinatedRival.SetActive(true);
				Weapon = Random.Range(1, 6);
				base.transform.position = Yandere.transform.position + Yandere.transform.forward;
				base.transform.eulerAngles = Yandere.transform.eulerAngles;
				YandereAnimation["f02_" + WeaponName[Weapon] + "LowSanityA_00"].time = 0f;
				RivalAnimation["f02_" + WeaponName[Weapon] + "LowSanityB_00"].time = 0f;
				YandereAnimation.Play("f02_" + WeaponName[Weapon] + "LowSanityA_00");
				RivalAnimation.Play("f02_" + WeaponName[Weapon] + "LowSanityB_00");
				if (Weapon == 1)
				{
					YandereAnimation.transform.localPosition = new Vector3(0f, 0f, 0f);
				}
				else if (Weapon == 5)
				{
					YandereAnimation.transform.localPosition = new Vector3(-0.25f, 0f, 0f);
				}
				else
				{
					YandereAnimation.transform.localPosition = new Vector3(-0.5f, 0f, 0f);
				}
				GameObject[] weapons = Weapons;
				foreach (GameObject gameObject in weapons)
				{
					if (gameObject != null)
					{
						gameObject.SetActive(false);
					}
				}
				Weapons[Weapon].SetActive(true);
				Hallucinate = true;
				Timer = 0f;
			}
		}
		if (!Hallucinate)
		{
			return;
		}
		if (YandereAnimation["f02_" + WeaponName[Weapon] + "LowSanityA_00"].time < 3f)
		{
			Alpha = Mathf.MoveTowards(Alpha, 1f, Time.deltaTime * 0.33333f);
		}
		else
		{
			Alpha = Mathf.MoveTowards(Alpha, 0f, Time.deltaTime * 0.33333f);
		}
		YandereHairRenderer.material.SetFloat("_Alpha", Alpha);
		if (RivalHairRenderer != null)
		{
			RivalHairRenderer.material.SetFloat("_Alpha", Alpha);
		}
		else
		{
			RichGirlHairRenderer.material.SetFloat("_Alpha", Alpha);
		}
		YandereRenderer.materials[0].SetFloat("_Alpha", Alpha);
		YandereRenderer.materials[1].SetFloat("_Alpha", Alpha);
		YandereRenderer.materials[2].SetFloat("_Alpha", Alpha);
		RivalRenderer.materials[0].SetFloat("_Alpha", Alpha);
		RivalRenderer.materials[1].SetFloat("_Alpha", Alpha);
		RivalRenderer.materials[2].SetFloat("_Alpha", Alpha);
		Renderer[] weaponRenderers = WeaponRenderers;
		foreach (Renderer renderer in weaponRenderers)
		{
			if (renderer != null)
			{
				renderer.material.SetFloat("_Alpha", Alpha);
			}
		}
		SawRenderer.material.SetFloat("_Alpha", Alpha);
		if (YandereAnimation["f02_" + WeaponName[Weapon] + "LowSanityA_00"].time == YandereAnimation["f02_" + WeaponName[Weapon] + "LowSanityA_00"].length || Yandere.Aiming)
		{
			MakeTransparent();
			Hallucinate = false;
		}
	}

	private void MakeTransparent()
	{
		Alpha = 0f;
		YandereHairRenderer.material.SetFloat("_Alpha", Alpha);
		RivalHairRenderer.material.SetFloat("_Alpha", Alpha);
		YandereRenderer.materials[0].SetFloat("_Alpha", Alpha);
		YandereRenderer.materials[1].SetFloat("_Alpha", Alpha);
		YandereRenderer.materials[2].SetFloat("_Alpha", Alpha);
		RivalRenderer.materials[0].SetFloat("_Alpha", Alpha);
		RivalRenderer.materials[1].SetFloat("_Alpha", Alpha);
		RivalRenderer.materials[2].SetFloat("_Alpha", Alpha);
		Renderer[] weaponRenderers = WeaponRenderers;
		foreach (Renderer renderer in weaponRenderers)
		{
			if (renderer != null)
			{
				renderer.material.SetFloat("_Alpha", Alpha);
			}
		}
		SawRenderer.material.SetFloat("_Alpha", Alpha);
	}
}
