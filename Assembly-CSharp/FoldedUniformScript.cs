using System;
using UnityEngine;

// Token: 0x020002CB RID: 715
public class FoldedUniformScript : MonoBehaviour
{
	// Token: 0x06001499 RID: 5273 RVA: 0x000CA234 File Offset: 0x000C8434
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
		if (GameGlobals.Eighties && this.BloodyEightiesTexture != null)
		{
			for (int j = 1; j < this.MyRenderer.Length; j++)
			{
				this.MyRenderer[j].material.mainTexture = this.BloodyEightiesTexture;
			}
		}
	}

	// Token: 0x0600149A RID: 5274 RVA: 0x000CA428 File Offset: 0x000C8628
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

	// Token: 0x0600149B RID: 5275 RVA: 0x000CA5B8 File Offset: 0x000C87B8
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

	// Token: 0x04002029 RID: 8233
	public YandereScript Yandere;

	// Token: 0x0400202A RID: 8234
	public PromptScript Prompt;

	// Token: 0x0400202B RID: 8235
	public GameObject SteamCloud;

	// Token: 0x0400202C RID: 8236
	public bool InPosition = true;

	// Token: 0x0400202D RID: 8237
	public bool Clean;

	// Token: 0x0400202E RID: 8238
	public bool Spare;

	// Token: 0x0400202F RID: 8239
	public float Timer;

	// Token: 0x04002030 RID: 8240
	public int Type;

	// Token: 0x04002031 RID: 8241
	public GameObject[] Uniforms;

	// Token: 0x04002032 RID: 8242
	public Renderer[] MyRenderer;

	// Token: 0x04002033 RID: 8243
	public Texture CleanTexture;

	// Token: 0x04002034 RID: 8244
	public Texture EightiesTexture;

	// Token: 0x04002035 RID: 8245
	public Texture BloodyEightiesTexture;
}
