using System;
using UnityEngine;

// Token: 0x020002CD RID: 717
public class FoldedUniformScript : MonoBehaviour
{
	// Token: 0x060014A3 RID: 5283 RVA: 0x000CAC54 File Offset: 0x000C8E54
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

	// Token: 0x060014A4 RID: 5284 RVA: 0x000CAE48 File Offset: 0x000C9048
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

	// Token: 0x060014A5 RID: 5285 RVA: 0x000CAFD8 File Offset: 0x000C91D8
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

	// Token: 0x0400203D RID: 8253
	public YandereScript Yandere;

	// Token: 0x0400203E RID: 8254
	public PromptScript Prompt;

	// Token: 0x0400203F RID: 8255
	public GameObject SteamCloud;

	// Token: 0x04002040 RID: 8256
	public bool InPosition = true;

	// Token: 0x04002041 RID: 8257
	public bool Clean;

	// Token: 0x04002042 RID: 8258
	public bool Spare;

	// Token: 0x04002043 RID: 8259
	public float Timer;

	// Token: 0x04002044 RID: 8260
	public int Type;

	// Token: 0x04002045 RID: 8261
	public GameObject[] Uniforms;

	// Token: 0x04002046 RID: 8262
	public Renderer[] MyRenderer;

	// Token: 0x04002047 RID: 8263
	public Texture CleanTexture;

	// Token: 0x04002048 RID: 8264
	public Texture EightiesTexture;

	// Token: 0x04002049 RID: 8265
	public Texture BloodyEightiesTexture;
}
