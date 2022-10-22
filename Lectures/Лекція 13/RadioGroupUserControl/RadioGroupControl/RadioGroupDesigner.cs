using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioGroupControl
{
    public class RadioGroupDesigner : System.Windows.Forms.Design.ParentControlDesigner
    {
        // A component change service signals ComponentChanged event every time when any property
        // of the control is changed at design time. Such behavior help us to display the changes
        // of the radioGroup.Items property. The string collection editor do not use the set method
        // of the Items property, therefore the change service gives us the only opportunity
        // to display changes at design time.

        private IComponentChangeService changeService;
        public override void Initialize(IComponent component)
        {
            // The designer keeps reference to the designed control.
            base.Initialize(component);
            changeService = (IComponentChangeService)GetService(typeof(IComponentChangeService));
            // Set a handler for the ComponentChanged event.
            if (changeService != null)
            {
                changeService.ComponentChanged +=
                    new ComponentChangedEventHandler(ComponentChanged);
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (changeService != null)
            {
                changeService.ComponentChanged -=
                    new ComponentChangedEventHandler(ComponentChanged);
            }
            base.Dispose(disposing);
        }
        private void ComponentChanged(object sender, ComponentChangedEventArgs e)
        {
            // We have to recognize type of the control and name of the changed property.
            IComponent comp = (IComponent)e.Component;
            if (comp.Site.Component.GetType() == typeof(RadioGroup))
            {
                RadioGroup radioGroup = (RadioGroup)comp.Site.Component;
                if (e.Member.Name == "Items")
                {
                    if (radioGroup.Sorted) radioGroup.Items.Sort();
                    // If the Items is changed then the buttons collection must be changed properly.
                    radioGroup.UpdateButtons();
                }
            }
        }

        // The designer infrastructure to create smart tags of the RadioGroup control
        private DesignerActionListCollection actionLists;
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (actionLists == null)
                {
                    actionLists = new DesignerActionListCollection();
                    actionLists.Add(new RadioGroupActionList((RadioGroup)Control));
                }
                return actionLists;
            }
        }
    }
}
