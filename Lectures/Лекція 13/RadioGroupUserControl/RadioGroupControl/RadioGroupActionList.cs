using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace RadioGroupControl
{
    public class RadioGroupActionList : DesignerActionList
    {
        private RadioGroup linkedControl;

        // The constructor associates the control to the smart tag action list.
        public RadioGroupActionList(RadioGroup control) : base(control)
        {
            this.linkedControl = control;
        }

        // A helper method to retrieve control properties.
        // GetProperties ensures undo and menu updates to work properly. 
        private PropertyDescriptor GetPropertyByName(String propertyName)
        {
            PropertyDescriptor property;
            property = TypeDescriptor.GetProperties(linkedControl)[propertyName];

            if (property == null)
            {
                throw new ArgumentException("Matching property not found.", propertyName);
            }
            else
            {
                return property;
            }
        }

        // Properties that are targets of DesignerActionPropertyItem entries. 
        public string Text
        {
            get
            {
                return linkedControl.Text;
            }
            set
            {
                GetPropertyByName("Text").SetValue(linkedControl, value);
            }
        }
        public int ColumnCount
        {
            get
            {
                return linkedControl.ColumnCount;
            }
            set
            {
                GetPropertyByName("ColumnCount").SetValue(linkedControl, value);
            }
        }
        public int IndexSelected
        {
            get
            {
                return linkedControl.IndexSelected;
            }
            set
            {
                GetPropertyByName("IndexSelected").SetValue(linkedControl, value);
            }
        }
        public bool Sorted
        {
            get
            {
                return linkedControl.Sorted;
            }
            set
            {
                GetPropertyByName("Sorted").SetValue(linkedControl, value);
            }
        }
        public RadioGroup.Direction FlowDirection
        {
            get
            {
                return linkedControl.FlowDirection;
            }
            set
            {
                GetPropertyByName("FlowDirection").SetValue(linkedControl, value);
            }
        }

        // Method that is target of a DesignerActionMethodItem.
        // It calls the string collection editor.
        public void EditNames()
        {
            PropertyDescriptor itemsPropertyDescriptor = GetPropertyByName("Items");
            TypeDescriptionContext context = new TypeDescriptionContext(linkedControl, itemsPropertyDescriptor);
            UITypeEditor editor = (UITypeEditor)itemsPropertyDescriptor.GetEditor(typeof(UITypeEditor));
            itemsPropertyDescriptor.SetValue(linkedControl, editor.EditValue(context, context, linkedControl.Items));
        }

        // Implementation of this abstract method creates smart tag 
        // items, associates their targets, and collects into list. 
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection items = new DesignerActionItemCollection();

            // Begin by creating the headers.
            items.Add(new DesignerActionHeaderItem("Appearance"));
            items.Add(new DesignerActionHeaderItem("Data"));
            items.Add(new DesignerActionHeaderItem("Behavior"));
            items.Add(new DesignerActionHeaderItem("Layout"));
            items.Add(new DesignerActionHeaderItem("Information"));

            // Add items that wrap the properties.
            items.Add(new DesignerActionPropertyItem("Text", "Caption text", "Appearance",
                "Sets the text in the border."));
            items.Add(new DesignerActionPropertyItem("ColumnCount", "Number of columns", "Appearance",
                "Sets quantity of columns the buttons will be separated to. Must be in [1; 8]."));
            items.Add(new DesignerActionPropertyItem("IndexSelected", "Checked button", "Behavior",
                "Sets index of the checked radioButton."));
            items.Add(new DesignerActionPropertyItem("Sorted", "List of the button's names is sorted", "Behavior",
                "Sets the sorting mode to the list of button's names"));
            items.Add(new DesignerActionPropertyItem("FlowDirection", "Flow direction", "Layout",
                "Defines fill mode: by columns or by rows."));

            // Add an action link.
            items.Add(new DesignerActionMethodItem(this, "EditNames", "Edit names collection...", "Data",
                "Opens the Lines collection editor", false));

            // Create entry for static Information section. 
            items.Add(new DesignerActionTextItem(String.Format("Number of buttons: {0} (reopen to refresh)",
                linkedControl.Items.Count), "Information"));

            return items;
        }

        // The "magical code" from the msdn documentation we need to run a string collection editor.
        public class TypeDescriptionContext : ITypeDescriptorContext, IServiceProvider, IWindowsFormsEditorService
        {
            private Control component;
            private PropertyDescriptor editingProperty;
            public TypeDescriptionContext(Control component, PropertyDescriptor property)
            {
                this.component = component;
                editingProperty = property;
            }
            public IContainer Container { get { return component.Container; } }
            public object Instance { get { return component; } }
            public void OnComponentChanged()
            {
                var svc = (IComponentChangeService)this.GetService(
                    typeof(IComponentChangeService));
                svc.OnComponentChanged(component, editingProperty, null, null);
            }
            public bool OnComponentChanging() { return true; }
            public PropertyDescriptor PropertyDescriptor { get { return editingProperty; } }
            public object GetService(Type serviceType)
            {
                if ((serviceType == typeof(ITypeDescriptorContext)) ||
                    (serviceType == typeof(IWindowsFormsEditorService)))
                    return this;
                return component.Site.GetService(serviceType);
            }
            public void CloseDropDown() { }
            public void DropDownControl(Control control) { }
            DialogResult IWindowsFormsEditorService.ShowDialog(Form dialog)
            {
                IUIService service = (IUIService)(this.GetService(typeof(IUIService)));
                return service.ShowDialog(dialog);
            }
        }
    }
}
