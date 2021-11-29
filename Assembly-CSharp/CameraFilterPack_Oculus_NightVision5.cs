using System;
using UnityEngine;

// Token: 0x020001F2 RID: 498
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Night Vision/Night Vision 5")]
public class CameraFilterPack_Oculus_NightVision5 : MonoBehaviour
{
	// Token: 0x170002F7 RID: 759
	// (get) Token: 0x0600108E RID: 4238 RVA: 0x00083D89 File Offset: 0x00081F89
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

	// Token: 0x0600108F RID: 4239 RVA: 0x00083DBD File Offset: 0x00081FBD
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

	// Token: 0x06001090 RID: 4240 RVA: 0x00083DD7 File Offset: 0x00081FD7
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

	// Token: 0x06001091 RID: 4241 RVA: 0x00083E00 File Offset: 0x00082000
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
			this.material.SetFloat("_Size", this._Size);
			this.material.SetFloat("_Dist", this._Dist);
			this.material.SetFloat("_Smooth", this._Smooth);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06001092 RID: 4242 RVA: 0x00084063 File Offset: 0x00082263
	private void OnValidate()
	{
		this.ChangeFilters();
	}

	// Token: 0x06001093 RID: 4243 RVA: 0x0008406B File Offset: 0x0008226B
	private void Update()
	{
	}

	// Token: 0x06001094 RID: 4244 RVA: 0x0008406D File Offset: 0x0008226D
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400150D RID: 5389
	private string ShaderName = "CameraFilterPack/Oculus_NightVision5";

	// Token: 0x0400150E RID: 5390
	public Shader SCShader;

	// Token: 0x0400150F RID: 5391
	[Range(0f, 1f)]
	public float FadeFX = 1f;

	// Token: 0x04001510 RID: 5392
	[Range(0f, 1f)]
	public float _Size = 0.37f;

	// Token: 0x04001511 RID: 5393
	[Range(0f, 1f)]
	public float _Smooth = 0.15f;

	// Token: 0x04001512 RID: 5394
	[Range(0f, 1f)]
	public float _Dist = 0.285f;

	// Token: 0x04001513 RID: 5395
	private float TimeX = 1f;

	// Token: 0x04001514 RID: 5396
	private Material SCMaterial;

	// Token: 0x04001515 RID: 5397
	private float[] Matrix9;
}
