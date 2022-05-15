using System;
using UnityEngine;

// Token: 0x020002D1 RID: 721
public class FoldedUniformScript : MonoBehaviour
{
	// Token: 0x060014C0 RID: 5312 RVA: 0x000CC760 File Offset: 0x000CA960
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

	// Token: 0x060014C1 RID: 5313 RVA: 0x000CC96C File Offset: 0x000CAB6C
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
				if (this.Type > 1)
				{
					this.Yandere.MyLocker.Bloody[this.Type] = false;
					this.Yandere.MyLocker.UpdateButtons();
				}
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

	// Token: 0x060014C2 RID: 5314 RVA: 0x000CCB44 File Offset: 0x000CAD44
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

	// Token: 0x0400207E RID: 8318
	public YandereScript Yandere;

	// Token: 0x0400207F RID: 8319
	public PromptScript Prompt;

	// Token: 0x04002080 RID: 8320
	public GameObject SteamCloud;

	// Token: 0x04002081 RID: 8321
	public bool ClubAttire;

	// Token: 0x04002082 RID: 8322
	public bool InPosition = true;

	// Token: 0x04002083 RID: 8323
	public bool Clean;

	// Token: 0x04002084 RID: 8324
	public bool Spare;

	// Token: 0x04002085 RID: 8325
	public float Timer;

	// Token: 0x04002086 RID: 8326
	public int Type;

	// Token: 0x04002087 RID: 8327
	public GameObject[] Uniforms;

	// Token: 0x04002088 RID: 8328
	public Renderer[] MyRenderer;

	// Token: 0x04002089 RID: 8329
	public Texture CleanTexture;

	// Token: 0x0400208A RID: 8330
	public Texture EightiesTexture;

	// Token: 0x0400208B RID: 8331
	public Texture BloodyEightiesTexture;
}
