using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x02000528 RID: 1320
	public class MessageScript : MonoBehaviour
	{
		// Token: 0x060021B0 RID: 8624 RVA: 0x001F07B4 File Offset: 0x001EE9B4
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

		// Token: 0x04004A0C RID: 18956
		[Header("== Partner Informations ==")]
		public Profile MyProfile;

		// Token: 0x04004A0D RID: 18957
		[Space(20f)]
		public UILabel NameLabel;

		// Token: 0x04004A0E RID: 18958
		public UILabel MessageLabel;

		// Token: 0x04004A0F RID: 18959
		public UITexture ProfilPictureTexture;
	}
}
