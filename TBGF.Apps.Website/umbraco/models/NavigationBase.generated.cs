//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Umbraco.ModelsBuilder.Embedded v11.1.0+bad9148
//
//   Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Linq.Expressions;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;
using Umbraco.Cms.Infrastructure.ModelsBuilder;
using Umbraco.Cms.Core;
using Umbraco.Extensions;

namespace Umbraco.Cms.Web.Common.PublishedModels
{
	// Mixin Content Type with alias "navigationBase"
	/// <summary>Navigation Base</summary>
	public partial interface INavigationBase : IPublishedContent
	{
		/// <summary>Browser Title</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.1.0+bad9148")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		string BrowserTitle { get; }

		/// <summary>Keywords</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.1.0+bad9148")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		global::System.Collections.Generic.IEnumerable<string> Keywords { get; }

		/// <summary>No follow</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.1.0+bad9148")]
		bool NoFollow { get; }

		/// <summary>No index</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.1.0+bad9148")]
		bool NoIndex { get; }

		/// <summary>Description</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.1.0+bad9148")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		string SeoMetaDescription { get; }

		/// <summary>Description</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.1.0+bad9148")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		string SomeDescription { get; }

		/// <summary>Image</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.1.0+bad9148")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		global::Umbraco.Cms.Core.Models.PublishedContent.IPublishedContent SomeImage { get; }

		/// <summary>Title</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.1.0+bad9148")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		string SomeTitle { get; }

		/// <summary>Hide in Navigation</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.1.0+bad9148")]
		bool UmbracoNavihide { get; }
	}

	/// <summary>Navigation Base</summary>
	[PublishedModel("navigationBase")]
	public partial class NavigationBase : PublishedContentModel, INavigationBase
	{
		// helpers
#pragma warning disable 0109 // new is redundant
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.1.0+bad9148")]
		public new const string ModelTypeAlias = "navigationBase";
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.1.0+bad9148")]
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.1.0+bad9148")]
		[return: global::System.Diagnostics.CodeAnalysis.MaybeNull]
		public new static IPublishedContentType GetModelContentType(IPublishedSnapshotAccessor publishedSnapshotAccessor)
			=> PublishedModelUtility.GetModelContentType(publishedSnapshotAccessor, ModelItemType, ModelTypeAlias);
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.1.0+bad9148")]
		[return: global::System.Diagnostics.CodeAnalysis.MaybeNull]
		public static IPublishedPropertyType GetModelPropertyType<TValue>(IPublishedSnapshotAccessor publishedSnapshotAccessor, Expression<Func<NavigationBase, TValue>> selector)
			=> PublishedModelUtility.GetModelPropertyType(GetModelContentType(publishedSnapshotAccessor), selector);
#pragma warning restore 0109

		private IPublishedValueFallback _publishedValueFallback;

		// ctor
		public NavigationBase(IPublishedContent content, IPublishedValueFallback publishedValueFallback)
			: base(content, publishedValueFallback)
		{
			_publishedValueFallback = publishedValueFallback;
		}

		// properties

		///<summary>
		/// Browser Title
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.1.0+bad9148")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("browserTitle")]
		public virtual string BrowserTitle => GetBrowserTitle(this, _publishedValueFallback);

		/// <summary>Static getter for Browser Title</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.1.0+bad9148")]
		[return: global::System.Diagnostics.CodeAnalysis.MaybeNull]
		public static string GetBrowserTitle(INavigationBase that, IPublishedValueFallback publishedValueFallback) => that.Value<string>(publishedValueFallback, "browserTitle");

		///<summary>
		/// Keywords: Keywords that describe the content of the page. This is consired optional since most modern search engines don't use this anymore
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.1.0+bad9148")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("keywords")]
		public virtual global::System.Collections.Generic.IEnumerable<string> Keywords => GetKeywords(this, _publishedValueFallback);

		/// <summary>Static getter for Keywords</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.1.0+bad9148")]
		[return: global::System.Diagnostics.CodeAnalysis.MaybeNull]
		public static global::System.Collections.Generic.IEnumerable<string> GetKeywords(INavigationBase that, IPublishedValueFallback publishedValueFallback) => that.Value<global::System.Collections.Generic.IEnumerable<string>>(publishedValueFallback, "keywords");

		///<summary>
		/// No follow
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.1.0+bad9148")]
		[ImplementPropertyType("noFollow")]
		public virtual bool NoFollow => GetNoFollow(this, _publishedValueFallback);

		/// <summary>Static getter for No follow</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.1.0+bad9148")]
		public static bool GetNoFollow(INavigationBase that, IPublishedValueFallback publishedValueFallback) => that.Value<bool>(publishedValueFallback, "noFollow");

		///<summary>
		/// No index
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.1.0+bad9148")]
		[ImplementPropertyType("noIndex")]
		public virtual bool NoIndex => GetNoIndex(this, _publishedValueFallback);

		/// <summary>Static getter for No index</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.1.0+bad9148")]
		public static bool GetNoIndex(INavigationBase that, IPublishedValueFallback publishedValueFallback) => that.Value<bool>(publishedValueFallback, "noIndex");

		///<summary>
		/// Description: A brief description of the content on your page. This text is shown below the title in a google search result and also used for Social Sharing Cards. The ideal length is between 130 and 155 characters
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.1.0+bad9148")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("seoMetaDescription")]
		public virtual string SeoMetaDescription => GetSeoMetaDescription(this, _publishedValueFallback);

		/// <summary>Static getter for Description</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.1.0+bad9148")]
		[return: global::System.Diagnostics.CodeAnalysis.MaybeNull]
		public static string GetSeoMetaDescription(INavigationBase that, IPublishedValueFallback publishedValueFallback) => that.Value<string>(publishedValueFallback, "seoMetaDescription");

		///<summary>
		/// Description
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.1.0+bad9148")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("someDescription")]
		public virtual string SomeDescription => GetSomeDescription(this, _publishedValueFallback);

		/// <summary>Static getter for Description</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.1.0+bad9148")]
		[return: global::System.Diagnostics.CodeAnalysis.MaybeNull]
		public static string GetSomeDescription(INavigationBase that, IPublishedValueFallback publishedValueFallback) => that.Value<string>(publishedValueFallback, "someDescription");

		///<summary>
		/// Image
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.1.0+bad9148")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("someImage")]
		public virtual global::Umbraco.Cms.Core.Models.PublishedContent.IPublishedContent SomeImage => GetSomeImage(this, _publishedValueFallback);

		/// <summary>Static getter for Image</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.1.0+bad9148")]
		[return: global::System.Diagnostics.CodeAnalysis.MaybeNull]
		public static global::Umbraco.Cms.Core.Models.PublishedContent.IPublishedContent GetSomeImage(INavigationBase that, IPublishedValueFallback publishedValueFallback) => that.Value<global::Umbraco.Cms.Core.Models.PublishedContent.IPublishedContent>(publishedValueFallback, "someImage");

		///<summary>
		/// Title
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.1.0+bad9148")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("someTitle")]
		public virtual string SomeTitle => GetSomeTitle(this, _publishedValueFallback);

		/// <summary>Static getter for Title</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.1.0+bad9148")]
		[return: global::System.Diagnostics.CodeAnalysis.MaybeNull]
		public static string GetSomeTitle(INavigationBase that, IPublishedValueFallback publishedValueFallback) => that.Value<string>(publishedValueFallback, "someTitle");

		///<summary>
		/// Hide in Navigation: If you don't want this page to appear in the navigation, check this box
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.1.0+bad9148")]
		[ImplementPropertyType("umbracoNavihide")]
		public virtual bool UmbracoNavihide => GetUmbracoNavihide(this, _publishedValueFallback);

		/// <summary>Static getter for Hide in Navigation</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "11.1.0+bad9148")]
		public static bool GetUmbracoNavihide(INavigationBase that, IPublishedValueFallback publishedValueFallback) => that.Value<bool>(publishedValueFallback, "umbracoNavihide");
	}
}
