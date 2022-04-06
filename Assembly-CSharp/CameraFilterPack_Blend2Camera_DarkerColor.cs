using System;
using UnityEngine;

// Token: 0x0200012D RID: 301
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/DarkerColor")]
public class CameraFilterPack_Blend2Camera_DarkerColor : MonoBehaviour
{
	// Token: 0x17000231 RID: 561
	// (get) Token: 0x06000B9B RID: 2971 RVA: 0x0006E03F File Offset: 0x0006C23F
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

	// Token: 0x06000B9C RID: 2972 RVA: 0x0006E074 File Offset: 0x0006C274
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

	// Token: 0x06000B9D RID: 2973 RVA: 0x0006E0D8 File Offset: 0x0006C2D8
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

	// Token: 0x06000B9E RID: 2974 RVA: 0x0006E1C8 File Offset: 0x0006C3C8
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000B9F RID: 2975 RVA: 0x0006E200 File Offset: 0x0006C400
	private void Update()
	{
	}

	// Token: 0x06000BA0 RID: 2976 RVA: 0x0006E202 File Offset: 0x0006C402
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BA1 RID: 2977 RVA: 0x0006E23A File Offset: 0x0006C43A
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

	// Token: 0x04000FD9 RID: 4057
	private string ShaderName = "CameraFilterPack/Blend2Camera_DarkerColor";

	// Token: 0x04000FDA RID: 4058
	public Shader SCShader;

	// Token: 0x04000FDB RID: 4059
	public Camera Camera2;

	// Token: 0x04000FDC RID: 4060
	private float TimeX = 1f;

	// Token: 0x04000FDD RID: 4061
	private Material SCMaterial;

	// Token: 0x04000FDE RID: 4062
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x04000FDF RID: 4063
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x04000FE0 RID: 4064
	private RenderTexture Camera2tex;
}
