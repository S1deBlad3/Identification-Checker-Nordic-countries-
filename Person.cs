using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Inlämningsuppgift_3_WindowsFormApplication
{
    class Person
    {
        //Deklarerar alla variabler
        public String SurName;
        public String lastName;
        public long socialSecurity;
        public String socialSecurityString;
        private String[] numbers;
        public int[] results;
        private StringBuilder sb;
        public bool isValidPerson;
        public String gender;



        /*
         * Constructor som sätter upp alla variabler
         * @Param name - namnet på personen
         * @Param lastName - efternamnet på personen
         * @Param Social - personnummret till personen
         */
        public Person(String name, String lastName, String social)
        {

            SurName = name;
            this.lastName = lastName;
            socialSecurityString = social;
            

            

        }

        //metod för att kolla om personnummret är korrekt enligt algo-21
        public bool checkSocialSecurty()
        {


            /*
             * Här delas alla siffror in i enskila element i en array
             */

            int[] nums = new int[10];
            Char[] st;
            st = socialSecurityString.ToArray(); //Vi delar upp alla karaktärer från String till Char så vi går från "123" till [1, 2, 3]


            //Här gör vi om alla char '1' till int 1 och sätter in i arrayn nums
            for (int i = 0; i < nums.Length; i++)
            {

                try
                {
                    nums[i] = Convert.ToInt32(st[i].ToString());
                }
                catch(Exception e)
                {
                    break;
                }

                


                
                



            }


            //Calculations


            /*
             * Här kollar vi om nummer 9 som är tredje numret i sista delen av personnummret och kollar vilket kön personen är
             * Detta gör vi genom att kolla om siffran är jämn eller ojämn
             */

            if (nums[9] % 2 == 0)
            {
                gender = "Female";
            }else if(nums[9] % 2 == 1)
            {
                gender = "Man";
            }

            /*
             * Det här är en lång och lite ambitiöst lösning
             * 1. Vi börjar med att skapa några nya variabler för att kunna använda till senare
             * 2. Ett av dessa kommer vara resultatet som vi får av att ta produkten av två varibaler i personnummret
             * 3. Vi helt enkelt använder två hjälp variabler för att se till att vi är på rätt plats i arrayen
             * 4. Sedan tar vi produkten och sätter in i resultatet
             * 5. Vi får då [1,2,3] som resultat
             * 6. Vi omvandlar det till en String ["123"]
             */
            numbers = new String[nums.Length];
            results = new int[nums.Length / 2];

            int first = 0, second = 1;

            for (int i = 0; i < nums.Length; i++)
            {

                if (first == 10 || second == 11)
                {
                    break;
                }

                    
                results[i] = nums[first] * nums[second];
                numbers[i] = Convert.ToString(results[i]);



                first += 2;
                second += 2;






            }

            /*
             * 1. Vi definerar en ny array för att dela in alla värden från resultatet som enskilda
             * 2. Vi gör detta genom att konvertera en String array till en enskild String med hjälp av StringBuilder
             * 3. Vi kan sedan göra om en String till char[] array och får ut alla enskilda element.
             * 4. Då går vi från "120" till ['1','2','0']
             * 5. Vi konverterar sedan alla char[] till int[] så att vi kan göra beräkningar med elementen.
             * 6. Vi tar sedan och summerar alla element
             * 7. Vi delar på 10 och kollar om talet kommer ut jämnt eller udda
             * 8. Vi returnerar sedan true eller false beroende på om det är jämnt eller udda
             */

            int[] singleResults = new int[12];

            Char[] singleUnitys;


            sb = new StringBuilder();
            String allNumbers;
            foreach (String i in numbers)
            {
                sb.Append(i);
            }

            allNumbers = sb.ToString();


            singleUnitys = allNumbers.ToArray();

            for (int j = 0; j < singleResults.Length; j++)
            {


                try
                {
                    singleResults[j] = Convert.ToInt32(singleUnitys[j].ToString());
                }catch (Exception e)
                {
                    break;
                }

                

            }

            int sum = 0;

            foreach (int x in singleResults)
            {
                sum += x;
            }

            sum /= 10;

            if (sum % 2 == 0)
            {
                isValidPerson = true;
                return true;
                
            }
            else
            {
                isValidPerson = false;
                return false;
            }





            

            
           
            
            



            return false;
        }


       
        /*
         * Den här funktiohnen hanterar att skriva ut all informationen för den här individen
         * @Param textBox - är richtextField vi har i får form
         * @Param validPerson - Är variablen som returneras när vi kollar om en person är valid eller inte
         */

        public void printInformation(System.Windows.Forms.RichTextBox textBox, bool validPerson)
        {

            //Skapar en premade string
            String something = "Name: " + SurName +  "\n Last name " + lastName + " \n Social Security nr: " + socialSecurityString +  "\nSex: " + gender +" \n Social security is valid ";

            //Kollar om personen är valid, om ja så skriver vi ut infon annars så skriver vi error
            if (validPerson)
            {
                textBox.Text = something;
            }
            if (!validPerson)
            {
                textBox.Text = "Invalid person, your social security number is not valid";
            }

            





        }






    }
}
