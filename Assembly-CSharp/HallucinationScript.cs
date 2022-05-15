using System;
using UnityEngine;

// Token: 0x0200030F RID: 783
public class HallucinationScript : MonoBehaviour
{
	// Token: 0x06001858 RID: 6232 RVA: 0x000E7218 File Offset: 0x000E5418
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
				this.YandereHairRenderer = this.RyobaHairRenderer;
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

	// Token: 0x06001859 RID: 6233 RVA: 0x000E73D4 File Offset: 0x000E55D4
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

	// Token: 0x0600185A RID: 6234 RVA: 0x000E783C File Offset: 0x000E5A3C
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

	// Token: 0x0400237B RID: 9083
	public SkinnedMeshRenderer YandereHairRenderer;

	// Token: 0x0400237C RID: 9084
	public SkinnedMeshRenderer YandereRenderer;

	// Token: 0x0400237D RID: 9085
	public SkinnedMeshRenderer RivalHairRenderer;

	// Token: 0x0400237E RID: 9086
	public SkinnedMeshRenderer RivalRenderer;

	// Token: 0x0400237F RID: 9087
	public Animation YandereAnimation;

	// Token: 0x04002380 RID: 9088
	public Animation RivalAnimation;

	// Token: 0x04002381 RID: 9089
	public YandereScript Yandere;

	// Token: 0x04002382 RID: 9090
	public Material Black;

	// Token: 0x04002383 RID: 9091
	public bool Hallucinate;

	// Token: 0x04002384 RID: 9092
	public float Alpha;

	// Token: 0x04002385 RID: 9093
	public float Timer;

	// Token: 0x04002386 RID: 9094
	public int Weapon;

	// Token: 0x04002387 RID: 9095
	public Renderer[] WeaponRenderers;

	// Token: 0x04002388 RID: 9096
	public Renderer SawRenderer;

	// Token: 0x04002389 RID: 9097
	public GameObject[] Weapons;

	// Token: 0x0400238A RID: 9098
	public string[] WeaponName;

	// Token: 0x0400238B RID: 9099
	public GameObject[] EightiesRivalHair;

	// Token: 0x0400238C RID: 9100
	public GameObject[] RivalHair;

	// Token: 0x0400238D RID: 9101
	public GameObject RyobaHair;

	// Token: 0x0400238E RID: 9102
	public SkinnedMeshRenderer RyobaHairRenderer;

	// Token: 0x0400238F RID: 9103
	public Mesh LongSleeveUniform;
}
