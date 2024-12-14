using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizza_Order
{
    public partial class PizzaOrderForm : Form
    {

        public Image leftSideJalapeno = Properties.Resource1.LeftSideJalapeno;
        public Image leftSideUnselected = Properties.Resource1.button_left;
        public Image leftSideSelected = Properties.Resource1.button_left_selected;
        public Image leftSideSpinach = Properties.Resource1.LeftSideSpinach;
        public Image RHJalapeno = Properties.Resource1.RHJalapeno;
        public Image RHOnion = Properties.Resource1.RHOnion;
        public Image RHPepper = Properties.Resource1.RHPepper;
        public Image RHMushroom = Properties.Resource1.RHMushroom;
        public Image RHPineapple = Properties.Resource1.RHPineapple;
        public Image WholeUnselected = Properties.Resource1.button_whole;
        public Image leftSideOnion = Properties.Resource1.LeftSideOnion;
        public Image Wholeselected = Properties.Resource1.button_whole_selected;
        public Image RightUnselected = Properties.Resource1.button_right;
        public Image RightSelected = Properties.Resource1.button_right_selected;
        public Image LHPineapple = Properties.Resource1.LHPineapple;
        public Image OnionPizza = Properties.Resource1.OnionPizza;
        public Image SpinachPizza = Properties.Resource1.SpinachPizza1;
        public Image PineapplePizza = Properties.Resource1.PineapplePizza1;
        public Image JalapenoPizza = Properties.Resource1.JalapenoPizza;
        public Image PeppersPizza = Properties.Resource1.GreenPepperPizza;
        public Image MushroomPizza = Properties.Resource1.MushroomPizza;
        public Image DefaultPizza = Properties.Resource1.DefaultPizza;
        public Image LeftHalfPepper = Properties.Resource1.LeftHalfPepper;

        public double Personal = 5.99;
        public double Small = 7.99;
        public double Medium = 9.99;
        public double Large = 12.99;
        public double Alfredo = 0.99;
        public double Tomato = 0.99;
        public double Cheddar = 0.99;
        public double Mozarella = 0.99;
        public double Feta = 0.99;
        public double Chicken = 0.99;
        public double Pepperoni = 0.99;
        public double Sausage = 0.99;
        public double Onions = 0.99;
        public double Peppers = 0.99;
        public double Mushroom = 0.99;
        public double Jalapeno = 0.99;
        public double Spinach = 0.99;
        public double Pineapple = 0.99;

        public static OrderInvoiceForm order = new OrderInvoiceForm();

        public static double Cost = 0.00; // Keeps track of total cost before Tax
        public static double Subtotal = 0.00; // Keeps track of cost after
        public static double TaxRate = 0.08; // Tax percent 8%

        public PizzaOrderForm()
        {
            InitializeComponent();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {

            PizzaOrderForm NewForm = new PizzaOrderForm();
            NewForm.Show();  // Show the new form
            this.Dispose(false); // Get rid of the old form

        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (PersonalRadioButton.Checked == true)
            {
                ListViewItem item = new ListViewItem("Personal Pizza Size");
                item.SubItems.Add("5.99");
                order.SubTotalListView.Items.Add(item); // add it to the list view
            }
            else if (SmallRadioButton.Checked == true)
            {
                ListViewItem item = new ListViewItem("Small Pizza Size");
                item.SubItems.Add("7.99");
                order.SubTotalListView.Items.Add(item);
            }

            else if (MediumRadioButton.Checked == true)
            {
                ListViewItem item = new ListViewItem("Medium Pizza Size");
                item.SubItems.Add("9.99");
                order.SubTotalListView.Items.Add(item);
            }

            else if (LargeRadioButton.Checked == true)
            {
                ListViewItem item = new ListViewItem("Large Pizza Size");
                item.SubItems.Add("12.99");
                order.SubTotalListView.Items.Add(item);
            }

            if (CheddarCheckBox.Checked == true)
            {
                ListViewItem item = new ListViewItem("Cheddar Cheese Topping");
                item.SubItems.Add("0.99");
                order.SubTotalListView.Items.Add(item);
            }

            if (AlfredoCheckBox.Checked == true)
            {
                ListViewItem item = new ListViewItem("Alfredo Sauce");
                item.SubItems.Add("0.99");
                order.SubTotalListView.Items.Add(item);
            }

            if (TomatoCheckBox.Checked == true)
            {
                ListViewItem item = new ListViewItem("Tomato Sauce");
                item.SubItems.Add("0.99");
                order.SubTotalListView.Items.Add(item);
            }

            if (MozarellaCheckBox.Checked == true)
            {
                ListViewItem item = new ListViewItem("Mozarella Cheese Topping");
                item.SubItems.Add("0.99");
                order.SubTotalListView.Items.Add(item);
            }

            if (FetaCheckBox.Checked == true)
            {
                ListViewItem item = new ListViewItem("Feta Cheese Topping");
                item.SubItems.Add("0.99");
                order.SubTotalListView.Items.Add(item);
            }

            if (ChickenCheckBox.Checked == true)
            {
                ListViewItem item = new ListViewItem("Chicken Topping");
                item.SubItems.Add("0.99");
                order.SubTotalListView.Items.Add(item);
            }

            if (PepperoniCheckBox.Checked == true)
            {
                ListViewItem item = new ListViewItem("Pepperoni Topping");
                item.SubItems.Add("0.99");
                order.SubTotalListView.Items.Add(item);
            }

            if (SausageCheckBox.Checked == true)
            {
                ListViewItem item = new ListViewItem("Sausage Topping");
                item.SubItems.Add("0.99");
                order.SubTotalListView.Items.Add(item);
            }

            if (OnionCheckBox.Checked == true)
            {
                ListViewItem item = new ListViewItem("Onion Topping");
                item.SubItems.Add("0.99");
                order.SubTotalListView.Items.Add(item);
            }

            if (MushroomCheckBox.Checked == true)
            {
                ListViewItem item = new ListViewItem("Mushroom Topping");
                item.SubItems.Add("0.99");
                order.SubTotalListView.Items.Add(item);
            }

            if (SpinachCheckBox.Checked == true)
            {
                ListViewItem item = new ListViewItem("Spinach Topping");
                item.SubItems.Add("0.99");
                order.SubTotalListView.Items.Add(item);
            }

            if (PineapplecheckBox.Checked == true)
            {
                ListViewItem item = new ListViewItem("Pineapple Topping");
                item.SubItems.Add("0.99");
                order.SubTotalListView.Items.Add(item);
            }

            if (GreenPeppersCheckBox.Checked == true)
            {
                ListViewItem item = new ListViewItem("Green Peppers Topping");
                item.SubItems.Add("0.99");
                order.SubTotalListView.Items.Add(item);
            }

            if (JalapenoCheckBox.Checked == true)
            {
                ListViewItem item = new ListViewItem("Jalapeno Topping");
                item.SubItems.Add("0.99");
                order.SubTotalListView.Items.Add(item);
            }


            order.Show(); // Shows the order invoice form because it is already instantiated
            this.Hide(); // Hides the current form


        }
        private void AlfredoCheckBox_CheckedChanged(object sender, EventArgs e)
        {

            if (AlfredoCheckBox.Checked == true)
            {
                TomatoCheckBox.Enabled = false;
            }

            else if (AlfredoCheckBox.Checked == false)
            {
                TomatoCheckBox.Enabled = true;
            }

        }

        private void TomatoCheckBox_CheckedChanged(object sender, EventArgs e)
        {

            if (TomatoCheckBox.Checked == true)
            {
                AlfredoCheckBox.Enabled = false;

            }
            else if (TomatoCheckBox.Checked == false)
            {
                AlfredoCheckBox.Enabled = true;

            }
        }

        private void BuildOwnRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (BuildOwnRadioButton.Checked == true)
            {
                BuildOwnGroupBox.Enabled = true;
            }
            else if (BuildOwnRadioButton.Checked == false)
            {
                BuildOwnGroupBox.Enabled = false;
            }
        }
        private void OnionsLeftPictureBox_Click(object sender, EventArgs e)
        {
            if (OnionCheckBox.Checked)
            {

                OnionsLeftPictureBox.Image = leftSideSelected; // Select the left image 
                OnionsWholePictureBox.Image = WholeUnselected; // Unselect the other
                OnionsRightPictureBox.Image = RightUnselected; // Unselect the other
                PizzaPictureBox.Image = leftSideOnion; // Prints the image

            }
        }

        private void OnionsWholePictureBox_Click(object sender, EventArgs e)
        {
            if (OnionCheckBox.Checked)
            {
                OnionsWholePictureBox.Image = Wholeselected; // Select the left image
                OnionsLeftPictureBox.Image = leftSideUnselected; // Unselect the other
                OnionsRightPictureBox.Image = RightUnselected; // Unselect the other
                PizzaPictureBox.Image = OnionPizza;


            }
        }
        private void OnionsRightPictureBox_Click(object sender, EventArgs e)
        {
            if (OnionCheckBox.Checked)
            {

                OnionsRightPictureBox.Image = RightSelected; // Select the left image
                OnionsLeftPictureBox.Image = leftSideUnselected; // Unselect the other
                OnionsWholePictureBox.Image = WholeUnselected; // Unselect the other
                PizzaPictureBox.Image = RHOnion;
            }
        }

        private void PeppersLeftPictureBox_Click(object sender, EventArgs e)
        {
            if (GreenPeppersCheckBox.Checked)
            {
                PeppersLeftPictureBox.Image = leftSideSelected;
                PeppersWholePictureBox.Image = WholeUnselected; // Unselect the other
                PeppersRightPictureBox.Image = RightUnselected; // Unselect the other
                PizzaPictureBox.Image = LeftHalfPepper;
            }
        }

        private void PeppersWholePictureBox_Click(object sender, EventArgs e)
        {
            if (GreenPeppersCheckBox.Checked)
            {
                PeppersWholePictureBox.Image = Wholeselected;
                PeppersLeftPictureBox.Image = leftSideUnselected; // Unselect the other
                PeppersRightPictureBox.Image = RightUnselected; // Unselect the other
                PizzaPictureBox.Image = PeppersPizza;
            }
        }

        private void PeppersRightPictureBox_Click(object sender, EventArgs e)
        {
            if (GreenPeppersCheckBox.Checked)
            {
                PeppersRightPictureBox.Image = RightSelected;
                PeppersLeftPictureBox.Image = leftSideUnselected; // Unselect the other
                PeppersWholePictureBox.Image = WholeUnselected; // Unselect the other
                PizzaPictureBox.Image = RHPepper;
            }

        }
        private void MushroomLeftPictureBox_Click(object sender, EventArgs e)
        {
            if (MushroomCheckBox.Checked)
            {
                MushroomLeftPictureBox.Image = leftSideSelected;
                MushroomWholePictureBox.Image = WholeUnselected; // Unselect the other
                MushroomRightPictureBox.Image = RightUnselected; // Unselect the other
            }

        }

        private void JalapenoLeftPictureBox_Click(object sender, EventArgs e)
        {
            if (JalapenoCheckBox.Checked)
            {
                JalapenoLeftPictureBox.Image = leftSideSelected;
                JalapenoWholePictureBox.Image = WholeUnselected; // Unselect the other
                JalapenoRightPictureBox.Image = RightUnselected; // Unselect the other
                PizzaPictureBox.Image = leftSideJalapeno;
            }
        }

        private void SpinachLeftPictureBox_Click(object sender, EventArgs e)
        {
            if (SpinachCheckBox.Checked)
            {
                SpinachLeftPictureBox.Image = leftSideSelected;
                SpinachWholePictureBox.Image = WholeUnselected; // Unselect the other
                SpinachRightPictureBox.Image = RightUnselected; // Unselect the other
                PizzaPictureBox.Image = leftSideSpinach;

            }
        }

        private void PineappleLeftPictureBox_Click(object sender, EventArgs e)
        {
            if (PineapplecheckBox.Checked)
            {
                PineappleLeftPictureBox.Image = leftSideSelected;
                PineappleWholePictureBox.Image = WholeUnselected; // Unselect the other
                PineappleRightPictureBox.Image = RightUnselected; // Unselect the other
                PizzaPictureBox.Image = LHPineapple;
            }
        }

        private void MushroomWholePictureBox_Click(object sender, EventArgs e)
        {
            if (MushroomCheckBox.Checked)
            {
                MushroomWholePictureBox.Image = Wholeselected;
                MushroomLeftPictureBox.Image = leftSideUnselected; // Unselect the other
                MushroomRightPictureBox.Image = RightUnselected; // Unselect the other
                PizzaPictureBox.Image = MushroomPizza;
            }
        }
        private void JalapenoWholePictureBox_Click(object sender, EventArgs e)
        {
            if (JalapenoCheckBox.Checked)
            {
                JalapenoWholePictureBox.Image = Wholeselected;
                JalapenoLeftPictureBox.Image = leftSideUnselected; // Unselect the other
                JalapenoRightPictureBox.Image = RightUnselected; // Unselect the other
                PizzaPictureBox.Image = JalapenoPizza;
            }
        }
        private void SpinachWholePictureBox_Click(object sender, EventArgs e)
        {
            if (SpinachCheckBox.Checked)
            {
                SpinachWholePictureBox.Image = Wholeselected;
                SpinachLeftPictureBox.Image = leftSideUnselected; // Unselect the other
                SpinachRightPictureBox.Image = RightUnselected; // Unselect the other
                PizzaPictureBox.Image = SpinachPizza;
            }
        }

        private void PineappleWholePictureBox_Click(object sender, EventArgs e)
        {
            if (PineapplecheckBox.Checked)
            {
                PineappleWholePictureBox.Image = Wholeselected;
                PineappleLeftPictureBox.Image = leftSideUnselected; // Unselect the other
                PineappleRightPictureBox.Image = RightUnselected; // Unselect the other
                PizzaPictureBox.Image = PineapplePizza;
            }
        }

        private void MushroomRightPictureBox_Click(object sender, EventArgs e)
        {
            if (MushroomCheckBox.Checked)
            {
                MushroomRightPictureBox.Image = RightSelected;
                MushroomLeftPictureBox.Image = leftSideUnselected; // Unselect the other
                MushroomWholePictureBox.Image = WholeUnselected; // Unselect the other
                PizzaPictureBox.Image = RHMushroom;
            }
        }

        private void JalapenoRightPictureBox_Click(object sender, EventArgs e)
        {
            if (JalapenoCheckBox.Checked)
            {
                JalapenoRightPictureBox.Image = RightSelected;
                JalapenoLeftPictureBox.Image = leftSideUnselected; // Unselect the other
                JalapenoWholePictureBox.Image = WholeUnselected; // Unselect the other
                PizzaPictureBox.Image = RHJalapeno;
            }
        }

        private void SpinachRightPictureBox_Click(object sender, EventArgs e)
        {
            if (SpinachCheckBox.Checked)
            {
                SpinachRightPictureBox.Image = RightSelected;
                SpinachLeftPictureBox.Image = leftSideUnselected; // Unselect the other
                SpinachWholePictureBox.Image = WholeUnselected; // Unselect the other
            }
        }
        private void PineappleRightPictureBox_Click(object sender, EventArgs e)
        {
            if (PineapplecheckBox.Checked)
            {
                PineappleRightPictureBox.Image = RightSelected;
                PineappleLeftPictureBox.Image = leftSideUnselected; // Unselect the other
                PineappleWholePictureBox.Image = WholeUnselected; // Unselect the other
                PizzaPictureBox.Image = RHPineapple;
            }
        }

        private void PizzaOrderForm_Load(object sender, EventArgs e)
        {
            PizzaPictureBox.Image = DefaultPizza;
        }
    }
}
