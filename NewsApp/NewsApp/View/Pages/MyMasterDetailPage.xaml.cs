using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace NewsApp.View.Pages
{
    public partial class MyMasterDetailPage : MasterDetailPage
    {
        public MyMasterDetailPage()
        {
            InitializeComponent();
            this.MasterBehavior = MasterBehavior.Popover;
            Master = new MasterDetailPageMaster();
            Detail = new NavigationPage(new MasterDetailPageDetail());
        }
    }
}
