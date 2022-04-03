using System;
using UnityEngine;

// Token: 0x0200042E RID: 1070
public class SkinnedMeshUpdater : MonoBehaviour
{
	// Token: 0x06001CCA RID: 7370 RVA: 0x00156089 File Offset: 0x00154289
	public void Start()
	{
		this.GlassesCheck();
	}

	// Token: 0x06001CCB RID: 7371 RVA: 0x00156094 File Offset: 0x00154294
	public void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			UnityEngine.Object.Instantiate<GameObject>(this.TransformEffect, this.Prompt.Yandere.Hips.position, Quaternion.identity);
			this.Prompt.Yandere.CharacterAnimation.Play(this.Prompt.Yandere.IdleAnim);
			this.Prompt.Yandere.CanMove = false;
			this.Prompt.Yandere.Egg = true;
			this.BreastR.name = "RightBreast";
			this.BreastL.name = "LeftBreast";
			this.Timer = 1f;
			this.ID++;
			if (this.ID == this.Characters.Length)
			{
				this.ID = 1;
			}
			this.Prompt.Yandere.Hairstyle = 120 + this.ID;
			this.Prompt.Yandere.UpdateHair();
			this.GlassesCheck();
			this.UpdateSkin();
		}
		if (this.Timer > 0f)
		{
			this.Timer = Mathf.MoveTowards(this.Timer, 0f, Time.deltaTime);
			if (this.Timer == 0f)
			{
				this.Prompt.Yandere.CanMove = true;
			}
		}
	}

	// Token: 0x06001CCC RID: 7372 RVA: 0x001561F8 File Offset: 0x001543F8
	public void UpdateSkin()
	{
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Characters[this.ID], Vector3.zero, Quaternion.identity);
		this.TempRenderer = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
		this.UpdateMeshRenderer(this.TempRenderer);
		UnityEngine.Object.Destroy(gameObject);
		this.MyRenderer.materials[0].mainTexture = this.Bodies[this.ID];
		this.MyRenderer.materials[1].mainTexture = this.Bodies[this.ID];
		this.MyRenderer.materials[2].mainTexture = this.Faces[this.ID];
	}

	// Token: 0x06001CCD RID: 7373 RVA: 0x001562A0 File Offset: 0x001544A0
	private void UpdateMeshRenderer(SkinnedMeshRenderer newMeshRenderer)
	{
		SkinnedMeshRenderer myRenderer = this.Prompt.Yandere.MyRenderer;
		myRenderer.sharedMesh = newMeshRenderer.sharedMesh;
		Transform[] componentsInChildren = this.Prompt.Yandere.transform.GetComponentsInChildren<Transform>(true);
		Transform[] array = new Transform[newMeshRenderer.bones.Length];
		int boneOrder;
		Predicate<Transform> <>9__0;
		int boneOrder2;
		for (boneOrder = 0; boneOrder < newMeshRenderer.bones.Length; boneOrder = boneOrder2 + 1)
		{
			Transform[] array2 = array;
			int boneOrder3 = boneOrder;
			Transform[] array3 = componentsInChildren;
			Predicate<Transform> match;
			if ((match = <>9__0) == null)
			{
				match = (<>9__0 = ((Transform c) => c.name == newMeshRenderer.bones[boneOrder].name));
			}
			array2[boneOrder3] = Array.Find<Transform>(array3, match);
			boneOrder2 = boneOrder;
		}
		myRenderer.bones = array;
	}

	// Token: 0x06001CCE RID: 7374 RVA: 0x0015636C File Offset: 0x0015456C
	private void GlassesCheck()
	{
		this.FumiGlasses.SetActive(false);
		this.NinaGlasses.SetActive(false);
		if (this.ID == 7)
		{
			this.FumiGlasses.SetActive(true);
			return;
		}
		if (this.ID == 8)
		{
			this.NinaGlasses.SetActive(true);
		}
	}

	// Token: 0x040033CF RID: 13263
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x040033D0 RID: 13264
	public GameObject TransformEffect;

	// Token: 0x040033D1 RID: 13265
	public GameObject[] Characters;

	// Token: 0x040033D2 RID: 13266
	public PromptScript Prompt;

	// Token: 0x040033D3 RID: 13267
	public GameObject BreastR;

	// Token: 0x040033D4 RID: 13268
	public GameObject BreastL;

	// Token: 0x040033D5 RID: 13269
	public GameObject FumiGlasses;

	// Token: 0x040033D6 RID: 13270
	public GameObject NinaGlasses;

	// Token: 0x040033D7 RID: 13271
	private SkinnedMeshRenderer TempRenderer;

	// Token: 0x040033D8 RID: 13272
	public Texture[] Bodies;

	// Token: 0x040033D9 RID: 13273
	public Texture[] Faces;

	// Token: 0x040033DA RID: 13274
	public float Timer;

	// Token: 0x040033DB RID: 13275
	public int ID;
}
