﻿using Kooboo.CMS.Common;
using Kooboo.CMS.Sites.Models;
using Kooboo.Web.Url;
using Kooboo.Globalization;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Kooboo.CMS.Sites.Extension.ModuleArea
{
    public static class ModulePathHelper
    {
        //[Obsolete("")]
        //#region .ctor
        //string _moduleName;
        //Site _site;
        //public ModulePathHelper(string moduleName)
        //    : this(moduleName, null)
        //{
        //}
        //public ModulePathHelper(string moduleName, Site site)
        //{
        //    _site = site;
        //    _moduleName = moduleName;
        //}
        //#endregion

        //#region GetModuleInstallationPath
        //public IPath GetModuleInstallationPath()
        //{
        //    return new ModulePath(_moduleName);
        //}
        //#endregion

        //#region GetModuleInstallationFilePath
        //public IPath GetModuleInstallationFilePath(params string[] moduleInstallationFilePaths)
        //{
        //    var path = GetModuleInstallationPath();

        //    if (moduleInstallationFilePaths != null && moduleInstallationFilePaths.Length > 0)
        //    {
        //        return new CommonPath()
        //        {
        //            PhysicalPath = Path.Combine(new[] { path.PhysicalPath }.Concat(moduleInstallationFilePaths).ToArray()),
        //            VirtualPath = UrlUtility.Combine(new[] { path.VirtualPath }.Concat(moduleInstallationFilePaths).ToArray())
        //        };
        //    }
        //    return path;
        //}
        //#endregion

        //#region GetModuleSharedFilePath/GetModuleLocalFilePath
        ///// <summary>
        ///// Get the module public shared file path, used by the same module in all websites. 
        ///// </summary>
        ///// <param name="extraPaths"></param>
        ///// <returns></returns>
        //public IPath GetModuleSharedFilePath(params string[] extraPaths)
        //{
        //    var baseDir = Kooboo.CMS.Common.Runtime.EngineContext.Current.Resolve<IBaseDir>();
        //    var physicalPaths = new[] { baseDir.Cms_DataPhysicalPath, "Modules", _moduleName };
        //    var virtualPaths = new[] { baseDir.Cms_DataVirtualPath, "Modules", _moduleName };
        //    if (extraPaths != null && extraPaths.Length > 0)
        //    {
        //        physicalPaths = physicalPaths.Concat(extraPaths).ToArray();
        //        virtualPaths = virtualPaths.Concat(extraPaths).ToArray();
        //    }
        //    var path = new CommonPath()
        //    {
        //        PhysicalPath = Path.Combine(physicalPaths),
        //        VirtualPath = UrlUtility.Combine(virtualPaths)
        //    };

        //    return path;

        //}

        ///// <summary>
        ///// Get the site related module file path. Each website has its seperated local file path for every module
        ///// </summary>
        ///// <param name="extraPaths"></param>
        ///// <returns></returns>
        //public IPath GetModuleLocalFilePath(params string[] extraPaths)
        //{
        //    if (_site == null)
        //    {
        //        throw new ArgumentNullException("site");
        //    }
        //    var physicalPaths = new[] { _site.PhysicalPath, "Modules", _moduleName };
        //    var virtualPaths = new[] { _site.VirtualPath, "Modules", _moduleName };
        //    if (extraPaths != null && extraPaths.Length > 0)
        //    {
        //        physicalPaths = physicalPaths.Concat(extraPaths).ToArray();
        //        virtualPaths = virtualPaths.Concat(extraPaths).ToArray();
        //    }
        //    var path = new CommonPath()
        //    {
        //        PhysicalPath = Path.Combine(physicalPaths),
        //        VirtualPath = UrlUtility.Combine(virtualPaths)
        //    };

        //    return path;
        //}
        //#endregion

        //#region GetViewPath
        ///// <summary>
        ///// Get the module view path
        ///// </summary>
        ///// <param name="relationViewPaths">the relative path base on the module path. for example: new []{"Views","Shared","_OnInstalling.cshtml"}</param>
        ///// <returns></returns>
        //public IPath GetViewPath(params string[] relationViewPaths)
        //{
        //    var modulePath = GetModuleInstallationPath();
        //    return new CommonPath()
        //    {
        //        PhysicalPath = Path.Combine(new[] { modulePath.PhysicalPath }.Concat(relationViewPaths).ToArray()),
        //        VirtualPath = UrlUtility.Combine(new[] { modulePath.VirtualPath }.Concat(relationViewPaths).ToArray())
        //    };
        //}
        //#endregion

        #region GetModuleInstallationFilePath
        public static IPath GetModuleInstallationFilePath(this ModulePath modulePath, params string[] moduleInstallationFilePaths)
        {
            if (moduleInstallationFilePaths != null && moduleInstallationFilePaths.Length > 0)
            {
                return new CommonPath()
                {
                    PhysicalPath = Path.Combine(new[] { modulePath.PhysicalPath }.Concat(moduleInstallationFilePaths).ToArray()),
                    VirtualPath = UrlUtility.Combine(new[] { modulePath.VirtualPath }.Concat(moduleInstallationFilePaths).ToArray())
                };
            }
            return modulePath;
        }
        #endregion

        #region GetModuleSharedFilePath
        public static IPath GetModuleSharedFilePath(this ModulePath modulePath, params string[] extraPaths)
        {
            var baseDir = Kooboo.CMS.Common.Runtime.EngineContext.Current.Resolve<IBaseDir>();
            var physicalPaths = new[] { baseDir.Cms_DataPhysicalPath, "Modules", modulePath.ModuleName };
            var virtualPaths = new[] { baseDir.Cms_DataVirtualPath, "Modules", modulePath.ModuleName };
            if (extraPaths != null && extraPaths.Length > 0)
            {
                physicalPaths = physicalPaths.Concat(extraPaths).ToArray();
                virtualPaths = virtualPaths.Concat(extraPaths).ToArray();
            }
            var path = new CommonPath()
            {
                PhysicalPath = Path.Combine(physicalPaths),
                VirtualPath = UrlUtility.Combine(virtualPaths)
            };

            return path;

        }
        #endregion

        #region GetModuleLocalFilePath
        public static IPath GetModuleLocalFilePath(this ModulePath modulePath, params string[] extraPaths)
        {
            if (modulePath.Site == null)
            {
                throw new Exception("The site is null, can not get the local file path".Localize());
            }
            var physicalPaths = new[] { modulePath.Site.PhysicalPath, "Modules", modulePath.ModuleName };
            var virtualPaths = new[] { modulePath.Site.VirtualPath, "Modules", modulePath.ModuleName };
            if (extraPaths != null && extraPaths.Length > 0)
            {
                physicalPaths = physicalPaths.Concat(extraPaths).ToArray();
                virtualPaths = virtualPaths.Concat(extraPaths).ToArray();
            }
            var path = new CommonPath()
            {
                PhysicalPath = Path.Combine(physicalPaths),
                VirtualPath = UrlUtility.Combine(virtualPaths)
            };

            return path;
        }
        #endregion
    }
}
