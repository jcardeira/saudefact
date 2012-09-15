namespace SISFACT.Properties
{
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Globalization;
    using System.Resources;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
    internal class Resources
    {
        private static CultureInfo resourceCulture;
        private static System.Resources.ResourceManager resourceMan;

        internal Resources()
        {
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static CultureInfo Culture
        {
            get
            {
                return resourceCulture;
            }
            set
            {
                resourceCulture = value;
            }
        }

        internal static Bitmap image002
        {
            get
            {
                return (Bitmap) ResourceManager.GetObject("image002", resourceCulture);
            }
        }

        internal static Bitmap Logovital
        {
            get
            {
                return (Bitmap) ResourceManager.GetObject("Logovital", resourceCulture);
            }
        }

        internal static Bitmap Logovital1
        {
            get
            {
                return (Bitmap) ResourceManager.GetObject("Logovital1", resourceCulture);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    System.Resources.ResourceManager manager = new System.Resources.ResourceManager("SISFACT.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = manager;
                }
                return resourceMan;
            }
        }
    }
}

