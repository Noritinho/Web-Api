﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Exceptions.Resources {
    using System;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class UsersResourceErrorMessages {
        
        private static System.Resources.ResourceManager resourceMan;
        
        private static System.Globalization.CultureInfo resourceCulture;
        
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal UsersResourceErrorMessages() {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public static System.Resources.ResourceManager ResourceManager {
            get {
                if (object.Equals(null, resourceMan)) {
                    System.Resources.ResourceManager temp = new System.Resources.ResourceManager("Exceptions.Resources.Users.UsersResourceErrorMessages", typeof(UsersResourceErrorMessages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public static System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        public static string USERNAME_EMPTY {
            get {
                return ResourceManager.GetString("USERNAME_EMPTY", resourceCulture);
            }
        }
        
        public static string USERNAME_INVALID {
            get {
                return ResourceManager.GetString("USERNAME_INVALID", resourceCulture);
            }
        }
        
        public static string USERNAME_LENGHT {
            get {
                return ResourceManager.GetString("USERNAME_LENGHT", resourceCulture);
            }
        }
        
        public static string EMAIL_EMPTY {
            get {
                return ResourceManager.GetString("EMAIL_EMPTY", resourceCulture);
            }
        }
        
        public static string EMAIL_INVALID {
            get {
                return ResourceManager.GetString("EMAIL_INVALID", resourceCulture);
            }
        }
        
        public static string PASSWORD_EMPTY {
            get {
                return ResourceManager.GetString("PASSWORD_EMPTY", resourceCulture);
            }
        }
        
        public static string PASSWORD_LENGHT {
            get {
                return ResourceManager.GetString("PASSWORD_LENGHT", resourceCulture);
            }
        }
        
        public static string PASSWORD_INVALID {
            get {
                return ResourceManager.GetString("PASSWORD_INVALID", resourceCulture);
            }
        }
        
        public static string USER_ROLE_EMPTY {
            get {
                return ResourceManager.GetString("USER_ROLE_EMPTY", resourceCulture);
            }
        }
        
        public static string USER_ROLE_INVALID {
            get {
                return ResourceManager.GetString("USER_ROLE_INVALID", resourceCulture);
            }
        }
        
        public static string USERNAME_ALREADY_EXISTS {
            get {
                return ResourceManager.GetString("USERNAME_ALREADY_EXISTS", resourceCulture);
            }
        }
        
        public static string EMAIL_ALREADY_EXISTS {
            get {
                return ResourceManager.GetString("EMAIL_ALREADY_EXISTS", resourceCulture);
            }
        }
    }
}
