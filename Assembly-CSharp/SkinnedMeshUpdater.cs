using System;
using UnityEngine;

// Token: 0x02000428 RID: 1064
public class SkinnedMeshUpdater : MonoBehaviour
{
	// Token: 0x06001C9F RID: 7327 RVA: 0x0015304D File Offset: 0x0015124D
	public void Start()
	{
		this.GlassesCheck();
	}

	// Token: 0x06001CA0 RID: 7328 RVA: 0x00153058 File Offset: 0x00151258
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

	// Token: 0x06001CA1 RID: 7329 RVA: 0x001531BC File Offset: 0x001513BC
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

	// Token: 0x06001CA2 RID: 7330 RVA: 0x00153264 File Offset: 0x00151464
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

	// Token: 0x06001CA3 RID: 7331 RVA: 0x00153330 File Offset: 0x00151530
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

	// Token: 0x0400334E RID: 13134
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x0400334F RID: 13135
	public GameObject TransformEffect;

	// Token: 0x04003350 RID: 13136
	public GameObject[] Characters;

	// Token: 0x04003351 RID: 13137
	public PromptScript Prompt;

	// Token: 0x04003352 RID: 13138
	public GameObject BreastR;

	// Token: 0x04003353 RID: 13139
	public GameObject BreastL;

	// Token: 0x04003354 RID: 13140
	public GameObject FumiGlasses;

	// Token: 0x04003355 RID: 13141
	public GameObject NinaGlasses;

	// Token: 0x04003356 RID: 13142
	private SkinnedMeshRenderer TempRenderer;

	// Token: 0x04003357 RID: 13143
	public Texture[] Bodies;

	// Token: 0x04003358 RID: 13144
	public Texture[] Faces;

	// Token: 0x04003359 RID: 13145
	public float Timer;

	// Token: 0x0400335A RID: 13146
	public int ID;
}
