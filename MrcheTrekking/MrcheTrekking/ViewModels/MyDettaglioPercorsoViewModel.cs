using System;
namespace MrcheTrekking.ViewModels
{
    public class MyDettaglioPercorsoViewModel
    {
        public MyPercorsiViewModel Item { get; set; }

        public MyDettaglioPercorsoViewModel(MyPercorsiViewModel item = null)
        {
            Item = item;
        }
    }
}
