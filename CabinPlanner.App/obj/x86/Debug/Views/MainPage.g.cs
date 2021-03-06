﻿#pragma checksum "C:\Users\Skants\Source\Repos\CabinPlanner\CabinPlanner.App\Views\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0C16C3EF7E6EF03ABFAA36A818791367"
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
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_Documents_Run_Text(global::Windows.UI.Xaml.Documents.Run obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class MainPage_obj10_Bindings :
            global::Windows.UI.Xaml.IDataTemplateExtension,
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IMainPage_Bindings
        {
            private global::CabinPlanner.Model.PlannedTrip dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);
            private bool removedDataContextHandler = false;

            // Fields for each control that has bindings.
            private global::System.WeakReference obj10;
            private global::Windows.UI.Xaml.Documents.Run obj11;
            private global::Windows.UI.Xaml.Documents.Run obj12;
            private global::Windows.UI.Xaml.Documents.Run obj13;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj11TextDisabled = false;
            private static bool isobj12TextDisabled = false;
            private static bool isobj13TextDisabled = false;

            public MainPage_obj10_Bindings()
            {
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 33 && columnNumber == 38)
                {
                    isobj11TextDisabled = true;
                }
                else if (lineNumber == 36 && columnNumber == 38)
                {
                    isobj12TextDisabled = true;
                }
                else if (lineNumber == 39 && columnNumber == 38)
                {
                    isobj13TextDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 10: // Views\MainPage.xaml line 31
                        this.obj10 = new global::System.WeakReference((global::Windows.UI.Xaml.Controls.TextBlock)target);
                        break;
                    case 11: // Views\MainPage.xaml line 33
                        this.obj11 = (global::Windows.UI.Xaml.Documents.Run)target;
                        break;
                    case 12: // Views\MainPage.xaml line 36
                        this.obj12 = (global::Windows.UI.Xaml.Documents.Run)target;
                        break;
                    case 13: // Views\MainPage.xaml line 39
                        this.obj13 = (global::Windows.UI.Xaml.Documents.Run)target;
                        break;
                    default:
                        break;
                }
            }

            public void DataContextChangedHandler(global::Windows.UI.Xaml.FrameworkElement sender, global::Windows.UI.Xaml.DataContextChangedEventArgs args)
            {
                 if (this.SetDataRoot(args.NewValue))
                 {
                    this.Update();
                 }
            }

            // IDataTemplateExtension

            public bool ProcessBinding(uint phase)
            {
                throw new global::System.NotImplementedException();
            }

            public int ProcessBindings(global::Windows.UI.Xaml.Controls.ContainerContentChangingEventArgs args)
            {
                int nextPhase = -1;
                ProcessBindings(args.Item, args.ItemIndex, (int)args.Phase, out nextPhase);
                return nextPhase;
            }

            public void ResetTemplate()
            {
                Recycle();
            }

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                nextPhase = -1;
                switch(phase)
                {
                    case 0:
                        nextPhase = -1;
                        this.SetDataRoot(item);
                        if (!removedDataContextHandler)
                        {
                            removedDataContextHandler = true;
                            (this.obj10.Target as global::Windows.UI.Xaml.Controls.TextBlock).DataContextChanged -= this.DataContextChangedHandler;
                        }
                        this.initialized = true;
                        break;
                }
                this.Update_((global::CabinPlanner.Model.PlannedTrip) item, 1 << phase);
            }

            public void Recycle()
            {
            }

            // IMainPage_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                if (newDataRoot != null)
                {
                    this.dataRoot = (global::CabinPlanner.Model.PlannedTrip)newDataRoot;
                    return true;
                }
                return false;
            }

            private delegate void InvokeFunctionDelegate(int phase);
            private global::System.Collections.Generic.Dictionary<string, InvokeFunctionDelegate> PendingFunctionBindings = new global::System.Collections.Generic.Dictionary<string, InvokeFunctionDelegate>();

            private void Invoke_FromDate_M_ToShortDateString_757602046(int phase)
            {
                global::System.String result = this.dataRoot.FromDate.ToShortDateString();
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\MainPage.xaml line 36
                    if (!isobj12TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Documents_Run_Text(this.obj12, result, null);
                    }
                }
            }

            private void Invoke_ToDate_M_ToShortDateString_757602046(int phase)
            {
                global::System.String result = this.dataRoot.ToDate.ToShortDateString();
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\MainPage.xaml line 39
                    if (!isobj13TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Documents_Run_Text(this.obj13, result, null);
                    }
                }
            }

            private void CompleteUpdate(int phase)
            {
                foreach(var function in this.PendingFunctionBindings)
                {
                    function.Value.Invoke(phase);
                }
                this.PendingFunctionBindings.Clear();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::CabinPlanner.Model.PlannedTrip obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_Comment(obj.Comment, phase);
                        this.Update_FromDate(obj.FromDate, phase);
                        this.Update_ToDate(obj.ToDate, phase);
                    }
                }
                this.CompleteUpdate(phase);
            }
            private void Update_Comment(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\MainPage.xaml line 33
                    if (!isobj11TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Documents_Run_Text(this.obj11, obj, null);
                    }
                }
            }
            private void Update_FromDate(global::System.DateTime obj, int phase)
            {
                if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                {
                    this.Update_FromDate_M_ToShortDateString_757602046(phase);
                }
            }
            private void Update_FromDate_M_ToShortDateString_757602046(int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    if (!isobj12TextDisabled)
                    {
                        this.PendingFunctionBindings["FromDate_M_ToShortDateString_757602046"] = new InvokeFunctionDelegate(this.Invoke_FromDate_M_ToShortDateString_757602046); 
                    }
                }
            }
            private void Update_ToDate(global::System.DateTime obj, int phase)
            {
                if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                {
                    this.Update_ToDate_M_ToShortDateString_757602046(phase);
                }
            }
            private void Update_ToDate_M_ToShortDateString_757602046(int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    if (!isobj13TextDisabled)
                    {
                        this.PendingFunctionBindings["ToDate_M_ToShortDateString_757602046"] = new InvokeFunctionDelegate(this.Invoke_ToDate_M_ToShortDateString_757602046); 
                    }
                }
            }
        }
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1: // Views\MainPage.xaml line 1
                {
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)(target);
                    ((global::Windows.UI.Xaml.Controls.Page)element1).Loaded += this.Page_Loaded;
                }
                break;
            case 2: // Views\MainPage.xaml line 12
                {
                    this.ContentArea = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 3: // Views\MainPage.xaml line 21
                {
                    this.NameTxt = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 4: // Views\MainPage.xaml line 23
                {
                    this.button = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.button).Click += this.Button_Click;
                }
                break;
            case 5: // Views\MainPage.xaml line 24
                {
                    this.button1 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.button1).Click += this.Button1_Click;
                }
                break;
            case 6: // Views\MainPage.xaml line 25
                {
                    this.NameField = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.NameField).KeyDown += this.EnterKeyDown;
                }
                break;
            case 7: // Views\MainPage.xaml line 26
                {
                    this.emailTxt = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 8: // Views\MainPage.xaml line 27
                {
                    this.logoutBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.logoutBtn).Click += this.LogoutBtn_Click;
                }
                break;
            case 9: // Views\MainPage.xaml line 28
                {
                    this.CommingTrips = (global::Windows.UI.Xaml.Controls.ListView)(target);
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
            switch(connectionId)
            {
            case 10: // Views\MainPage.xaml line 31
                {                    
                    global::Windows.UI.Xaml.Controls.TextBlock element10 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                    MainPage_obj10_Bindings bindings = new MainPage_obj10_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(element10.DataContext);
                    element10.DataContextChanged += bindings.DataContextChangedHandler;
                    global::Windows.UI.Xaml.DataTemplate.SetExtensionInstance(element10, bindings);
                    global::Windows.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element10, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}

