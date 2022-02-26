using System;
using UnityEngine;

// Token: 0x02000126 RID: 294
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/Blend")]
public class CameraFilterPack_Blend2Camera_Blend : MonoBehaviour
{
	// Token: 0x1700022A RID: 554
	// (get) Token: 0x06000B62 RID: 2914 RVA: 0x0006C9B8 File Offset: 0x0006ABB8
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

	// Token: 0x06000B63 RID: 2915 RVA: 0x0006C9EC File Offset: 0x0006ABEC
	private void Start()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000B64 RID: 2916 RVA: 0x0006CA50 File Offset: 0x0006AC50
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.SCShader != null)
		{
			this.TimeX += Time.deltaTime;
			if (this.TimeX > 100f)
			{
				this.TimeX = 0f;
			}
			this.material.SetTexture("_MainTex2", this.Camera2tex);
			this.material.SetFloat("_TimeX", this.TimeX);
			this.material.SetFloat("_Value", this.BlendFX);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000B65 RID: 2917 RVA: 0x0006CB1C File Offset: 0x0006AD1C
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000B66 RID: 2918 RVA: 0x0006CB54 File Offset: 0x0006AD54
	private void Update()
	{
	}

	// Token: 0x06000B67 RID: 2919 RVA: 0x0006CB56 File Offset: 0x0006AD56
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000B68 RID: 2920 RVA: 0x0006CB8E File Offset: 0x0006AD8E
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

	// Token: 0x04000F85 RID: 3973
	private string ShaderName = "CameraFilterPack/Blend2Camera_Blend";

	// Token: 0x04000F86 RID: 3974
	public Shader SCShader;

	// Token: 0x04000F87 RID: 3975
	public Camera Camera2;

	// Token: 0x04000F88 RID: 3976
	private float TimeX = 1f;

	// Token: 0x04000F89 RID: 3977
	private Material SCMaterial;

	// Token: 0x04000F8A RID: 3978
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x04000F8B RID: 3979
	private RenderTexture Camera2tex;
}
