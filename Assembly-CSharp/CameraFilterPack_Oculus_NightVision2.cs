using System;
using UnityEngine;

// Token: 0x020001F1 RID: 497
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Night Vision/Night Vision 2")]
public class CameraFilterPack_Oculus_NightVision2 : MonoBehaviour
{
	// Token: 0x170002F5 RID: 757
	// (get) Token: 0x06001084 RID: 4228 RVA: 0x00083F0A File Offset: 0x0008210A
	private Material material
	{
		get
		{
			if (this.SCMaterial == null)
			{
				this.SCMaterial = new Material(this.SCShader);
				this.SCMaterial.hideFlags = HideFlags.HideAndDontSave;
			}
			return this.SCMaterial;
		}
	}

	// Token: 0x06001085 RID: 4229 RVA: 0x00083F3E File Offset: 0x0008213E
	private void ChangeFilters()
	{
		this.Matrix9 = new float[]
		{
			200f,
			-200f,
			-200f,
			195f,
			4f,
			-160f,
			200f,
			-200f,
			-200f,
			-200f,
			10f,
			-200f
		};
	}

	// Token: 0x06001086 RID: 4230 RVA: 0x00083F58 File Offset: 0x00082158
	private void Start()
	{
		this.ChangeFilters();
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001087 RID: 4231 RVA: 0x00083F80 File Offset: 0x00082180
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.SCShader != null)
		{
			this.TimeX += Time.deltaTime;
			if (this.TimeX > 100f)
			{
				this.TimeX = 0f;
			}
			this.material.SetFloat("_TimeX", this.TimeX);
			this.material.SetFloat("_Red_R", this.Matrix9[0] / 100f);
			this.material.SetFloat("_Red_G", this.Matrix9[1] / 100f);
			this.material.SetFloat("_Red_B", this.Matrix9[2] / 100f);
			this.material.SetFloat("_Green_R", this.Matrix9[3] / 100f);
			this.material.SetFloat("_Green_G", this.Matrix9[4] / 100f);
			this.material.SetFloat("_Green_B", this.Matrix9[5] / 100f);
			this.material.SetFloat("_Blue_R", this.Matrix9[6] / 100f);
			this.material.SetFloat("_Blue_G", this.Matrix9[7] / 100f);
			this.material.SetFloat("_Blue_B", this.Matrix9[8] / 100f);
			this.material.SetFloat("_Red_C", this.Matrix9[9] / 100f);
			this.material.SetFloat("_Green_C", this.Matrix9[10] / 100f);
			this.material.SetFloat("_Blue_C", this.Matrix9[11] / 100f);
			this.material.SetFloat("_FadeFX", this.FadeFX);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06001088 RID: 4232 RVA: 0x000841A1 File Offset: 0x000823A1
	private void OnValidate()
	{
		this.ChangeFilters();
	}

	// Token: 0x06001089 RID: 4233 RVA: 0x000841A9 File Offset: 0x000823A9
	private void Update()
	{
	}

	// Token: 0x0600108A RID: 4234 RVA: 0x000841AB File Offset: 0x000823AB
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001514 RID: 5396
	private string ShaderName = "CameraFilterPack/Oculus_NightVision2";

	// Token: 0x04001515 RID: 5397
	public Shader SCShader;

	// Token: 0x04001516 RID: 5398
	[Range(0f, 1f)]
	public float FadeFX = 1f;

	// Token: 0x04001517 RID: 5399
	private float TimeX = 1f;

	// Token: 0x04001518 RID: 5400
	private Material SCMaterial;

	// Token: 0x04001519 RID: 5401
	private float[] Matrix9;
}
