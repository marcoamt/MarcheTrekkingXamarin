using MrcheTrekking.Models;
using XLabs.Forms.Mvvm;

namespace MrcheTrekking.ViewModels
{
    public class DettaglioPercorsoViewModel : ViewModel
    {
        public PercorsiViewModel Item { get; set; }

        public DettaglioPercorsoViewModel(PercorsiViewModel item = null)
        {
            Item = item;
        }
    }
}

