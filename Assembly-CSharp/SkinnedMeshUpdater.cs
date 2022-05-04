using System;
using UnityEngine;

// Token: 0x02000430 RID: 1072
public class SkinnedMeshUpdater : MonoBehaviour
{
	// Token: 0x06001CDC RID: 7388 RVA: 0x00156FC1 File Offset: 0x001551C1
	public void Start()
	{
		this.GlassesCheck();
	}

	// Token: 0x06001CDD RID: 7389 RVA: 0x00156FCC File Offset: 0x001551CC
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

	// Token: 0x06001CDE RID: 7390 RVA: 0x00157130 File Offset: 0x00155330
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

	// Token: 0x06001CDF RID: 7391 RVA: 0x001571D8 File Offset: 0x001553D8
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

	// Token: 0x06001CE0 RID: 7392 RVA: 0x001572A4 File Offset: 0x001554A4
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

	// Token: 0x040033EC RID: 13292
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x040033ED RID: 13293
	public GameObject TransformEffect;

	// Token: 0x040033EE RID: 13294
	public GameObject[] Characters;

	// Token: 0x040033EF RID: 13295
	public PromptScript Prompt;

	// Token: 0x040033F0 RID: 13296
	public GameObject BreastR;

	// Token: 0x040033F1 RID: 13297
	public GameObject BreastL;

	// Token: 0x040033F2 RID: 13298
	public GameObject FumiGlasses;

	// Token: 0x040033F3 RID: 13299
	public GameObject NinaGlasses;

	// Token: 0x040033F4 RID: 13300
	private SkinnedMeshRenderer TempRenderer;

	// Token: 0x040033F5 RID: 13301
	public Texture[] Bodies;

	// Token: 0x040033F6 RID: 13302
	public Texture[] Faces;

	// Token: 0x040033F7 RID: 13303
	public float Timer;

	// Token: 0x040033F8 RID: 13304
	public int ID;
}
