using System;
using UnityEngine;

// Token: 0x0200042F RID: 1071
public class SkinnedMeshUpdater : MonoBehaviour
{
	// Token: 0x06001CD5 RID: 7381 RVA: 0x001567B9 File Offset: 0x001549B9
	public void Start()
	{
		this.GlassesCheck();
	}

	// Token: 0x06001CD6 RID: 7382 RVA: 0x001567C4 File Offset: 0x001549C4
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

	// Token: 0x06001CD7 RID: 7383 RVA: 0x00156928 File Offset: 0x00154B28
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

	// Token: 0x06001CD8 RID: 7384 RVA: 0x001569D0 File Offset: 0x00154BD0
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

	// Token: 0x06001CD9 RID: 7385 RVA: 0x00156A9C File Offset: 0x00154C9C
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

	// Token: 0x040033DD RID: 13277
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x040033DE RID: 13278
	public GameObject TransformEffect;

	// Token: 0x040033DF RID: 13279
	public GameObject[] Characters;

	// Token: 0x040033E0 RID: 13280
	public PromptScript Prompt;

	// Token: 0x040033E1 RID: 13281
	public GameObject BreastR;

	// Token: 0x040033E2 RID: 13282
	public GameObject BreastL;

	// Token: 0x040033E3 RID: 13283
	public GameObject FumiGlasses;

	// Token: 0x040033E4 RID: 13284
	public GameObject NinaGlasses;

	// Token: 0x040033E5 RID: 13285
	private SkinnedMeshRenderer TempRenderer;

	// Token: 0x040033E6 RID: 13286
	public Texture[] Bodies;

	// Token: 0x040033E7 RID: 13287
	public Texture[] Faces;

	// Token: 0x040033E8 RID: 13288
	public float Timer;

	// Token: 0x040033E9 RID: 13289
	public int ID;
}
