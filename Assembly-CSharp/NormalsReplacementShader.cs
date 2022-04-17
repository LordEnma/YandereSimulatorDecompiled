using System;
using UnityEngine;

// Token: 0x020004FB RID: 1275
public class NormalsReplacementShader : MonoBehaviour
{
	// Token: 0x06002129 RID: 8489 RVA: 0x001EB268 File Offset: 0x001E9468
	private void Start()
	{
		Camera component = base.GetComponent<Camera>();
		this.renderTexture = new RenderTexture(component.pixelWidth, component.pixelHeight, 24);
		Shader.SetGlobalTexture("_CameraNormalsTexture", this.renderTexture);
		GameObject gameObject = new GameObject("Normals camera");
		this.camera = gameObject.AddComponent<Camera>();
		this.camera.CopyFrom(component);
		this.camera.transform.SetParent(base.transform);
		this.camera.targetTexture = this.renderTexture;
		this.camera.SetReplacementShader(this.normalsShader, "RenderType");
		this.camera.depth = component.depth - 1f;
	}

	// Token: 0x04004961 RID: 18785
	[SerializeField]
	private Shader normalsShader;

	// Token: 0x04004962 RID: 18786
	private RenderTexture renderTexture;

	// Token: 0x04004963 RID: 18787
	private Camera camera;
}
