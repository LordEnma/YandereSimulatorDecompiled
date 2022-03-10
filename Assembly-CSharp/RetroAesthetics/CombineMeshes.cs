using System;
using UnityEngine;

namespace RetroAesthetics
{
	// Token: 0x0200054A RID: 1354
	[ExecuteInEditMode]
	public class CombineMeshes : MonoBehaviour
	{
		// Token: 0x0600229F RID: 8863 RVA: 0x001F044A File Offset: 0x001EE64A
		private void CombineButtonHandler()
		{
			this.CombineChildMeshes();
		}

		// Token: 0x060022A0 RID: 8864 RVA: 0x001F0454 File Offset: 0x001EE654
		public virtual void CombineChildMeshes()
		{
			Vector3 position = base.transform.position;
			base.transform.position = Vector3.zero;
			MeshFilter[] componentsInChildren = base.GetComponentsInChildren<MeshFilter>();
			CombineInstance[] array = new CombineInstance[componentsInChildren.Length];
			Material material = null;
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				array[i].mesh = componentsInChildren[i].sharedMesh;
				array[i].transform = componentsInChildren[i].transform.localToWorldMatrix;
				Renderer component = componentsInChildren[i].gameObject.GetComponent<Renderer>();
				if (component != null)
				{
					component.enabled = false;
				}
				if (material == null && component.sharedMaterial != null)
				{
					material = component.sharedMaterial;
				}
			}
			MeshFilter meshFilter = base.GetComponent<MeshFilter>();
			if (meshFilter == null)
			{
				meshFilter = base.gameObject.AddComponent<MeshFilter>();
			}
			meshFilter.mesh = new Mesh();
			meshFilter.sharedMesh.CombineMeshes(array, true, true);
			if (base.GetComponent<MeshRenderer>() == null)
			{
				base.gameObject.AddComponent<MeshRenderer>().sharedMaterial = material;
			}
			base.transform.position = position;
		}

		// Token: 0x04004AB9 RID: 19129
		[InspectorButton("CombineButtonHandler")]
		public bool combineChildMeshes;
	}
}
