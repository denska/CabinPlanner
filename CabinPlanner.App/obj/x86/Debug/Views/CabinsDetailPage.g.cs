﻿#pragma checksum "C:\Users\Skants\Source\Repos\CabinPlanner\CabinPlanner.App\Views\CabinsDetailPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9AA1FE2765FF5778AC27E5A756AF8E8C"
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
    partial class CabinsDetailPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
            public static void Set_Microsoft_Toolkit_Uwp_UI_Animations_Connected_AnchorElement(global::Windows.UI.Xaml.DependencyObject obj, global::Windows.UI.Xaml.UIElement value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::Windows.UI.Xaml.UIElement) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::Windows.UI.Xaml.UIElement), targetNullValue);
                }
                global::Microsoft.Toolkit.Uwp.UI.Animations.Connected.SetAnchorElement(obj, value);
            }
            public static void Set_Windows_UI_Xaml_Controls_TextBlock_Text(global::Windows.UI.Xaml.Controls.TextBlock obj, global::System.String value, string targetNullValue)
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
        private class CabinsDetailPage_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            ICabinsDetailPage_Bindings
        {
            private global::CabinPlanner.App.Views.CabinsDetailPage dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.Grid obj2;
            private global::Windows.UI.Xaml.Controls.TextBlock obj5;
            private global::Windows.UI.Xaml.Controls.TextBlock obj10;
            private global::Windows.UI.Xaml.Controls.TextBlock obj11;
            private global::Windows.UI.Xaml.Controls.TextBlock obj14;
            private global::Windows.UI.Xaml.Controls.TextBlock obj15;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj2AnchorElementDisabled = false;
            private static bool isobj5TextDisabled = false;
            private static bool isobj10TextDisabled = false;
            private static bool isobj11TextDisabled = false;
            private static bool isobj14TextDisabled = false;
            private static bool isobj15TextDisabled = false;

            private CabinsDetailPage_obj1_BindingsTracking bindingsTracking;

            public CabinsDetailPage_obj1_Bindings()
            {
                this.bindingsTracking = new CabinsDetailPage_obj1_BindingsTracking(this);
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 14 && columnNumber == 9)
                {
                    isobj2AnchorElementDisabled = true;
                }
                else if (lineNumber == 56 && columnNumber == 21)
                {
                    isobj5TextDisabled = true;
                }
                else if (lineNumber == 80 && columnNumber == 36)
                {
                    isobj10TextDisabled = true;
                }
                else if (lineNumber == 75 && columnNumber == 36)
                {
                    isobj11TextDisabled = true;
                }
                else if (lineNumber == 68 && columnNumber == 36)
                {
                    isobj14TextDisabled = true;
                }
                else if (lineNumber == 63 && columnNumber == 36)
                {
                    isobj15TextDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 2: // Views\CabinsDetailPage.xaml line 11
                        this.obj2 = (global::Windows.UI.Xaml.Controls.Grid)target;
                        break;
                    case 5: // Views\CabinsDetailPage.xaml line 52
                        this.obj5 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 10: // Views\CabinsDetailPage.xaml line 80
                        this.obj10 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 11: // Views\CabinsDetailPage.xaml line 75
                        this.obj11 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 14: // Views\CabinsDetailPage.xaml line 68
                        this.obj14 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 15: // Views\CabinsDetailPage.xaml line 63
                        this.obj15 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    default:
                        break;
                }
            }

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                throw new global::System.NotImplementedException();
            }

            public void Recycle()
            {
                throw new global::System.NotImplementedException();
            }

            // ICabinsDetailPage_Bindings

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
                this.bindingsTracking.ReleaseAllListeners();
                this.initialized = false;
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                this.bindingsTracking.ReleaseAllListeners();
                if (newDataRoot != null)
                {
                    this.dataRoot = (global::CabinPlanner.App.Views.CabinsDetailPage)newDataRoot;
                    return true;
                }
                return false;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::CabinPlanner.App.Views.CabinsDetailPage obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_itemHero(obj.itemHero, phase);
                    }
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_ViewModel(obj.ViewModel, phase);
                    }
                }
            }
            private void Update_itemHero(global::Windows.UI.Xaml.Controls.Grid obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\CabinsDetailPage.xaml line 11
                    if (!isobj2AnchorElementDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_Toolkit_Uwp_UI_Animations_Connected_AnchorElement(this.obj2, obj, null);
                    }
                }
            }
            private void Update_ViewModel(global::CabinPlanner.App.ViewModels.CabinsDetailViewModel obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_ViewModel(obj);
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_ViewModel_Item(obj.Item, phase);
                    }
                }
            }
            private void Update_ViewModel_Item(global::CabinPlanner.Model.Cabin obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_ViewModel_Item_CabinName(obj.CabinName, phase);
                    }
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_ViewModel_Item_CabinOwner(obj.CabinOwner, phase);
                    }
                }
            }
            private void Update_ViewModel_Item_CabinName(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Views\CabinsDetailPage.xaml line 52
                    if (!isobj5TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj5, obj, null);
                    }
                }
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\CabinsDetailPage.xaml line 75
                    if (!isobj11TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj11, obj, null);
                    }
                }
            }
            private void Update_ViewModel_Item_CabinOwner(global::CabinPlanner.Model.Person obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\CabinsDetailPage.xaml line 80
                    if (!isobj10TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj10, obj != null ? obj.ToString() : null, null);
                    }
                    // Views\CabinsDetailPage.xaml line 68
                    if (!isobj14TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj14, obj != null ? obj.ToString() : null, null);
                    }
                    // Views\CabinsDetailPage.xaml line 63
                    if (!isobj15TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj15, obj != null ? obj.ToString() : null, null);
                    }
                }
            }

            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private class CabinsDetailPage_obj1_BindingsTracking
            {
                private global::System.WeakReference<CabinsDetailPage_obj1_Bindings> weakRefToBindingObj; 

                public CabinsDetailPage_obj1_BindingsTracking(CabinsDetailPage_obj1_Bindings obj)
                {
                    weakRefToBindingObj = new global::System.WeakReference<CabinsDetailPage_obj1_Bindings>(obj);
                }

                public CabinsDetailPage_obj1_Bindings TryGetBindingObject()
                {
                    CabinsDetailPage_obj1_Bindings bindingObject = null;
                    if (weakRefToBindingObj != null)
                    {
                        weakRefToBindingObj.TryGetTarget(out bindingObject);
                        if (bindingObject == null)
                        {
                            weakRefToBindingObj = null;
                            ReleaseAllListeners();
                        }
                    }
                    return bindingObject;
                }

                public void ReleaseAllListeners()
                {
                    UpdateChildListeners_ViewModel(null);
                }

                public void PropertyChanged_ViewModel(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    CabinsDetailPage_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        string propName = e.PropertyName;
                        global::CabinPlanner.App.ViewModels.CabinsDetailViewModel obj = sender as global::CabinPlanner.App.ViewModels.CabinsDetailViewModel;
                        if (global::System.String.IsNullOrEmpty(propName))
                        {
                            if (obj != null)
                            {
                                bindings.Update_ViewModel_Item(obj.Item, DATA_CHANGED);
                            }
                        }
                        else
                        {
                            switch (propName)
                            {
                                case "Item":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_ViewModel_Item(obj.Item, DATA_CHANGED);
                                    }
                                    break;
                                }
                                default:
                                    break;
                            }
                        }
                    }
                }
                private global::CabinPlanner.App.ViewModels.CabinsDetailViewModel cache_ViewModel = null;
                public void UpdateChildListeners_ViewModel(global::CabinPlanner.App.ViewModels.CabinsDetailViewModel obj)
                {
                    if (obj != cache_ViewModel)
                    {
                        if (cache_ViewModel != null)
                        {
                            ((global::System.ComponentModel.INotifyPropertyChanged)cache_ViewModel).PropertyChanged -= PropertyChanged_ViewModel;
                            cache_ViewModel = null;
                        }
                        if (obj != null)
                        {
                            cache_ViewModel = obj;
                            ((global::System.ComponentModel.INotifyPropertyChanged)obj).PropertyChanged += PropertyChanged_ViewModel;
                        }
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
            case 2: // Views\CabinsDetailPage.xaml line 11
                {
                    this.ContentArea = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 3: // Views\CabinsDetailPage.xaml line 34
                {
                    this.contentPanel = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 4: // Views\CabinsDetailPage.xaml line 38
                {
                    this.itemHero = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 5: // Views\CabinsDetailPage.xaml line 52
                {
                    this.title = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 6: // Views\CabinsDetailPage.xaml line 60
                {
                    this.propertiesGroup1 = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 7: // Views\CabinsDetailPage.xaml line 72
                {
                    this.propertiesGroup2 = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 8: // Views\CabinsDetailPage.xaml line 73
                {
                    this.shipToGroup = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 9: // Views\CabinsDetailPage.xaml line 78
                {
                    this.orderTotalGroup = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 12: // Views\CabinsDetailPage.xaml line 61
                {
                    this.statusGroup = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 13: // Views\CabinsDetailPage.xaml line 66
                {
                    this.orderDateGroup = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
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
            case 1: // Views\CabinsDetailPage.xaml line 1
                {                    
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    CabinsDetailPage_obj1_Bindings bindings = new CabinsDetailPage_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                    global::Windows.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element1, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}

