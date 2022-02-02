using System;
using UnityEngine;

namespace RetroAesthetics
{
	// Token: 0x02000547 RID: 1351
	[ExecuteInEditMode]
	public class CombineMeshes : MonoBehaviour
	{
		// Token: 0x06002284 RID: 8836 RVA: 0x001EE4C2 File Offset: 0x001EC6C2
		private void CombineButtonHandler()
		{
			this.CombineChildMeshes();
		}

		// Token: 0x06002285 RID: 8837 RVA: 0x001EE4CC File Offset: 0x001EC6CC
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

		// Token: 0x04004A7A RID: 19066
		[InspectorButton("CombineButtonHandler")]
		public bool combineChildMeshes;
	}
}
