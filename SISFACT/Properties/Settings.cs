namespace SISFACT.Properties
{
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Configuration;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0"), CompilerGenerated]
    internal sealed class Settings : ApplicationSettingsBase
    {
        private static Settings defaultInstance = ((Settings) SettingsBase.Synchronized(new Settings()));

        private void SettingChangingEventHandler(object sender, SettingChangingEventArgs e)
        {
        }

        private void SettingsSavingEventHandler(object sender, CancelEventArgs e)
        {
        }

        public static Settings Default
        {
            get
            {
                return defaultInstance;
            }
        }

        [ApplicationScopedSetting, DefaultSettingValue(@"Data Source=IBM-T42\SQLEXPRESS;Initial Catalog=Vital_dent;Persist Security Info=True;User ID=sa;Password=NLSAdmin"), DebuggerNonUserCode, SpecialSetting(SpecialSetting.ConnectionString)]
        public string Vital_dentConnectionString
        {
            get
            {
                return (string) this["Vital_dentConnectionString"];
            }
        }
    }
}

