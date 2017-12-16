using System.Xml.Serialization;

namespace KuehneNagel.WeatherForecast.Domain.Entities.Xml
{

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class place
    {

        private string nameField;

        private string phenomenonField;

        private string tempminField;

        private string tempmaxField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string phenomenon
        {
            get
            {
                return this.phenomenonField;
            }
            set
            {
                this.phenomenonField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string tempmin
        {
            get
            {
                return this.tempminField;
            }
            set
            {
                this.tempminField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string tempmax
        {
            get
            {
                return this.tempmaxField;
            }
            set
            {
                this.tempmaxField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class wind
    {

        private string nameField;

        private string directionField;

        private string speedminField;

        private string speedmaxField;

        private string gustField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string direction
        {
            get
            {
                return this.directionField;
            }
            set
            {
                this.directionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string speedmin
        {
            get
            {
                return this.speedminField;
            }
            set
            {
                this.speedminField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string speedmax
        {
            get
            {
                return this.speedmaxField;
            }
            set
            {
                this.speedmaxField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string gust
        {
            get
            {
                return this.gustField;
            }
            set
            {
                this.gustField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class forecasts
    {

        private object[] itemsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("forecast", typeof(forecastsForecast), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlElementAttribute("place", typeof(place))]
        [System.Xml.Serialization.XmlElementAttribute("wind", typeof(wind))]
        public object[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class forecastsForecast
    {

        private forecastsForecastNight[] nightField;

        private forecastsForecastDay[] dayField;

        private string dateField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("night", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public forecastsForecastNight[] night
        {
            get
            {
                return this.nightField;
            }
            set
            {
                this.nightField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("day", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public forecastsForecastDay[] day
        {
            get
            {
                return this.dayField;
            }
            set
            {
                this.dayField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string date
        {
            get
            {
                return this.dateField;
            }
            set
            {
                this.dateField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class forecastsForecastNight
    {

        private string phenomenonField;

        private string tempminField;

        private string tempmaxField;

        private string textField;

        private string seaField;

        private string peipsiField;

        private place[] placeField;

        private wind[] windField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string phenomenon
        {
            get
            {
                return this.phenomenonField;
            }
            set
            {
                this.phenomenonField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string tempmin
        {
            get
            {
                return this.tempminField;
            }
            set
            {
                this.tempminField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string tempmax
        {
            get
            {
                return this.tempmaxField;
            }
            set
            {
                this.tempmaxField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string sea
        {
            get
            {
                return this.seaField;
            }
            set
            {
                this.seaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string peipsi
        {
            get
            {
                return this.peipsiField;
            }
            set
            {
                this.peipsiField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("place")]
        public place[] place
        {
            get
            {
                return this.placeField;
            }
            set
            {
                this.placeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("wind")]
        public wind[] wind
        {
            get
            {
                return this.windField;
            }
            set
            {
                this.windField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class forecastsForecastDay
    {

        private string phenomenonField;

        private string tempminField;

        private string tempmaxField;

        private string textField;

        private string seaField;

        private string peipsiField;

        private place[] placeField;

        private wind[] windField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string phenomenon
        {
            get
            {
                return this.phenomenonField;
            }
            set
            {
                this.phenomenonField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string tempmin
        {
            get
            {
                return this.tempminField;
            }
            set
            {
                this.tempminField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string tempmax
        {
            get
            {
                return this.tempmaxField;
            }
            set
            {
                this.tempmaxField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string sea
        {
            get
            {
                return this.seaField;
            }
            set
            {
                this.seaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string peipsi
        {
            get
            {
                return this.peipsiField;
            }
            set
            {
                this.peipsiField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("place")]
        public place[] place
        {
            get
            {
                return this.placeField;
            }
            set
            {
                this.placeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("wind")]
        public wind[] wind
        {
            get
            {
                return this.windField;
            }
            set
            {
                this.windField = value;
            }
        }
    }
}