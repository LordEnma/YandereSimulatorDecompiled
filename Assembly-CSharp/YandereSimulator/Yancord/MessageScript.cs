using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x02000517 RID: 1303
	public class MessageScript : MonoBehaviour
	{
		// Token: 0x06002141 RID: 8513 RVA: 0x001E673C File Offset: 0x001E493C
		public void Awake()
		{
			if (this.MyProfile != null)
			{
				if (this.NameLabel != null)
				{
					this.NameLabel.text = this.MyProfile.FirstName + " " + this.MyProfile.LastName;
				}
				if (this.ProfilPictureTexture != null)
				{
					this.ProfilPictureTexture.mainTexture = this.MyProfile.ProfilePicture;
				}
				base.gameObject.name = this.MyProfile.FirstName + "_Message";
			}
		}

		// Token: 0x040048E1 RID: 18657
		[Header("== Partner Informations ==")]
		public Profile MyProfile;

		// Token: 0x040048E2 RID: 18658
		[Space(20f)]
		public UILabel NameLabel;

		// Token: 0x040048E3 RID: 18659
		public UILabel MessageLabel;

		// Token: 0x040048E4 RID: 18660
		public UITexture ProfilPictureTexture;
	}
}
