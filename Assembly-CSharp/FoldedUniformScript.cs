using System;
using UnityEngine;

// Token: 0x020002CE RID: 718
public class FoldedUniformScript : MonoBehaviour
{
	// Token: 0x060014AF RID: 5295 RVA: 0x000CBAF4 File Offset: 0x000C9CF4
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

	// Token: 0x060014B0 RID: 5296 RVA: 0x000CBD00 File Offset: 0x000C9F00
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

	// Token: 0x060014B1 RID: 5297 RVA: 0x000CBEA8 File Offset: 0x000CA0A8
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

	// Token: 0x04002065 RID: 8293
	public YandereScript Yandere;

	// Token: 0x04002066 RID: 8294
	public PromptScript Prompt;

	// Token: 0x04002067 RID: 8295
	public GameObject SteamCloud;

	// Token: 0x04002068 RID: 8296
	public bool ClubAttire;

	// Token: 0x04002069 RID: 8297
	public bool InPosition = true;

	// Token: 0x0400206A RID: 8298
	public bool Clean;

	// Token: 0x0400206B RID: 8299
	public bool Spare;

	// Token: 0x0400206C RID: 8300
	public float Timer;

	// Token: 0x0400206D RID: 8301
	public int Type;

	// Token: 0x0400206E RID: 8302
	public GameObject[] Uniforms;

	// Token: 0x0400206F RID: 8303
	public Renderer[] MyRenderer;

	// Token: 0x04002070 RID: 8304
	public Texture CleanTexture;

	// Token: 0x04002071 RID: 8305
	public Texture EightiesTexture;

	// Token: 0x04002072 RID: 8306
	public Texture BloodyEightiesTexture;
}
