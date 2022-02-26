using System;
using UnityEngine;

// Token: 0x0200042A RID: 1066
public class SkinnedMeshUpdater : MonoBehaviour
{
	// Token: 0x06001CB1 RID: 7345 RVA: 0x0015409D File Offset: 0x0015229D
	public void Start()
	{
		this.GlassesCheck();
	}

	// Token: 0x06001CB2 RID: 7346 RVA: 0x001540A8 File Offset: 0x001522A8
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

	// Token: 0x06001CB3 RID: 7347 RVA: 0x0015420C File Offset: 0x0015240C
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

	// Token: 0x06001CB4 RID: 7348 RVA: 0x001542B4 File Offset: 0x001524B4
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

	// Token: 0x06001CB5 RID: 7349 RVA: 0x00154380 File Offset: 0x00152580
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

	// Token: 0x04003368 RID: 13160
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x04003369 RID: 13161
	public GameObject TransformEffect;

	// Token: 0x0400336A RID: 13162
	public GameObject[] Characters;

	// Token: 0x0400336B RID: 13163
	public PromptScript Prompt;

	// Token: 0x0400336C RID: 13164
	public GameObject BreastR;

	// Token: 0x0400336D RID: 13165
	public GameObject BreastL;

	// Token: 0x0400336E RID: 13166
	public GameObject FumiGlasses;

	// Token: 0x0400336F RID: 13167
	public GameObject NinaGlasses;

	// Token: 0x04003370 RID: 13168
	private SkinnedMeshRenderer TempRenderer;

	// Token: 0x04003371 RID: 13169
	public Texture[] Bodies;

	// Token: 0x04003372 RID: 13170
	public Texture[] Faces;

	// Token: 0x04003373 RID: 13171
	public float Timer;

	// Token: 0x04003374 RID: 13172
	public int ID;
}
