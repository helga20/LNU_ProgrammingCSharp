using System;

namespace Events
{
    /* InteractionArgs -  клас для зберігання інформації про події */
    public class InteractionArgs : EventArgs
    {
        public string Action { get; set; }
    }
}

