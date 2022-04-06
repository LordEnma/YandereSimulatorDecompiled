using System;
using UnityEngine;

// Token: 0x0200012C RID: 300
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/Darken")]
public class CameraFilterPack_Blend2Camera_Darken : MonoBehaviour
{
	// Token: 0x17000230 RID: 560
	// (get) Token: 0x06000B93 RID: 2963 RVA: 0x0006DDE7 File Offset: 0x0006BFE7
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

	// Token: 0x06000B94 RID: 2964 RVA: 0x0006DE1C File Offset: 0x0006C01C
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

	// Token: 0x06000B95 RID: 2965 RVA: 0x0006DE80 File Offset: 0x0006C080
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

	// Token: 0x06000B96 RID: 2966 RVA: 0x0006DF70 File Offset: 0x0006C170
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000B97 RID: 2967 RVA: 0x0006DFA8 File Offset: 0x0006C1A8
	private void Update()
	{
	}

	// Token: 0x06000B98 RID: 2968 RVA: 0x0006DFAA File Offset: 0x0006C1AA
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000B99 RID: 2969 RVA: 0x0006DFE2 File Offset: 0x0006C1E2
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

	// Token: 0x04000FD1 RID: 4049
	private string ShaderName = "CameraFilterPack/Blend2Camera_Darken";

	// Token: 0x04000FD2 RID: 4050
	public Shader SCShader;

	// Token: 0x04000FD3 RID: 4051
	public Camera Camera2;

	// Token: 0x04000FD4 RID: 4052
	private float TimeX = 1f;

	// Token: 0x04000FD5 RID: 4053
	private Material SCMaterial;

	// Token: 0x04000FD6 RID: 4054
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x04000FD7 RID: 4055
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x04000FD8 RID: 4056
	private RenderTexture Camera2tex;
}
