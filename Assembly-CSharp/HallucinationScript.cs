using System;
using UnityEngine;

// Token: 0x0200030B RID: 779
public class HallucinationScript : MonoBehaviour
{
	// Token: 0x06001831 RID: 6193 RVA: 0x000E5118 File Offset: 0x000E3318
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

	// Token: 0x06001832 RID: 6194 RVA: 0x000E52E4 File Offset: 0x000E34E4
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

	// Token: 0x06001833 RID: 6195 RVA: 0x000E574C File Offset: 0x000E394C
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

	// Token: 0x04002320 RID: 8992
	public SkinnedMeshRenderer YandereHairRenderer;

	// Token: 0x04002321 RID: 8993
	public SkinnedMeshRenderer YandereRenderer;

	// Token: 0x04002322 RID: 8994
	public SkinnedMeshRenderer RivalHairRenderer;

	// Token: 0x04002323 RID: 8995
	public SkinnedMeshRenderer RivalRenderer;

	// Token: 0x04002324 RID: 8996
	public Animation YandereAnimation;

	// Token: 0x04002325 RID: 8997
	public Animation RivalAnimation;

	// Token: 0x04002326 RID: 8998
	public YandereScript Yandere;

	// Token: 0x04002327 RID: 8999
	public Material Black;

	// Token: 0x04002328 RID: 9000
	public bool Hallucinate;

	// Token: 0x04002329 RID: 9001
	public float Alpha;

	// Token: 0x0400232A RID: 9002
	public float Timer;

	// Token: 0x0400232B RID: 9003
	public int Weapon;

	// Token: 0x0400232C RID: 9004
	public Renderer[] WeaponRenderers;

	// Token: 0x0400232D RID: 9005
	public Renderer SawRenderer;

	// Token: 0x0400232E RID: 9006
	public GameObject[] Weapons;

	// Token: 0x0400232F RID: 9007
	public string[] WeaponName;

	// Token: 0x04002330 RID: 9008
	public GameObject[] EightiesRivalHair;

	// Token: 0x04002331 RID: 9009
	public GameObject[] RivalHair;

	// Token: 0x04002332 RID: 9010
	public GameObject RyobaHair;

	// Token: 0x04002333 RID: 9011
	public Mesh LongSleeveUniform;
}
