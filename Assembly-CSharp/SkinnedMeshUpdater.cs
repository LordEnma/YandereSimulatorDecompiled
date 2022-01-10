using System;
using UnityEngine;

// Token: 0x02000427 RID: 1063
public class SkinnedMeshUpdater : MonoBehaviour
{
	// Token: 0x06001C9C RID: 7324 RVA: 0x00151505 File Offset: 0x0014F705
	public void Start()
	{
		this.GlassesCheck();
	}

	// Token: 0x06001C9D RID: 7325 RVA: 0x00151510 File Offset: 0x0014F710
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

	// Token: 0x06001C9E RID: 7326 RVA: 0x00151674 File Offset: 0x0014F874
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

	// Token: 0x06001C9F RID: 7327 RVA: 0x0015171C File Offset: 0x0014F91C
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

	// Token: 0x06001CA0 RID: 7328 RVA: 0x001517E8 File Offset: 0x0014F9E8
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

	// Token: 0x04003343 RID: 13123
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x04003344 RID: 13124
	public GameObject TransformEffect;

	// Token: 0x04003345 RID: 13125
	public GameObject[] Characters;

	// Token: 0x04003346 RID: 13126
	public PromptScript Prompt;

	// Token: 0x04003347 RID: 13127
	public GameObject BreastR;

	// Token: 0x04003348 RID: 13128
	public GameObject BreastL;

	// Token: 0x04003349 RID: 13129
	public GameObject FumiGlasses;

	// Token: 0x0400334A RID: 13130
	public GameObject NinaGlasses;

	// Token: 0x0400334B RID: 13131
	private SkinnedMeshRenderer TempRenderer;

	// Token: 0x0400334C RID: 13132
	public Texture[] Bodies;

	// Token: 0x0400334D RID: 13133
	public Texture[] Faces;

	// Token: 0x0400334E RID: 13134
	public float Timer;

	// Token: 0x0400334F RID: 13135
	public int ID;
}
