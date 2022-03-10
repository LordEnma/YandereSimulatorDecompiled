using System;
using UnityEngine;

// Token: 0x020002CE RID: 718
public class FoldedUniformScript : MonoBehaviour
{
	// Token: 0x060014AC RID: 5292 RVA: 0x000CB684 File Offset: 0x000C9884
	private void Start()
	{
		for (int i = 1; i < this.Uniforms.Length; i++)
		{
			this.Uniforms[i].SetActive(false);
		}
		if (this.Uniforms.Length != 0)
		{
			this.Uniforms[StudentGlobals.FemaleUniform].SetActive(true);
		}
		if (this.Prompt != null && this.Prompt.Yandere != null)
		{
			this.Yandere = this.Prompt.Yandere;
		}
		else
		{
			GameObject gameObject = GameObject.Find("YandereChan");
			if (gameObject != null)
			{
				this.Yandere = gameObject.GetComponent<YandereScript>();
			}
		}
		bool flag = false;
		if (this.Spare && !GameGlobals.SpareUniform)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			flag = true;
		}
		if (!flag && this.Clean && this.Prompt.Button[0] != null)
		{
			this.Prompt.HideButton[0] = true;
			this.Yandere.StudentManager.NewUniforms++;
			this.Yandere.StudentManager.UpdateStudents(0);
			this.Yandere.StudentManager.Uniforms[this.Yandere.StudentManager.NewUniforms] = base.transform;
			Debug.Log("A new uniform has been spawned. The number of ''New Uniforms'' at school is now " + this.Yandere.StudentManager.NewUniforms.ToString() + ".");
		}
		if (this.Type == 1)
		{
			base.gameObject.name = "School Uniform";
		}
		if (this.Type == 2)
		{
			base.gameObject.name = "Swimsuit";
		}
		else if (this.Type == 3)
		{
			base.gameObject.name = "Gym Uniform";
		}
		else
		{
			base.gameObject.name = "Folded Club Uniform";
		}
		if (GameGlobals.Eighties && this.BloodyEightiesTexture != null)
		{
			for (int j = 1; j < this.MyRenderer.Length; j++)
			{
				this.MyRenderer[j].material.mainTexture = this.BloodyEightiesTexture;
			}
		}
	}

	// Token: 0x060014AD RID: 5293 RVA: 0x000CB890 File Offset: 0x000C9A90
	private void Update()
	{
		if (this.Clean)
		{
			this.InPosition = this.Yandere.StudentManager.LockerRoomArea.bounds.Contains(base.transform.position);
			if (this.Yandere.MyRenderer.sharedMesh != this.Yandere.Towel || this.Yandere.Bloodiness != 0f || !this.InPosition)
			{
				this.Prompt.HideButton[0] = true;
			}
			else
			{
				this.Prompt.HideButton[0] = false;
			}
			if (this.Prompt.Circle[0] != null && this.Prompt.Circle[0].fillAmount == 0f)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.SteamCloud, this.Yandere.transform.position + Vector3.up * 0.81f, Quaternion.identity);
				this.Yandere.CharacterAnimation.CrossFade("f02_stripping_00");
				this.Yandere.CurrentUniformOrigin = 2;
				this.Yandere.Stripping = true;
				this.Yandere.CanMove = false;
				this.Timer += Time.deltaTime;
			}
			if (this.Timer > 0f)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer > 1.5f)
				{
					this.Yandere.Schoolwear = this.Type;
					this.Yandere.ChangeSchoolwear();
					UnityEngine.Object.Destroy(base.gameObject);
				}
			}
		}
	}

	// Token: 0x060014AE RID: 5294 RVA: 0x000CBA38 File Offset: 0x000C9C38
	public void CleanUp()
	{
		Debug.Log("A folded uniform is firing the ''CleanUp()'' function.");
		if (GameGlobals.Eighties && this.EightiesTexture != null)
		{
			this.CleanTexture = this.EightiesTexture;
		}
		this.Clean = true;
		for (int i = 1; i < this.MyRenderer.Length; i++)
		{
			this.MyRenderer[i].material.mainTexture = this.CleanTexture;
		}
	}

	// Token: 0x04002055 RID: 8277
	public YandereScript Yandere;

	// Token: 0x04002056 RID: 8278
	public PromptScript Prompt;

	// Token: 0x04002057 RID: 8279
	public GameObject SteamCloud;

	// Token: 0x04002058 RID: 8280
	public bool ClubAttire;

	// Token: 0x04002059 RID: 8281
	public bool InPosition = true;

	// Token: 0x0400205A RID: 8282
	public bool Clean;

	// Token: 0x0400205B RID: 8283
	public bool Spare;

	// Token: 0x0400205C RID: 8284
	public float Timer;

	// Token: 0x0400205D RID: 8285
	public int Type;

	// Token: 0x0400205E RID: 8286
	public GameObject[] Uniforms;

	// Token: 0x0400205F RID: 8287
	public Renderer[] MyRenderer;

	// Token: 0x04002060 RID: 8288
	public Texture CleanTexture;

	// Token: 0x04002061 RID: 8289
	public Texture EightiesTexture;

	// Token: 0x04002062 RID: 8290
	public Texture BloodyEightiesTexture;
}
