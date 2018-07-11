using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S50cBL18;
using S50cSys18;
using S50cBO18;

namespace Sage50c.ExtenderSample
{
    public class StockHandler : IDisposable
    {
        private ExtenderEvents headerStockEvents = null;
        private ExtenderEvents detailsStockEvents = null;

        private BSOStockTransaction bsoStockTrans = null;
        private PropertyChangeNotifier propaChangeNotifier = null;

        public void SetDetailEventsHandler(ExtenderEvents e)
        {
            detailsStockEvents = e;

            detailsStockEvents.OnValidating += DetailsStockEvents_OnValidating;
        }

        private void DetailsStockEvents_OnValidating(object Sender, ExtenderEventArgs e) {
            ExtendedPropertyList properties = (ExtendedPropertyList)e.get_data();
            ItemTransactionDetail itemTransactionDetail = (ItemTransactionDetail)properties.get_Value("Data");

            string errorMessage = string.Empty;

            // Colocar a falso para falhar a validação e impedir de continuar
            e.result.Success = true;                            
            // Se preenchido, a mesnsagem será sempres apresentada independentemente de se marcar a validação com true ou false
            e.result.ResultMessage = string.Format("Artigo {0} Validado com sucesso", itemTransactionDetail.ItemID);
        }

        public void SetHeaderEventsHandler(ExtenderEvents e)
        {
            headerStockEvents = e;

            headerStockEvents.OnInitialize += HeaderStockEvents_OnInitialize;
            headerStockEvents.OnMenuItem += HeaderStockEvents_OnMenuItem;
            headerStockEvents.OnValidating += HeaderStockEvents_OnValidating;
        }

        private void HeaderStockEvents_OnValidating(object Sender, ExtenderEventArgs e) {
            var propList = (ExtendedPropertyList)e.get_data();
            var forDeletion = (bool)propList.get_Value("forDeletion");
            var transaction = (StockTransaction)propList.get_Value("Data");

            e.result.Success = true;
            e.result.ResultMessage = string.Format("Documento {0} validado com sucesso.", transaction.TransactionID.ToString());
        }

        void HeaderStockEvents_OnMenuItem(object Sender, ExtenderEventArgs e)
        {
            var menuId = (string)e.get_data();

            switch (menuId)
            {
                case "mniXTrans11":
                    System.Windows.Forms.MessageBox.Show("YAY");
                    break;
            }
        }

        private void HeaderStockEvents_OnInitialize(object Sender, ExtenderEventArgs e)
        {
            var propList = (ExtendedPropertyList)e.get_data();
            propaChangeNotifier = (PropertyChangeNotifier)propList.get_Value("PropertyChangeNotifier");
            propaChangeNotifier.PropertyChanged += OnaPropertyChanged;

            bsoStockTrans = (BSOStockTransaction)propList.get_Value("TransactionManager");

            e.result.ResultMessage = "HeaderEvents_OnInitialize";

            var newMenus1 = new ExtenderMenuItems();
            //
            //Criar o grupo: Tab
            var mnuGroup1 = newMenus1.Add("mniXCustomTools1", "Custom Tools");
            //criar item1
            var mnuItem1 = mnuGroup1.ChildItems.Add("mniXTrans11", "Custom Item 1");
            mnuItem1.GroupType = ExtenderGroupType.ExtenderGroupTypeExtraOptions;
            //mnuItem1.Picture = ImageConverter.GetIPictureDispFromImage(  )

            //criar item2
            mnuItem1 = mnuGroup1.ChildItems.Add("mniXTrans21", "Custom Item 2");
            mnuItem1.GroupType = ExtenderGroupType.ExtenderGroupTypeExtraOptions;

            object returnMenu = newMenus1;
            e.result.set_data(returnMenu);
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }

        void OnaPropertyChanged(string PropertyID, ref object value, ref bool Cancel)
        {
            // HANDLE BSOItemTransaction PROPERTY CHANGES HERE

            Console.WriteLine("OnPropertyChanged {0}={1}; Cancel={2}", PropertyID, value, Cancel);
            //Cancel = false;
        }
    }
}
