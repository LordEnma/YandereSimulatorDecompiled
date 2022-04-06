using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200051D RID: 1309
public class YanSaveStaticIdentifier : MonoBehaviour
{
	// Token: 0x040049C1 RID: 18881
	[SerializeField]
	public List<string> StaticTypeNames = new List<string>();

	// Token: 0x040049C2 RID: 18882
	[SerializeField]
	public List<KeyValuePair<Type, string>> DisabledMembers = new List<KeyValuePair<Type, string>>();

	// Token: 0x040049C3 RID: 18883
	[SerializeField]
	public List<YanSavePlayerPrefTracker> PrefTrackers = new List<YanSavePlayerPrefTracker>();
}
