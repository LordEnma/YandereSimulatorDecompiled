using System;
using UnityEngine;

// Token: 0x0200042A RID: 1066
public class SkinnedMeshUpdater : MonoBehaviour
{
	// Token: 0x06001CB3 RID: 7347 RVA: 0x00154621 File Offset: 0x00152821
	public void Start()
	{
		this.GlassesCheck();
	}

	// Token: 0x06001CB4 RID: 7348 RVA: 0x0015462C File Offset: 0x0015282C
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

	// Token: 0x06001CB5 RID: 7349 RVA: 0x00154790 File Offset: 0x00152990
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

	// Token: 0x06001CB6 RID: 7350 RVA: 0x00154838 File Offset: 0x00152A38
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

	// Token: 0x06001CB7 RID: 7351 RVA: 0x00154904 File Offset: 0x00152B04
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

	// Token: 0x0400337E RID: 13182
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x0400337F RID: 13183
	public GameObject TransformEffect;

	// Token: 0x04003380 RID: 13184
	public GameObject[] Characters;

	// Token: 0x04003381 RID: 13185
	public PromptScript Prompt;

	// Token: 0x04003382 RID: 13186
	public GameObject BreastR;

	// Token: 0x04003383 RID: 13187
	public GameObject BreastL;

	// Token: 0x04003384 RID: 13188
	public GameObject FumiGlasses;

	// Token: 0x04003385 RID: 13189
	public GameObject NinaGlasses;

	// Token: 0x04003386 RID: 13190
	private SkinnedMeshRenderer TempRenderer;

	// Token: 0x04003387 RID: 13191
	public Texture[] Bodies;

	// Token: 0x04003388 RID: 13192
	public Texture[] Faces;

	// Token: 0x04003389 RID: 13193
	public float Timer;

	// Token: 0x0400338A RID: 13194
	public int ID;
}
