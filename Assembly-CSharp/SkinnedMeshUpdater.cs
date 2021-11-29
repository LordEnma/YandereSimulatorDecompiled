using System;
using UnityEngine;

// Token: 0x02000424 RID: 1060
public class SkinnedMeshUpdater : MonoBehaviour
{
	// Token: 0x06001C8B RID: 7307 RVA: 0x001504D1 File Offset: 0x0014E6D1
	public void Start()
	{
		this.GlassesCheck();
	}

	// Token: 0x06001C8C RID: 7308 RVA: 0x001504DC File Offset: 0x0014E6DC
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

	// Token: 0x06001C8D RID: 7309 RVA: 0x00150640 File Offset: 0x0014E840
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

	// Token: 0x06001C8E RID: 7310 RVA: 0x001506E8 File Offset: 0x0014E8E8
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

	// Token: 0x06001C8F RID: 7311 RVA: 0x001507B4 File Offset: 0x0014E9B4
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

	// Token: 0x0400330B RID: 13067
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x0400330C RID: 13068
	public GameObject TransformEffect;

	// Token: 0x0400330D RID: 13069
	public GameObject[] Characters;

	// Token: 0x0400330E RID: 13070
	public PromptScript Prompt;

	// Token: 0x0400330F RID: 13071
	public GameObject BreastR;

	// Token: 0x04003310 RID: 13072
	public GameObject BreastL;

	// Token: 0x04003311 RID: 13073
	public GameObject FumiGlasses;

	// Token: 0x04003312 RID: 13074
	public GameObject NinaGlasses;

	// Token: 0x04003313 RID: 13075
	private SkinnedMeshRenderer TempRenderer;

	// Token: 0x04003314 RID: 13076
	public Texture[] Bodies;

	// Token: 0x04003315 RID: 13077
	public Texture[] Faces;

	// Token: 0x04003316 RID: 13078
	public float Timer;

	// Token: 0x04003317 RID: 13079
	public int ID;
}
