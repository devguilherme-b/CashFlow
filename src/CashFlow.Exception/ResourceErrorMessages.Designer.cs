namespace CashFlow.Exception {
    using System;
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ResourceErrorMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ResourceErrorMessages() {
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("CashFlow.Exception.ResourceErrorMessages", typeof(ResourceErrorMessages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        public static string AMOUNT_MUST_BE_GREAT_THAN_ZERO {
            get {
                return ResourceManager.GetString("AMOUNT_MUST_BE_GREAT_THAN_ZERO", resourceCulture);
            }
        }
        public static string DATE_CANNOT_BE_FOR_THE_FUTURE {
            get {
                return ResourceManager.GetString("DATE_CANNOT_BE_FOR_THE_FUTURE", resourceCulture);
            }
        }
        
        public static string PAYMENT_TYPE_INVALID {
            get {
                return ResourceManager.GetString("PAYMENT_TYPE_INVALID", resourceCulture);
            }
        }
        public static string TITLE_REQUIRED {
            get {
                return ResourceManager.GetString("TITLE_REQUIRED", resourceCulture);
            }
        }
        public static string UNKNOW_ERROR {
            get {
                return ResourceManager.GetString("UNKNOW_ERROR", resourceCulture);
            }
        }
    }
}
