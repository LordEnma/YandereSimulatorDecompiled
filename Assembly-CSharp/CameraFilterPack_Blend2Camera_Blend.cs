using System;
using UnityEngine;

// Token: 0x02000126 RID: 294
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/Blend")]
public class CameraFilterPack_Blend2Camera_Blend : MonoBehaviour
{
	// Token: 0x1700022A RID: 554
	// (get) Token: 0x06000B61 RID: 2913 RVA: 0x0006C754 File Offset: 0x0006A954
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

	// Token: 0x06000B62 RID: 2914 RVA: 0x0006C788 File Offset: 0x0006A988
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

	// Token: 0x06000B63 RID: 2915 RVA: 0x0006C7EC File Offset: 0x0006A9EC
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

	// Token: 0x06000B64 RID: 2916 RVA: 0x0006C8B8 File Offset: 0x0006AAB8
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000B65 RID: 2917 RVA: 0x0006C8F0 File Offset: 0x0006AAF0
	private void Update()
	{
	}

	// Token: 0x06000B66 RID: 2918 RVA: 0x0006C8F2 File Offset: 0x0006AAF2
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000B67 RID: 2919 RVA: 0x0006C92A File Offset: 0x0006AB2A
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

	// Token: 0x04000F82 RID: 3970
	private string ShaderName = "CameraFilterPack/Blend2Camera_Blend";

	// Token: 0x04000F83 RID: 3971
	public Shader SCShader;

	// Token: 0x04000F84 RID: 3972
	public Camera Camera2;

	// Token: 0x04000F85 RID: 3973
	private float TimeX = 1f;

	// Token: 0x04000F86 RID: 3974
	private Material SCMaterial;

	// Token: 0x04000F87 RID: 3975
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x04000F88 RID: 3976
	private RenderTexture Camera2tex;
}
