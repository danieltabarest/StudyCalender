//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudyCalender {
    using System;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    
    
    public partial class MasterPage : global::Xamarin.Forms.ContentPage {
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::ImageCircle.Forms.Plugin.Abstractions.CircleImage RejectOutgongCallButton;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.Label MasterPage_txtTermName;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.Label MasterPage_txtSemester;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::ImageCircle.Forms.Plugin.Abstractions.CircleImage Settings;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.ListView listView;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private void InitializeComponent() {
            this.LoadFromXaml(typeof(MasterPage));
            RejectOutgongCallButton = this.FindByName<global::ImageCircle.Forms.Plugin.Abstractions.CircleImage>("RejectOutgongCallButton");
            MasterPage_txtTermName = this.FindByName<global::Xamarin.Forms.Label>("MasterPage_txtTermName");
            MasterPage_txtSemester = this.FindByName<global::Xamarin.Forms.Label>("MasterPage_txtSemester");
            Settings = this.FindByName<global::ImageCircle.Forms.Plugin.Abstractions.CircleImage>("Settings");
            listView = this.FindByName<global::Xamarin.Forms.ListView>("listView");
        }
    }
}
