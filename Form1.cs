using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



/*
 * Det här är ett program som lägger in en person i programmet och kollar om deras personnummer är korrekt
 * @author Marius Daldorff Pedersen, dalmar-9
 */



namespace Inlämningsuppgift_3_WindowsFormApplication
{
    public partial class Employees : Form
    {
        /*
         * Vi börjar med att skapa alla variabler som vi behöver
         * Person array är en viktig här
         */
      
        
        Person[] allPeople = new Person[15]; //Har valt att maximalt kunna ha 15 styckten personer inuti programmet
        int nrOfPeople = 0; //Hjälp variabel

        Person[] tempPerson; //Har hård kodat in hur många personer man kan lägga till men det går att göra modular.

        public Employees()
        {
            InitializeComponent();
            
        }


        /*
         * Event handler för när knappen för ok trycks
         */
        private void button1_Click(object sender, EventArgs e)
        {


            //Kollar om vi skrivit in 10 siffror annars kommer vi skriva ut error.

            if (socialSecurity.Text.Length != 10)
            {
                ResultField.Text = "Error you have not typed correct numbers of your security number";
                return;
            }
            else
            {



                /*
                 * 1. Här skapar vi en ny person för varje gång någon trycker på ok knappen
                 * 2. vi kollar också med en bool om personnummret är okej och korrekt
                 * 3. lägg till 1 till hjälp variablen
                 */
                allPeople[nrOfPeople] = new Person(surName.Text, lastName.Text, socialSecurity.Text);
                bool k = allPeople[nrOfPeople].checkSocialSecurty();
                allPeople[nrOfPeople].printInformation(ResultField, k);
                nrOfPeople++;

            }



        }
        //Kollar event för avsluta knappen
        private void button2_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
        //kollar event för add employee knappen
        private void addEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {


            //Gör showResult window osynligt och alla andra synliga

            ResultField.Visible = true;
            exitButton.Visible = true;
            okButton.Visible = true;
            surName.Visible = true;
            lastName.Visible = true;
            socialSecurity.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            showAllResults.Visible = false;









        }
        //Kollar event för view employee window
        private void viewEmployeesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //Gör allt osynligt förutom showAllResults

            ResultField.Visible = false;
            exitButton.Visible = false;
            okButton.Visible = false;
            surName.Visible = false;
            lastName.Visible = false;
            socialSecurity.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            showAllResults.Visible = true;




            //Nollar window
            showAllResults.Text = "";

            /*
             * Går igenom alla objekt och skriver ut deras personliga detaljer
             * hanterar också lite errors om objekten skulle vara null så breakar vi ifrån loopen
             */

            for (int i = 0; i < allPeople.Length; i++)
            {

                try
                {

                    if (allPeople[i] == null)
                    {
                        break;
                    }


                    showAllResults.AppendText("Name " + allPeople[i].SurName + "\n Last name " + allPeople[i].lastName + " \n Social Security nr: " + allPeople[i].socialSecurityString + "\nSex: " + allPeople[i].gender + " \n Social security is valid \n");
                    showAllResults.AppendText("\n \n");

                }
                catch (Exception p)
                {

                    break;
                }




            }
        }
    }
}
