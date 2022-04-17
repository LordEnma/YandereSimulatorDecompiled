using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200051D RID: 1309
public class YanSaveStaticIdentifier : MonoBehaviour
{
	// Token: 0x040049D3 RID: 18899
	[SerializeField]
	public List<string> StaticTypeNames = new List<string>();

	// Token: 0x040049D4 RID: 18900
	[SerializeField]
	public List<KeyValuePair<Type, string>> DisabledMembers = new List<KeyValuePair<Type, string>>();

	// Token: 0x040049D5 RID: 18901
	[SerializeField]
	public List<YanSavePlayerPrefTracker> PrefTrackers = new List<YanSavePlayerPrefTracker>();
}
