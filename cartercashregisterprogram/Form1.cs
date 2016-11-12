using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Media;

//Program created by Carter Bott
//on October 11th, 2016
//to complete the cash register summative.

namespace cartercashregisterprogram
{
    public partial class mcdonaldsForm : Form
    {
        const double BURGER = 2.49; //Declares the cost of all the menu items and the tax percentage 
        const double FRIES = 1.89;
        const double SODA = 0.99;
        const double ICECREAM = 1.29;
        const double TAX = 1.13;

        double totalcost;           //Creates variables to hold the amount of items bought and makes the
        int burgercost;             //total cost a double
        int friescost;
        int sodacost;
        int icecreamcost;

        double tender;             //Declares tender, change, tax amount and sub total as doubles
        double change;
        double taxAmount;
        double subtotal;

        double burgercostr;
        double friescostr;
        double sodacostr;
        double icecreamcostr;

        Graphics fg;  //Creates a global graphics object

        public mcdonaldsForm()
        {
            InitializeComponent();

            subtotalCalc.Visible = false;   //Makes all calculations invisible
            taxCalc.Visible = false;
            totalCalc.Visible = false;
            changeCalc.Visible = false;

            storeLabel.Visible = false;     //Makes all receipt labels invisible
            mcdonsLabel.Visible = false;
            quantityrecieptLabel.Visible = false;
            itemLabel.Visible = false;
            priceLabel.Visible = false;

            burgerquantity.Visible = false; //Makes all receipt quantity labels invisible
            burgerquantity.Visible = false;
            friesquantity.Visible = false;
            sodaquantity.Visible = false;
            icecreamquantity.Visible = false;

            burgerrLabel.Visible = false;   //Makes all item receipt labels invisble
            friesrlabel.Visible = false;
            sodarLabel.Visible = false;
            icecreamrLabel.Visible = false;

            burgertotalLabel.Visible = false;   //Makes all item total labels invisible
            friestotalLabel.Visible = false;
            sodatotalLabel.Visible = false;
            icecreamtotalLabel.Visible = false;

            totalOutput.Visible = false;    //Makes all receipt output labels invisible
            taxOutput.Visible = false;
            changeOutput.Visible = false;
            subtotalOutput.Visible = false;

            totalrLabel.Visible = false;    //Makes all receipt calculation labels invsible
            taxrLabel.Visible = false;
            changerLabel.Visible = false;
            subtotalrLabel.Visible = false;

            fg = this.CreateGraphics();

        }

        private void totalButton_Click(object sender, EventArgs e)
        { 
            burgercost = Convert.ToInt16(burgertextBox.Text);   //Declares the varibles for holding the amount of
            friescost = Convert.ToInt16(friestextBox.Text);     //food items selected
            sodacost = Convert.ToInt16(sodatextBox.Text);
            icecreamcost = Convert.ToInt16(icecreamtextBox.Text);

            subtotal = BURGER * burgercost + FRIES * friescost + SODA * //Variable to calculate the sub total of the order
            sodacost + icecreamcost * ICECREAM;                         

            taxAmount = subtotal * TAX - subtotal;  //Variable to calculate tax
                                                    
            totalcost = subtotal + taxAmount;   //Variable to calculate the total cost

            subtotalCalc.Text = subtotal.ToString("C"); //Converts the calculation to a string (int to string)
            subtotalCalc.Visible = true;                //and makes the label visible

            taxCalc.Text = taxAmount.ToString("C"); //Converts the calculation to a string (int to string)
            taxCalc.Visible = true;                 //and makes the label visible     

            totalCalc.Text = totalcost.ToString("C");   //Converts the calculation to a string (int to string)
            totalCalc.Visible = true;                   //and makes the label visible

            burgercostr = burgercost * BURGER;  //Calculates individual item cost
            friescostr = friescost * FRIES;
            sodacostr = sodacost * SODA;
            icecreamcostr = icecreamcost * ICECREAM;

        }

        private void payButton_Click(object sender, EventArgs e)
        {      
            tender = Convert.ToDouble(payBox.Text); //Creates a variabe to hold the amount of tender and converts it to a number
            change = tender - totalcost;            //Calculates change

            if (tender < totalcost) //Displays error message in tender is insufficient
            {
                changeCalc.Text = ("Insufficient tender.");
                changeCalc.Visible = true;
            }
            else //Outputs change amount to change label and plays a sound
            {
                changeCalc.Text = change.ToString("C");
                changeCalc.Visible = true;

                SoundPlayer cashPlayer = new SoundPlayer(Properties.Resources.chaching); //Creates a player to store the cash register sound and
                cashPlayer.Play();                                                       //and plays the sound
            }
        }

        private void receiptButton_Click(object sender, EventArgs e)
        {

            SoundPlayer receiptPlayer = new SoundPlayer(Properties.Resources.receiptprint); //Creates a player to store the receipt printing sound
            receiptPlayer.Play();                                                           //and plays the sound
            Thread.Sleep(1000);
            receiptPlayer.Play();
           
            SolidBrush receiptBrush = new SolidBrush(Color.White);

            fg.FillRectangle(receiptBrush, 350, 0, 5000, 5000);

            storeLabel.Visible = true;      //Makes all the reciept labels visible
            mcdonsLabel.Visible = true;
            quantityrecieptLabel.Visible = true;
            itemLabel.Visible = true;
            priceLabel.Visible = true;

            burgerquantity.Visible = true;      //Makes all the reciept quantity labels visible
            burgerquantity.Visible = true;
            friesquantity.Visible = true;
            sodaquantity.Visible = true;
            icecreamquantity.Visible = true;

            storeLabel.Visible = true;      //Makes all the reciept labels visible
            mcdonsLabel.Visible = true;
            quantityrecieptLabel.Visible = true;
            itemLabel.Visible = true;
            priceLabel.Visible = true;

            burgerquantity.Visible = true;       //Makes all the reciept quantity labels visible
            friesquantity.Visible = true;
            sodaquantity.Visible = true;
            icecreamquantity.Visible = true;

            burgertotalLabel.Visible = true;    //Makes all total cost labels visible
            friestotalLabel.Visible = true;
            sodatotalLabel.Visible = true;
            icecreamtotalLabel.Visible = true;

            totalOutput.Visible = true;     //Makes all output labels visible
            taxOutput.Visible = true;
            changeOutput.Visible = true;
            subtotalOutput.Visible = true;

            totalrLabel.Visible = true;     //Makes all reciept total labels visible
            taxrLabel.Visible = true;
            changerLabel.Visible = true;
            subtotalrLabel.Visible = true;
            
            burgerrLabel.Visible = true;    //Makes all the reciept item labels visible
            friesrlabel.Visible = true; 
            sodarLabel.Visible = true;  
            icecreamrLabel.Visible = true;

            burgerquantity.Text = burgertextBox.Text;   //Outputs the item quantity to the receipt label
            friesquantity.Text = friestextBox.Text;
            sodaquantity.Text = sodatextBox.Text;
            icecreamquantity.Text = icecreamtextBox.Text;

            burgertotalLabel.Text = burgercostr.ToString("C");   //Outputs the cost of each item to the receipt label
            friestotalLabel.Text = friescostr.ToString("C");
            sodatotalLabel.Text = sodacostr.ToString("C");
            icecreamtotalLabel.Text = icecreamcostr.ToString("C");

            subtotalOutput.Text = subtotal.ToString("C");   //Outputs the cost labels to each 
            changeOutput.Text = change.ToString("C");
            totalOutput.Text = totalcost.ToString("C");
            taxOutput.Text = taxAmount.ToString("C");

        }

        private void neworderButton_Click(object sender, EventArgs e)
        {
            subtotalCalc.Visible = false;   //Makes the calculation labels invisble
            taxCalc.Visible = false;
            totalCalc.Visible = false;
            changeCalc.Visible = false;

            storeLabel.Visible = false;     //Makes all the reciept labels invisible
            mcdonsLabel.Visible = false;
            quantityrecieptLabel.Visible = false;
            itemLabel.Visible = false;
            priceLabel.Visible = false;

            subtotalCalc.Text = ""; //Clears the calculation labels
            taxCalc.Text = "";
            totalCalc.Text = "";
            changeCalc.Text = "";

            burgertextBox.Text = "";    //Clears the menu text boxes
            friestextBox.Text = "";
            sodatextBox.Text = "";
            icecreamtextBox.Text = "";
            payBox.Text = "";

            burgerquantity.Visible = false;      //Makes all the reciept quantity labels visible
            burgerquantity.Visible = false;
            friesquantity.Visible = false;
            sodaquantity.Visible = false;
            icecreamquantity.Visible = false;

            storeLabel.Visible = false;     //Makes all the reciept labels invisible
            mcdonsLabel.Visible = false;
            quantityrecieptLabel.Visible = false;
            itemLabel.Visible = false;
            priceLabel.Visible = false;

            burgerquantity.Visible = false;      //Makes all the reciept quantity labels visible
            burgerquantity.Visible = false;
            friesquantity.Visible = false;
            sodaquantity.Visible = false;
            icecreamquantity.Visible = false;

            burgertotalLabel.Visible = false;   //Makes all item total labels visible
            friestotalLabel.Visible = false;
            sodatotalLabel.Visible = false;
            icecreamtotalLabel.Visible = false;

            totalOutput.Visible = false;    //Makes all output labels visible
            taxOutput.Visible = false;
            changeOutput.Visible = false;
            subtotalOutput.Visible = false;

            totalrLabel.Visible = false;    //Makes all reciept total labels visible
            taxrLabel.Visible = false;
            changerLabel.Visible = false;
            subtotalrLabel.Visible = false;

            burgerrLabel.Visible = false;   //Makes all reciept item labels visible
            friesrlabel.Visible = false;
            sodarLabel.Visible = false;
            icecreamrLabel.Visible = false;

            burgerquantity.Text = "";       //Clears the quantity text boxes
            burgerquantity.Text = "";
            friesquantity.Text = "";
            sodaquantity.Text = "";
            icecreamquantity.Text = "";

            fg.Clear(Color.Maroon);
        }
    }
}
