﻿//
// IInstallNuGetPackageAction.cs
//
// Author:
//       Matt Ward <matt.ward@xamarin.com>
//
// Copyright (c) 2016 Xamarin Inc. (http://xamarin.com)
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using MonoDevelop.Projects;
using NuGet.Versioning;

namespace MonoDevelop.PackageManagement
{
	internal interface IInstallNuGetPackageAction
	{
		//string PackageId { get; }
		//NuGetVersion Version { get; }
		bool IsForProject (DotNetProject project);
	}

	internal static class IInstallNuGetPackageActionExtensions
	{
		public static string GetPackageId (this IInstallNuGetPackageAction action)
		{
			var installPackageAction = action as InstallPackageAction;
			if (installPackageAction != null) {
				return installPackageAction.GetPackageId ();
			}
			var installNuGetPackageAction = (InstallNuGetPackageAction)action;
			return installNuGetPackageAction.PackageId;
		}

		public static NuGetVersion GetPackageVersion (this IInstallNuGetPackageAction action)
		{
			var installNuGetPackageAction = action as InstallNuGetPackageAction;
			if (installNuGetPackageAction != null) {
				return installNuGetPackageAction.Version;
			}
			var installPackageAction = action as InstallPackageAction;
			return new NuGetVersion (installNuGetPackageAction.Version.ToString ());
		}
	}
}

