﻿#pragma checksum "C:\Users\Skants\Source\Repos\CabinPlanner\CabinPlanner.App\Views\RegisterPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9730E12A00C2DFB21F0199A849903A10"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CabinPlanner.App.Views
{
    partial class RegisterPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // Views\RegisterPage.xaml line 9
                {
                    this.ContentArea = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 3: // Views\RegisterPage.xaml line 14
                {
                    this.textBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 4: // Views\RegisterPage.xaml line 15
                {
                    this.firstNameField = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 5: // Views\RegisterPage.xaml line 16
                {
                    this.lastNameField = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 6: // Views\RegisterPage.xaml line 17
                {
                    this.emailField = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 7: // Views\RegisterPage.xaml line 18
                {
                    this.passwordField = (global::Windows.UI.Xaml.Controls.PasswordBox)(target);
                }
                break;
            case 8: // Views\RegisterPage.xaml line 19
                {
                    this.birthdayField = (global::Windows.UI.Xaml.Controls.DatePicker)(target);
                }
                break;
            case 9: // Views\RegisterPage.xaml line 20
                {
                    this.isMan = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                }
                break;
            case 10: // Views\RegisterPage.xaml line 21
                {
                    this.isWoman = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                }
                break;
            case 11: // Views\RegisterPage.xaml line 22
                {
                    this.registerBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.registerBtn).Click += this.RegisterBtn_Click;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

