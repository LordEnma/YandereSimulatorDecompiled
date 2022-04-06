using System;
using UnityEngine;

// Token: 0x0200012A RID: 298
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/ColorDodge")]
public class CameraFilterPack_Blend2Camera_ColorDodge : MonoBehaviour
{
	// Token: 0x1700022E RID: 558
	// (get) Token: 0x06000B84 RID: 2948 RVA: 0x0006D8EB File Offset: 0x0006BAEB
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

	// Token: 0x06000B85 RID: 2949 RVA: 0x0006D920 File Offset: 0x0006BB20
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

	// Token: 0x06000B86 RID: 2950 RVA: 0x0006D984 File Offset: 0x0006BB84
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
			this.material.SetFloat("_Value2", this.SwitchCameraToCamera2);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000B87 RID: 2951 RVA: 0x0006DA74 File Offset: 0x0006BC74
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000B88 RID: 2952 RVA: 0x0006DAAC File Offset: 0x0006BCAC
	private void Update()
	{
	}

	// Token: 0x06000B89 RID: 2953 RVA: 0x0006DAAE File Offset: 0x0006BCAE
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000B8A RID: 2954 RVA: 0x0006DAE6 File Offset: 0x0006BCE6
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

	// Token: 0x04000FBA RID: 4026
	private string ShaderName = "CameraFilterPack/Blend2Camera_ColorDodge";

	// Token: 0x04000FBB RID: 4027
	public Shader SCShader;

	// Token: 0x04000FBC RID: 4028
	public Camera Camera2;

	// Token: 0x04000FBD RID: 4029
	private float TimeX = 1f;

	// Token: 0x04000FBE RID: 4030
	private Material SCMaterial;

	// Token: 0x04000FBF RID: 4031
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x04000FC0 RID: 4032
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x04000FC1 RID: 4033
	private RenderTexture Camera2tex;
}
