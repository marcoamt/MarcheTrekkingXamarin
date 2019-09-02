using MrcheTrekking.Models;
using XLabs.Forms.Mvvm;

namespace MrcheTrekking.ViewModels
{
    class MieiPercorsiViewModel : ViewModel
    {
        public MieiPercorsiViewModel Img { get; set; }

        public MieiPercorsiViewModel(MieiPercorsiViewModel img = null)
        {
            Img = img;
        }
    }
}
