using System;
using UnityEngine;

// Token: 0x02000308 RID: 776
public class HallucinationScript : MonoBehaviour
{
	// Token: 0x0600181A RID: 6170 RVA: 0x000E3B40 File Offset: 0x000E1D40
	private void Start()
	{
		this.YandereHairRenderer.material = this.Black;
		this.RivalHairRenderer.material = this.Black;
		this.YandereRenderer.materials[0] = this.Black;
		this.YandereRenderer.materials[1] = this.Black;
		this.YandereRenderer.materials[2] = this.Black;
		this.RivalRenderer.materials[0] = this.Black;
		this.RivalRenderer.materials[1] = this.Black;
		this.RivalRenderer.materials[2] = this.Black;
		foreach (Renderer renderer in this.WeaponRenderers)
		{
			if (renderer != null)
			{
				renderer.material = this.Black;
			}
		}
		this.SawRenderer.material = this.Black;
		this.MakeTransparent();
		for (int j = 1; j < 11; j++)
		{
			this.EightiesRivalHair[j].SetActive(false);
		}
		if (GameGlobals.Eighties)
		{
			if (DateGlobals.Week > 0 && DateGlobals.Week < 11)
			{
				this.YandereHairRenderer.transform.parent.gameObject.SetActive(false);
				this.RivalHair[1].SetActive(false);
				this.EightiesRivalHair[DateGlobals.Week].SetActive(true);
				this.YandereHairRenderer = this.RyobaHair.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>();
				this.RivalHairRenderer = this.EightiesRivalHair[DateGlobals.Week].transform.GetChild(0).GetComponent<SkinnedMeshRenderer>();
				this.YandereRenderer.sharedMesh = this.LongSleeveUniform;
				this.RivalRenderer.sharedMesh = this.LongSleeveUniform;
				return;
			}
		}
		else
		{
			this.RyobaHair.SetActive(false);
		}
	}

	// Token: 0x0600181B RID: 6171 RVA: 0x000E3D0C File Offset: 0x000E1F0C
	private void Update()
	{
		if (this.Yandere.Sanity < 33.33333f)
		{
			if (!this.Yandere.Aiming && this.Yandere.CanMove)
			{
				this.Timer += Time.deltaTime;
			}
			if (this.Timer > 6f)
			{
				this.Weapon = UnityEngine.Random.Range(1, 6);
				base.transform.position = this.Yandere.transform.position + this.Yandere.transform.forward;
				base.transform.eulerAngles = this.Yandere.transform.eulerAngles;
				this.YandereAnimation["f02_" + this.WeaponName[this.Weapon] + "LowSanityA_00"].time = 0f;
				this.RivalAnimation["f02_" + this.WeaponName[this.Weapon] + "LowSanityB_00"].time = 0f;
				this.YandereAnimation.Play("f02_" + this.WeaponName[this.Weapon] + "LowSanityA_00");
				this.RivalAnimation.Play("f02_" + this.WeaponName[this.Weapon] + "LowSanityB_00");
				if (this.Weapon == 1)
				{
					this.YandereAnimation.transform.localPosition = new Vector3(0f, 0f, 0f);
				}
				else if (this.Weapon == 5)
				{
					this.YandereAnimation.transform.localPosition = new Vector3(-0.25f, 0f, 0f);
				}
				else
				{
					this.YandereAnimation.transform.localPosition = new Vector3(-0.5f, 0f, 0f);
				}
				foreach (GameObject gameObject in this.Weapons)
				{
					if (gameObject != null)
					{
						gameObject.SetActive(false);
					}
				}
				this.Weapons[this.Weapon].SetActive(true);
				this.Hallucinate = true;
				this.Timer = 0f;
			}
		}
		if (this.Hallucinate)
		{
			if (this.YandereAnimation["f02_" + this.WeaponName[this.Weapon] + "LowSanityA_00"].time < 3f)
			{
				this.Alpha = Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime * 0.33333f);
			}
			else
			{
				this.Alpha = Mathf.MoveTowards(this.Alpha, 0f, Time.deltaTime * 0.33333f);
			}
			this.YandereHairRenderer.material.SetFloat("_Alpha", this.Alpha);
			this.RivalHairRenderer.material.SetFloat("_Alpha", this.Alpha);
			this.YandereRenderer.materials[0].SetFloat("_Alpha", this.Alpha);
			this.YandereRenderer.materials[1].SetFloat("_Alpha", this.Alpha);
			this.YandereRenderer.materials[2].SetFloat("_Alpha", this.Alpha);
			this.RivalRenderer.materials[0].SetFloat("_Alpha", this.Alpha);
			this.RivalRenderer.materials[1].SetFloat("_Alpha", this.Alpha);
			this.RivalRenderer.materials[2].SetFloat("_Alpha", this.Alpha);
			foreach (Renderer renderer in this.WeaponRenderers)
			{
				if (renderer != null)
				{
					renderer.material.SetFloat("_Alpha", this.Alpha);
				}
			}
			this.SawRenderer.material.SetFloat("_Alpha", this.Alpha);
			if (this.YandereAnimation["f02_" + this.WeaponName[this.Weapon] + "LowSanityA_00"].time == this.YandereAnimation["f02_" + this.WeaponName[this.Weapon] + "LowSanityA_00"].length || this.Yandere.Aiming)
			{
				this.MakeTransparent();
				this.Hallucinate = false;
			}
		}
	}

	// Token: 0x0600181C RID: 6172 RVA: 0x000E4174 File Offset: 0x000E2374
	private void MakeTransparent()
	{
		this.Alpha = 0f;
		this.YandereHairRenderer.material.SetFloat("_Alpha", this.Alpha);
		this.RivalHairRenderer.material.SetFloat("_Alpha", this.Alpha);
		this.YandereRenderer.materials[0].SetFloat("_Alpha", this.Alpha);
		this.YandereRenderer.materials[1].SetFloat("_Alpha", this.Alpha);
		this.YandereRenderer.materials[2].SetFloat("_Alpha", this.Alpha);
		this.RivalRenderer.materials[0].SetFloat("_Alpha", this.Alpha);
		this.RivalRenderer.materials[1].SetFloat("_Alpha", this.Alpha);
		this.RivalRenderer.materials[2].SetFloat("_Alpha", this.Alpha);
		foreach (Renderer renderer in this.WeaponRenderers)
		{
			if (renderer != null)
			{
				renderer.material.SetFloat("_Alpha", this.Alpha);
			}
		}
		this.SawRenderer.material.SetFloat("_Alpha", this.Alpha);
	}

	// Token: 0x040022E6 RID: 8934
	public SkinnedMeshRenderer YandereHairRenderer;

	// Token: 0x040022E7 RID: 8935
	public SkinnedMeshRenderer YandereRenderer;

	// Token: 0x040022E8 RID: 8936
	public SkinnedMeshRenderer RivalHairRenderer;

	// Token: 0x040022E9 RID: 8937
	public SkinnedMeshRenderer RivalRenderer;

	// Token: 0x040022EA RID: 8938
	public Animation YandereAnimation;

	// Token: 0x040022EB RID: 8939
	public Animation RivalAnimation;

	// Token: 0x040022EC RID: 8940
	public YandereScript Yandere;

	// Token: 0x040022ED RID: 8941
	public Material Black;

	// Token: 0x040022EE RID: 8942
	public bool Hallucinate;

	// Token: 0x040022EF RID: 8943
	public float Alpha;

	// Token: 0x040022F0 RID: 8944
	public float Timer;

	// Token: 0x040022F1 RID: 8945
	public int Weapon;

	// Token: 0x040022F2 RID: 8946
	public Renderer[] WeaponRenderers;

	// Token: 0x040022F3 RID: 8947
	public Renderer SawRenderer;

	// Token: 0x040022F4 RID: 8948
	public GameObject[] Weapons;

	// Token: 0x040022F5 RID: 8949
	public string[] WeaponName;

	// Token: 0x040022F6 RID: 8950
	public GameObject[] EightiesRivalHair;

	// Token: 0x040022F7 RID: 8951
	public GameObject[] RivalHair;

	// Token: 0x040022F8 RID: 8952
	public GameObject RyobaHair;

	// Token: 0x040022F9 RID: 8953
	public Mesh LongSleeveUniform;
}
