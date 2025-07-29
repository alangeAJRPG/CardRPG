using System;
using UnityEngine;


    [AttributeUsage(AttributeTargets.Method, Inherited = true)]
    public class ButtonAttribute : PropertyAttribute
    {
        public string ButtonLabel { get; }

        public ButtonAttribute(string buttonLabel = null)
        {
            ButtonLabel = buttonLabel;
        }
    }


