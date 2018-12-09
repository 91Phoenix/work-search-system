using System;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

namespace WSS_Prototipo.Presentazione
{
    public partial class EditingDocumentControl : UserControl
    {
        
        private Type _editingType = null;
        private readonly Dictionary<PropertyInfo, object> _properties = new Dictionary<PropertyInfo, object>(); 
        private int _errorCounter = 0;
        
        public event EventHandler HasErrorChanged;

        public EditingDocumentControl()
        {
            InitializeComponent();
        }
        public Dictionary<PropertyInfo, object> Properties
        {
            get { return _properties; }
        }

        public bool HasError
        {
            get
            {
                return _errorCounter > 0 ;
            }
        }
 
        public void SetEditableType(Type editingType)
        {
           
            if (editingType == null)
                throw new ArgumentNullException("");
            _editingType = editingType;
            _properties.Clear();
            _errorCounter = 0;
            _tableLayoutPanel.Controls.Clear();

            foreach (PropertyInfo propertyInfo in _editingType.GetProperties()) 
            {
                EditableAttribute[] attributes = (EditableAttribute[]) propertyInfo.GetCustomAttributes(typeof(EditableAttribute), false);
                if (attributes.Length == 0)
                    continue;
                if (!propertyInfo.CanRead)
                    throw new ApplicationException("!propertyInfo.CanRead");
                if (propertyInfo.CanWrite)
                {
                    _properties.Add(propertyInfo, null);
                    AddRow(attributes[0], propertyInfo);
                }
            }
            RefreshTextBoxes(null);
        }

        public void ResetEditingType()
        {
            foreach (Control control in _tableLayoutPanel.Controls)
            {
                if (control is TextBox)
                {
                    TextBox textBox = (TextBox) control;
                    textBox.Text = String.Empty;
                    
                    PropertyInfo info = (PropertyInfo)textBox.Tag;
                    if(info.CanWrite)
                        Validate(textBox);
                }
            }
        }   
        private void AddRow(EditableAttribute editableAttribute, PropertyInfo propertyInfo)
        {     
            Label label = new Label();
            label.Text = editableAttribute.Label;
            label.AutoSize = true;
            _tableLayoutPanel.Controls.Add(label);
            TextBox textBox = new TextBox();
            textBox.Width = editableAttribute.Width;
            textBox.Height = textBox.PreferredHeight;
            textBox.Enabled = propertyInfo.CanWrite;
            textBox.Tag = propertyInfo;
            textBox.Validating += ValidatingHandler;
            _tableLayoutPanel.Controls.Add(textBox);
        }
        private void RefreshTextBoxes(TextBox excludedTextBox)
        {
            foreach (Control control in _tableLayoutPanel.Controls)
            {
                if (control is TextBox && control != excludedTextBox)
                {
                    TextBox current = (TextBox) control;
                    PropertyInfo propertyInfo = (PropertyInfo) current.Tag;
                    object value = _properties[propertyInfo];
                    current.Text = value != null ? value.ToString() : String.Empty;
                    if (propertyInfo.CanWrite)
                        Validate(current);
                }
            }
        }

        
        private void ValidatingHandler(object sender, CancelEventArgs args)
        {    
            Validate((TextBox) sender);
            if(!HasError)
                RefreshTextBoxes((TextBox) sender);
        }

        private void Validate(TextBox textBox)
        {
            try
            {
                if (String.IsNullOrEmpty(textBox.Text)) throw new ArgumentException("Campo Obbligatorio!");
                PropertyInfo propertyInfo = (PropertyInfo)textBox.Tag;
                object newValue = Convert.ChangeType(textBox.Text,propertyInfo.PropertyType);
                _properties[propertyInfo] = newValue;
                SetError(textBox, null);
            }
            catch (Exception exception)
            {
                while (exception.InnerException != null)
                    exception = exception.InnerException;
                SetError(textBox, exception.Message);
            }
        }

        private void SetError(TextBox textBox, string newMessage)
        {       
            string oldError = _errorProvider.GetError(textBox);
            _errorProvider.SetError(textBox, newMessage);
            if (String.IsNullOrEmpty(oldError))
            {
                if (!(String.IsNullOrEmpty(newMessage)))
                {
                    _errorCounter++;
                    if (_errorCounter == 1)
                        OnHasErrorChanged();
                }
            }
            else if (String.IsNullOrEmpty(newMessage))
            {
                _errorCounter--;
                if (_errorCounter == 0)
                    OnHasErrorChanged();
            }          
        }
        protected virtual void OnHasErrorChanged()
        {
            if (HasErrorChanged != null)
                HasErrorChanged(this, EventArgs.Empty);
        }
    }
 }
