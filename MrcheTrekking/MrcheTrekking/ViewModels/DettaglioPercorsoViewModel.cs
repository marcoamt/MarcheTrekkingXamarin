using XLabs.Forms.Mvvm;

namespace MrcheTrekking.ViewModels
{
    public class DettaglioPercorsoViewModel : ViewModel
    {
        public PercorsiViewModel Item { get; set; }
        public MyPercorsiViewModel PercItem { get; set; }

        public DettaglioPercorsoViewModel(object item = null)
        {
            if(item is PercorsiViewModel )
            {
                Item = (PercorsiViewModel)item;
            }
            else
            {
                PercItem = (MyPercorsiViewModel)item;
            }
        }
    }
}

