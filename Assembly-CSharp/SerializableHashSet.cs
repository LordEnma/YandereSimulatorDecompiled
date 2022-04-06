using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using UnityEngine;

// Token: 0x020004B1 RID: 1201
public class SerializableHashSet<T> : HashSet<T>, ISerializationCallbackReceiver, IXmlSerializable
{
	// Token: 0x06001F9D RID: 8093 RVA: 0x001BDF18 File Offset: 0x001BC118
	public SerializableHashSet()
	{
		this.elements = new List<T>();
	}

	// Token: 0x06001F9E RID: 8094 RVA: 0x001BDF2C File Offset: 0x001BC12C
	public void OnBeforeSerialize()
	{
		this.elements.Clear();
		foreach (T item in this)
		{
			this.elements.Add(item);
		}
	}

	// Token: 0x06001F9F RID: 8095 RVA: 0x001BDF8C File Offset: 0x001BC18C
	public void OnAfterDeserialize()
	{
		base.Clear();
		for (int i = 0; i < this.elements.Count; i++)
		{
			base.Add(this.elements[i]);
		}
	}

	// Token: 0x06001FA0 RID: 8096 RVA: 0x001BDFC8 File Offset: 0x001BC1C8
	public XmlSchema GetSchema()
	{
		return null;
	}

	// Token: 0x06001FA1 RID: 8097 RVA: 0x001BDFCC File Offset: 0x001BC1CC
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

	// Token: 0x06001FA2 RID: 8098 RVA: 0x001BE030 File Offset: 0x001BC230
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

	// Token: 0x04004223 RID: 16931
	[SerializeField]
	private List<T> elements;

	// Token: 0x04004224 RID: 16932
	private const string XML_Element = "Element";
}
