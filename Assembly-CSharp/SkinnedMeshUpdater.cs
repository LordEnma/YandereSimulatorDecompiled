using System;
using UnityEngine;

// Token: 0x02000431 RID: 1073
public class SkinnedMeshUpdater : MonoBehaviour
{
	// Token: 0x06001CE2 RID: 7394 RVA: 0x00157C75 File Offset: 0x00155E75
	public void Start()
	{
		this.GlassesCheck();
	}

	// Token: 0x06001CE3 RID: 7395 RVA: 0x00157C80 File Offset: 0x00155E80
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

	// Token: 0x06001CE4 RID: 7396 RVA: 0x00157DE4 File Offset: 0x00155FE4
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

	// Token: 0x06001CE5 RID: 7397 RVA: 0x00157E8C File Offset: 0x0015608C
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

	// Token: 0x06001CE6 RID: 7398 RVA: 0x00157F58 File Offset: 0x00156158
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

	// Token: 0x04003401 RID: 13313
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x04003402 RID: 13314
	public GameObject TransformEffect;

	// Token: 0x04003403 RID: 13315
	public GameObject[] Characters;

	// Token: 0x04003404 RID: 13316
	public PromptScript Prompt;

	// Token: 0x04003405 RID: 13317
	public GameObject BreastR;

	// Token: 0x04003406 RID: 13318
	public GameObject BreastL;

	// Token: 0x04003407 RID: 13319
	public GameObject FumiGlasses;

	// Token: 0x04003408 RID: 13320
	public GameObject NinaGlasses;

	// Token: 0x04003409 RID: 13321
	private SkinnedMeshRenderer TempRenderer;

	// Token: 0x0400340A RID: 13322
	public Texture[] Bodies;

	// Token: 0x0400340B RID: 13323
	public Texture[] Faces;

	// Token: 0x0400340C RID: 13324
	public float Timer;

	// Token: 0x0400340D RID: 13325
	public int ID;
}
