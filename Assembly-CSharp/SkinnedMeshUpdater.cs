using System;
using UnityEngine;

// Token: 0x02000429 RID: 1065
public class SkinnedMeshUpdater : MonoBehaviour
{
	// Token: 0x06001CA8 RID: 7336 RVA: 0x001535F1 File Offset: 0x001517F1
	public void Start()
	{
		this.GlassesCheck();
	}

	// Token: 0x06001CA9 RID: 7337 RVA: 0x001535FC File Offset: 0x001517FC
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

	// Token: 0x06001CAA RID: 7338 RVA: 0x00153760 File Offset: 0x00151960
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

	// Token: 0x06001CAB RID: 7339 RVA: 0x00153808 File Offset: 0x00151A08
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

	// Token: 0x06001CAC RID: 7340 RVA: 0x001538D4 File Offset: 0x00151AD4
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

	// Token: 0x04003358 RID: 13144
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x04003359 RID: 13145
	public GameObject TransformEffect;

	// Token: 0x0400335A RID: 13146
	public GameObject[] Characters;

	// Token: 0x0400335B RID: 13147
	public PromptScript Prompt;

	// Token: 0x0400335C RID: 13148
	public GameObject BreastR;

	// Token: 0x0400335D RID: 13149
	public GameObject BreastL;

	// Token: 0x0400335E RID: 13150
	public GameObject FumiGlasses;

	// Token: 0x0400335F RID: 13151
	public GameObject NinaGlasses;

	// Token: 0x04003360 RID: 13152
	private SkinnedMeshRenderer TempRenderer;

	// Token: 0x04003361 RID: 13153
	public Texture[] Bodies;

	// Token: 0x04003362 RID: 13154
	public Texture[] Faces;

	// Token: 0x04003363 RID: 13155
	public float Timer;

	// Token: 0x04003364 RID: 13156
	public int ID;
}
