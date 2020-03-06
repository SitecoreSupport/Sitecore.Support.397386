using Microsoft.Extensions.DependencyInjection;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.DependencyInjection;
using Sitecore.Shell.Applications.Dialogs.MediaBrowser;
using Sitecore.Web.UI.Sheer;
using Sitecore.XA.Foundation.Multisite;
using Sitecore.XA.Foundation.SitecoreExtensions.Repositories;

namespace Sitecore.Support.XA.Foundation.Editing.Commands
{
    public class ChooseImage : Sitecore.XA.Foundation.Editing.Commands.ChooseImage
    {
        protected override void SelectSiteMediaRoot(ClientPipelineArgs args, MediaBrowserOptions options)
        {
            if (string.IsNullOrWhiteSpace(args.Parameters["contextItem"]))
            {
                return;
            }
            Item obj = ServiceLocator.ServiceProvider.GetService<IContentRepository>().GetItem(ID.Parse(args.Parameters["contextItem"]));
            if (obj == null)
            {
                return;
            }
            Item siteMediaItem = Client.ContentDatabase.GetItem(ServiceLocator.ServiceProvider.GetService<IMultisiteContext>().GetSiteMediaItem(obj).ID, options.Root.Language);
            if (siteMediaItem == null)
            {
                return;
            }
            options.Root = siteMediaItem;
        }
    }
}