namespace POS
{
    class Menu
    {
        /*
         * Prompt User Select Menu Items by Categories or List All
         * Select Quant
         * Store line total and name of product in recetipt
         */

        public void promptReciept()
        {
            string addItem = "Some Menue Item"; ///Use this as your string a new menu item
            int lineItemTotal = 1 ; /// put the total of a menu item here
            var newRecieptItem = new Reciept(addItem,lineItemTotal);          
            Reciept.AddITemToReciept(newRecieptItem);  //this will add a RecieptItem to the Reciept list
            
        }
        
    }

}
