using System.IO;
using System.Xml.Serialization;

namespace WemoScanner
{

	// NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
	/// <remarks/>
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:Belkin:device-1-0")]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:Belkin:device-1-0", IsNullable = false)]
	public partial class WemoSetup
	{

		private rootSpecVersion specVersionField;

		private rootDevice deviceField;

		/// <remarks/>
		public rootSpecVersion specVersion
		{
			get
			{
				return this.specVersionField;
			}
			set
			{
				this.specVersionField = value;
			}
		}

		/// <remarks/>
		public rootDevice device
		{
			get
			{
				return this.deviceField;
			}
			set
			{
				this.deviceField = value;
			}
		}
		public static WemoSetup GetFromXml(string resp)
		{
			resp = resp.Replace("<? xml version = \"1.0\" ?>", "").Replace("<root ", "<WemoSetup ").Replace("</root>", "</WemoSetup>");
			var serializer = new XmlSerializer(typeof(WemoSetup));
			object result;
			using (TextReader reader = new StringReader(resp))
				result = serializer.Deserialize(reader);

			return (WemoSetup)result;
		}
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:Belkin:device-1-0")]
	public partial class rootSpecVersion
	{

		private byte majorField;

		private byte minorField;

		/// <remarks/>
		public byte major
		{
			get
			{
				return this.majorField;
			}
			set
			{
				this.majorField = value;
			}
		}

		/// <remarks/>
		public byte minor
		{
			get
			{
				return this.minorField;
			}
			set
			{
				this.minorField = value;
			}
		}
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:Belkin:device-1-0")]
	public partial class rootDevice
	{

		private string deviceTypeField;

		private string friendlyNameField;

		private string manufacturerField;

		private string manufacturerURLField;

		private string modelDescriptionField;

		private string modelNameField;

		private decimal modelNumberField;

		private string modelURLField;

		private string serialNumberField;

		private string uDNField;

		private uint uPCField;

		private string macAddressField;

		private string firmwareVersionField;

		private string iconVersionField;

		private byte binaryStateField;

		private rootDeviceIconList iconListField;

		private rootDeviceService[] serviceListField;

		private string presentationURLField;

		/// <remarks/>
		public string deviceType
		{
			get
			{
				return this.deviceTypeField;
			}
			set
			{
				this.deviceTypeField = value;
			}
		}

		/// <remarks/>
		public string friendlyName
		{
			get
			{
				return this.friendlyNameField;
			}
			set
			{
				this.friendlyNameField = value;
			}
		}

		/// <remarks/>
		public string manufacturer
		{
			get
			{
				return this.manufacturerField;
			}
			set
			{
				this.manufacturerField = value;
			}
		}

		/// <remarks/>
		public string manufacturerURL
		{
			get
			{
				return this.manufacturerURLField;
			}
			set
			{
				this.manufacturerURLField = value;
			}
		}

		/// <remarks/>
		public string modelDescription
		{
			get
			{
				return this.modelDescriptionField;
			}
			set
			{
				this.modelDescriptionField = value;
			}
		}

		/// <remarks/>
		public string modelName
		{
			get
			{
				return this.modelNameField;
			}
			set
			{
				this.modelNameField = value;
			}
		}

		/// <remarks/>
		public decimal modelNumber
		{
			get
			{
				return this.modelNumberField;
			}
			set
			{
				this.modelNumberField = value;
			}
		}

		/// <remarks/>
		public string modelURL
		{
			get
			{
				return this.modelURLField;
			}
			set
			{
				this.modelURLField = value;
			}
		}

		/// <remarks/>
		public string serialNumber
		{
			get
			{
				return this.serialNumberField;
			}
			set
			{
				this.serialNumberField = value;
			}
		}

		/// <remarks/>
		public string UDN
		{
			get
			{
				return this.uDNField;
			}
			set
			{
				this.uDNField = value;
			}
		}

		/// <remarks/>
		public uint UPC
		{
			get
			{
				return this.uPCField;
			}
			set
			{
				this.uPCField = value;
			}
		}

		/// <remarks/>
		public string macAddress
		{
			get
			{
				return this.macAddressField;
			}
			set
			{
				this.macAddressField = value;
			}
		}

		/// <remarks/>
		public string firmwareVersion
		{
			get
			{
				return this.firmwareVersionField;
			}
			set
			{
				this.firmwareVersionField = value;
			}
		}

		/// <remarks/>
		public string iconVersion
		{
			get
			{
				return this.iconVersionField;
			}
			set
			{
				this.iconVersionField = value;
			}
		}

		/// <remarks/>
		public byte binaryState
		{
			get
			{
				return this.binaryStateField;
			}
			set
			{
				this.binaryStateField = value;
			}
		}

		/// <remarks/>
		public rootDeviceIconList iconList
		{
			get
			{
				return this.iconListField;
			}
			set
			{
				this.iconListField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlArrayItemAttribute("service", IsNullable = false)]
		public rootDeviceService[] serviceList
		{
			get
			{
				return this.serviceListField;
			}
			set
			{
				this.serviceListField = value;
			}
		}

		/// <remarks/>
		public string presentationURL
		{
			get
			{
				return this.presentationURLField;
			}
			set
			{
				this.presentationURLField = value;
			}
		}
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:Belkin:device-1-0")]
	public partial class rootDeviceIconList
	{

		private rootDeviceIconListIcon iconField;

		/// <remarks/>
		public rootDeviceIconListIcon icon
		{
			get
			{
				return this.iconField;
			}
			set
			{
				this.iconField = value;
			}
		}
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:Belkin:device-1-0")]
	public partial class rootDeviceIconListIcon
	{

		private string mimetypeField;

		private byte widthField;

		private byte heightField;

		private byte depthField;

		private string urlField;

		/// <remarks/>
		public string mimetype
		{
			get
			{
				return this.mimetypeField;
			}
			set
			{
				this.mimetypeField = value;
			}
		}

		/// <remarks/>
		public byte width
		{
			get
			{
				return this.widthField;
			}
			set
			{
				this.widthField = value;
			}
		}

		/// <remarks/>
		public byte height
		{
			get
			{
				return this.heightField;
			}
			set
			{
				this.heightField = value;
			}
		}

		/// <remarks/>
		public byte depth
		{
			get
			{
				return this.depthField;
			}
			set
			{
				this.depthField = value;
			}
		}

		/// <remarks/>
		public string url
		{
			get
			{
				return this.urlField;
			}
			set
			{
				this.urlField = value;
			}
		}
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:Belkin:device-1-0")]
	public partial class rootDeviceService
	{

		private string serviceTypeField;

		private string serviceIdField;

		private string controlURLField;

		private string eventSubURLField;

		private string sCPDURLField;

		/// <remarks/>
		public string serviceType
		{
			get
			{
				return this.serviceTypeField;
			}
			set
			{
				this.serviceTypeField = value;
			}
		}

		/// <remarks/>
		public string serviceId
		{
			get
			{
				return this.serviceIdField;
			}
			set
			{
				this.serviceIdField = value;
			}
		}

		/// <remarks/>
		public string controlURL
		{
			get
			{
				return this.controlURLField;
			}
			set
			{
				this.controlURLField = value;
			}
		}

		/// <remarks/>
		public string eventSubURL
		{
			get
			{
				return this.eventSubURLField;
			}
			set
			{
				this.eventSubURLField = value;
			}
		}

		/// <remarks/>
		public string SCPDURL
		{
			get
			{
				return this.sCPDURLField;
			}
			set
			{
				this.sCPDURLField = value;
			}
		}
	}
}
