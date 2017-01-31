using PU_Application.Interfaces;
using PU_Application.Model;
using PU_Application.Services.Standard;
using Xamarin.Forms;

[assembly: Dependency(typeof(MyItemStore))]
namespace PU_Application.Services.Standard
{
    public class MyItemStore : BaseStore<MyItem>, IMyItemStore
    {
        public override string Identifier => "MyItem";
    }
}
