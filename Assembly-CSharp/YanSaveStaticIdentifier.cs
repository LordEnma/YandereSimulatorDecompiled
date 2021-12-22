using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200050D RID: 1293
public class YanSaveStaticIdentifier : MonoBehaviour
{
	// Token: 0x040048BE RID: 18622
	[SerializeField]
	public List<string> StaticTypeNames = new List<string>();

	// Token: 0x040048BF RID: 18623
	[SerializeField]
	public List<KeyValuePair<Type, string>> DisabledMembers = new List<KeyValuePair<Type, string>>();

	// Token: 0x040048C0 RID: 18624
	[SerializeField]
	public List<YanSavePlayerPrefTracker> PrefTrackers = new List<YanSavePlayerPrefTracker>();
}
