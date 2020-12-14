using System;
using System.Collections.Generic;
using System.Windows.Input;
using Foundation;
using MvvmCross.Binding.Bindings;
using MvvmCross.Platforms.Ios.Binding.Views;
using UIKit;

namespace ToDo_list.iOS.Views.Main.TableView.Source
{
    public class MvxDeleteRowStandardTableViewSource  : MvxStandardTableViewSource
    {
        public ICommand RemoveRowCommand { get; set; }

        public MvxDeleteRowStandardTableViewSource(UITableView tableView) : base(tableView)
        {
        }

        public MvxDeleteRowStandardTableViewSource(UITableView tableView, NSString cellIdentifier) : base(tableView, cellIdentifier)
        {
        }

        public MvxDeleteRowStandardTableViewSource(UITableView tableView, string bindingText) : base(tableView, bindingText)
        {
        }

        public MvxDeleteRowStandardTableViewSource(IntPtr handle) : base(handle)
        {
        }

        public MvxDeleteRowStandardTableViewSource(UITableView tableView, UITableViewCellStyle style, NSString cellIdentifier, string bindingText, UITableViewCellAccessory tableViewCellAccessory = UITableViewCellAccessory.None) : base(tableView, style, cellIdentifier, bindingText, tableViewCellAccessory)
        {
        }

        public MvxDeleteRowStandardTableViewSource(UITableView tableView, UITableViewCellStyle style, NSString cellIdentifier, IEnumerable<MvxBindingDescription> descriptions, UITableViewCellAccessory tableViewCellAccessory = UITableViewCellAccessory.None) : base(tableView, style, cellIdentifier, descriptions, tableViewCellAccessory)
        {
        }

        public override bool CanEditRow(UITableView tableView, NSIndexPath indexPath)
        {
            return true;
        }

        public override void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
        {
            switch (editingStyle)
            {
                case UITableViewCellEditingStyle.Delete:
                    var item = GetItemAt(indexPath);
                    RemoveRowCommand?.Execute(item);
                    break;
                case UITableViewCellEditingStyle.None:
                    break;
            }
        }

        public override UITableViewCellEditingStyle EditingStyleForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return UITableViewCellEditingStyle.Delete;
        }

        public override bool CanMoveRow(UITableView tableView, NSIndexPath indexPath)
        {
            return false;
        }
    }
}