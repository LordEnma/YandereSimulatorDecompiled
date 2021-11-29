using System;
using UnityEngine;

// Token: 0x02000126 RID: 294
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Chroma Key/BlueScreen")]
public class CameraFilterPack_Blend2Camera_BlueScreen : MonoBehaviour
{
	// Token: 0x1700022B RID: 555
	// (get) Token: 0x06000B66 RID: 2918 RVA: 0x0006C78F File Offset: 0x0006A98F
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

	// Token: 0x06000B67 RID: 2919 RVA: 0x0006C7C3 File Offset: 0x0006A9C3
	private void OnValidate()
	{
		this.ScreenSize.x = (float)Screen.width;
		this.ScreenSize.y = (float)Screen.height;
	}

	// Token: 0x06000B68 RID: 2920 RVA: 0x0006C7E8 File Offset: 0x0006A9E8
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

	// Token: 0x06000B69 RID: 2921 RVA: 0x0006C85C File Offset: 0x0006AA5C
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

	// Token: 0x06000B6A RID: 2922 RVA: 0x0006C98D File Offset: 0x0006AB8D
	private void Update()
	{
		this.ScreenSize.x = (float)Screen.width;
		this.ScreenSize.y = (float)Screen.height;
		bool isPlaying = Application.isPlaying;
	}

	// Token: 0x06000B6B RID: 2923 RVA: 0x0006C9B7 File Offset: 0x0006ABB7
	private void OnEnable()
	{
		this.Start();
	}

	// Token: 0x06000B6C RID: 2924 RVA: 0x0006C9BF File Offset: 0x0006ABBF
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

	// Token: 0x04000F84 RID: 3972
	private string ShaderName = "CameraFilterPack/Blend2Camera_BlueScreen";

	// Token: 0x04000F85 RID: 3973
	public Shader SCShader;

	// Token: 0x04000F86 RID: 3974
	public Camera Camera2;

	// Token: 0x04000F87 RID: 3975
	private float TimeX = 1f;

	// Token: 0x04000F88 RID: 3976
	private Material SCMaterial;

	// Token: 0x04000F89 RID: 3977
	[Range(0f, 1f)]
	public float BlendFX = 1f;

	// Token: 0x04000F8A RID: 3978
	[Range(-0.2f, 0.2f)]
	public float Adjust;

	// Token: 0x04000F8B RID: 3979
	[Range(-0.2f, 0.2f)]
	public float Precision;

	// Token: 0x04000F8C RID: 3980
	[Range(-0.2f, 0.2f)]
	public float Luminosity;

	// Token: 0x04000F8D RID: 3981
	[Range(-0.3f, 0.3f)]
	public float Change_Red;

	// Token: 0x04000F8E RID: 3982
	[Range(-0.3f, 0.3f)]
	public float Change_Green;

	// Token: 0x04000F8F RID: 3983
	[Range(-0.3f, 0.3f)]
	public float Change_Blue;

	// Token: 0x04000F90 RID: 3984
	private RenderTexture Camera2tex;

	// Token: 0x04000F91 RID: 3985
	private Vector2 ScreenSize;
}
