using System;
using UnityEngine;

// Token: 0x0200012E RID: 302
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/Difference")]
public class CameraFilterPack_Blend2Camera_Difference : MonoBehaviour
{
	// Token: 0x17000232 RID: 562
	// (get) Token: 0x06000BA1 RID: 2977 RVA: 0x0006DE1B File Offset: 0x0006C01B
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

	// Token: 0x06000BA2 RID: 2978 RVA: 0x0006DE50 File Offset: 0x0006C050
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

	// Token: 0x06000BA3 RID: 2979 RVA: 0x0006DEB4 File Offset: 0x0006C0B4
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

	// Token: 0x06000BA4 RID: 2980 RVA: 0x0006DFA4 File Offset: 0x0006C1A4
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BA5 RID: 2981 RVA: 0x0006DFDC File Offset: 0x0006C1DC
	private void Update()
	{
	}

	// Token: 0x06000BA6 RID: 2982 RVA: 0x0006DFDE File Offset: 0x0006C1DE
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BA7 RID: 2983 RVA: 0x0006E016 File Offset: 0x0006C216
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

	// Token: 0x04000FDA RID: 4058
	private string ShaderName = "CameraFilterPack/Blend2Camera_Difference";

	// Token: 0x04000FDB RID: 4059
	public Shader SCShader;

	// Token: 0x04000FDC RID: 4060
	public Camera Camera2;

	// Token: 0x04000FDD RID: 4061
	private float TimeX = 1f;

	// Token: 0x04000FDE RID: 4062
	private Material SCMaterial;

	// Token: 0x04000FDF RID: 4063
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x04000FE0 RID: 4064
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x04000FE1 RID: 4065
	private RenderTexture Camera2tex;
}
