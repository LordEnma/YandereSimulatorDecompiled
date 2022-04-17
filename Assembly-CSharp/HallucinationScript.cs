using System;
using UnityEngine;

// Token: 0x0200030E RID: 782
public class HallucinationScript : MonoBehaviour
{
	// Token: 0x0600184F RID: 6223 RVA: 0x000E6A50 File Offset: 0x000E4C50
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

	// Token: 0x06001850 RID: 6224 RVA: 0x000E6C0C File Offset: 0x000E4E0C
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

	// Token: 0x06001851 RID: 6225 RVA: 0x000E7074 File Offset: 0x000E5274
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

	// Token: 0x04002367 RID: 9063
	public SkinnedMeshRenderer YandereHairRenderer;

	// Token: 0x04002368 RID: 9064
	public SkinnedMeshRenderer YandereRenderer;

	// Token: 0x04002369 RID: 9065
	public SkinnedMeshRenderer RivalHairRenderer;

	// Token: 0x0400236A RID: 9066
	public SkinnedMeshRenderer RivalRenderer;

	// Token: 0x0400236B RID: 9067
	public Animation YandereAnimation;

	// Token: 0x0400236C RID: 9068
	public Animation RivalAnimation;

	// Token: 0x0400236D RID: 9069
	public YandereScript Yandere;

	// Token: 0x0400236E RID: 9070
	public Material Black;

	// Token: 0x0400236F RID: 9071
	public bool Hallucinate;

	// Token: 0x04002370 RID: 9072
	public float Alpha;

	// Token: 0x04002371 RID: 9073
	public float Timer;

	// Token: 0x04002372 RID: 9074
	public int Weapon;

	// Token: 0x04002373 RID: 9075
	public Renderer[] WeaponRenderers;

	// Token: 0x04002374 RID: 9076
	public Renderer SawRenderer;

	// Token: 0x04002375 RID: 9077
	public GameObject[] Weapons;

	// Token: 0x04002376 RID: 9078
	public string[] WeaponName;

	// Token: 0x04002377 RID: 9079
	public GameObject[] EightiesRivalHair;

	// Token: 0x04002378 RID: 9080
	public GameObject[] RivalHair;

	// Token: 0x04002379 RID: 9081
	public GameObject RyobaHair;

	// Token: 0x0400237A RID: 9082
	public SkinnedMeshRenderer RyobaHairRenderer;

	// Token: 0x0400237B RID: 9083
	public Mesh LongSleeveUniform;
}
