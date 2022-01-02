using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x02000517 RID: 1303
	public class MessageScript : MonoBehaviour
	{
		// Token: 0x06002144 RID: 8516 RVA: 0x001E6D2C File Offset: 0x001E4F2C
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

		// Token: 0x040048EA RID: 18666
		[Header("== Partner Informations ==")]
		public Profile MyProfile;

		// Token: 0x040048EB RID: 18667
		[Space(20f)]
		public UILabel NameLabel;

		// Token: 0x040048EC RID: 18668
		public UILabel MessageLabel;

		// Token: 0x040048ED RID: 18669
		public UITexture ProfilPictureTexture;
	}
}
