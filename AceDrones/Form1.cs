using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace AceDrones
{
    public partial class FormAceDrones : Form
    {
        // Global Variables
        static int max = 20; // Max array size
        Drone[] drones = new Drone[max];
        Customer[] customers = new Customer[max];
        string[,] transactions = new string[max, 3];
        // File names
        string droneFileName = "drones.dat";
        string customerFileName = "customers.dat";
        string transFileName = "transactions.dat";
        // for handling array size
        int droneCounter;
        int customerCounter;
        int transCounter;
        int mid;

        public FormAceDrones()
        {
            InitializeComponent();
        }

        private void FormAceDrones_Load(object sender, EventArgs e)
        {
            // #1, #2, #3 Load data from files
            DialogResult dialogResult = MessageBox.Show("Do you want to load saved file?", "Data Loading", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                loadData();
                displayDrones();
                displayCustomers();
                displayTransactions();
            }

            // Set Tool tips
            toolTipSerialNum.SetToolTip(textBoxSerialNum, "Double click to clear");
            toolTipCustID.SetToolTip(textBoxCustomerID, "Right click to search, double click to clear");
            toolTipTransID.SetToolTip(textBoxTransID, "Double click to clear");
            toolTipListBoxDrones.SetToolTip(listBoxDrones, "Select item to display");
            toolTipListBoxCustomers.SetToolTip(listBoxCustomers, "Select item to display");
            toolTipListBoxTransaction.SetToolTip(listBoxTransaction, "Select item to display");
            toolTipAddDrone.SetToolTip(buttonAddDrone, "Click to Add Drone");
            toolTipAddCustomer.SetToolTip(buttonAddCustomer, "Click to Add Customer");
            toolTipAddTransaction.SetToolTip(buttonAddTransaction, "Click to Add Transaction");
        }
        // #4 Add Drome Method
        private void buttonAddDrone_Click(object sender, EventArgs e)
        {
            if (droneCounter < max) // check array capacity
            {
                if (!(string.IsNullOrEmpty(textBoxSerialNum.Text)) &&
                    !(string.IsNullOrEmpty(textBoxModel.Text)) &&
                    !(string.IsNullOrEmpty(textBoxEngConfig.Text)) &&
                    !(string.IsNullOrEmpty(textBoxRange.Text)) &&
                    !(string.IsNullOrEmpty(textBoxAccessories.Text)) &&
                    !(string.IsNullOrEmpty(textBoxPrice.Text)) &&
                    !(string.IsNullOrEmpty(textBoxDate.Text)))
                {
                    drones[droneCounter] = new Drone(textBoxSerialNum.Text, textBoxModel.Text, textBoxEngConfig.Text, textBoxRange.Text, textBoxAccessories.Text, textBoxPrice.Text, textBoxDate.Text);
                    droneCounter++;
                }
                else
                {
                    MessageBox.Show("Data is incorrect or missing");
                }
            }
            else
            {
                MessageBox.Show("Your array is full");
            }
            clearBoxes(); // Method to clrear TextBox
            displayDrones(); // Method to display Drone array in the listBox
        }

        // #5 Add Customer Method
        private void buttonAddCustomer_Click(object sender, EventArgs e)
        {
            if (customerCounter < max) // check array capacity
            {
                if (!(string.IsNullOrEmpty(textBoxCustomerID.Text)) &&
                    !(string.IsNullOrEmpty(textBoxName.Text)) &&
                    !(string.IsNullOrEmpty(textBoxCity.Text)) &&
                    !(string.IsNullOrEmpty(textBoxCountry.Text)))
                {
                    customers[customerCounter] = new Customer(textBoxCustomerID.Text, textBoxName.Text, textBoxCity.Text, textBoxCountry.Text);
                    customerCounter++;
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to generate a default customer?", "Creat default", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        customers[customerCounter] = new Customer(textBoxCustomerID.Text, textBoxName.Text, textBoxCity.Text, textBoxCountry.Text);
                        customerCounter++;
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Your array is full");
            }
            clearBoxes(); // Method to clrear TextBox
            displayCustomers(); // Method to display Drone array in the listBox
        }

        // #7, #8 Add Transaction Method
        private void buttonAddTransaction_Click(object sender, EventArgs e)
        {
            if (transCounter < max) // check array capacity
            {
                if (!(string.IsNullOrEmpty(textBoxTransID.Text)) &&
                    !(string.IsNullOrEmpty(textBoxCustID.Text)) &&
                    !(string.IsNullOrEmpty(textBoxSerialNumber.Text)))
                {
                    transactions[transCounter, 0] = textBoxTransID.Text;
                    transactions[transCounter, 1] = textBoxCustID.Text;
                    transactions[transCounter, 2] = textBoxSerialNumber.Text;
                    transCounter++;
                }
                else
                {
                    MessageBox.Show("Select Drone & Customer fields and Input Transaction ID");
                }
            }
            else
            {
                MessageBox.Show("Your array is full");
            }
            clearBoxes(); // Method to clrear TextBox
            displayTransactions(); // Method to display Drone array in the listBox
        }

        // #12 Save all Arrays to the file
        private void FormAceDrones_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveData();
        }
        // Method for display Drones
        private void displayDrones()
        {
            Drone temp = new Drone();

            if (drones[0] == null)
            {
                return;
            }
            // sorting
            if (droneCounter > 1)
            {
                for (int outer = 0; outer < droneCounter; outer++)
                {
                    for (int inner = 0; inner < droneCounter - 1; inner++)
                    {
                        int cmpVal = drones[inner].SerialNumber.CompareTo(drones[inner + 1].SerialNumber);
                        if (cmpVal > 0)
                        {
                            temp = drones[inner + 1];
                            drones[inner + 1] = drones[inner];
                            drones[inner] = temp;
                        }
                    }
                }
            }

            listBoxDrones.Items.Clear();
            for (int i = 0; i < droneCounter; i++)
            {
                Drone displayDrone = drones[i];
                listBoxDrones.Items.Add($"{displayDrone.SerialNumber} - {displayDrone.EngineConfiguration} - {displayDrone.Price}");
            }
        }
        // Method for display Customers
        private void displayCustomers()
        {
            Customer temp = new Customer();

            if (customers[0] == null)
            {
                return;
            }
            // sorting
            if (customerCounter > 1)
            {
                for (int outer = 0; outer < customerCounter; outer++)
                {
                    for (int inner = 0; inner < customerCounter - 1; inner++)
                    {
                        int cmpVal = customers[inner].CustomerID.CompareTo(customers[inner + 1].CustomerID);
                        if (cmpVal > 0)
                        {
                            temp = customers[inner + 1];
                            customers[inner + 1] = customers[inner];
                            customers[inner] = temp;
                        }
                    }
                }
            }

            listBoxCustomers.Items.Clear();
            for (int i = 0; i < customerCounter; i++)
            {
                Customer displayCustomer = customers[i];
                listBoxCustomers.Items.Add($"{displayCustomer.CustomerID} {displayCustomer.Name} {displayCustomer.City} {displayCustomer.Country}");
            }
        }
        // Method for display Transactions
        private void displayTransactions()
        {
            string temp;
            if (transactions[0, 0] == null)
            {
                return;
            }
            // sorting
            if (transCounter > 1)
            {
                for (int outer = 0; outer < transCounter; outer++)
                {
                    for (int inner = 0; inner < transCounter - 1; inner++)
                    {
                        int cmpVal = transactions[inner, 0].CompareTo(transactions[inner + 1, 0]);
                        if (cmpVal > 0)
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                temp = transactions[inner + 1, i];
                                transactions[inner + 1, i] = transactions[inner, i];
                                transactions[inner, i] = temp;
                            }
                        }
                    }
                }
            }

            listBoxTransaction.Items.Clear();
            for (int i = 0; i < transCounter; i++)
            {
                listBoxTransaction.Items.Add($"{transactions[i, 0]}\t{transactions[i, 1]}\t{transactions[i, 2]}");
            }
        }
        // Method to clear textboxes
        private void clearBoxes()
        {
            textBoxSerialNum.Clear();
            textBoxModel.Clear();
            textBoxEngConfig.Clear();
            textBoxRange.Clear();
            textBoxAccessories.Clear();
            textBoxPrice.Clear();
            textBoxDate.Clear();
            textBoxCustomerID.Clear();
            textBoxName.Clear();
            textBoxCity.Clear();
            textBoxCountry.Clear();
            textBoxTransID.Clear();
            textBoxCustID.Clear();
            textBoxSerialNumber.Clear();
        }
        // #1 Load data Method
        private void loadData()
        {
            // Loading Drones
            try
            {
                int row = 0;
                droneCounter = 0;

                using (Stream stream = File.Open(droneFileName, FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    {
                        drones[droneCounter] = new Drone();
                        while (stream.Position < stream.Length)
                        {
                            if (row < 7)
                            {
                                string word = bin.Deserialize(stream).ToString();
                                switch (row)
                                {
                                    case 0:
                                        drones[droneCounter].SerialNumber = word;
                                        row++;
                                        break;
                                    case 1:
                                        drones[droneCounter].Model = word;
                                        row++;
                                        break;
                                    case 2:
                                        drones[droneCounter].EngineConfiguration = word;
                                        row++;
                                        break;
                                    case 3:
                                        drones[droneCounter].Range = word;
                                        row++;
                                        break;
                                    case 4:
                                        drones[droneCounter].Accessories = word;
                                        row++;
                                        break;
                                    case 5:
                                        drones[droneCounter].Price = word;
                                        row++;
                                        break;
                                    case 6:
                                        drones[droneCounter].PurchaseDate = word;
                                        row++;
                                        droneCounter++;
                                        drones[droneCounter] = new Drone();
                                        break;
                                }
                            }
                            else
                            {
                                row = 0;
                            }
                        }
                    }
                }
            }
            catch (IOException)
            {
                MessageBox.Show("cannot read Drones data");
            }
            // Loading Customers
            try
            {
                int row = 0;
                customerCounter = 0;

                using (Stream stream = File.Open(customerFileName, FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    {
                        customers[customerCounter] = new Customer();
                        while (stream.Position < stream.Length)
                        {
                            if (row < 4)
                            {
                                string word = bin.Deserialize(stream).ToString();
                                switch (row)
                                {
                                    case 0:
                                        customers[customerCounter].CustomerID = word;
                                        row++;
                                        break;
                                    case 1:
                                        customers[customerCounter].Name = word;
                                        row++;
                                        break;
                                    case 2:
                                        customers[customerCounter].City = word;
                                        row++;
                                        break;
                                    case 3:
                                        customers[customerCounter].Country = word;
                                        row++;
                                        customerCounter++;
                                        customers[customerCounter] = new Customer();
                                        break;
                                }
                            }
                            else
                            {
                                row = 0;
                            }
                        }
                    }
                }
            }
            catch (IOException)
            {
                MessageBox.Show("cannot read Customers data");
            }
            // Loading Transactions
            try
            {
                int row = 0;
                int col = 0;
                transCounter = 0;
                using (Stream stream = File.Open(transFileName, FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    {
                        while (stream.Position < stream.Length)
                        {
                            if (row < 3)
                            {
                                string word = bin.Deserialize(stream).ToString();
                                transactions[col, row] = word;
                                row++;
                            }
                            else
                            {
                                row = 0;
                                transCounter++;
                                col++;
                            }
                        }
                        transCounter++;
                    }
                }
            }
            catch (IOException)
            {
                MessageBox.Show("cannot read Transactions data");
            }
        }
        // #12 Save Data Method
        private void saveData()
        {
            // Saving Drones
            try
            {
                using (Stream stream = File.Open(droneFileName, FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    {
                        for (int i = 0; i < droneCounter; i++)
                        {
                            bin.Serialize(stream, drones[i].SerialNumber);
                            bin.Serialize(stream, drones[i].Model);
                            bin.Serialize(stream, drones[i].EngineConfiguration);
                            bin.Serialize(stream, drones[i].Range);
                            bin.Serialize(stream, drones[i].Accessories);
                            bin.Serialize(stream, drones[i].Price);
                            bin.Serialize(stream, drones[i].PurchaseDate);
                        }
                    }
                }
            }
            catch (IOException)
            {
                MessageBox.Show("unable to save Drones");
            }
            // Saving Customers
            try
            {
                using (Stream stream = File.Open(customerFileName, FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    {
                        for (int i = 0; i < customerCounter; i++)
                        {
                            bin.Serialize(stream, customers[i].CustomerID);
                            bin.Serialize(stream, customers[i].Name);
                            bin.Serialize(stream, customers[i].City);
                            bin.Serialize(stream, customers[i].Country);
                        }
                    }
                }
            }
            catch (IOException)
            {
                MessageBox.Show("unable to save Customers");
            }
            // Saving Transactions
            try
            {
                using (Stream stream = File.Open(transFileName, FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    {
                        for (int i = 0; i < transCounter; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                bin.Serialize(stream, transactions[i, j]);
                            }
                        }
                    }
                }
            }
            catch (IOException)
            {
                MessageBox.Show("unable to save Transactions");
            }
        }
        // #6 Selcet List box Method
        private void listBoxDrones_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string fromList = listBoxDrones.SelectedItem.ToString();
                string[] temp = fromList.Split('-');
                textBoxSerialNum.Text = temp[0].Trim();

                d_binarySearch();
            }
            catch (NullReferenceException ex)
            {
                Console.Write(ex);
            }
        }
        // #6 Selcet List box Method
        private void listBoxCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string fromList = listBoxCustomers.SelectedItem.ToString();
                string[] temp = fromList.Split(' ');
                textBoxCustomerID.Text = temp[0];

                c_binarySearch();
            }
            catch (NullReferenceException ex)
            {
                Console.Write(ex);
            }
        }
        // #6 Selcet List box Method
        private void listBoxTransaction_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string fromList = listBoxTransaction.SelectedItem.ToString();
                string[] temp = fromList.Split('\t');
                textBoxTransID.Text = temp[0];

                t_binarySearch();
            }
            catch (NullReferenceException ex)
            {
                Console.Write(ex);
            }
        }
        // #10 Method for binary Search
        private void d_binarySearch()
        {
            int lowBound = 0;
            int highBound = droneCounter;
            string target;
            bool found = false;
            target = textBoxSerialNum.Text;

            while (lowBound <= highBound)
            {
                // Find the mid-point
                mid = (lowBound + highBound) / 2;
                int cmpVal = drones[mid].SerialNumber.CompareTo(target);

                if (cmpVal == 0)
                {
                    // Target has been found
                    textBoxSerialNum.Text = drones[mid].SerialNumber;
                    textBoxSerialNumber.Text = drones[mid].SerialNumber;
                    textBoxModel.Text = drones[mid].Model;
                    textBoxEngConfig.Text = drones[mid].EngineConfiguration;
                    textBoxRange.Text = drones[mid].Range;
                    textBoxAccessories.Text = drones[mid].Accessories;
                    textBoxPrice.Text = drones[mid].Price;
                    textBoxDate.Text = drones[mid].PurchaseDate;
                    found = true;
                    return;
                }
                else if (cmpVal > 0)
                {
                    highBound = mid - 1;
                }
                else
                {
                    lowBound = mid + 1;
                }
            }
            if (!found)
            {
                MessageBox.Show("Couln't find the match result");
            }
        }
        // #10 Method for binary Search
        private void c_binarySearch()
        {
            int lowBound = 0;
            int highBound = customerCounter;
            string target;
            bool found = false;
            target = textBoxCustomerID.Text;

            while (lowBound <= highBound)
            {
                // Find the mid-point
                mid = (lowBound + highBound) / 2;
                int cmpVal = customers[mid].CustomerID.CompareTo(target);

                if (cmpVal == 0)
                {
                    // Target has been found
                    textBoxCustomerID.Text = customers[mid].CustomerID;
                    textBoxCustID.Text = customers[mid].CustomerID;
                    textBoxName.Text = customers[mid].Name;
                    textBoxCity.Text = customers[mid].City;
                    textBoxCountry.Text = customers[mid].Country;
                    found = true;
                    return;
                }
                else if (cmpVal > 0)
                {
                    highBound = mid - 1;
                }
                else
                {
                    lowBound = mid + 1;
                }
            }
            if (!found)
            {
                MessageBox.Show("Couln't find the match result");
            }
        }
        // #10 Method for binary Search
        private void t_binarySearch()
        {
            int lowBound = 0;
            int highBound = transCounter;
            string target;
            bool found = false;
            target = textBoxTransID.Text;

            while (lowBound <= highBound)
            {
                // Find the mid-point
                mid = (lowBound + highBound) / 2;
                int cmpVal = transactions[mid, 0].CompareTo(target);

                if (cmpVal == 0)
                {
                    // Target has been found
                    textBoxTransID.Text = transactions[mid, 0];
                    textBoxCustID.Text = transactions[mid, 1];
                    textBoxCustomerID.Text = transactions[mid, 1];
                    c_binarySearch();
                    textBoxSerialNumber.Text = transactions[mid, 2];
                    textBoxSerialNum.Text = transactions[mid, 2];
                    d_binarySearch();
                    found = true;
                    return;
                }
                else if (cmpVal > 0)
                {
                    highBound = mid - 1;
                }
                else
                {
                    lowBound = mid + 1;
                }
            }
            if (!found)
            {
                MessageBox.Show("Couln't find the match result");
            }
        }
        // #8 Clear textboxes Method when double click
        private void textBoxSerialNum_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBoxSerialNum.Clear();
            textBoxModel.Clear();
            textBoxEngConfig.Clear();
            textBoxRange.Clear();
            textBoxAccessories.Clear();
            textBoxPrice.Clear();
            textBoxDate.Clear();
        }
        // #9 Clear textboxes Method when double click
        private void textBoxCustomerID_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBoxCustomerID.Clear();
            textBoxName.Clear();
            textBoxCity.Clear();
            textBoxCountry.Clear();
        }
        // #11 Clear textboxes Method when double click
        private void textBoxTransID_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBoxTransID.Clear();
            textBoxCustID.Clear();
            textBoxSerialNumber.Clear();
        }
        // #10 Search Method when mouse right click
        private void textBoxCustomerID_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu contextMenu = new ContextMenu();

                MenuItem m1 = new MenuItem("Search Customer ID", MenuItem_Click);
                contextMenu.MenuItems.Add(m1);
                contextMenu.Show(textBoxCustomerID, e.Location);
            }
        }
        // #10 Search Method when mouse right click
        private void MenuItem_Click(object sender, EventArgs e)
        {
            c_binarySearch();
        }
        // Delete Method(extra) for Customer
        private void listBoxCustomers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to delete line?", "Delete Line", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    string fromList = listBoxCustomers.SelectedItem.ToString();
                    if (fromList == null)
                    {
                        return;
                    }
                    string[] temp = fromList.Split(' ');
                    textBoxModel.Text = temp[0];
                    c_binarySearch();
                    for (int i = mid; i < customerCounter - 1; i++)
                    {
                        if (i == customerCounter - 1)
                        {
                            continue;
                        }
                        customers[i] = customers[i + 1];
                    }
                    MessageBox.Show($"{temp[0]} deleted");
                    customers[customerCounter] = null;
                    customerCounter--;
                    displayCustomers();
                }
                // Catch Exception when double click blank
                catch (NullReferenceException ex)
                {
                    Console.Write(ex);
                }
            }
        }
    }
}
