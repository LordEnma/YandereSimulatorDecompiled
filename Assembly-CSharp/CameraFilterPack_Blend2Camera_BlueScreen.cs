using System;
using UnityEngine;

// Token: 0x02000127 RID: 295
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Chroma Key/BlueScreen")]
public class CameraFilterPack_Blend2Camera_BlueScreen : MonoBehaviour
{
	// Token: 0x1700022B RID: 555
	// (get) Token: 0x06000B6A RID: 2922 RVA: 0x0006CAD7 File Offset: 0x0006ACD7
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

	// Token: 0x06000B6B RID: 2923 RVA: 0x0006CB0B File Offset: 0x0006AD0B
	private void OnValidate()
	{
		this.ScreenSize.x = (float)Screen.width;
		this.ScreenSize.y = (float)Screen.height;
	}

	// Token: 0x06000B6C RID: 2924 RVA: 0x0006CB30 File Offset: 0x0006AD30
	private void Start()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture((int)this.ScreenSize.x, (int)this.ScreenSize.y, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000B6D RID: 2925 RVA: 0x0006CBA4 File Offset: 0x0006ADA4
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.SCShader != null)
		{
			this.TimeX += Time.deltaTime;
			if (this.TimeX > 100f)
			{
				this.TimeX = 0f;
			}
			if (this.Camera2 != null)
			{
				this.material.SetTexture("_MainTex2", this.Camera2tex);
			}
			this.material.SetFloat("_TimeX", this.TimeX);
			this.material.SetFloat("_Value", this.BlendFX);
			this.material.SetFloat("_Value2", this.Adjust);
			this.material.SetFloat("_Value3", this.Precision);
			this.material.SetFloat("_Value4", this.Luminosity);
			this.material.SetFloat("_Value5", this.Change_Red);
			this.material.SetFloat("_Value6", this.Change_Green);
			this.material.SetFloat("_Value7", this.Change_Blue);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000B6E RID: 2926 RVA: 0x0006CCD5 File Offset: 0x0006AED5
	private void Update()
	{
		this.ScreenSize.x = (float)Screen.width;
		this.ScreenSize.y = (float)Screen.height;
		bool isPlaying = Application.isPlaying;
	}

	// Token: 0x06000B6F RID: 2927 RVA: 0x0006CCFF File Offset: 0x0006AEFF
	private void OnEnable()
	{
		this.Start();
	}

	// Token: 0x06000B70 RID: 2928 RVA: 0x0006CD07 File Offset: 0x0006AF07
	private void OnDisable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2.targetTexture = null;
		}
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000F8C RID: 3980
	private string ShaderName = "CameraFilterPack/Blend2Camera_BlueScreen";

	// Token: 0x04000F8D RID: 3981
	public Shader SCShader;

	// Token: 0x04000F8E RID: 3982
	public Camera Camera2;

	// Token: 0x04000F8F RID: 3983
	private float TimeX = 1f;

	// Token: 0x04000F90 RID: 3984
	private Material SCMaterial;

	// Token: 0x04000F91 RID: 3985
	[Range(0f, 1f)]
	public float BlendFX = 1f;

	// Token: 0x04000F92 RID: 3986
	[Range(-0.2f, 0.2f)]
	public float Adjust;

	// Token: 0x04000F93 RID: 3987
	[Range(-0.2f, 0.2f)]
	public float Precision;

	// Token: 0x04000F94 RID: 3988
	[Range(-0.2f, 0.2f)]
	public float Luminosity;

	// Token: 0x04000F95 RID: 3989
	[Range(-0.3f, 0.3f)]
	public float Change_Red;

	// Token: 0x04000F96 RID: 3990
	[Range(-0.3f, 0.3f)]
	public float Change_Green;

	// Token: 0x04000F97 RID: 3991
	[Range(-0.3f, 0.3f)]
	public float Change_Blue;

	// Token: 0x04000F98 RID: 3992
	private RenderTexture Camera2tex;

	// Token: 0x04000F99 RID: 3993
	private Vector2 ScreenSize;
}
