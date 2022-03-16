using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using UnityEngine;

// Token: 0x020004AD RID: 1197
public class SerializableHashSet<T> : HashSet<T>, ISerializationCallbackReceiver, IXmlSerializable
{
	// Token: 0x06001F8B RID: 8075 RVA: 0x001BC484 File Offset: 0x001BA684
	public SerializableHashSet()
	{
		this.elements = new List<T>();
	}

	// Token: 0x06001F8C RID: 8076 RVA: 0x001BC498 File Offset: 0x001BA698
	public void OnBeforeSerialize()
	{
		this.elements.Clear();
		foreach (T item in this)
		{
			this.elements.Add(item);
		}
	}

	// Token: 0x06001F8D RID: 8077 RVA: 0x001BC4F8 File Offset: 0x001BA6F8
	public void OnAfterDeserialize()
	{
		base.Clear();
		for (int i = 0; i < this.elements.Count; i++)
		{
			base.Add(this.elements[i]);
		}
	}

	// Token: 0x06001F8E RID: 8078 RVA: 0x001BC534 File Offset: 0x001BA734
	public XmlSchema GetSchema()
	{
		return null;
	}

	// Token: 0x06001F8F RID: 8079 RVA: 0x001BC538 File Offset: 0x001BA738
	public void ReadXml(XmlReader reader)
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
		bool isEmptyElement = reader.IsEmptyElement;
		reader.Read();
		if (isEmptyElement)
		{
			return;
		}
		while (reader.NodeType != XmlNodeType.EndElement)
		{
			reader.ReadStartElement("Element");
			T item = (T)((object)xmlSerializer.Deserialize(reader));
			reader.ReadEndElement();
			base.Add(item);
			reader.MoveToContent();
		}
	}

	// Token: 0x06001F90 RID: 8080 RVA: 0x001BC59C File Offset: 0x001BA79C
	public void WriteXml(XmlWriter writer)
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
		foreach (T t in this)
		{
			writer.WriteStartElement("Element");
			xmlSerializer.Serialize(writer, t);
			writer.WriteEndElement();
		}
	}

	// Token: 0x040041F3 RID: 16883
	[SerializeField]
	private List<T> elements;

	// Token: 0x040041F4 RID: 16884
	private const string XML_Element = "Element";
}
