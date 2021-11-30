using System;
using UnityEngine;

// Token: 0x020002CA RID: 714
public class FoldedUniformScript : MonoBehaviour
{
	// Token: 0x06001492 RID: 5266 RVA: 0x000C9850 File Offset: 0x000C7A50
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
			Debug.Log("A new uniform has appeared. There are now " + this.Yandere.StudentManager.NewUniforms.ToString() + " new uniforms at school.");
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
			base.gameObject.name = "School Uniform";
		}
		if (this.BloodyEightiesTexture != null)
		{
			for (int j = 1; j < this.MyRenderer.Length; j++)
			{
				this.MyRenderer[j].material.mainTexture = this.BloodyEightiesTexture;
			}
		}
	}

	// Token: 0x06001493 RID: 5267 RVA: 0x000C9A3C File Offset: 0x000C7C3C
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
			if (this.Prompt.Circle[0].fillAmount == 0f)
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

	// Token: 0x06001494 RID: 5268 RVA: 0x000C9BCC File Offset: 0x000C7DCC
	public void CleanUp()
	{
		Debug.Log("Firing the ''CleanUp()'' function.");
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

	// Token: 0x04002006 RID: 8198
	public YandereScript Yandere;

	// Token: 0x04002007 RID: 8199
	public PromptScript Prompt;

	// Token: 0x04002008 RID: 8200
	public GameObject SteamCloud;

	// Token: 0x04002009 RID: 8201
	public bool InPosition = true;

	// Token: 0x0400200A RID: 8202
	public bool Clean;

	// Token: 0x0400200B RID: 8203
	public bool Spare;

	// Token: 0x0400200C RID: 8204
	public float Timer;

	// Token: 0x0400200D RID: 8205
	public int Type;

	// Token: 0x0400200E RID: 8206
	public GameObject[] Uniforms;

	// Token: 0x0400200F RID: 8207
	public Renderer[] MyRenderer;

	// Token: 0x04002010 RID: 8208
	public Texture CleanTexture;

	// Token: 0x04002011 RID: 8209
	public Texture EightiesTexture;

	// Token: 0x04002012 RID: 8210
	public Texture BloodyEightiesTexture;
}
