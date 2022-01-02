using System;
using UnityEngine;

// Token: 0x02000425 RID: 1061
public class SkinnedMeshUpdater : MonoBehaviour
{
	// Token: 0x06001C95 RID: 7317 RVA: 0x00151201 File Offset: 0x0014F401
	public void Start()
	{
		this.GlassesCheck();
	}

	// Token: 0x06001C96 RID: 7318 RVA: 0x0015120C File Offset: 0x0014F40C
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

	// Token: 0x06001C97 RID: 7319 RVA: 0x00151370 File Offset: 0x0014F570
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

	// Token: 0x06001C98 RID: 7320 RVA: 0x00151418 File Offset: 0x0014F618
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

	// Token: 0x06001C99 RID: 7321 RVA: 0x001514E4 File Offset: 0x0014F6E4
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

	// Token: 0x0400333D RID: 13117
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x0400333E RID: 13118
	public GameObject TransformEffect;

	// Token: 0x0400333F RID: 13119
	public GameObject[] Characters;

	// Token: 0x04003340 RID: 13120
	public PromptScript Prompt;

	// Token: 0x04003341 RID: 13121
	public GameObject BreastR;

	// Token: 0x04003342 RID: 13122
	public GameObject BreastL;

	// Token: 0x04003343 RID: 13123
	public GameObject FumiGlasses;

	// Token: 0x04003344 RID: 13124
	public GameObject NinaGlasses;

	// Token: 0x04003345 RID: 13125
	private SkinnedMeshRenderer TempRenderer;

	// Token: 0x04003346 RID: 13126
	public Texture[] Bodies;

	// Token: 0x04003347 RID: 13127
	public Texture[] Faces;

	// Token: 0x04003348 RID: 13128
	public float Timer;

	// Token: 0x04003349 RID: 13129
	public int ID;
}
