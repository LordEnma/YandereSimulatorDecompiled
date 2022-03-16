using System;
using UnityEngine;

// Token: 0x0200042B RID: 1067
public class SkinnedMeshUpdater : MonoBehaviour
{
	// Token: 0x06001CC0 RID: 7360 RVA: 0x0015552D File Offset: 0x0015372D
	public void Start()
	{
		this.GlassesCheck();
	}

	// Token: 0x06001CC1 RID: 7361 RVA: 0x00155538 File Offset: 0x00153738
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

	// Token: 0x06001CC2 RID: 7362 RVA: 0x0015569C File Offset: 0x0015389C
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

	// Token: 0x06001CC3 RID: 7363 RVA: 0x00155744 File Offset: 0x00153944
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

	// Token: 0x06001CC4 RID: 7364 RVA: 0x00155810 File Offset: 0x00153A10
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

	// Token: 0x040033B3 RID: 13235
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x040033B4 RID: 13236
	public GameObject TransformEffect;

	// Token: 0x040033B5 RID: 13237
	public GameObject[] Characters;

	// Token: 0x040033B6 RID: 13238
	public PromptScript Prompt;

	// Token: 0x040033B7 RID: 13239
	public GameObject BreastR;

	// Token: 0x040033B8 RID: 13240
	public GameObject BreastL;

	// Token: 0x040033B9 RID: 13241
	public GameObject FumiGlasses;

	// Token: 0x040033BA RID: 13242
	public GameObject NinaGlasses;

	// Token: 0x040033BB RID: 13243
	private SkinnedMeshRenderer TempRenderer;

	// Token: 0x040033BC RID: 13244
	public Texture[] Bodies;

	// Token: 0x040033BD RID: 13245
	public Texture[] Faces;

	// Token: 0x040033BE RID: 13246
	public float Timer;

	// Token: 0x040033BF RID: 13247
	public int ID;
}
