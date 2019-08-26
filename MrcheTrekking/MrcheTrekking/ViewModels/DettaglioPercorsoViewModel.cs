using XLabs.Forms.Mvvm;

namespace MrcheTrekking.ViewModels
{
    public class DettaglioPercorsoViewModel : ViewModel
    {
        private PercorsiViewModel _percorso;
        public PercorsiViewModel Percorso
        {
            get { return _percorso; }
            set
            {
                _percorso = value;
                NotifyPropertyChanged();
            }
        }
    }
}

